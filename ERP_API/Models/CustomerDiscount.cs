using System;
using System.Collections.Generic;

#nullable disable

namespace ERP_API.Models
{
    public partial class CustomerDiscount
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DiscountId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
