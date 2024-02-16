 using Green.Web.Models;
using Green.Web.Models.Dto;
using Green.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            ResponseDto? responseDto = await couponService.GetCouponsAsync();

            List<CouponDto>? list = new();

            if (responseDto is not null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = "Sorry! coupons are avilable at the moment";
            }

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await couponService.CreateCouponAsync(couponDto);

                if (responseDto is not null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Great! a new coupon has been created.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = responseDto?.Message;
                }
            }
            return View(couponDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? responseDto = await couponService.GetCouponByIdAsync(id);

            CouponDto? couponDto;

            if (responseDto is not null && responseDto.IsSuccess)
            {
                couponDto = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));
                return View(couponDto);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await couponService.DeleteCouponAsync(couponDto.Id);

                if (responseDto is not null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Amazing! the old coupon has been deleted.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = responseDto?.Message;
                }
            }
            return View(couponDto);
        }
    }
}

