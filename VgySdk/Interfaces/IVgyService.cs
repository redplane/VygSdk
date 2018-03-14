using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VgySdk.Models;

namespace VgySdk.Interfaces
{
    public interface IVgyService
    {
        #region Methods

        /// <summary>
        ///     Upload file asynchronously.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="contentType"></param>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> UploadAsync<T>(byte[] bytes, string contentType, string fileName,
            CancellationToken cancellationToken) where T: VgyResponseBase;

        /// <summary>
        ///     Set user key.
        /// </summary>
        /// <param name="userKey"></param>
        void SetUserKey(string userKey);

        #endregion
    }
}