using System;
using System.Collections.Generic;

namespace WpfApp12;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? DateOrder { get; set; }

    public DateTime? DateDelivery { get; set; }

    public int? PickupPoint { get; set; }

    public int? Client { get; set; }

    public int? Code { get; set; }

    public int? Status { get; set; }

    public virtual User? ClientNavigation { get; set; }

    public virtual PickupPoint? PickupPointNavigation { get; set; }

    public virtual Status? StatusNavigation { get; set; }
}
