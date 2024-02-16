using System;
using AutoMapper;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Models.Dto;

namespace Green.Services.CouponAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			return new MapperConfiguration(config =>
			{
				config.CreateMap<CouponDto, Coupon>();
				config.CreateMap<Coupon, CouponDto>();
			});
		}
	}
}

