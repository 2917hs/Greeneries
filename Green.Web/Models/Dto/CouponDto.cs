using System;
namespace Green.Web.Models.Dto
{
	public class CouponDto
	{
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public double Discount { get; set; }

        public double MinimumAmount { get; set; }
    }
}

