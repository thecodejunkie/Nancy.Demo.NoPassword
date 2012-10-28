namespace Nancy.Demo.NoPassword.Modules
{
    using System;
    using FluentEmail;
    using Nancy.Authentication.Forms;
    using Nancy.Demo.NoPassword.Authentication;

    public class Login : NancyModule
    {
        public Login(IUserDatabase userDatabase)
        {
            Get["/login"] = x =>
            {
                return View["login"];
            };

            Get["/login/{token}"] = x =>
            {
                var userGuid =
                    new Guid((string)x.token);

                var redirectUrl = (Request.Query.returnUrl.HasValue) ?
                    (string)Request.Query.returnUrl :
                    "/";

                return this.LoginAndRedirect(userGuid, DateTime.MaxValue, redirectUrl);
            };

            Post["login/send"] = x =>
            {
                var emailAdress =
                    Request.Form.email;

                if (emailAdress.HasValue)
                {
                    var identifier =
                        userDatabase.GetIdentifier(emailAdress).ToString();

                    var loginUrl =
                        Request.Url.Clone();

                    loginUrl.Path = 
                        string.Concat("/login", "/", identifier.ToString());

                    var template =
                        string.Format("Dear [Your Service] user, click <a href=\'{0}\'>here to login</a>", loginUrl);

                    var email = Email
                        .From("no-reply@yourservice.com")
                        .To(emailAdress)
                        .Subject("Your [Your Service] login")
                        .Body(template);

                    email.Send();
                }

                return Response.AsRedirect("/");
            };

            Get["/logout"] = x =>
            {
                return this.LogoutAndRedirect("~/");
            };
        }
    }
}