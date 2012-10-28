namespace Nancy.Demo.NoPassword
{
    public static class UrlExtensions
    {
        public static Url Clone(this Url source)
        {
            return new Url
                {
                    BasePath = source.BasePath,
                    Fragment = source.Fragment,
                    HostName = source.HostName,
                    Path = source.Path,
                    Port = source.Port,
                    Query = source.Query,
                    Scheme = source.Scheme
                };
        }
    }
}