# Nancy.Demo.NoPassword

This is a demo for showing how you can implement [NoPassword](https://nopassword.alexsmolen.com/) authentication in your Nancy applications.

The demo uses the [Nancy.Authentication.Forms](https://github.com/NancyFx/Nancy/wiki/Forms-authentication) package to perform authentication, but instead of directly logging the user in, it uses the [Fluent Email](http://nuget.org/packages/fluent-email) Nuget to send the user an e-mail with the login token.

When the user clicks the link it will be taken to the site which will verify the token and log the user in. A cookie will be generated which is then used to re-authenticate the user when visiting the site. As soon as the user logs out, the token will be revoked (and the cookie removed) an can no longer be used.

In order to run this demo locally, on your machine, you need to make sure the mail settings, in web.config, are properly configured. You can save the e-mails to your hard drive by using the following settings

```xml
<smtp deliveryMethod="SpecifiedPickupDirectory">
	<specifiedPickupDirectory pickupDirectoryLocation="C:\TestMailMessages\" />
</smtp>
```

Or you can use a fake SMTP service, like [Papercut](http://papercut.codeplex.com), to send the e-mails to a local SMTP server that will enable you to view the e-mail content using a GUI.

```xml
<smtp deliveryMethod="Network">
	<network host="localhost" port="25" defaultCredentials="true" />
</smtp>
```