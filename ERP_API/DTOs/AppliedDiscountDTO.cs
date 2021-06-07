using System.Collections.Generic;

namespace ERP_API.DTOs
{
    public class AppliedDiscountDTO
    {
        public DiscountDTO Discount { get; set; }
        public double AppliedDiscount { get; set; }
    }
}
