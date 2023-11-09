using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRMS.Domain.Entities
{
    public class Categories
    {
        public string CategoryId { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
       
        public string CategoryIcon { get; set; } = null!;

        public string RequestID { get; set; } = null!;
    }
    public class CategoriesView
    {

        public string CategoryId { get; set; } = null!;
        public string CategoryName { get; set; } = null!;

        public string CategoryIcon { get; set; } = null!;


        public string CreatedByCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedByCode { get; set; } = null!;
    }
}
