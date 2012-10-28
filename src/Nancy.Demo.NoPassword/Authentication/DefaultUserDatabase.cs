namespace Nancy.Demo.NoPassword.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Security;

    public class DefaultUserDatabase : IUserMapper, IUserDatabase
    {
        private readonly IDictionary<string, Guid> users;

        public DefaultUserDatabase()
        {
            this.users = new Dictionary<string, Guid>
            {
                { "john@doe.com", Guid.Empty }
            };
        }

        public Guid GetIdentifier(string email)
        {
            if (this.users[email].Equals(Guid.Empty))
            {
                this.users[email] = Guid.NewGuid();
            }

            return this.users[email];
        }

        public void RevokeIdentifier(Guid identifier)
        {
            var email =
                this.GetEmailFromIdentifier(identifier);

            if (!string.IsNullOrEmpty(email))
            {
                this.users[email] = Guid.Empty;
            }
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var email =
                this.GetEmailFromIdentifier(identifier);

            return new Identity(email);
        }

        private string GetEmailFromIdentifier(Guid identifier)
        {
            return this.users
                .Where(x => x.Value.Equals(identifier))
                .Select(x => x.Key)
                .FirstOrDefault();
        }
    }
}