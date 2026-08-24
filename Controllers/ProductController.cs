using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using _241230812_NguyenThiNhung_BTThucHanh_BTVN.Models;

namespace _241230812_NguyenThiNhung_BTThucHanh_BTVN.Controllers
{
    public class ProductController : Controller
    {
        // 1. Tạo dữ liệu mẫu Danh mục
        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần Áo" }, // Khớp với ảnh mẫu
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" },
                new Category { Id = 7, Name = "Quạt điện" },
                new Category { Id = 8, Name = "Lò sưởi" }
            };
        }

        // 2. Tạo dữ liệu mẫu Sản phẩm
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", Price = 50000, SalePrice = 35000, CategoryId = 1, Image = Url.Content("/images/anh5.png"), Description = "Chất liệu cao cấp, co giãn tốt.", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", Price = 50000, SalePrice = 35000, CategoryId = 1, Image = Url.Content("/images/anh6.png"), Description = "Màu sắc tươi sáng, an toàn cho bé.", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", Price = 50000, SalePrice = 35000, CategoryId = 1, Image = Url.Content("/images/anh7.png"), Description = "Thiết kế sang trọng, hiện đại.", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", Price = 50000, SalePrice = 35000, CategoryId = 1, Image = Url.Content("/images/anh8.png"), Description = "Chất liệu an toàn.", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = 5, Name = "Túi thời trang mẫu mới 2021", Price = 50000, SalePrice = 35000, CategoryId = 2, Image = Url.Content("/images/anh9.png"), Description = "Mô tả sản phẩm 5", Status = true, CreatedAt = DateTime.Now },
                new Product { Id = 6, Name = "Túi thời trang da cá sấu", Price = 50000, SalePrice = 35000, CategoryId = 2, Image = Url.Content("/images/anh10.png"), Description = "Mô tả sản phẩm 6", Status = true, CreatedAt = DateTime.Now }
            };
        }

        // 3. Trang danh sách (Có xử lý lọc theo CategoryId)
        [Route("san-pham", Name = "product")]
        public IActionResult Index(int? categoryId)
        {
            var categories = GetCategories();
            var products = GetProducts();

            // Nếu người dùng click vào danh mục bên trái, ta sẽ lọc sản phẩm
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            // Gửi cả Danh mục và Sản phẩm sang View
            ViewBag.Categories = categories;
            return View(products);
        }

        // 4. Trang chi tiết
        [Route("chi-tiet-san-pham", Name = "product_detail")]
        public IActionResult Detail(int id)
        {
            var product = GetProducts().FirstOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}