# Google Drive ASP .net core sample

1. Make sure that you create a Web app client on [Google cloud console](https://console.cloud.google.com/). 
2. I have a videio on YouTube which will show you how to do that [How to create Google Oauth2 web application credentials in 2021.](https://youtu.be/pBVAyU4pZOU).
3. Add your Client id and client secrete at the top of [Startup.cs](https://github.com/LindaLawton/GoogleAspNetCoreSamples/blob/main/GoogleDrive/WebApplication1/Startup.cs)
4. Make sure to enable the Google Drive api under libraries, and the Google People API if you want to use the section that shows you how to access user profile Information.
5. If you get Redirect URI missmatch errror [Google OAuth2: How the fix redirect_uri_mismatch error. Part 2 server sided web applications.](https://youtu.be/QHz1Rs6lZHQ) please see.


# Sample request credit

This sample was created for the user [else-forty](https://stackoverflow.com/users/15876073/else-forty) in response to their question [google drive Api not working in production “Failed to launch browser with”](https://stackoverflow.com/q/67454668/1841839)

