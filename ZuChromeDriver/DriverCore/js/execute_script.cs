// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Copyright 2019 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file — see THIRD-PARTY-NOTICES in the Chromium tree.

namespace Zu.Chrome.DriverCore
{
    /// <summary>
    /// Embeds chromium <c>chrome/test/chromedriver/js/execute_script.js</c> as a callable
    /// for <see cref="WindowCommands.ExecuteScript"/> (async function wrapper + promise).
    /// </summary>
    static class execute_script
    {
        public const string JsSource = @"function(script, args) {
  try {
    var f = (new Function('return async function(){' + script + '}'))();
    var PromiseCtor = window.cdc_adoQpoasnfa76pfcZLmcfl_Promise || window.Promise;
    return PromiseCtor.resolve(f.apply(null, args));
  } catch (e) {
    var PromiseCtor = window.cdc_adoQpoasnfa76pfcZLmcfl_Promise || window.Promise;
    return PromiseCtor.reject(e);
  }
}";
    }
}
