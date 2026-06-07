// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the chrome-dev-tools-sample, licensed under the MIT License. More info in THIRD-PARTY-NOTICES file.

using System.Text.Json.Serialization;
namespace Zu.Chrome
{

    public class ChromeSessionInfo
    {
        [JsonPropertyName("description")]
        public string Description
        {
            get;
            set;
        }

        [JsonPropertyName("devtoolsFrontendUrl")]
        public string DevToolsFrontendUrl
        {
            get;
            set;
        }

        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }

        [JsonPropertyName("webSocketDebuggerUrl")]
        public string WebSocketDebuggerUrl
        {
            get;
            set;
        }
    }
}
