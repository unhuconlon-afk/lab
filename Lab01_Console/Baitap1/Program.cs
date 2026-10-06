using System;
using System.Text;

namespace Baitap1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font/encoding hiển thị tiếng Việt trên màn hình console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== BÀI TẬP 1: NHẬP - XUẤT CƠ BẢN ===");
            Console.Write("Nhap vao ten ban: ");
            string? ten = Console.ReadLine();

            Console.WriteLine("Xin chao " + ten);

            // Tự động dừng màn hình nếu chạy trên cửa sổ Console thực tế
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("\nBấm phím bất kỳ để kết thúc...");
                Console.ReadKey(true);
            }
        }
    }
}
