using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webbangiay.Models;

public partial class QlbanGiayContext : DbContext
{
    public QlbanGiayContext()
    {
    }

    public QlbanGiayContext(DbContextOptions<QlbanGiayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdd> Chitietdds { get; set; }

    public virtual DbSet<Chitietpnk> Chitietpnks { get; set; }

    public virtual DbSet<Chitietsp> Chitietsps { get; set; }

    public virtual DbSet<Dactrung> Dactrungs { get; set; }

    public virtual DbSet<DactrungSanpham> DactrungSanphams { get; set; }

    public virtual DbSet<Dondat> Dondats { get; set; }

    public virtual DbSet<Loaidt> Loaidts { get; set; }

    public virtual DbSet<Loaigiay> Loaigiays { get; set; }

    public virtual DbSet<Phieunhapkho> Phieunhapkhos { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LNJIEDL\\SQLEXPRESS;Initial Catalog=QLBanGiay;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdd>(entity =>
        {
            entity.HasKey(e => e.MachitietDd).HasName("PK__CHITIETD__B0D6D2A5266CA5E5");

            entity.ToTable("CHITIETDD");

            entity.HasIndex(e => new { e.Masanpham, e.Madondat }, "ctiet_ddh_unique").IsUnique();

            entity.Property(e => e.MachitietDd).HasColumnName("machitietDD");
            entity.Property(e => e.Madondat).HasColumnName("madondat");
            entity.Property(e => e.Masanpham).HasColumnName("masanpham");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");

            entity.HasOne(d => d.MadondatNavigation).WithMany(p => p.Chitietdds)
                .HasForeignKey(d => d.Madondat)
                .HasConstraintName("FK__CHITIETDD__madon__693CA210");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.Chitietdds)
                .HasForeignKey(d => d.Masanpham)
                .HasConstraintName("FK__CHITIETDD__masan__68487DD7");
        });

        modelBuilder.Entity<Chitietpnk>(entity =>
        {
            entity.HasKey(e => e.Machitietpnk).HasName("PK__CHITIETP__915DA5482C06C5E7");

            entity.ToTable("CHITIETPNK");

            entity.HasIndex(e => new { e.Masanpham, e.Maphieunhap }, "cttiet_pnk_unique").IsUnique();

            entity.Property(e => e.Machitietpnk).HasColumnName("machitietpnk");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("ghichu");
            entity.Property(e => e.Gianhap).HasColumnName("gianhap");
            entity.Property(e => e.Lohang)
                .HasMaxLength(255)
                .HasColumnName("lohang");
            entity.Property(e => e.Maphieunhap).HasColumnName("maphieunhap");
            entity.Property(e => e.Masanpham).HasColumnName("masanpham");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");

            entity.HasOne(d => d.MaphieunhapNavigation).WithMany(p => p.Chitietpnks)
                .HasForeignKey(d => d.Maphieunhap)
                .HasConstraintName("FK__CHITIETPN__maphi__6477ECF3");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.Chitietpnks)
                .HasForeignKey(d => d.Masanpham)
                .HasConstraintName("FK__CHITIETPN__masan__6383C8BA");
        });

        modelBuilder.Entity<Chitietsp>(entity =>
        {
            entity.HasKey(e => e.Machitietsp).HasName("PK__CHITIETS__B0DB54A525898CF8");

            entity.ToTable("CHITIETSP");

            entity.HasIndex(e => new { e.Masanpham, e.Chitietthu }, "chitietsp_unique").IsUnique();

            entity.Property(e => e.Machitietsp).HasColumnName("machitietsp");
            entity.Property(e => e.Chitietthu)
                .HasMaxLength(50)
                .HasColumnName("chitietthu");
            entity.Property(e => e.MachitietDd).HasColumnName("machitietDD");
            entity.Property(e => e.Machitietpnk).HasColumnName("machitietpnk");
            entity.Property(e => e.Masanpham).HasColumnName("masanpham");
            entity.Property(e => e.Sodinhdanh)
                .HasMaxLength(255)
                .HasColumnName("sodinhdanh");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(255)
                .HasColumnName("tinhtrang");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.Chitietsps)
                .HasForeignKey(d => d.Masanpham)
                .HasConstraintName("FK__CHITIETSP__masan__71D1E811");
        });

        modelBuilder.Entity<Dactrung>(entity =>
        {
            entity.HasKey(e => e.Madactrung).HasName("PK__DACTRUNG__8BCA8C3E79E48DB9");

            entity.ToTable("DACTRUNG");

            entity.HasIndex(e => new { e.Maloaidt, e.Thutu }, "dtrung_unique").IsUnique();

            entity.Property(e => e.Madactrung).HasColumnName("madactrung");
            entity.Property(e => e.Donvi)
                .HasMaxLength(50)
                .HasColumnName("donvi");
            entity.Property(e => e.Maloaidt).HasColumnName("maloaidt");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");
            entity.Property(e => e.Thutu).HasColumnName("thutu");

            entity.HasOne(d => d.MaloaidtNavigation).WithMany(p => p.Dactrungs)
                .HasForeignKey(d => d.Maloaidt)
                .HasConstraintName("FK__DACTRUNG__maloai__5FB337D6");
        });

        modelBuilder.Entity<DactrungSanpham>(entity =>
        {
            entity.HasKey(e => e.Madtsp).HasName("PK__DACTRUNG__AB0F5B231312D188");

            entity.ToTable("DACTRUNG_SANPHAM");

            entity.HasIndex(e => new { e.Masanpham, e.Madactrung }, "dtrung_spham_unique").IsUnique();

            entity.Property(e => e.Madtsp).HasColumnName("madtsp");
            entity.Property(e => e.Madactrung).HasColumnName("madactrung");
            entity.Property(e => e.Masanpham).HasColumnName("masanpham");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");

            entity.HasOne(d => d.MadactrungNavigation).WithMany(p => p.DactrungSanphams)
                .HasForeignKey(d => d.Madactrung)
                .HasConstraintName("FK__DACTRUNG___madac__6E01572D");

            entity.HasOne(d => d.MasanphamNavigation).WithMany(p => p.DactrungSanphams)
                .HasForeignKey(d => d.Masanpham)
                .HasConstraintName("FK__DACTRUNG___masan__6D0D32F4");
        });

        modelBuilder.Entity<Dondat>(entity =>
        {
            entity.HasKey(e => e.Madondat).HasName("PK__DONDAT__B7322AB2E3E599AC");

            entity.ToTable("DONDAT");

            entity.HasIndex(e => new { e.Mataikhoan, e.Thoigian }, "dondat_unique").IsUnique();

            entity.Property(e => e.Madondat).HasColumnName("madondat");
            entity.Property(e => e.Mataikhoan).HasColumnName("mataikhoan");
            entity.Property(e => e.Thoigian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
            entity.Property(e => e.Trangthaitt)
                .HasMaxLength(50)
                .HasColumnName("trangthaitt");

            entity.HasOne(d => d.MataikhoanNavigation).WithMany(p => p.Dondats)
                .HasForeignKey(d => d.Mataikhoan)
                .HasConstraintName("FK__DONDAT__mataikho__52593CB8");
        });

        modelBuilder.Entity<Loaidt>(entity =>
        {
            entity.HasKey(e => e.Maloaidt).HasName("PK__LOAIDT__F579942D55417FCC");

            entity.ToTable("LOAIDT");

            entity.Property(e => e.Maloaidt).HasColumnName("maloaidt");
            entity.Property(e => e.Loaidactrung)
                .HasMaxLength(30)
                .HasColumnName("loaidactrung");
        });

        modelBuilder.Entity<Loaigiay>(entity =>
        {
            entity.HasKey(e => e.Maloaigiay).HasName("PK__LOAIGIAY__9FCC427279335DD9");

            entity.ToTable("LOAIGIAY");

            entity.Property(e => e.Maloaigiay).HasColumnName("maloaigiay");
            entity.Property(e => e.Tenloaigiay)
                .HasMaxLength(30)
                .HasColumnName("tenloaigiay");
        });

        modelBuilder.Entity<Phieunhapkho>(entity =>
        {
            entity.HasKey(e => e.Maphieunhapkho).HasName("PK__PHIEUNHA__F72B711A5D55138F");

            entity.ToTable("PHIEUNHAPKHO");

            entity.HasIndex(e => new { e.Mataikhoan, e.Thoigian }, "phieunhap_unique").IsUnique();

            entity.Property(e => e.Maphieunhapkho).HasColumnName("maphieunhapkho");
            entity.Property(e => e.Mataikhoan).HasColumnName("mataikhoan");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");
            entity.Property(e => e.Thoigian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            entity.Property(e => e.Trangthaitt)
                .HasMaxLength(50)
                .HasColumnName("trangthaitt");

            entity.HasOne(d => d.MataikhoanNavigation).WithMany(p => p.Phieunhapkhos)
                .HasForeignKey(d => d.Mataikhoan)
                .HasConstraintName("FK__PHIEUNHAP__matai__571DF1D5");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masanpham).HasName("PK__SANPHAM__8F121B2FF95EC908");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masanpham).HasColumnName("masanpham");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.Maloaigiay).HasColumnName("maloaigiay");
            entity.Property(e => e.Mathuonghieu).HasColumnName("mathuonghieu");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("mota");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(50)
                .HasColumnName("tensanpham");

            entity.HasOne(d => d.MaloaigiayNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Maloaigiay)
                .HasConstraintName("FK__SANPHAM__maloaig__5BE2A6F2");

            entity.HasOne(d => d.MathuonghieuNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Mathuonghieu)
                .HasConstraintName("FK__SANPHAM__mathuon__5AEE82B9");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Mataikhoan).HasName("PK__TAIKHOAN__0477B98C988BC656");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Mataikhoan).HasColumnName("mataikhoan");
            entity.Property(e => e.Loaitaikhoan)
                .HasMaxLength(50)
                .HasColumnName("loaitaikhoan");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.Tendangnhap)
                .HasMaxLength(30)
                .HasColumnName("tendangnhap");
        });

        modelBuilder.Entity<Thuonghieu>(entity =>
        {
            entity.HasKey(e => e.Mathuonghieu).HasName("PK__THUONGHI__125C3AE0FB4C1192");

            entity.ToTable("THUONGHIEU");

            entity.Property(e => e.Mathuonghieu).HasColumnName("mathuonghieu");
            entity.Property(e => e.Tenthuonghieu)
                .HasMaxLength(30)
                .HasColumnName("tenthuonghieu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
