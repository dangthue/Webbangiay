using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Dactrung
{
    public int Madactrung { get; set; }

    public int? Maloaidt { get; set; }

    public int Thutu { get; set; }

    public string? Donvi { get; set; }

    public string Ten { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<DactrungSanpham> DactrungSanphams { get; set; } = new List<DactrungSanpham>();

    public virtual Loaidt? MaloaidtNavigation { get; set; }
}
