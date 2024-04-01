using System;
using System.Collections.Generic;

namespace NTO_2024WPF.data;

public partial class Studio
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Deskription { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
