using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Chitietpnk
{
    public int Machitietpnk { get; set; }

    public int? Masanpham { get; set; }

    public int? Maphieunhap { get; set; }

    public int Soluong { get; set; }

    public double? Gianhap { get; set; }

    public double? Tongtien { get; set; }

    public string? Lohang { get; set; }

    public string? Ghichu { get; set; }

    public virtual Phieunhapkho? MaphieunhapNavigation { get; set; }

    public virtual Sanpham? MasanphamNavigation { get; set; }
}
