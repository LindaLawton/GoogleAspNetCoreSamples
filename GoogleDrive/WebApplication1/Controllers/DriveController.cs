using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Drive : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lists the authenticated user's Google Drive files.
        /// Specifying the <see cref="GoogleScopedAuthorizeAttribute"> will guarantee that the code
        /// executes only if the user is authenticated and has granted the scope specified in the attribute
        /// to this application.
        /// </summary>
        /// <param name="auth">The Google authorization provider.
        /// This can also be injected on the controller constructor.</param>
        [GoogleScopedAuthorize(new[] {Google.Apis.Drive.v3.DriveService.ScopeConstants.DriveReadonly})]
        public async Task<IActionResult> ListFiles([FromServices] IGoogleAuthProvider auth, string directoryId, string directoryName)
        {
            if (directoryId == null)
            {
                directoryId = "root";
                directoryName = "root";
            }

            var cred = await auth.GetCredentialAsync();
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred,
                ApplicationName = "Drive Oauth2 Authentication Sample"
            });

            var request = service.Files.List();
            request.Q = $"parents in '{directoryId}'";

            var response = await request.ExecuteAsync();

            var files = response.Files.OrderBy(a => a.Name);

            var viewModel = new DirectoryListModel()
            {
                DirectoryId = directoryId,
                DirectoryName = directoryName,
                Files = files.ToList()
            };
            

            return View(viewModel);
        }
    }
}