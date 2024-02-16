using System;
using Green.Services.CouponAPI.Models;

namespace Green.Services.CouponAPI.Data
{
	public interface IDataAccess
	{
		Coupon GetCouponById(int id);

		Coupon GetCouponByCode(string code);

		IEnumerable<Coupon> GetCoupons();

		Coupon CreateCoupon(Coupon coupon);

        Coupon UpdateCoupon(Coupon coupon);

		bool DeleteCoupon(int id);
    }
}

