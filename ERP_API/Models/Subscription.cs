using System;
using System.Collections.Generic;

#nullable disable

namespace ERP_API.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            CustomerSubscriptions = new HashSet<CustomerSubscription>();
        }

        public int Id { get; set; }
        public string SubscriptionName { get; set; }
        public double SubscriptionPrice { get; set; }

        public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; }
    }
}
