using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Loaigiay
{
    public int Maloaigiay { get; set; }

    public string Tenloaigiay { get; set; } = null!;

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
