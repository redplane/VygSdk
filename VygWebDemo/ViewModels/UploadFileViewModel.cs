using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VygWebDemo.ViewModels
{
    public class UploadFileViewModel
    {
        #region Properties

        /// <summary>
        /// File to be uploaded.
        /// </summary>
        public IFormFile File { get; set; }

        #endregion
    }
}