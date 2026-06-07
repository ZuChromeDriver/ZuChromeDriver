// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
// Copyright (c) 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

namespace Zu.Chrome.DriverCore
{
    class execute_async_script
    {
        /// <summary>
        /// Port of <c>chrome/test/chromedriver/js/execute_async_script.js</c>: Promise/async pipeline
        /// with <see cref="WebView.CallUserAsyncFunction"/> supplying CDP <c>Runtime.Evaluate</c>
        /// timeout (milliseconds) and optional JS <paramref name="timeout"/> for Chromedriver-style
        /// <c>setTimeout</c> retention of the pending promise.
        /// </summary>
        public const string JsSource = @"
function() {

/**
 * Enum for WebDriver status codes.
 * @enum {number}
 */
var StatusCode = {
  OK: 0,
  UNKNOWN_ERROR: 13,
  JAVASCRIPT_ERROR: 17,
  SCRIPT_TIMEOUT: 28,
};

/**
* Execute the given script and save its asynchronous result.
*
* If script1 finishes after script2 is executed, then script1's result will be
* discarded while script2's will be saved.
*
* @param {string} script The asynchronous script to be executed. The script
*     should be a proper function body. It will be wrapped in a function and
*     invoked with the given arguments and, as the final argument, a callback
*     function to invoke to report the asynchronous result.
* @param {!Array<*>} args Arguments to be passed to the script.
* @param {boolean} isUserSupplied Whether the script is supplied by the user.
*     If not, UnknownError will be used instead of JavaScriptError if an
*     exception occurs during the script, and an additional error callback will
*     be supplied to the script.
 * @param {number|undefined} timeout Optional duration in milliseconds; when positive, a
 *     Promise.race against the user script rejects with SCRIPT_TIMEOUT (user scripts) if the
 *     callback is not invoked in time. Matches the observable behavior of classic Chromedriver
 *     when the C++ layer enforces script_timeout alongside Runtime.awaitPromise.
*/
async function executeAsyncScript(script, args, isUserSupplied, timeout) {
  var PromiseCtor = window.cdc_adoQpoasnfa76pfcZLmcfl_Promise || window.Promise;
  function isThenable(value) {
    return typeof value === 'object' && value !== null &&
        typeof value.then === 'function';
  }
  function reportValue(value) {
    return {status: StatusCode.OK, value: value};
  }
  function reportError(error) {
    var code = StatusCode.UNKNOWN_ERROR;
    if (error && error.code !== undefined && error.code !== null)
      code = error.code;
    else if (isUserSupplied)
      code = StatusCode.JAVASCRIPT_ERROR;
    var message = error.message || String(error);
    if (error.stack) {
      message += '\nJavaScript stack:\n' + error.stack;
    }
    return {status: code, value: message};
  }
  var promise = new PromiseCtor(function(resolve, reject) {
    args.push(resolve);
    if (!isUserSupplied) {
      args.push(reject);
    }
    try {
      var scriptResult = new Function(script).apply(null, args);
      if (isThenable(scriptResult)) {
        PromiseCtor.resolve(scriptResult).then(function(value) {
          // Matches main Chromium chromedriver: user-supplied scripts only
          // adopt promise settlement when the fulfilled value is itself thenable,
          // so plain async returns still require invoking the callback.
          if (!isUserSupplied || isThenable(value))
            resolve(value);
        }, reject);
      }
    } catch (error) {
      reject(error);
    }
  });

  var settled = promise;
  if (typeof timeout !== 'undefined' && timeout > 0) {
    var timeoutMs = timeout;
    var timeoutPromise = new PromiseCtor(function(resolveIgnored, rejectTimeout) {
      window.setTimeout(function() {
        var err = new Error('result was not received in ' + (timeoutMs / 1000) +
            ' seconds');
        err.code = isUserSupplied ? StatusCode.SCRIPT_TIMEOUT :
            StatusCode.UNKNOWN_ERROR;
        rejectTimeout(err);
      }, timeoutMs);
    });
    settled = PromiseCtor.race([promise, timeoutPromise]);
  }

  if (typeof timeout !== 'undefined') {
    window.setTimeout(function() { return settled; }, timeout);
  }
  return await settled.then(function(result) {
    return reportValue(result);
  }).catch(function(error) {
    return reportError(error);
  });
}
return executeAsyncScript.apply(null, arguments);
}
";
    }
}
