using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Chitietdd
{
    public int MachitietDd { get; set; }

    public int? Masanpham { get; set; }

    public int? Madondat { get; set; }

    public int? Soluong { get; set; }

    public double? Tongtien { get; set; }

    public virtual Dondat? MadondatNavigation { get; set; }

    public virtual Sanpham? MasanphamNavigation { get; set; }
}
