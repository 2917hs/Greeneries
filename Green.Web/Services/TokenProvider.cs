using System;
using Green.Web.Utility;

namespace Green.Web.Services
{
    public class TokenProvider : ITokenProvider
    { 
        private readonly IHttpContextAccessor httpContextAccessor;

		public TokenProvider(IHttpContextAccessor httpContextAccessor)
		{
            this.httpContextAccessor = httpContextAccessor;
		}

        public void ClearToken()
        {
            httpContextAccessor.HttpContext?.Response.Cookies.Delete(TokenKey.Key);
        }

        public string? GetToken()
        {
            string? token = null;

            bool? tokenAvailable = httpContextAccessor.HttpContext?.Request.Cookies.
                TryGetValue(TokenKey.Key, out token);

            return token;
        }

        public void SetToken(string token)
        {
            httpContextAccessor.HttpContext?.Response.Cookies.Append(TokenKey.Key, token);
        }
    }
}

