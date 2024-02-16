using Green.Web.Models;
using Green.Web.Models.Dto;

namespace Green.Web.Services
{
    public interface ICouponService
	{
		Task<ResponseDto?> GetCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> GetCouponByCodeAsync(string code);
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}

