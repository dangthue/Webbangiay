using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbangiay.Models;
using X.PagedList;


namespace webbangiay.Controllers
{
    public class HomeController : Controller
    {
        QlbanGiayContext db = new QlbanGiayContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.Sanphams.AsNoTracking().OrderBy(x => x.Tensanpham);
            PagedList<Sanpham> lst = new PagedList<Sanpham>(lstSanPham, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "Mathuonghieu", "Tenthuonghieu");
            ViewBag.Maloaigiay = new SelectList(db.Loaigiays.ToList(), "Maloaigiay", "Tenloaigiay");

            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Sanpham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Sanphams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }




        [Route("danhmucdondat")]
        public IActionResult DanhMucDonDat(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstDonDat = db.Dondats.AsNoTracking().OrderBy(x => x.Thoigian);
            PagedList<Dondat> lst = new PagedList<Dondat>(lstDonDat, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemDonDatMoi")]
        [HttpGet]
        public IActionResult ThemDonDatMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Mataikhoan = new SelectList(db.Taikhoans.ToList(), "Mataikhoan", "Tendangnhap");
            

            return View();
        }
        [Route("ThemDonDatMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemDonDatMoi(Dondat donDat)
        {
            if (ModelState.IsValid)
            {
                db.Dondats.Add(donDat);
                db.SaveChanges();
                return RedirectToAction("DanhMucDonDat");
            }
            return View(donDat);
        }

        [Route("danhmucchitietdd")]
        public IActionResult DanhMucChiTietDD(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstChiTietDD = db.Chitietdds.AsNoTracking().OrderBy(x => x.MachitietDd);
            PagedList<Chitietdd> lst = new PagedList<Chitietdd>(lstChiTietDD, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemChiTietDDMoi")]
        [HttpGet]
        public IActionResult ThemChiTietDDMoi()
        {
            //  ViewBag.Mathuonghieu = new SelectList(db.Thuonghieus.ToList(), "MaTh", "TenTh");
            ViewBag.Masanpham = new SelectList(db.Sanphams.ToList(), "Masanpham", "Tensanpham");
            ViewBag.Madondat = new SelectList(db.Dondats.ToList(), "Madondat", "Mataikhoan","Thoigian");


            return View();
        }
        [Route("ThemChiTietDDMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemChiTietDDMoi(Chitietdd chitietdd)
        {
            if (ModelState.IsValid)
            {
                db.Chitietdds.Add(chitietdd);
                db.SaveChanges();
                return RedirectToAction("DanhMucChiTietDD");
            }
            return View(chitietdd);
        }


    }
}