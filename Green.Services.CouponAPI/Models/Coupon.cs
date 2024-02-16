using System;
using System.ComponentModel.DataAnnotations;

namespace Green.Services.CouponAPI.Models
{
	public class Coupon
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Code { get; set; } = string.Empty;

        [Required]
        public decimal Discount { get; set; }

        public decimal? MinimumAmount { get; set; }
	}
}

