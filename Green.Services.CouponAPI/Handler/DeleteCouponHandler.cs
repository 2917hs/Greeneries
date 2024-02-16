using System;
using Green.Services.CouponAPI.Commands;
using Green.Services.CouponAPI.Data;
using MediatR;

namespace Green.Services.CouponAPI.Handler
{
    public class DeleteCouponHandler : IRequestHandler<DeleteCouponCommand, bool>
	{
        private readonly IDataAccess dataAccess;

		public DeleteCouponHandler(IDataAccess dataAccess)
		{
            this.dataAccess = dataAccess;
		}

        public Task<bool> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.DeleteCoupon(request.id));
        }
    }
}

