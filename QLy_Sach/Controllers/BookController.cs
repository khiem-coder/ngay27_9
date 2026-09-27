using Microsoft.AspNetCore.Mvc;
using QLy_Sach.Models;

namespace QLy_Sach.Controllers
{
    public class BookController : Controller
    {
        // Danh sách lưu tạm dữ liệu sách trong bộ nhớ
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // Chức năng 1: Danh sách sách (/Book/Index)
        public IActionResult Index()
        {
            return View(books);
        }

        // Chức năng 2: Chi tiết sách (/Book/Detail/1)
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Không tìm thấy sách!");
            }
            return View(book);
        }

        // Chức năng 3: Form thêm sách (GET: /Book/Create)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Chức năng 3: Xử lý thêm sách sau khi Submit (POST: /Book/Create)
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            if (ModelState.IsValid)
            {
                // Tự động sinh Id kế tiếp
                newBook.Id = books.Max(b => b.Id) + 1;
                books.Add(newBook);

                // Lưu thông báo thành công vào TempData để hiển thị ở trang Danh sách
                TempData["SuccessMessage"] = "Thêm sách mới thành công!";

                return RedirectToAction("Index");
            }
            return View(newBook);
        }
    }
}