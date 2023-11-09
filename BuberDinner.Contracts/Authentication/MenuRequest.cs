

namespace SmartRMS.Contracts.Authentication;

    public record MenuRequest(
        string MenuId,
        string MenuCode,
        string MenuName,
        string PhotoURL,
        string CategoryID,
        string isNeedCook,
        string CookingTime,
        string isSubMenuID,
         string RequestID
        );


