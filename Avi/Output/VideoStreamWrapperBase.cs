﻿using System;

namespace Screna.Avi
{
    /// <summary>
    /// Base class for wrappers around <see cref="IAviVideoStreamInternal"/>.
    /// </summary>
    /// <remarks>
    /// Simply delegates all operations to wrapped stream.
    /// </remarks>
    abstract class VideoStreamWrapperBase : IAviVideoStreamInternal, IDisposable
    {
        protected VideoStreamWrapperBase(IAviVideoStreamInternal baseStream)
        {
            this.baseStream = baseStream;
        }

        protected IAviVideoStreamInternal BaseStream => baseStream;
        readonly IAviVideoStreamInternal baseStream;

        public virtual void Dispose()
        {
            var baseStreamDisposable = baseStream as IDisposable;
            if (baseStreamDisposable != null) baseStreamDisposable.Dispose();
        }

        public virtual int Width
        {
            get { return baseStream.Width; }
            set { baseStream.Width = value; }
        }

        public virtual int Height
        {
            get { return baseStream.Height; }
            set { baseStream.Height = value; }
        }

        public virtual BitsPerPixel BitsPerPixel
        {
            get { return baseStream.BitsPerPixel; }
            set { baseStream.BitsPerPixel = value; }
        }

        public virtual FourCC Codec
        {
            get { return baseStream.Codec; }
            set { baseStream.Codec = value; }
        }

        public virtual void WriteFrame(bool isKeyFrame, byte[] frameData, int startIndex, int length)
        {
            baseStream.WriteFrame(isKeyFrame, frameData, startIndex, length);
        }

        public virtual System.Threading.Tasks.Task WriteFrameAsync(bool isKeyFrame, byte[] frameData, int startIndex, int length)
        {
            return baseStream.WriteFrameAsync(isKeyFrame, frameData, startIndex, length);
        }

        public int FramesWritten => baseStream.FramesWritten;

        public int Index => baseStream.Index;

        public virtual string Name
        {
            get { return baseStream.Name; }
            set { baseStream.Name = value; }
        }

        public FourCC StreamType => baseStream.StreamType;

        public FourCC ChunkId => baseStream.ChunkId;

        public virtual void PrepareForWriting() => baseStream.PrepareForWriting();

        public virtual void FinishWriting() => baseStream.FinishWriting();

        public void WriteHeader() => baseStream.WriteHeader();

        public void WriteFormat() => baseStream.WriteFormat();
    }
}