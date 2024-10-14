

namespace SmartRMS.Domain.Entities
{
    public class CustomerRecord
    {
        public string CustomerId { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string RequestID { get; set; } = null!;
    }
    public class CustomerView
    {

        public string CustomerId { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string RequestID { get; set; } = null!;

        public string CreatedByCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedByCode { get; set; } = null!;
    }
}
