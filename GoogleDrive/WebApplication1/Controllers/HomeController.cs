using System.Diagnostics;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
        [GoogleScopedAuthorize(new []{ PeopleServiceService.ScopeConstants.UserinfoProfile})]
        public async Task<IActionResult> UserProfile([FromServices] IGoogleAuthProvider auth)
        {
            var cred = await auth.GetCredentialAsync();
            var service = new PeopleServiceService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred,
                ApplicationName = "People Oauth2 Authentication Sample"
            });

            var request =  service.People.Get("people/me");
            request.PersonFields = "names";
            var person = await request.ExecuteAsync();
            
            return View(person);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}