using System.Text.Json.Serialization;

namespace SS_RMS.Domain.Entities
{
    public class Tabels
    {

        public string TableId { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public string TableNo { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Status { get; set; } = null!;

        public string RequestID { get; set; } = null!;
    }



    public class TabelsView
    {

        public string TableId { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public string TableNo { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Status { get; set; } = null!;

        public string CreatedByCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 
        public DateTime ModifiedOn { get; set; } 
        public string ModifiedByCode { get; set; } = null!;
    }
}