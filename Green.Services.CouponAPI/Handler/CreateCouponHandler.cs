using System;
using Green.Services.CouponAPI.Commands;
using Green.Services.CouponAPI.Data;
using Green.Services.CouponAPI.Models;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
	public class CreateCouponHandler : IRequestHandler<CreateCouponCommand, Coupon>
	{
        private readonly IDataAccess dataAccess;

		public CreateCouponHandler(IDataAccess dataAccess)
		{
            this.dataAccess = dataAccess;
		}

        public Task<Coupon> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.CreateCoupon(request.coupon));
        }
    }
}

