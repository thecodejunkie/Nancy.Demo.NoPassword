namespace Nancy.Demo.NoPassword.Authentication
{
    using System;

    public interface IUserDatabase
    {
        Guid GetIdentifier(string email);

        void RevokeIdentifier(Guid identifier);
    }
}