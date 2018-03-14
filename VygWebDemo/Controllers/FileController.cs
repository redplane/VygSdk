using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VgySdk.Interfaces;
using VgySdk.Models;
using VygWebDemo.ViewModels;

namespace VygWebDemo.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        #region Properties

        /// <summary>
        /// Vgy service instance.
        /// </summary>
        private readonly IVgyService _vgyService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize controller with injectors.
        /// </summary>
        /// <param name="vgyService"></param>
        public FileController(IVgyService vgyService)
        {
            _vgyService = vgyService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Upload image to vgy hosting.
        /// </summary>
        /// <returns></returns>
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(UploadFileViewModel info)
        {
            // Read file from vgy
            var file = info.File;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();
                var vgyResponse =
                    await _vgyService.UploadAsync<VgySuccessResponse>(bytes, file.ContentType, file.FileName, CancellationToken.None);
                
                if (vgyResponse == null)
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new ApiErrorResponse("Unable to upload invalid file."));
                
                return Ok(vgyResponse);
            }

            #endregion
        }
    }
}
