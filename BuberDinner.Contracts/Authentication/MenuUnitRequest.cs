
namespace SmartRMS.Contracts.Authentication
{
    public record MenuUnitRequest
    (
        string UnitId,
        string MenuId,
        string UnitLabel,
        string Price,
        string Barcode,
        string Qrcode,
        string ItLowerUnit,
        string ConvertQty,
         string RequestID
        );
    }
