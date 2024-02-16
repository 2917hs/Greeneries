using AutoMapper;
using Green.Services.CouponAPI.Commands;
using Green.Services.CouponAPI.Models;
using Green.Services.CouponAPI.Models.Dto;
using Green.Services.CouponAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Green.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
	[ApiController]
	public class CouponAPIController : ControllerBase
	{
		private readonly IMediator mediator;
        private readonly IMapper mapper;
        private ResponseDto responseDto;

		public CouponAPIController(IMediator mediator, IMapper mapper)
		{
			this.mediator = mediator;
            this.mapper = mapper;
            // to avoid null check
            responseDto = new ResponseDto();
		}

		[HttpGet]
		public  ResponseDto Get()
		{
			try
			{
                var result =  mediator.Send(new GetCouponsLisQuery());
                if (result?.Result is not null)
                {
                    responseDto.Result = mapper.Map<IEnumerable<CouponDto>>(result.Result);
                    responseDto.IsSuccess = true;
                }
			}
			catch (Exception ex)
			{
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
			}
            return responseDto;
		}

		[HttpGet]
		[Route("{id:int}")]
		public ResponseDto Get(int id)
		{
            try
            {
                var result = mediator.Send(new GetCouponByIdQuery(id));
                if (result?.Result is not null)
                {
                    responseDto.Result = mapper.Map<CouponDto>(result.Result);
                    responseDto.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet]
        [Route("GetByCode/code")]
        public  ResponseDto Get(string code)
        {
            try
            {
                var result = mediator.Send(new GetCouponByCodeQuery(code));
                if (result?.Result is not null)
                {
                    responseDto.Result = mapper.Map<CouponDto>(result.Result);
                    responseDto.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpPost]
		public ResponseDto Post([FromBody] CouponDto couponDto)
		{
            try
            {
                var coupon = mapper.Map<Coupon>(couponDto);
                var result = mediator.Send(new CreateCouponCommand(coupon));
                if (result?.Result is not null)
                {
                    responseDto.Result = mapper.Map<CouponDto>(result.Result);
                    responseDto.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpPut]
        public object Put([FromBody] CouponDto couponDto)
        {
            try
            {
                var coupon = mapper.Map<Coupon>(couponDto);
                var result = mediator.Send(new UpdateCouponCommand(coupon));
                if (result?.Result is not null)
                {
                    responseDto.Result = mapper.Map<CouponDto>(result.Result);
                    responseDto.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                var result = mediator.Send(new DeleteCouponCommand(id));
                if (result?.Result is not null && result.Result)
                {
                    responseDto.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }
    }
}

