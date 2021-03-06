﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Benchmarks
{
    using System;
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;
    using Nerdbank.Streams;
    using StreamJsonRpc;

    [MemoryDiagnoser]
    public class InvokeBenchmarks
    {
        private readonly JsonRpc clientRpc;
        private readonly JsonRpc serverRpc;

        public InvokeBenchmarks()
        {
            (System.IO.Pipelines.IDuplexPipe, System.IO.Pipelines.IDuplexPipe) duplex = FullDuplexStream.CreatePipePair();
            this.clientRpc = new JsonRpc(new HeaderDelimitedMessageHandler(duplex.Item1, new JsonMessageFormatter()));
            this.clientRpc.StartListening();

            this.serverRpc = new JsonRpc(new HeaderDelimitedMessageHandler(duplex.Item2, new JsonMessageFormatter()));
            this.serverRpc.AddLocalRpcTarget(new Server());
            this.serverRpc.StartListening();
        }

        /// <summary>
        /// Workaround https://github.com/dotnet/BenchmarkDotNet/issues/837.
        /// </summary>
        [GlobalSetup]
        public void Workaround() => this.InvokeAsync_NoArgs();

        [Benchmark]
        public Task InvokeAsync_NoArgs() => this.clientRpc.InvokeAsync(nameof(Server.NoOp), Array.Empty<object>());

        private class Server
        {
            public void NoOp()
            {
            }
        }
    }
}
