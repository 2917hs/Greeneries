using Green.Web.Models;
using Green.Web.Models.Dto;

namespace Green.Web.Services
{
    public class CouponService : ICouponService
	{
        private readonly IBaseService baseService;

		public CouponService(IBaseService baseService)
		{
            this.baseService = baseService;
		}

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.POST,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon",
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.DELETE,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon/{id}"
            });
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string code)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.GET,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon/GetByCode/{code}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.GET,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon/{id}"
            });
        }

        public async Task<ResponseDto?> GetCouponsAsync()
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.GET,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.PUT,
                Url = $"{Utility.StaticDetails.CouponApiBase}api/Coupon",
                Data = couponDto
            });
        }
    }
}

