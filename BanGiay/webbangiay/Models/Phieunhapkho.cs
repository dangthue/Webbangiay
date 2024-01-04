using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Phieunhapkho
{
    public int Maphieunhapkho { get; set; }

    public int? Mataikhoan { get; set; }

    public string Trangthaitt { get; set; } = null!;

    public DateTime? Thoigian { get; set; }

    public double? Tongtien { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Chitietpnk> Chitietpnks { get; set; } = new List<Chitietpnk>();

    public virtual Taikhoan? MataikhoanNavigation { get; set; }
}
