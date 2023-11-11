using System.Threading.Tasks;

namespace SmartRMS.Domain.Entities;

public class MenuRecord
{
    public string MenuId { get; set; } = null!;
    public string MenuCode { get; set; } = null!;
    public string MenuName { get; set; } = null!;
    public string PhotoURL { get; set; } = null!;
    public string CategoryID { get; set; } = null!;
    public string isNeedCook { get; set; } = null!;
    public string CookingTime { get; set; } = null!;
    public string isSubMenuID { get; set; } = null!;

    public string RequestID { get; set; } = null!;
}
public class MenuView
{
    public string MenuId { get; set; } = null!;
    public string MenuCode { get; set; } = null!;
    public string MenuName { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public bool IsNeedCook { get; set; }
    public string isNeedCookString => IsNeedCook.
        ToString();
    public decimal CookingTime { get; set; }
    public string CookingTimeString => CookingTime.
       ToString();
    public bool isSubMenuID { get; set; }
    public string CategoryName { get; set; } = null!;
    public string isSubMenuIDString => isSubMenuID.
      ToString();


    public string CreatedByCode { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedByCode { get; set; } = null!;
}

