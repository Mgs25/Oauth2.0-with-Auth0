using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleMvcApp.Support;
using Auth0.AspNetCore.Authentication;
using Rsk.AspNetCore.Authentication.Saml2p;
using Rsk.Saml.Configuration;
using IdentityServer4;
using System.Security.Cryptography.X509Certificates;

namespace SampleMvcApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSameSiteNoneCookies();

            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
            });

            // services.AddAuthentication()
            //     .AddSaml2p("saml2p", options =>
            //     {
            //         options.Licensee = "DEMO";
            //         options.LicenseKey = " eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjItMTAtMDZUMDE6MjE6MjYuNjQzNTUxMiswMDowMCIsImlhdCI6IjIwMjItMDktMDZUMDE6MjE6MjYiLCJvcmciOiJERU1PIiwiYXVkIjoyfQ==.pWTdA5V5dkexQYRhs89Vjfj7UK2sDMc/STCPfx4hV1H5jLXyDOJtlW9PoxlhpdPjeIno/SVUYXmYePYTlQD48oaXGdl/+mLgX1UnP8tpPHO1Cpk+fLJz4b/6YWmj1efIAhok5OvETKdODvqHwZkSS+c0OVOBJqWJZ7hWImZ31evGOIb7bgQkWm8uRRSHQHt8RE2hCQ5o2zRnvI7Eu8vbsPHI4nRg3sykwsZe3XdxUW4L419c52lsLl/8hm73bTtg1zlfixWd/zWVhCTfVuDAzzjcOFQSqVc7tMOvRhRob4+/6+EjOtTi+K+rZHoFp6EjGPhtP3KiBJdUD0g730+8l1v23lUVuvmilWQ5qCqD6kNDvtE+WDB+tdevKEHsry0kLkiTlVlOV36l8Bh+j6UPhrLDxhRt6r4csDz/xTLd8bwyEaWGmaD3zKUJOGYEqWd8ffGPjZOTiwryhhesB8Z2IzmmEBkykMlFhbMr+rximkbkEKClalVKSNjNapopLX3yvMuYFuQTWDWAg4eEpGKHaohURPEf3UALC0mtHnWOg4JW2MhlRav8rg2kLQXRy2ys+7Fqj+ovrmE+f9+8wWP5q3lXPODjwAb7iFFzASUrsH0cH1owYis2Ff7Plam9ZDNHGYLryOP6gLOAh3h2qDcINl90VJVV/CEwF8+2inp+OOc=";

            //         options.NameIdClaimType = "sub";
            //         options.CallbackPath = "/signin-saml";
            //         options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //         options.IdentityProviderMetadataAddress = "https://dev-19593071.okta.com/app/exk6esbtwojHWODro5d7/sso/saml/metadata";
            //         options.RequireValidMetadataSignature = false;

            //         // Details about yourself (the SP)
            //         options.ServiceProviderOptions = new SpOptions
            //         {
            //             EntityId = "https://localhost:5001/saml",
            //             MetadataPath = "/saml/metadata",
            //             SignAuthenticationRequests = true, // OPTIONAL - use if you want to sign your auth requests
            //             SigningCertificate = new X509Certificate2("testclient.pfx", "test")
            //         };
            //     });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
