using Newtonsoft.Json;

namespace VgySdk.Models
{
    public class VgySuccessResponse : VgyResponseBase
    {
        #region Properties

        /// <summary>
        /// File size
        /// </summary>
        [JsonProperty("size")]
        public int FileSize { get; set; }

        /// <summary>
        /// Name of file which is uploaded to server.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File extension.
        /// </summary>
        [JsonProperty("ext")]
        public string Extension { get; set; }

        /// <summary>
        /// Url of page (links collection)
        /// </summary>
        [JsonProperty("url")]
        public string PageUrl { get; set; }

        /// <summary>
        /// Url of image.
        /// </summary>
        [JsonProperty("image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Url for image deletion.
        /// </summary>
        [JsonProperty("delete")]
        public string ImageDeleteUrl { get; set; }

        #endregion
    }
}