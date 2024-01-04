using System;
using System.Collections.Generic;

namespace webbangiay.Models;

public partial class Dondat
{
    public int Madondat { get; set; }

    public int? Mataikhoan { get; set; }

    public string Trangthaitt { get; set; } = null!;

    public DateTime? Thoigian { get; set; }

    public virtual ICollection<Chitietdd> Chitietdds { get; set; } = new List<Chitietdd>();

    public virtual Taikhoan? MataikhoanNavigation { get; set; }
}
