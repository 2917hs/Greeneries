using System;
using Green.Services.CouponAPI.Commands;
using Green.Services.CouponAPI.Data;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
    public class UpdateCouponHandler  : IRequestHandler<UpdateCouponCommand, Coupon>
    {
        private readonly IDataAccess dataAccess;

        public UpdateCouponHandler(IDataAccess dataAccess)
		{
            this.dataAccess = dataAccess;
		}

        public Task<Coupon> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.UpdateCoupon(request.coupon));
        }
    }
}

