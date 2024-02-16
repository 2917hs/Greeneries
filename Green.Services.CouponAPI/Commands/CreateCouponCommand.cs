using System;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Models.Dto;
using MediatR;

namespace Green.Services.CouponAPI.Commands
{
    public record CreateCouponCommand(Coupon coupon) : IRequest<Coupon>;
}

