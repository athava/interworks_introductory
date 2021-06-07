using System.Collections.Generic;

namespace ERP_API.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public int DiscountId { get; set; }
        public int SubscriptionId { get; set; }
        public Dictionary<SubscriptionDTO, List<AppliedDiscountDTO>> AppliedDiscounts { get; set; }

    }
}
