﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SmartRMS.Domain.Models;

public partial class MasMenuUnitView
{
    public string UnitId { get; set; }

    public string MenuId { get; set; }

    public string UnitLabel { get; set; }

    public decimal? Price { get; set; }

    public string Barcode { get; set; }

    public string Qrcode { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string CreatedByCode { get; set; }

    public string ModifiedByCode { get; set; }

    public string MenuCode { get; set; }

    public string MenuName { get; set; }

    public string CategoryId { get; set; }

    public string PhotoUrl { get; set; }

    public string IsNeedCook { get; set; }

    public string CookingTime { get; set; }

    public string IsSubMenuId { get; set; }
}