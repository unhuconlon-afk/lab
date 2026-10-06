using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lab01_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("============================================================================");
                Console.WriteLine("     TRƯỜNG ĐH SƯ PHẠM TP.HCM - KHOA CÔNG NGHỆ THÔNG TIN                   ");
                Console.WriteLine("          MÔN HỌC: LẬP TRÌNH WINDOWS VỚI C# (WINDOWS PROGRAMMING)          ");
                Console.WriteLine("                    BÁO CÁO LAB 01 - C# CONSOLE APPLICATION                 ");
                Console.WriteLine("          Giảng viên hướng dẫn: ThS. Lương Trần Hy Hiến                     ");
                Console.WriteLine("============================================================================");
                Console.WriteLine("  1. Bài tập 1: Nhập - Xuất cơ bản (Console Input/Output)");
                Console.WriteLine("  2. Bài tập 2: Rẽ nhánh & Giải phương trình bậc 1 (Validation, TryParse)");
                Console.WriteLine("  3. Bài tập 3: Thao tác trên Mảng số nguyên (Tổng, Max, Min, Debug)");
                Console.WriteLine("  4. Bài tập 4: Thao tác trên Chuỗi (Tách họ tên, Chuẩn hóa hoa thường)");
                Console.WriteLine("  0. Thoát chương trình");
                Console.WriteLine("============================================================================");
                Console.Write("Mời bạn chọn bài tập cần thực thi (0 - 4): ");

                string? choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("\nCảm ơn thầy cô và các bạn đã theo dõi!");
                    break;
                }

                string projectFolder = "";
                string projectName = "";
                switch (choice)
                {
                    case "1":
                        projectFolder = "Baitap1";
                        projectName = "Baitap1";
                        break;
                    case "2":
                        projectFolder = "Baitap2";
                        projectName = "Baitap2";
                        break;
                    case "3":
                        projectFolder = "Baitap3";
                        projectName = "Baitap3";
                        break;
                    case "4":
                        projectFolder = "Baitap4";
                        projectName = "Baitap4";
                        break;
                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ. Vui lòng bấm phím bất kỳ để chọn lại...");
                        Console.ReadKey(true);
                        continue;
                }

                ChayDuAn(projectFolder, projectName);
            }
        }

        static void ChayDuAn(string folderName, string projectName)
        {
            Console.WriteLine($"\n>>> Đang khởi chạy {projectName}... <<<\n");

            // Tìm thư mục gốc của Solution
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", ".."));
            string projectPath = Path.Combine(solutionDir, folderName, $"{projectName}.csproj");

            if (!File.Exists(projectPath))
            {
                // Thử đường dẫn tương đối hiện tại
                projectPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, $"{projectName}.csproj");
            }

            if (!File.Exists(projectPath))
            {
                projectPath = Path.Combine(Directory.GetCurrentDirectory(), "..", folderName, $"{projectName}.csproj");
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"run --project \"{projectPath}\"",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            try
            {
                using (Process? process = Process.Start(psi))
                {
                    process?.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể khởi chạy dự án: {ex.Message}");
            }

            Console.WriteLine("\n[Đã hoàn thành phiên chạy]");
            Console.WriteLine("Bấm phím bất kỳ để quay lại menu chính...");
            Console.ReadKey(true);
        }
    }
}
