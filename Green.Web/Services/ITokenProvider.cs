using System;
namespace Green.Web.Services
{
	public interface ITokenProvider
	{
		void SetToken(string token);

		string? GetToken();

		void ClearToken();
	}
}

