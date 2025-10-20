namespace Utf8Library
{
    public class Utf8Stream : Stream
    {
        private readonly Stream _stream;

        public Utf8Stream(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Writes the integer passed through <paramref name="value"/> in UTF-8 
        /// encoding to the stream.
        /// </summary>
        /// <param name="value">Integer to be written</param>
        public void Write(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the character passed through <paramref name="character"/> in 
        /// UTF-8 encoding to the stream.
        /// </summary>
        /// <param name="character">Character to be written</param>
        public void Write(char character)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the string passed through <paramref name="str"/> as a sequence 
        /// of UTF-8 encoded characters to the underlying stream.
        /// </summary>
        /// <param name="str">String to be written</param>
        public void Write(string str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the next UTF-8 encoded integer from the underlying stream.
        /// </summary>
        /// <returns>Value read from the stream</returns>
        /// <exception cref="EndOfStreamException">Nothing more can be read</exception>
        public int ReadInt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the next UTF-8 encoded character from the underlying stream.
        /// </summary>
        /// <returns>Value read from the stream</returns>
        /// <exception cref="EndOfStreamException">Nothing more can be read</exception>
        public char ReadChar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the underlying steram as UTF-8 encoded characters.
        /// </summary>
        /// <returns>The stream's content as string</returns>
        /// <exception cref="EndOfStreamException">Nothing more can be read</exception>
        public string ReadString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Separates the string given into a list of unicode sclars. 
        /// As an unicode string consists of a sequence of characters which are 
        /// - by definition - stored in UTF-16, measures have to be taken to convert
        /// characters not fitting into a single UTF-16 value into an UTF-32 scalar.
        /// </summary>
        /// <param name="str">String to be split</param>
        /// <returns>An enumerable sequence of UTF-32 scalars ("UTF-32 characters")</returns>
        private static IEnumerable<int> UnicodeScalarsFromString(string str)
        {
            var uc_scalars = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                uc_scalars.Add(char.ConvertToUtf32(str, i));
                if (char.IsHighSurrogate(str[i]))
                {
                    i += 1;
                }
            }
            return uc_scalars;
        }

        #region Stream Interface
        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position
        {
            set
            {
                _stream.Position = value;
            }
            get
            {
                return _stream.Position;
            }
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count); 
        }
        #endregion
    }
}
