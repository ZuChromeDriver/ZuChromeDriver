using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var contentRootPath = builder.Environment.ContentRootPath;

builder.WebHost.UseUrls("http://localhost:2310");

var app = builder.Build();

app.UsePathBase("/HtmlForTests");

var staticFilesRoot = new PhysicalFileProvider(contentRootPath);

// Before DefaultFiles: paths like /encoding (no extension) are otherwise treated as
// directories and can 404 before dynamic handlers run.
// Must also run before UseStaticFiles (unknown paths never reach later middleware).
app.Use(async (context, next) =>
{
    if (HttpMethods.IsGet(context.Request.Method)
        && context.Request.Path.Equals("/sleep", StringComparison.OrdinalIgnoreCase))
    {
        _ = int.TryParse(context.Request.Query["time"].ToString(), out var seconds);
        if (seconds < 0)
            seconds = 0;

        await Task.Delay(TimeSpan.FromSeconds(seconds));

        context.Response.ContentType = "text/html; charset=utf-8";
        var html = "<html><head><title>Done</title></head><body>Slept for " + seconds + "s</body></html>";
        await context.Response.WriteAsync(html, Encoding.UTF8);
        return;
    }

    if (HttpMethods.IsGet(context.Request.Method)
        && context.Request.Path.Equals("/encoding", StringComparison.OrdinalIgnoreCase))
    {
        string html =
            "<html><title>Character encoding (UTF 16)</title>"
            + "<body><p id='text'>"
            + "\u05E9\u05DC\u05D5\u05DD"
            + "</p></body></html>";
        var bytes = Encoding.Unicode.GetBytes(html);
        context.Response.ContentType = "text/html;charset=UTF-16LE";
        await context.Response.Body.WriteAsync(bytes);
        return;
    }

    if (HttpMethods.IsPost(context.Request.Method)
        && context.Request.Path.Equals("/resultPage.html", StringComparison.OrdinalIgnoreCase))
    {
        var resultPath = Path.Combine(contentRootPath, "resultPage.html");
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync(resultPath);
        return;
    }

    await next();
});

app.UseDefaultFiles(new DefaultFilesOptions { FileProvider = staticFilesRoot });

// Dynamic cookie endpoint (see Selenium CookieHandler); used by HttpOnly cookie tests.
app.MapGet("/cookie", (HttpContext ctx) =>
{
    ctx.Response.Headers.CacheControl = "no-cache";
    ctx.Response.Headers.Pragma = "no-cache";
    ctx.Response.Headers.Expires = "Thu, 01 Jan 1970 00:00:00 GMT";

    var action = ctx.Request.Query["action"].ToString();
    if (action == "add")
    {
        var name = ctx.Request.Query["name"].ToString();
        var value = ctx.Request.Query["value"].ToString();
        var sb = new StringBuilder();
        sb.Append(name).Append('=').Append(value).Append("; ");
        var domain = ctx.Request.Query["domain"].ToString();
        if (!string.IsNullOrEmpty(domain))
        {
            sb.Append("Domain=").Append(domain).Append("; ");
        }

        var path = ctx.Request.Query["path"].ToString();
        if (!string.IsNullOrEmpty(path))
        {
            sb.Append("Path=").Append(path).Append("; ");
        }

        var expiry = ctx.Request.Query["expiry"].ToString();
        if (!string.IsNullOrEmpty(expiry) && int.TryParse(expiry, out var maxAge))
        {
            sb.Append("Max-Age=").Append(maxAge).Append("; ");
        }

        if (ctx.Request.Query.ContainsKey("secure"))
        {
            sb.Append("Secure; ");
        }

        if (ctx.Request.Query["httpOnly"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
        {
            sb.Append("HttpOnly; ");
        }

        var header = sb.ToString().TrimEnd(' ', ';');
        ctx.Response.Headers.Append("Set-Cookie", header);
        var html = "<html><head><title>Done</title></head><body>Cookie added : "
            + System.Net.WebUtility.HtmlEncode(name) + "</body></html>";
        return Results.Content(html, "text/html; charset=utf-8", Encoding.UTF8);
    }

    var unrecognized = System.Net.WebUtility.HtmlEncode(action);
    return Results.Content(
        "<html><head><title>Done</title></head><body>Unrecognized action : " + unrecognized + "</body></html>",
        "text/html; charset=utf-8",
        Encoding.UTF8);
});

// Selenium test server UploadHandler: multipart field "upload", slow response, iframe callback.
app.MapPost("/upload", async (HttpContext ctx) =>
{
    if (!ctx.Request.HasFormContentType)
    {
        ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
        return;
    }

    var form = await ctx.Request.ReadFormAsync();
    var file = form.Files.GetFile("upload");
    string body = string.Empty;
    if (file != null && file.Length > 0)
    {
        using var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
        body = await reader.ReadToEndAsync();
    }

    await Task.Delay(2500).ConfigureAwait(false);

    ctx.Response.ContentType = "text/html; charset=utf-8";
    await ctx.Response.WriteAsync(body + "<script>window.top.window.onUploadDone();</script>", Encoding.UTF8);
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = staticFilesRoot,
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/octet-stream"
});

app.MapPost("/CreatePage.aspx", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
    var requestFromPost = await reader.ReadToEndAsync();
    var json = JsonNode.Parse(requestFromPost) as JsonObject;
    var dir = (json?["dir"] as JsonValue)?.GetValue<string>();
    var fileName = $"temp-{Guid.NewGuid():N}.html";
    var content = (json?["content"] as JsonValue)?.GetValue<string>() ?? json?["content"]?.ToString();
    Directory.CreateDirectory(dir);
    await File.WriteAllTextAsync(Path.Combine(dir, fileName), content);
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(fileName);
});

app.MapGet("/Page.aspx", (HttpRequest request) => ResultsForPage(request, null));
app.MapGet("/Page.aspx/{**pathInfo}", (HttpRequest request, string pathInfo) => ResultsForPage(request, pathInfo));

app.MapGet("/Redirect.aspx", () => Results.Redirect("resultPage.html"));

app.Run();

static IResult ResultsForPage(HttpRequest request, string pathInfo)
{
    string pageNumber;
    if (string.IsNullOrEmpty(pathInfo))
    {
        pageNumber = "Unknown";
    }
    else
    {
        var lastIndex = pathInfo.LastIndexOf('/');
        pageNumber = lastIndex == -1 ? pathInfo : pathInfo.Substring(lastIndex + 1);
    }

    if (!string.IsNullOrEmpty(request.Query["pageNumber"]))
    {
        pageNumber = request.Query["pageNumber"]!;
    }

    // Match selenium/common/src/web/Page.aspx: link targets top-level document (frameset tests).
    var html = "<html><head><title>Page" + pageNumber + "</title></head>" +
               "<body><a href=\"../xhtmlTest.html\" target=\"_top\">top</a> " +
               "Page number <span id=\"pageNumber\">" + pageNumber +
               "</span></body></html>";
    return Results.Content(html, "text/html", Encoding.UTF8);
}
