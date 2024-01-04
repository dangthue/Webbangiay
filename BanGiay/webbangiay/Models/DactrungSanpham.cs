using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class DactrungSanpham
{
    public int Madtsp { get; set; }

    public int? Masanpham { get; set; }

    public int? Madactrung { get; set; }

    public string? Mota { get; set; }

    public virtual Dactrung? MadactrungNavigation { get; set; }

    public virtual Sanpham? MasanphamNavigation { get; set; }
}
