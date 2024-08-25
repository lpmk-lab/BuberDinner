
namespace SmartRMS.Domain.Entities
{
    public class MenuUnitRecord
    {


        public string UnitId { get; set; } = null!;
        public string MenuId { get; set; } = null!;
        public string UnitLabel { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public string Qrcode { get; set; } = null!;
        public string ItLowerUnit { get; set; } = null!;
        public string ConvertQty { get; set; } = null!;

        public string RequestID { get; set; } = null!;
      
        }



        public class MenuUnitView
    {

        public string UnitId { get; set; } = null!;
        public string MenuId { get; set; } = null!;
        public string UnitLabel { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Barcode { get; set; } = null!;
        public string Qrcode { get; set; } = null!;
        public string ItLowerUnit { get; set; } = null!;
        public string ConvertQty { get; set; } = null!;
        public string CreatedByCode { get; set; } = null!;
            public DateTime CreatedOn { get; set; }
            public DateTime ModifiedOn { get; set; }
            public string ModifiedByCode { get; set; } = null!;
        }
    }

