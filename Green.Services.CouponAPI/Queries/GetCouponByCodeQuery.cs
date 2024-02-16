using System;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Queries
{
	public record GetCouponByCodeQuery (string Code) : IRequest<Coupon>;
}

