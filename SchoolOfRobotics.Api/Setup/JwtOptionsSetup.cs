using Microsoft.Extensions.Options;
using SchoolOfRobotics.Infrastructure.Authentication;

namespace SchoolOfRobotics.Api.Setup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
	private const string SectionName = "JwtSettings";
	private readonly IConfiguration _configuration;

	public JwtOptionsSetup(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public void Configure(JwtOptions options)
	{
		_configuration.GetSection(SectionName).Bind(options);
	}
}
