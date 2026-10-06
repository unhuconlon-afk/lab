using System;
using System.Text;

namespace Baitap2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== BÀI TẬP 2: GIẢI PHƯƠNG TRÌNH BẬC 1 (ax + b = 0) ===");
            Console.WriteLine("Chọn chế độ chạy:");
            Console.WriteLine("1. Chạy theo code mẫu giáo trình (sử dụng double.Parse trực tiếp)");
            Console.WriteLine("2. Chạy phiên bản nâng cao (xử lý lỗi nhập liệu bằng TryParse & try-catch)");
            Console.Write("Lựa chọn của bạn (1 hoặc 2, mặc định 2): ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                ChayTheoGiaoTrinh();
            }
            else
            {
                ChayNangCaoCoKiemLoi();
            }

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("\nBấm phím bất kỳ để kết thúc...");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Code mẫu theo đúng từng dòng trong tài liệu hướng dẫn Lab 01
        /// </summary>
        static void ChayTheoGiaoTrinh()
        {
            Console.WriteLine("\n--- [CHẾ ĐỘ CƠ BẢN THEO GIÁO TRÌNH] ---");
            Console.Write("Nhap tham so a: ");
            double a = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap tham so b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");

            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine("Phuong trinh co vo so nghiem");
                else
                    Console.WriteLine("Phuong trinh vo nghiem");
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("Phuong trinh co nghiem x= " + x.ToString());
            }
        }

        /// <summary>
        /// Phiên bản hoàn thiện trả lời mục Hỏi - Đáp trong giáo trình:
        /// Áp dụng double.TryParse và try...catch để ngăn chặn ứng dụng bị crash khi nhập ký tự sai.
        /// </summary>
        static void ChayNangCaoCoKiemLoi()
        {
            Console.WriteLine("\n--- [CHẾ ĐỘ NÂNG CAO: KIỂM SOÁT NGOẠI LỆ & TRYPARSE] ---");
            
            // Nhập hệ số a có kiểm tra tính hợp lệ bằng TryParse
            double a = NhapSoThuc("Nhập tham số a: ");
            
            // Nhập hệ số b có kiểm tra tính hợp lệ bằng try...catch để minh họa cả 2 giải pháp
            double b = NhapSoThucTryCatch("Nhập tham số b: ");

            Console.WriteLine($"\nPhương trình vừa nhập: {a}x + ({b}) = 0");

            // Biện luận nghiệm phương trình bậc nhất
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("=> Kết luận: Phương trình có vô số nghiệm.");
                }
                else
                {
                    Console.WriteLine("=> Kết luận: Phương trình vô nghiệm.");
                }
            }
            else
            {
                double x = -b / a;
                Console.WriteLine($"=> Kết luận: Phương trình có nghiệm duy nhất x = {x}");
            }
        }

        /// <summary>
        /// Giải pháp 1 (Gợi ý giáo trình): Sử dụng TryParse để bắt lỗi nhập liệu
        /// </summary>
        static double NhapSoThuc(string thongBao)
        {
            double giaTri;
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine();
                if (double.TryParse(input, out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("  [Lỗi]: Giá trị nhập vào không phải là số hợp lệ! Vui lòng nhập lại.");
            }
        }

        /// <summary>
        /// Giải pháp 2 (Gợi ý giáo trình): Sử dụng try...catch để bắt lỗi FormatException / OverflowException
        /// </summary>
        static double NhapSoThucTryCatch(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine();
                try
                {
                    double giaTri = double.Parse(input ?? "");
                    return giaTri;
                }
                catch (FormatException)
                {
                    Console.WriteLine("  [Lỗi try-catch]: Chuỗi nhập vào không đúng định dạng số! Vui lòng nhập lại.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("  [Lỗi try-catch]: Số nhập vào vượt quá giới hạn kiểu double! Vui lòng nhập lại.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  [Lỗi try-catch]: Đã xảy ra lỗi không xác định: {ex.Message}. Vui lòng nhập lại.");
                }
            }
        }
    }
}
