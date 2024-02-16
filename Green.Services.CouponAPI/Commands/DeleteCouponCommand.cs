using System;
using MediatR;

namespace Green.Services.CouponAPI.Commands
{
	public record DeleteCouponCommand(int id) : IRequest<bool>;
}

