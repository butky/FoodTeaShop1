using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace FoodTeaShop1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            
            return View();
        }

        [ChildActionOnly]
         
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }

        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,    
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

         public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        

        [OutputCache(CacheProfile = "Cache1DayForProduct")]
        public ActionResult Category(long cateId,int page = 1,int pageSize = 6)
        {
            
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId,ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            // Số trang hiển thị tối đa
            int maxPage = 5;
            //Tổng số trang tính ra , mặc định là 0
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1; 

            return View(model);
        }


        [OutputCache(CacheProfile = "Cache1DayForProduct")]
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);

            // Hiển Thị Chi tiết sản phẩm
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);

            // Hiển thị sản phẩm liên quan
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProducts(id);
            // Hiển thị sản phẩm HOT --> chi tiết sản phẩm
            ViewBag.SanPhamHot = new ProductDao().ListSanPhamHot(10);
            return View(product);
        }
    }
}