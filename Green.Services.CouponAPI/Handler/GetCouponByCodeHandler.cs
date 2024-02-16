using System;
using Green.Services.CouponAPI.Data;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Queries;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
	public class GetCouponByCodeHandler : IRequestHandler<GetCouponByCodeQuery, Coupon>
    {
        private readonly IDataAccess dataAccess;

        public GetCouponByCodeHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public  Task<Coupon> Handle(GetCouponByCodeQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult( dataAccess.GetCouponByCode(request.Code));
        }
    }
}

