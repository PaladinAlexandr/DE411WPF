using System;
using System.Collections.Generic;

namespace WpfApp12;

public partial class Product
{
    public string? Article { get; set; }

    public string? ProductName { get; set; }

    public string? Unit { get; set; }

    public decimal? Price { get; set; }

    public int? Supplier { get; set; }

    public int? Manufacture { get; set; }

    public int? Category { get; set; }

    public decimal? Discount { get; set; }

    public int? CountInBox { get; set; }

    public string? Discription { get; set; }

    public string? Phorto { get; set; }

    public int Id { get; set; }

    public virtual Category? CategoryNavigation { get; set; }

    public virtual Manufacture? ManufactureNavigation { get; set; }

    public virtual Supplier? SupplierNavigation { get; set; }
}
