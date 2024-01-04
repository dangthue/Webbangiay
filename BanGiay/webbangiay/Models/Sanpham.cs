using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Sanpham
{
    public int Masanpham { get; set; }

    public string Tensanpham { get; set; } = null!;

    public string? Mota { get; set; }

    public int? Gia { get; set; }

    public int? Mathuonghieu { get; set; }

    public int? Maloaigiay { get; set; }

    public virtual ICollection<Chitietdd> Chitietdds { get; set; } = new List<Chitietdd>();

    public virtual ICollection<Chitietpnk> Chitietpnks { get; set; } = new List<Chitietpnk>();

    public virtual ICollection<Chitietsp> Chitietsps { get; set; } = new List<Chitietsp>();

    public virtual ICollection<DactrungSanpham> DactrungSanphams { get; set; } = new List<DactrungSanpham>();

    public virtual Loaigiay? MaloaigiayNavigation { get; set; }

    public virtual Thuonghieu? MathuonghieuNavigation { get; set; }
}
