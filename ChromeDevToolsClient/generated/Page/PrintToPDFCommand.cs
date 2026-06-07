namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Print page as PDF.
    /// </summary>
    public sealed class PrintToPDFCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.printToPDF";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Paper orientation. Defaults to false.
        /// </summary>
        [JsonPropertyName("landscape")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Landscape
        {
            get;
            set;
        }
        /// <summary>
        /// Display header and footer. Defaults to false.
        /// </summary>
        [JsonPropertyName("displayHeaderFooter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DisplayHeaderFooter
        {
            get;
            set;
        }
        /// <summary>
        /// Print background graphics. Defaults to false.
        /// </summary>
        [JsonPropertyName("printBackground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PrintBackground
        {
            get;
            set;
        }
        /// <summary>
        /// Scale of the webpage rendering. Defaults to 1.
        /// </summary>
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Scale
        {
            get;
            set;
        }
        /// <summary>
        /// Paper width in inches. Defaults to 8.5 inches.
        /// </summary>
        [JsonPropertyName("paperWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? PaperWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Paper height in inches. Defaults to 11 inches.
        /// </summary>
        [JsonPropertyName("paperHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? PaperHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Top margin in inches. Defaults to 1cm (~0.4 inches).
        /// </summary>
        [JsonPropertyName("marginTop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MarginTop
        {
            get;
            set;
        }
        /// <summary>
        /// Bottom margin in inches. Defaults to 1cm (~0.4 inches).
        /// </summary>
        [JsonPropertyName("marginBottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MarginBottom
        {
            get;
            set;
        }
        /// <summary>
        /// Left margin in inches. Defaults to 1cm (~0.4 inches).
        /// </summary>
        [JsonPropertyName("marginLeft")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MarginLeft
        {
            get;
            set;
        }
        /// <summary>
        /// Right margin in inches. Defaults to 1cm (~0.4 inches).
        /// </summary>
        [JsonPropertyName("marginRight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MarginRight
        {
            get;
            set;
        }
        /// <summary>
        /// Paper ranges to print, one based, e.g., '1-5, 8, 11-13'. Pages are
        /// printed in the document order, not in the order specified, and no
        /// more than once.
        /// Defaults to empty string, which implies the entire document is printed.
        /// The page numbers are quietly capped to actual page count of the
        /// document, and ranges beyond the end of the document are ignored.
        /// If this results in no pages to print, an error is reported.
        /// It is an error to specify a range with start greater than end.
        /// </summary>
        [JsonPropertyName("pageRanges")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PageRanges
        {
            get;
            set;
        }
        /// <summary>
        /// HTML template for the print header. Should be valid HTML markup with following
        /// classes used to inject printing values into them:
        /// - `date`: formatted print date
        /// - `title`: document title
        /// - `url`: document location
        /// - `pageNumber`: current page number
        /// - `totalPages`: total pages in the document
        /// 
        /// For example, `<span class=title></span>` would generate span containing the title.
        /// </summary>
        [JsonPropertyName("headerTemplate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string HeaderTemplate
        {
            get;
            set;
        }
        /// <summary>
        /// HTML template for the print footer. Should use the same format as the `headerTemplate`.
        /// </summary>
        [JsonPropertyName("footerTemplate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FooterTemplate
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to prefer page size as defined by css. Defaults to false,
        /// in which case the content will be scaled to fit the paper size.
        /// </summary>
        [JsonPropertyName("preferCSSPageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PreferCSSPageSize
        {
            get;
            set;
        }
        /// <summary>
        /// return as stream
        /// </summary>
        [JsonPropertyName("transferMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TransferMode
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to generate tagged (accessible) PDF. Defaults to embedder choice.
        /// </summary>
        [JsonPropertyName("generateTaggedPDF")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GenerateTaggedPDF
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to embed the document outline into the PDF.
        /// </summary>
        [JsonPropertyName("generateDocumentOutline")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GenerateDocumentOutline
        {
            get;
            set;
        }
    }

    public sealed class PrintToPDFCommandResponse : ICommandResponse<PrintToPDFCommand>
    {
        /// <summary>
        /// Base64-encoded pdf data. Empty if |returnAsStream| is specified. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// A handle of the stream that holds resulting PDF data.
        ///</summary>
        [JsonPropertyName("stream")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Stream
        {
            get;
            set;
        }
    }
}