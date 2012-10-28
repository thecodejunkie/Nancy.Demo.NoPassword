namespace Nancy.Demo.NoPassword.Modules
{
    using Nancy;

    public class Home : NancyModule
    {
        public Home()
        {
            Get["/"] = x =>
            {
                return View["home"];
            };
        }
    }
}