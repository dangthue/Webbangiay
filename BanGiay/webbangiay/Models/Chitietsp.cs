using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Chitietsp
{
    public int Machitietsp { get; set; }

    public int? Masanpham { get; set; }

    public string Chitietthu { get; set; } = null!;

    public string? Tinhtrang { get; set; }

    public string? Sodinhdanh { get; set; }

    public int? MachitietDd { get; set; }

    public int? Machitietpnk { get; set; }

    public virtual Sanpham? MasanphamNavigation { get; set; }
}
