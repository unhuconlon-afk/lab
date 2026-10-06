# Windows Programming with C# - Labs

Kho lưu trữ bài tập thực hành môn **Lập trình trên môi trường Windows với C# (Windows Programming with C#)**.

---

## Danh mục bài tập

### 📂 [Lab01_Console](./Lab01_Console)
Thực hành các thao tác cơ bản trên C# Console Application:
- **Bài tập 1 (`Baitap1`)**: Nhập - xuất cơ bản (Console Input/Output).
- **Bài tập 2 (`Baitap2`)**: Rẽ nhánh & Giải phương trình bậc 1 ($ax + b = 0$). Xử lý chống crash dữ liệu với `double.TryParse` và `try-catch`.
- **Bài tập 3 (`Baitap3`)**: Thao tác trên mảng 1 chiều số nguyên (Tính tổng, tìm Max, Min, hướng dẫn Debug với Breakpoint và Watch Window).
- **Bài tập 4 (`Baitap4`)**: Xử lý chuỗi ký tự (Ghép chuỗi, cắt chuỗi bằng `Split`, chuẩn hóa họ tên hoa thường & loại bỏ khoảng trắng thừa, xử lý tổng quát khi không có tên lót).
- **`Lab01_Launcher`**: Menu tổng hợp khởi chạy nhanh từng bài tập.

---

## Hướng dẫn chạy chương trình

### Yêu cầu môi trường
- .NET SDK (phiên bản 8.0 trở lên) hoặc Visual Studio 2022 / 2019 / VS Code.

### Lệnh chạy với .NET CLI
Mở terminal tại thư mục `Lab01_Console` và thực thi:

```bash
# Khởi chạy menu tổng hợp
dotnet run --project Lab01_Launcher/Lab01_Launcher.csproj

# Hoặc chạy trực tiếp từng bài:
dotnet run --project Baitap1/Baitap1.csproj
dotnet run --project Baitap2/Baitap2.csproj
dotnet run --project Baitap3/Baitap3.csproj
dotnet run --project Baitap4/Baitap4.csproj
```
