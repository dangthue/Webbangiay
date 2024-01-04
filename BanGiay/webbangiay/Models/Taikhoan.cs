using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Taikhoan
{
    public int Mataikhoan { get; set; }

    public string Tendangnhap { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string Loaitaikhoan { get; set; } = null!;

    public int? Sdt { get; set; }

    public virtual ICollection<Dondat> Dondats { get; set; } = new List<Dondat>();

    public virtual ICollection<Phieunhapkho> Phieunhapkhos { get; set; } = new List<Phieunhapkho>();
}
