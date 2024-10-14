
namespace SmartRMS.Contracts.Authentication
{
    public record CustomerRequest
    (
     string CustomerId ,
     string CustomerName,
     string PhoneNo ,
     string RequestID 
    );
}
