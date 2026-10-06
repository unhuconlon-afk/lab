using System;
using System.Text;

namespace Baitap3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== BÀI TẬP 3: THAO TÁC TRÊN MẢNG SỐ NGUYÊN ===");
            
            // Bước 2: Nhập số lượng phần tử n
            int n = 0;
            while (true)
            {
                Console.Write("Nhap so luong phan tu: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Số lượng phần tử phải là số nguyên dương lớn hơn 0! Vui lòng nhập lại.");
            }

            // Khởi tạo mảng số nguyên
            int[] mang = new int[n];

            // Nhập từng phần tử của mảng
            Console.WriteLine("\n--- Nhập giá trị các phần tử mảng ---");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write("Nhap phan tu " + i.ToString() + ": ");
                    if (int.TryParse(Console.ReadLine(), out mang[i]))
                    {
                        break;
                    }
                    Console.WriteLine("Giá trị không hợp lệ! Vui lòng nhập số nguyên.");
                }
            }

            // Hiển thị mảng vừa nhập
            Console.Write("\nMảng vừa nhập là: [ ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(mang[i] + (i < n - 1 ? ", " : " "));
            }
            Console.WriteLine("]");

            // 1. Tính tổng các phần tử trong mảng
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                tong += mang[i];
            }
            Console.WriteLine("Tong cua mang la: " + tong.ToString());

            // Bước 3: Tìm giá trị lớn nhất (Max) và nhỏ nhất (Min) của mảng (tự thực hiện)
            int max = mang[0];
            int min = mang[0];

            for (int i = 1; i < n; i++)
            {
                if (mang[i] > max)
                {
                    max = mang[i];
                }

                if (mang[i] < min)
                {
                    min = mang[i];
                }
            }

            // Xuất kết quả
            Console.WriteLine("Gia tri lon nhat trong mang la (Max): " + max.ToString());
            Console.WriteLine("Gia tri nho nhat trong mang la (Min): " + min.ToString());

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("\nBấm phím bất kỳ để kết thúc...");
                Console.ReadKey(true);
            }
        }
    }
}
