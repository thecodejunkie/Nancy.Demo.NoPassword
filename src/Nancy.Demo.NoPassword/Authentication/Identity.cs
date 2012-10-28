namespace Nancy.Demo.NoPassword.Authentication
{
    using System.Collections.Generic;
    using Nancy.Security;

    public class Identity : IUserIdentity
    {
        public Identity(string email)
        {
            this.UserName = email;
        }

        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }
}