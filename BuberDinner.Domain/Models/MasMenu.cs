﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SmartRMS.Domain.Models;

public partial class MasMenu
{
    public string MenuId { get; set; }

    public string MenuCode { get; set; }

    public string MenuName { get; set; }

    public string PhotoUrl { get; set; }

    public string CategoryId { get; set; }

    public bool? IsNeedCook { get; set; }

    public decimal? CookingTime { get; set; }

    public bool? IsSubMenuId { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
}