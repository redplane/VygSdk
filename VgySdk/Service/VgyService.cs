using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using VgySdk.Constant;

namespace VgySdk.Service
{
    public class VgyService
    {
        #region Properties

        /// <summary>
        /// User key.
        /// </summary>
        private string _userKey;

        #endregion

        #region Methods

        /// <summary>
        /// Upload file asynchronously.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="contentType"></param>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UploadAsync(byte[] bytes, string contentType, string fileName, CancellationToken cancellationToken)
        {
            #region Parameters validation

            if (bytes == null)
                throw new Exception("File content cannot be empty");

            if (string.IsNullOrWhiteSpace(contentType))
                throw new Exception("Content type cannot be empty");

            if (string.IsNullOrWhiteSpace(fileName))
                throw new Exception("File name cannot be empty");

            #endregion

            // Initialize http client.
            var httpClient = new HttpClient();

            try
            {
                // Initialize multipart/form-data.
                var multipartFormDataContent = new MultipartFormDataContent();

                // Initialize byte content.
                var byteArrayContent = new ByteArrayContent(bytes);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                multipartFormDataContent.Add(byteArrayContent, "file", fileName);

                // Add parameters to request.
                if (!string.IsNullOrWhiteSpace(_userKey))
                    multipartFormDataContent.Add(new StringContent(_userKey), "userkey");

                // Submit file service api.
                var httpResponseMessage = await httpClient.PostAsync(new Uri(VygUrlConstant.UrlUploadFile),
                    multipartFormDataContent, cancellationToken);

                return httpResponseMessage;
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        /// <summary>
        /// Set user key.
        /// </summary>
        /// <param name="userKey"></param>
        public void SetUserKey(string userKey)
        {
            _userKey = userKey;
        }

        #endregion
    }
}