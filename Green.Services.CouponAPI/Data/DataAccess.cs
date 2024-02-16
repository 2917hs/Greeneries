using Green.Services.CouponAPI.Models;

namespace Green.Services.CouponAPI.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext applicationDbContext;

		public DataAccess(ApplicationDbContext applicationDbContext)
		{
            this.applicationDbContext = applicationDbContext;
        }

        public Coupon CreateCoupon(Coupon coupon)
        {
            applicationDbContext.Coupon.Add(coupon);
            applicationDbContext.SaveChanges();
            return coupon;
        }

        public bool DeleteCoupon(int id)
        {
            var coupon = applicationDbContext.Coupon.First(c => c.Id == id);
            applicationDbContext.Coupon.Remove(coupon);
            var result = applicationDbContext.SaveChanges();
            return result == 1;
        }

        public  Coupon GetCouponByCode(string code)
        {
            return  applicationDbContext.Coupon.First(c => c.Code.Equals(code));
        }

        public  Coupon GetCouponById(int id)
        {
            return  applicationDbContext.Coupon.First(c => c.Id.Equals(id));
        }

        public  IEnumerable<Coupon> GetCoupons()
        {
            return  applicationDbContext.Coupon.ToList();
        }

        public Coupon UpdateCoupon(Coupon coupon)
        {
            applicationDbContext.Coupon.Add(coupon);
            applicationDbContext.Update(coupon);
            applicationDbContext.SaveChanges();
            return coupon;
        }
    }
}

