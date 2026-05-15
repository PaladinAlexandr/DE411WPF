using System;
using System.Collections.Generic;

namespace WpfApp12;

public partial class OrderProduct
{
    public int? Article { get; set; }

    public int? Amount { get; set; }

    public int? NumberOrder { get; set; }

    public int Id { get; set; }

    public virtual Product? ArticleNavigation { get; set; }

    public virtual Order? NumberOrderNavigation { get; set; }
}
