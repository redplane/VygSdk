using Newtonsoft.Json;

namespace VgySdk.Models
{
    public class VgyResponseBase
    {
        #region Properies

        /// <summary>
        /// Whether the response is failingly or not.
        /// </summary>
        [JsonProperty]
        public bool IsError { get; set; }
        
        #endregion
    }
}