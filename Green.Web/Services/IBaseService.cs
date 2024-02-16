using System;
using Green.Web.Models;
using Green.Web.Models.Dto;

namespace Green.Web.Services
{
	public interface IBaseService
	{
		Task<ResponseDto?> SendAsync(RequestDto requestDto);
	}
}

