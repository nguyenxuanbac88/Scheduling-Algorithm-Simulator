# Ứng dụng Mô phỏng Thuật toán Lập lịch

## Giới thiệu

Đây là một ứng dụng Windows Forms viết bằng C# để mô phỏng các thuật toán lập lịch CPU phổ biến:
- **First Come First Serve (FCFS)**
- **Shortest Job First (SJF)**
- **Round Robin (RR)**
- **Priority Scheduling**

Ứng dụng cho phép người dùng nhập thông tin tiến trình, chọn thuật toán lập lịch, và hiển thị kết quả qua sơ đồ Gantt. Ngoài ra, ứng dụng còn tính toán và hiển thị thời gian hoàn thành (Turnaround Time) và thời gian chờ (Waiting Time) cho từng tiến trình.

## Tính năng

- **Bảng nhập tiến trình**: Người dùng có thể nhập ID tiến trình, Thời gian Đến, Thời gian Xử lý và Độ ưu tiên.
- **Quantum Time**: Trường nhập cho thời gian Quantum dùng trong thuật toán Round Robin.
- **Lựa chọn thuật toán**: Bao gồm các thuật toán FCFS, SJF, RR, và Priority.
- **Hiển thị sơ đồ Gantt**: Biểu diễn trực quan thứ tự thực hiện của các tiến trình.
- **Tính thời gian trung bình**: Hiển thị thời gian hoàn thành và thời gian chờ trung bình của tất cả các tiến trình.

## Cài đặt

1. Clone repository này:
   ```bash
   git clone https://github.com/nguyenxuanbac88/Scheduling-Algorithm-Simulator.git
2. Mở dự án trong Visual Studio.
3. Xây dựng (Build) giải pháp để khôi phục các dependency và chuẩn bị cho việc sử dụng ứng dụng.
4. Chọn thuật toán lập lịch bằng cách nhấn vào nút tương ứng.
5. Xem sơ đồ Gantt và các thời gian tính toán trong phần hiển thị kết quả.
