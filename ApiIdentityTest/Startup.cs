using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiIdentityTest
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews(mvcOtions =>
			{
				mvcOtions.EnableEndpointRouting = false;
			});

			services.AddCors(options =>
			{
				// ����� �������� CORS, ����� ���� ���������� ���������� ����� ��������� ������ �� ������ API
				options.AddPolicy("default", policy =>
				{
					policy.WithOrigins("http://localhost:5003")
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme =
										   JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme =
										   JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.Authority = "http://localhost:5000";
				o.Audience = "apiApp";
				o.RequireHttpsMetadata = false;
			});

			// ����������� ������ MVC Core ��� ������ Razor, DataAnnotations � ���������, ����������� � Asp.NET 4.5 WebApi
			services.AddMvcCore()
				// ��������� �����������, ��������� ����� ����� �������� �������� Authorize
				.AddAuthorization(options =>
					// �������� ��������� �� �������� � Roles magic strings, ����������� ������������ ����� ����� �������
					options.AddPolicy("AdminsOnly", policyUser =>
					{
						policyUser.RequireClaim("role", "admin");
					})
				)
				// ����������� AddMVC, �� ����������� AddMvcCore, �� �� ����� �������� ��������� � JSON 
				.AddJsonOptions(o =>
				{
					o.JsonSerializerOptions.PropertyNamingPolicy = null;
					o.JsonSerializerOptions.DictionaryKeyPolicy = null;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			//loggerFactory.AddConsole(LogLevel.Debug);

			// ��������� middleware ��� CORS 
			app.UseCors("default");
			app.UseAuthentication();


			// ��������� middleware ��� ���������� ������� ������������ �� OpenId  Connect JWT-�������
			//app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
			//{
			//	// ��� IdentityServer
			//	Authority = "http://localhost:5000",
			//	// �������, ��� ��� �� ��������� HTTPS ��� ������� � IdentityServer, ������ ���� true �� ����������
			//	// https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.builder.openidconnectoptions
			//	RequireHttpsMetadata = false,

			//	// ��� �������� ����� ������������ �� ��������� ���� aud ������ access_token JWT
			//	ApiName = "api1",

			//	// ����� ��� ��������, ���� �� ����� ��������� ��� api �� ��������� scopes � �� �� ��������� ��������� scope
			//	// AllowedScopes = { "api1.read", "api1.write" }

			//	// ������ JWT-����� � ��������� claims ������ � HttpContext.User ���� ���� �� ������������ ������� Authorize �� ������, ��������������� ������
			//	AutomaticAuthenticate = true,
			//	// ��������� ���� middleware ��� ������������ ��� ������������ authentication challenge
			//	AutomaticChallenge = true,

			//	// ��������� ��� [Authorize], ��� IdentityServerAuthenticationOptions - �������� �� ���������
			//	RoleClaimType = "role",
			//});

			app.UseMvc();
		}
	}
}
