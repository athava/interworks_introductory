namespace ERP_UI.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }

        // public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}
