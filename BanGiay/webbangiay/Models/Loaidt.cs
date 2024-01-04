using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Loaidt
{
    public int Maloaidt { get; set; }

    public string Loaidactrung { get; set; } = null!;

    public virtual ICollection<Dactrung> Dactrungs { get; set; } = new List<Dactrung>();
}
