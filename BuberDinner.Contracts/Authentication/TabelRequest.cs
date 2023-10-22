

namespace SmartRMS.Contracts.Authentication;

public record TabelRequest(
    string TableId,
    string TableName,
    string TableNo,
    string Location,
    string RequestID
);
