using System;
using System.Collections.Generic;

namespace NTO_2024WPF.data;

public partial class Exhibit
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long StudiosId { get; set; }

    public virtual Studio Studios { get; set; } = null!;
}
