using System;
using Green.Services.CouponAPI.Data;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Queries;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
	public class GetCouponsListHandler : IRequestHandler<GetCouponsLisQuery, IEnumerable<Coupon>>
	{
        private readonly IDataAccess dataAccess;

        public GetCouponsListHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

		public  Task<IEnumerable<Coupon>> Handle(GetCouponsLisQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult( dataAccess.GetCoupons());
        }
    }
}

