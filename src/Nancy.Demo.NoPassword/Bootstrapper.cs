namespace Nancy.Demo.NoPassword
{
    using Authentication;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Bootstrapper;
    using Nancy.Cryptography;
    using TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var cryptographyConfiguration = new CryptographyConfiguration(
                new RijndaelEncryptionProvider(new PassphraseKeyGenerator("SuperSecretPass", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })),
                new DefaultHmacProvider(new PassphraseKeyGenerator("UberSuperSecure", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })));

            var config =
                new FormsAuthenticationConfiguration()
                {
                        
                    CryptographyConfiguration = cryptographyConfiguration,
                    RedirectUrl = "/login",
                    UserMapper = container.Resolve<IUserDatabase>() as IUserMapper,
                };

            FormsAuthentication.Enable(pipelines, config);
        }
    }
}