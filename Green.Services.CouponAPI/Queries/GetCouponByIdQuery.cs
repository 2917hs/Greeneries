using System;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Queries
{
    public record GetCouponByIdQuery(int Id) : IRequest<Coupon>;
}

