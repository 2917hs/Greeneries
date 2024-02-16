using System;
using static Green.Web.Utility.StaticDetails;

namespace Green.Web.Models.Dto
{
	public class RequestDto
	{
		public object? Data { get; set; }

		public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;
	}
}

