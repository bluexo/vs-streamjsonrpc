﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace StreamJsonRpc.Protocol
{
    /// <summary>
    /// Error codes laid out in the JSON-RPC spec or this library.
    /// </summary>
    /// <remarks>
    /// The error codes from and including -32768 to -32000 are reserved for pre-defined errors.
    /// </remarks>
    public enum JsonRpcErrorCode : int
    {
        /// <summary>
        /// Indicates the RPC call was made but the target threw an exception.
        /// </summary>
        InvocationError = -32000,

        /// <summary>
        /// Indicates a request was made to a remotely marshaled object that never existed or has already been disposed of.
        /// </summary>
        NoMarshaledObjectFound = -32001,

        /* We're skipping -32002 because LSP uses it at the app level: https://github.com/microsoft/vscode-languageserver-node/issues/672 */

        /// <summary>
        /// Indicates a response could not be serialized as the application intended.
        /// </summary>
        ResponseSerializationFailure = -32003,

        /// <summary>
        /// Invalid JSON was received by the server. An error occurred on the server while parsing the JSON text.
        /// </summary>
        ParseError = -32700,

        /// <summary>
        /// The JSON sent is not a valid Request object.
        /// </summary>
        InvalidRequest = -32600,

        /// <summary>
        /// The method does not exist / is not available.
        /// </summary>
        MethodNotFound = -32601,

        /// <summary>
        /// Invalid method parameter(s).
        /// </summary>
        InvalidParams = -32602,

        /// <summary>
        /// Internal JSON-RPC error.
        /// </summary>
        InternalError = -32603,

        /// <summary>
        /// Execution of the server method was aborted due to a cancellation request from the client.
        /// </summary>
        RequestCanceled = -32800,
    }
}
