using System.Collections.Generic;

#nullable disable

namespace ERP_API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerSubscriptions = new HashSet<CustomerSubscription>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }

        public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; }
    }
}
