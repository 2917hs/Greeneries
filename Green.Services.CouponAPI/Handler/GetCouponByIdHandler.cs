using System;
using Green.Services.CouponAPI.Data;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Queries;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
	public class GetCouponByIdHandler : IRequestHandler<GetCouponByIdQuery, Coupon>
    {
        private readonly IDataAccess dataAccess;

        public GetCouponByIdHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

		public  Task<Coupon> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult<Coupon>( dataAccess.GetCouponById(request.Id));
        }
    }
}

