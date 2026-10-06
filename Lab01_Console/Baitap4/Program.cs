using System;
using System.Text;

namespace Baitap4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                if (!Console.IsInputRedirected)
                {
                    Console.Clear();
                }
                Console.WriteLine("==============================================================");
                Console.WriteLine("                BÀI TẬP 4: THAO TÁC TRÊN CHUỖI               ");
                Console.WriteLine("==============================================================");
                Console.WriteLine("1. Phần 1: Nhập họ, tên lót, tên -> Xuất họ tên đầy đủ");
                Console.WriteLine("2. Phần 2: Nhập họ tên đầy đủ -> Cắt tách họ, tên lót, tên");
                Console.WriteLine("3. Phần 3: Chuẩn hóa họ tên (loại bỏ khoảng trắng thừa, viết hoa)");
                Console.WriteLine("4. Phần Nâng Cao: Xử lý tổng quát khi KHÔNG CÓ tên lót hoặc tên dài");
                Console.WriteLine("5. Chạy tuần tự tất cả các bài");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("--------------------------------------------------------------");
                Console.Write("Mời bạn chọn chức năng (0-5): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(choice) || choice == "0")
                {
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Bai4_Phan1();
                        DungManHinh();
                        break;
                    case "2":
                        Bai4_Phan2();
                        DungManHinh();
                        break;
                    case "3":
                        Bai4_Phan3();
                        DungManHinh();
                        break;
                    case "4":
                        Bai4_NangCaoXuLyKhongTenLot();
                        DungManHinh();
                        break;
                    case "5":
                        Bai4_Phan1();
                        Console.WriteLine("\n--------------------------------------------------\n");
                        Bai4_Phan2();
                        Console.WriteLine("\n--------------------------------------------------\n");
                        Bai4_Phan3();
                        Console.WriteLine("\n--------------------------------------------------\n");
                        Bai4_NangCaoXuLyKhongTenLot();
                        DungManHinh();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại!");
                        DungManHinh();
                        break;
                }

                if (Console.IsInputRedirected)
                {
                    break;
                }
            }
        }

        static void DungManHinh()
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("\nBấm phím bất kỳ để tiếp tục...");
                Console.ReadKey(true);
            }
        }

        #region Bài 4.1
        /// <summary>
        /// 1. Viết chương trình nhập họ, tên lót, tên. Xuất ra tên đầy đủ.
        /// </summary>
        static void Bai4_Phan1()
        {
            Console.WriteLine(">>> 4.1. NHẬP HỌ, TÊN LÓT, TÊN -> XUẤT HỌ TÊN ĐẦY ĐỦ <<<");

            Console.Write("Nhap ho: ");
            string ho = Console.ReadLine() ?? "";

            Console.Write("Nhap ten lot: ");
            string tenlot = Console.ReadLine() ?? "";

            Console.Write("Nhap ten: ");
            string ten = Console.ReadLine() ?? "";

            Console.WriteLine("Ho va ten day du: {0} {1} {2}", ho, tenlot, ten);
        }
        #endregion

        #region Bài 4.2
        /// <summary>
        /// 2. Viết chương trình nhập vào họ tên đầy đủ. Xuất ra từng phần gồm họ, tên lót, tên.
        /// </summary>
        static void Bai4_Phan2()
        {
            Console.WriteLine(">>> 4.2. NHẬP HỌ TÊN ĐẦY ĐỦ -> XUẤT RA TỪNG PHẦN GỒM HỌ, TÊN LÓT, TÊN <<<");

            Console.Write("Nhap ho ten: ");
            string fullname = Console.ReadLine() ?? "";

            string SPACE = " ";
            string[] parts = fullname.Split(new string[] { SPACE }, StringSplitOptions.None);

            if (parts.Length >= 3)
            {
                Console.WriteLine("Ho: {0}, ten lot: {1}, ten: {2}", parts[0], parts[1], parts[2]);
            }
            else
            {
                Console.WriteLine("Lưu ý: Chuỗi nhập vào ít hơn 3 từ ({0} từ).", parts.Length);
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.WriteLine("Phần [{0}]: {1}", i, parts[i]);
                }
            }
        }
        #endregion

        #region Bài 4.3
        /// <summary>
        /// 3. Viết chương trình nhập vào họ tên hoa thường không đúng qui tắc, khoảng trắng không đúng.
        /// Xuất ra màn hình họ tên theo dạng chuẩn.
        /// </summary>
        static void Bai4_Phan3()
        {
            Console.WriteLine(">>> 4.3. CHUẨN HÓA HỌ TÊN HOA THƯỜNG VÀ KHOẢNG TRẮNG <<<");

            Console.Write("Nhap ho ten (khong can theo chuan): ");
            string fullname = Console.ReadLine() ?? "";

            string SEPERATOR = " ";

            // Tách từ dựa vào khoảng trắng, loại bỏ các giá trị rỗng do khoảng trắng thừa
            string[] parts = fullname.Split(new string[] { SEPERATOR }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                Console.WriteLine("Bạn chưa nhập họ tên!");
                return;
            }

            if (parts.Length >= 3)
            {
                string ho = ChuanHoaTu(parts[0]);
                string tenlot = ChuanHoaTu(parts[1]);
                string ten = ChuanHoaTu(parts[2]);

                Console.WriteLine("Ten theo dung chuan la: {0} {1} {2}", ho, tenlot, ten);
            }
            else
            {
                // Nếu ít hơn 3 từ, chuẩn hóa từng từ rồi ghép lại
                Console.WriteLine("Chuỗi nhập ít hơn 3 từ. Chuẩn hóa tất cả các từ:");
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = ChuanHoaTu(parts[i]);
                }
                Console.WriteLine("Ten theo dung chuan la: " + string.Join(" ", parts));
            }
        }

        /// <summary>
        /// Hàm viết hoa chữ cái đầu và viết thường phần còn lại
        /// </summary>
        static string ChuanHoaTu(string tu)
        {
            if (string.IsNullOrEmpty(tu)) return tu;
            if (tu.Length == 1) return tu.ToUpper();
            return tu.Substring(0, 1).ToUpper() + tu.Substring(1, tu.Length - 1).ToLower();
        }
        #endregion

        #region Bài 4 Nâng Cao (Giải đáp câu hỏi gợi ý)
        /// <summary>
        /// Giải pháp toàn diện cho câu hỏi gợi ý suy nghĩ:
        /// - Xử lý trường hợp không có tên lót (chỉ có 2 từ như "Nguyễn An")
        /// - Xử lý trường hợp chỉ có 1 từ ("Nam")
        /// - Xử lý trường hợp tên lót có nhiều từ ("Nguyễn Thị Ngọc Anh")
        /// </summary>
        static void Bai4_NangCaoXuLyKhongTenLot()
        {
            Console.WriteLine(">>> 4.4. GIẢI QUYẾT CÂU HỎI GỢI Ý: XỬ LÝ KHI KHÔNG CÓ TÊN LÓT HOẶC TÊN DÀI <<<");

            Console.Write("Nhap ho ten bat ky (vi du: 'nguyen   an' hoac 'tran  thi  mai  huong'): ");
            string fullname = Console.ReadLine() ?? "";

            string[] rawParts = fullname.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (rawParts.Length == 0)
            {
                Console.WriteLine("Chuỗi họ tên rỗng!");
                return;
            }

            // Chuẩn hóa từng từ
            string[] parts = new string[rawParts.Length];
            for (int i = 0; i < rawParts.Length; i++)
            {
                parts[i] = ChuanHoaTu(rawParts[i]);
            }

            string ho = "";
            string tenLot = "";
            string ten = "";

            if (parts.Length == 1)
            {
                // Chỉ có 1 từ: coi là Tên (hoặc Họ)
                ten = parts[0];
                ho = "(Khong co)";
                tenLot = "(Khong co)";
            }
            else if (parts.Length == 2)
            {
                // Không có tên lót: từ đầu là Họ, từ cuối là Tên
                ho = parts[0];
                ten = parts[1];
                tenLot = "(Khong co ten lot)";
            }
            else
            {
                // Có 3 từ trở lên:
                // Họ: từ đầu tiên
                ho = parts[0];
                // Tên: từ cuối cùng
                ten = parts[parts.Length - 1];
                // Tên lót: tất cả các từ nằm giữa Họ và Tên
                string[] lotArray = new string[parts.Length - 2];
                Array.Copy(parts, 1, lotArray, 0, parts.Length - 2);
                tenLot = string.Join(" ", lotArray);
            }

            Console.WriteLine("\n=== KẾT QUẢ PHÂN TÍCH VÀ CHUẨN HÓA ===");
            Console.WriteLine("1. Họ:       " + ho);
            Console.WriteLine("2. Tên lót:  " + tenLot);
            Console.WriteLine("3. Tên:      " + ten);
            Console.WriteLine("=> Họ và tên chuẩn hoàn chỉnh: " + string.Join(" ", parts));
        }
        #endregion
    }
}
