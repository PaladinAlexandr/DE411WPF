using System;
using System.Collections.Generic;

namespace WpfApp12;

public partial class PickupPoint
{
    public int Id { get; set; }

    public int? IndexHouse { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? House { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
