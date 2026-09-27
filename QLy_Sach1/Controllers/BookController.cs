using Microsoft.AspNetCore.Mvc;
using QLy_Sach1.Models;

namespace QLy_Sach1.Controllers
{
    public class BookController : Controller
    {
        // Danh sách lưu trữ tạm thời trong bộ nhớ
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // Chức năng 1: Danh sách sách (/Book hay /Book/Index)
        public IActionResult Index()
        {
            return View(books);
        }

        // Chức năng 2: Chi tiết sách (/Book/Detail/{id})
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Chức năng 3 & Bài 3: Form thêm sách (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Chức năng 3 & Bài 3: Xử lý submit thêm sách (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            // Kiểm tra Validation từ Model
            if (ModelState.IsValid)
            {
                // Tự động tăng Id
                book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
                books.Add(book);

                // Thông báo thêm thành công
                TempData["SuccessMessage"] = "Thêm sách mới thành công!";

                return RedirectToAction(nameof(Index));
            }

            // Nếu dữ liệu không hợp lệ, trả lại Form cùng các thông báo lỗi
            return View(book);
        }
    }
}