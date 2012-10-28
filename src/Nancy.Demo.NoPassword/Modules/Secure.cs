namespace Nancy.Demo.NoPassword.Modules
{
    using Nancy;
    using Nancy.Security;

    public class Secure : NancyModule
    {
        public Secure() : base("/secure")
        {
            this.RequiresAuthentication();

            Get["/"] = parameters => {
                return View["secure"];
            };
        }
    }
}