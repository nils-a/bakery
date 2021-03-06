﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;

namespace Cake.Scripting.Transport.Tests.Fixtures.Serialization
{
    public abstract class SerializerFixture : IDisposable
    {
        private readonly MemoryStream _stream;

        public BinaryWriter Writer { get; }

        public BinaryReader Reader { get; }

        protected SerializerFixture()
        {
            _stream = new MemoryStream();

            Writer = new BinaryWriter(_stream);
            Reader = new BinaryReader(_stream);
        }

        public void ResetStreamPosition()
        {
            _stream.Position = 0;
        }

        public void ResetStream()
        {
            _stream.SetLength(0);
        }

        public void Dispose()
        {
            _stream?.Dispose();
            Writer?.Dispose();
            Reader?.Dispose();
        }
    }
}
