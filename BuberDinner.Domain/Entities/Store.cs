using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRMS.Domain.Entities
{
    public class StoreRecord
    {
        public string StoreId { get; set; } = null!;

        public string StoreName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ManagerName { get; set; } = null!;
        public bool IsSaleStore { get; set; } = false!;
        public string RequestID { get; set; } = null!;
    }
    public class StoreView
    {

        public string StoreId { get; set; } = null!;

        public string StoreName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ManagerName { get; set; } = null!;
        public string RequestID { get; set; } = null!;

        public string CreatedByCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedByCode { get; set; } = null!;
    }
}
