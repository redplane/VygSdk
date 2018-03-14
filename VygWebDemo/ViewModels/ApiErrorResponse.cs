namespace VygWebDemo.ViewModels
{
    public class ApiErrorResponse
    {
        #region Properties

        /// <summary>
        /// Message of error.
        /// </summary>
        public string Message { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializ message with specific information.
        /// </summary>
        /// <param name="message"></param>
        public ApiErrorResponse(string message)
        {
            Message = message;
        }

        #endregion
    }
}