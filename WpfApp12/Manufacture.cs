using System;
using System.Collections.Generic;

namespace WpfApp12;

public partial class Manufacture
{
    public int Id { get; set; }

    public string? Manufacture1 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
