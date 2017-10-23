using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AzureStorage;

namespace Lykke.Messages.Email
{
    public abstract class EmailAttachment
    {
        public string FileName { get; }

        public string ContentType { get; }

        public string EncodingWebName { get; }

        public virtual Task SaveToBlobAsync(IBlobStorage blob, string containerName, string key)
        {
            // TODO: save ContentType and EncodingWebName
            return Task.CompletedTask;
        }

        protected EmailAttachment(string fileName, string contentType, string encodingWebName)
        {
            FileName = fileName;
            ContentType = contentType;
            EncodingWebName = encodingWebName;
        }

        /// <summary>
        /// Creates a text attachment from inmemory text
        /// </summary>
        /// <param name="fileName">Attachment file name</param>
        /// <param name="text">Attachment text</param>
        /// <param name="contentType">Attachment content type (typically text/something)</param>
        /// <param name="encoding">Attachment encoding (UTF8 by default)</param>
        /// <returns>Attachment</returns>
        public static EmailAttachment CreateText(string fileName, string text, string contentType = "text/plain", Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            if (encoding == null)
                encoding = Encoding.UTF8;

            return new ByteArrayEmailAttachment(fileName, encoding.GetBytes(text), contentType, encoding.WebName);
        }

        /// <summary>
        /// Creates a text attachment from inmemory text
        /// </summary>
        /// <param name="fileName">Attachment file name</param>
        /// <param name="stream">Attachment stream</param>
        /// <param name="contentType">Attachment content type (typically text/something)</param>
        /// <param name="encoding">Attachment encoding (UTF8 by default)</param>
        /// <returns>Attachment</returns>
        public static EmailAttachment CreateText(string fileName, Stream stream, string contentType = "text/plain", Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            if (encoding == null)
                encoding = Encoding.UTF8;

            return new StreamEmailAttachment(fileName, stream, contentType, encoding.WebName);
        }

        /// <summary>
        /// Creates a binary attachment
        /// </summary>
        /// <param name="fileName">Attachment file name</param>
        /// <param name="data">Attachment data</param>
        /// <param name="contentType">Attachment content type (typically application/octet-stream)</param>
        /// <returns></returns>
        public static EmailAttachment CreateBinary(string fileName, byte[] data, string contentType = "application/octet-stream")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (string.IsNullOrWhiteSpace(contentType))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(contentType));

            return new ByteArrayEmailAttachment(fileName, data, contentType, null);
        }

        /// <summary>
        /// Creates a text attachment from inmemory text
        /// </summary>
        /// <param name="fileName">Attachment file name</param>
        /// <param name="stream">Attachment stream</param>
        /// <param name="contentType">Attachment content type (typically application/octet-stream)</param>
        /// <returns>Attachment</returns>
        public static EmailAttachment CreateBinary(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));

            return new StreamEmailAttachment(fileName, stream, contentType, null);
        }
    }

    internal sealed class ByteArrayEmailAttachment : EmailAttachment
    {
        public byte[] Bytes { get; }

        public ByteArrayEmailAttachment(string fileName, byte[] bytes, string contentType, string encodingWebName) : base(fileName, contentType, encodingWebName)
        {
            Bytes = bytes;
        }

        public override async Task SaveToBlobAsync(IBlobStorage blob, string containerName, string key)
        {
            await blob.SaveBlobAsync(containerName, key, Bytes);
            await base.SaveToBlobAsync(blob, containerName, key);
        }
    }

    internal sealed class StreamEmailAttachment : EmailAttachment
    {
        public Stream Stream { get; }

        public StreamEmailAttachment(string fileName, Stream stream, string contentType, string encodingWebName) : base(fileName, contentType, encodingWebName)
        {
            Stream = stream;
        }

        public override async Task SaveToBlobAsync(IBlobStorage blob, string containerName, string key)
        {
            await blob.SaveBlobAsync(containerName, key, Stream);
            await base.SaveToBlobAsync(blob, containerName, key);
        }
    }
}