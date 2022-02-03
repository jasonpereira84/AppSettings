using System;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static WsFederation AsWsFederation(this Okta.WsFederation okta)
            => new WsFederation
            {
                Realm = $"urn:okta:app:{okta.Id}",
                Issuer = $"http://www.okta.com/{okta.Id}",
                Referer = $"{okta.Origin}/app/template_wsfed/sso/wsfed/passive",
                Metadata = $"{okta.Origin}/FederationMetadata/2007-06/{okta.Id}/FederationMetadata.xml",
                Audiences = new String[] { $"{okta.Host}", $"{okta.Host}/" }
            };
    }
}