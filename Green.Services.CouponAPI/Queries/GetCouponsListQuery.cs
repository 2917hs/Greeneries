using System;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Queries
{
	public record GetCouponsLisQuery : IRequest<IEnumerable<Coupon>>;
}

