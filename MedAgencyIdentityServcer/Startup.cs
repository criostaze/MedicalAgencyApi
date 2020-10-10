using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Logging;

namespace MedAgencyIdentityServcer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddIdentityServer(options =>
            {
                // http://docs.identityserver.io/en/release/reference/options.html#refoptions
                options.Endpoints = new EndpointsOptions
                {
                    // � Implicit Flow ������������ ��� ��������� �������
                    EnableAuthorizeEndpoint = true,
                    // ��� ��������� ������� ������
                    EnableCheckSessionEndpoint = true,
                    // ��� ������� �� ���������� ������������
                    EnableEndSessionEndpoint = true,
                    // ��� ��������� claims �������������������� ������������ 
                    // http://openid.net/specs/openid-connect-core-1_0.html#UserInfo
                    EnableUserInfoEndpoint = true,
                    // ������������ OpenId Connect ��� ��������� ����������
                    EnableDiscoveryEndpoint = true,

                    // ��� ��������� ���������� � �������, �� �� ����������
                    EnableIntrospectionEndpoint = false,
                    // ��� �� ����� �.�. � Implicit Flow access_token �������� ����� authorization_endpoint
                    EnableTokenEndpoint = false,
                    // �� �� ���������� refresh � reference tokens 
                    // http://docs.identityserver.io/en/release/topics/reference_tokens.html
                    EnableTokenRevocationEndpoint = false
                };

                // IdentitySever ���������� cookie ��� �������� ����� ������
                options.Authentication = new IdentityServer4.Configuration.AuthenticationOptions
                {
                    CookieLifetime = TimeSpan.FromDays(1)
                };

            })
                // �������� x509-����������, IdentityServer ���������� RS256 ��� ������� JWT
                .AddDeveloperSigningCredential()
                // ��� �������� � id_token
                .AddInMemoryIdentityResources(GetIdentityResources())
                // ��� �������� � access_token
                .AddInMemoryApiResources(GetApiResources())
                // ��������� ���������� ����������
                .AddInMemoryClients(GetClients())
                // �������� ������������
                .AddTestUsers(GetUsers());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! loggerFactory.AddConsole(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            // ���������� middleware IdentityServer
            app.UseIdentityServer();

            // ��� 2 ������� �����, ����� ��������� �������������� �������� ������
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            // ����������, ����� scopes ����� �������� IdentityServer
            return new List<IdentityResource>
            {
                 // "sub" claim
                 new IdentityResources.OpenId(),
                 // ����������� claims � ������������ � profile scope
                 // http://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims
                 new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            // claims ���� scopes ����� �������� � access_token
            return new List<ApiResource>
    {
        // ���������� scope "api1" ��� IdentityServer
        new ApiResource("api1", "API 1", 
            // ��� claims ������ � scope api1
            new[] {"name", "role" })
    };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            // ������������ ��������, ��� ������ client_id ������ ��������� ���������� ���������� 
            ClientId = "js",
            ClientName = "JavaScript Client",
            AllowedGrantTypes = GrantTypes.Implicit,
            AllowAccessTokensViaBrowser = true,
            // �� ���� ��������� ������� ������ ������, 
            // ��� false ����� �������� ����������� ���������� ����� UserInfo endpoint
            AlwaysIncludeUserClaimsInIdToken = true,
            // ����� ������ ������� �� ������� ���������� ���������� ����� ���������
            // ������������� User Agent, ����� ��� ������������
            RedirectUris = {
                // ����� ��������������� ����� ������
                "http://localhost:5003/callback.html",
                // ����� ��������������� ��� �������������� ���������� access_token ����� iframe
                "http://localhost:5003/callback-silent.html"
            },
            PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
            // ����� ����������� ����������, ������ ������ ���������� ������ CORS-���������
            AllowedCorsOrigins = { "http://localhost:5003" },
            // ������ scopes, ����������� ������ ��� ������� ����������� ����������
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "api1"
            },

            AccessTokenLifetime = 3600, // ������, ��� �������� �� ���������
            IdentityTokenLifetime = 300, // ������, ��� �������� �� ���������

            // ��������� �� ��������� refresh-������� ����� �������� scope offline_access
            AllowOfflineAccess = false,
        }
    };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password",

            Claims = new List<Claim>
            {
                new Claim("name", "Alice"),
                new Claim("website", "https://alice.com"),
                new Claim("role", "user"),
            }
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password",

            Claims = new List<Claim>
            {
                new Claim("name", "Bob"),
                new Claim("website", "https://bob.com"),
                new Claim("role", "admin"),
            }
        }
    };
        }
    }
}
