using System;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Commands
{
	public record UpdateCouponCommand(Coupon coupon) : IRequest<Coupon>;
}

