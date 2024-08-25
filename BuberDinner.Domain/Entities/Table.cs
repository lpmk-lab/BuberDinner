
namespace SS_RMS.Domain.Entities
{
    public class Tabels
    {

        public string MenuID { get; set; } = null!;
        public string UnitLabel { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public string QRCode { get; set; } = null!;
        public string itLowerUnit { get; set; } = null!;
        public string ConvertQTY { get; set; } = null!;

        public string RequestID { get; set; } = null!;
    }



    public class TabelsView
    {

        public string MenuID { get; set; } = null!;
        public string UnitLabel { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public string QRCode { get; set; } = null!;
        public string itLowerUnit { get; set; } = null!;
        public string ConvertQTY { get; set; } = null!;

        public string CreatedByCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 
        public DateTime ModifiedOn { get; set; } 
        public string ModifiedByCode { get; set; } = null!;
    }
}