namespace VgySdk.Models
{
    public class VgyErrorResponse : VgyResponseBase
    {
        #region Properties

        /// <summary>
        /// List of messages returned from vgy.me
        /// </summary>
        public string[] Messages { get; set; }

        #endregion
    }
}