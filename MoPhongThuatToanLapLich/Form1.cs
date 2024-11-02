using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MoPhongThuatToanLapLich
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dgvProcesses.CellValidating += new DataGridViewCellValidatingEventHandler(dgvProcesses_CellValidating);
            dgvProcesses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            SetupDataGridView();
            SetupResultsDataGridView();
            dgvProcesses.BorderStyle = BorderStyle.None;
            lblAvgTurnaroundTime.Text = "Turnaround Time Trung Bình: N/A";
            lblAvgWaitingTime.Text = "Waiting Time Trung Bình: N/A";
            lblAvgWaitingTime.Text = "Waiting Time Trung Bình: N/A";
        }

        private void SetupDataGridView()
        {
            // Xóa các cột hiện có nếu có
            dgvProcesses.Columns.Clear();
            // Thêm các cột cần thiết
            dgvProcesses.Columns.Add("ProcessID", "Process ID");
            dgvProcesses.Columns.Add("ArrivalTime", "Arrival Time");
            dgvProcesses.Columns.Add("BurstTime", "Burst Time");
            dgvProcesses.Columns.Add("Priority", "Priority");

            // Đặt chiều rộng và cho phép thay đổi kích thước cột
            dgvProcesses.Columns["ProcessID"].Width = 70;
            dgvProcesses.Columns["ArrivalTime"].Width = 100;
            dgvProcesses.Columns["BurstTime"].Width = 90;
            dgvProcesses.Columns["Priority"].Width = 120;

            // Cho phép người dùng thay đổi kích thước cột
            dgvProcesses.AllowUserToResizeColumns = true;
        }

        private void SetupResultsDataGridView()
        {
            dgvResults.Columns.Clear(); // Xóa các cột nếu có trước đó

            dgvResults.Columns.Add("ProcessID", "Process ID");
            dgvResults.Columns.Add("StartTime", "Start Time"); // Thêm cột Start Time
            dgvResults.Columns.Add("CompletionTime", "Completion Time");
            dgvResults.Columns.Add("TurnaroundTime", "Turnaround Time");
            dgvResults.Columns.Add("WaitingTime", "Waiting Time");

            // Đặt `ReadOnly` và `AllowUserToAddRows` để ngăn chỉnh sửa
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
        }

        private void dgvProcesses_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Chỉ kiểm tra các cột số nguyên như ArrivalTime, BurstTime, Priority
            if ( dgvProcesses.Columns[e.ColumnIndex].Name == "ArrivalTime" ||
                dgvProcesses.Columns[e.ColumnIndex].Name == "BurstTime" ||
                dgvProcesses.Columns[e.ColumnIndex].Name == "Priority")
            {
                // Nếu giá trị là null hoặc chuỗi rỗng thì gán giá trị mặc định là 0
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgvProcesses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
                else if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    e.Cancel = true;
                    dgvProcesses.Rows[e.RowIndex].ErrorText = "Chỉ nhập số nguyên!";
                }
                else
                {
                    dgvProcesses.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }


        private List<Process> GetProcessesFromDataGridView()
        {
            List<Process> processes = new List<Process>();

            foreach (DataGridViewRow row in dgvProcesses.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng trống

                Process process = new Process
                {
                    ProcessID = row.Cells["ProcessID"].Value.ToString(), // Lấy ProcessID dưới dạng chuỗi
                    ArrivalTime = Convert.ToInt32(row.Cells["ArrivalTime"].Value),
                    BurstTime = Convert.ToInt32(row.Cells["BurstTime"].Value),
                    Priority = row.Cells["Priority"].Value != null ? Convert.ToInt32(row.Cells["Priority"].Value) : 0
                };
                processes.Add(process);
            }

            return processes;
        }


        public void FCFS(List<Process> processes)
        {
            processes = processes.OrderBy(p => p.ArrivalTime).ToList();
            int currentTime = 0;

            foreach (var process in processes)
            {
                if (currentTime < process.ArrivalTime)
                    currentTime = process.ArrivalTime;

                process.StartTime = currentTime;  // Gán thời gian bắt đầu cho tiến trình
                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;

                currentTime += process.BurstTime;
            }
        }

        public void SJF(List<Process> processes)
        {
            processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.BurstTime).ToList();
            int currentTime = 0;

            foreach (var process in processes)
            {
                if (currentTime < process.ArrivalTime)
                    currentTime = process.ArrivalTime;

                process.StartTime = currentTime;  // Gán thời gian bắt đầu cho tiến trình
                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;

                currentTime += process.BurstTime;
            }
        }

        public void RoundRobin(List<Process> processes, int quantumTime)
        {
            int currentTime = 0; // Thời gian hiện tại của hệ thống
            Queue<Process> queue = new Queue<Process>(); // Hàng đợi để quản lý các tiến trình
            List<Process> remainingProcesses = new List<Process>(processes); // Danh sách tiến trình chưa hoàn thành

            // Khởi tạo RemainingTime cho mỗi tiến trình
            foreach (var process in processes)
            {
                process.RemainingTime = process.BurstTime; // Đặt RemainingTime ban đầu bằng BurstTime
                process.StartTime = -1; // Khởi tạo StartTime là -1 để xác định lần đầu tiến trình chạy
            }

            // Thêm các tiến trình đã đến vào hàng đợi ban đầu
            foreach (var process in remainingProcesses.Where(p => p.ArrivalTime <= currentTime).ToList())
            {
                queue.Enqueue(process);
                remainingProcesses.Remove(process);
            }

            while (queue.Count > 0)
            {
                // Lấy tiến trình đầu tiên trong hàng đợi để thực thi
                var process = queue.Dequeue();

                // Chỉ gán StartTime nếu đây là lần đầu tiên tiến trình được thực thi
                if (process.StartTime == -1)
                {
                    process.StartTime = currentTime;
                }

                // Tiến hành thực thi tiến trình trong khoảng thời gian Quantum hoặc ít hơn nếu gần hoàn thành
                int timeSlice = Math.Min(quantumTime, process.RemainingTime);
                process.RemainingTime -= timeSlice;
                currentTime += timeSlice;

                // Kiểm tra xem tiến trình đã hoàn thành chưa
                if (process.RemainingTime == 0)
                {
                    process.CompletionTime = currentTime;
                    process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                    process.WaitingTime = process.TurnaroundTime - process.BurstTime;
                }
                else
                {
                    // Nếu tiến trình chưa hoàn thành, đưa nó lại vào hàng đợi
                    queue.Enqueue(process);
                }

                // Thêm các tiến trình mới đến hàng đợi nếu Arrival Time <= currentTime
                foreach (var arrivingProcess in remainingProcesses.Where(p => p.ArrivalTime <= currentTime).ToList())
                {
                    queue.Enqueue(arrivingProcess);
                    remainingProcesses.Remove(arrivingProcess);
                }

                // Nếu hàng đợi trống và còn tiến trình chưa đến, cập nhật currentTime để xử lý tiếp
                if (queue.Count == 0 && remainingProcesses.Count > 0)
                {
                    currentTime = remainingProcesses.Min(p => p.ArrivalTime);
                    foreach (var processToAdd in remainingProcesses.Where(p => p.ArrivalTime <= currentTime).ToList())
                    {
                        queue.Enqueue(processToAdd);
                        remainingProcesses.Remove(processToAdd);
                    }
                }
            }
        }




        private void DisplayResults(List<Process> processes)
        {
            dgvResults.Rows.Clear(); // Xóa dữ liệu cũ trong `dgvResults`

            foreach (var process in processes)
            {
                dgvResults.Rows.Add(
                    process.ProcessID,
                    process.StartTime,
                    process.CompletionTime,
                    process.TurnaroundTime,
                    process.WaitingTime
                );
            }
        }

        private void CalculateAverageTimes(List<Process> processes)
        {
            if (processes == null || processes.Count == 0)
            {
                MessageBox.Show("Không có tiến trình nào để tính toán thời gian trung bình.");
                return;
            }

            double avgTurnaroundTime = processes.Average(p => p.TurnaroundTime);
            double avgWaitingTime = processes.Average(p => p.WaitingTime);

            lblAvgTurnaroundTime.Text = $"Turnaround Time Trung Bình: {avgTurnaroundTime:F2}";
            lblAvgWaitingTime.Text = $"Waiting Time Trung Bình: {avgWaitingTime:F2}";
        }
        public void PriorityScheduling(List<Process> processes)
        {
            // Danh sách lưu các tiến trình đã hoàn thành
            List<Process> completedProcesses = new List<Process>();
            int currentTime = 0;

            // Sử dụng danh sách tạm thời cho các tiến trình còn lại
            List<Process> availableProcesses = new List<Process>(processes);

            while (availableProcesses.Count > 0)
            {
                // Lọc các tiến trình có ArrivalTime <= currentTime
                var readyQueue = availableProcesses.Where(p => p.ArrivalTime <= currentTime).OrderBy(p => p.Priority).ToList();

                if (readyQueue.Count == 0)
                {
                    // Nếu không có tiến trình sẵn sàng, tăng currentTime lên theo tiến trình có ArrivalTime sớm nhất
                    currentTime = availableProcesses.Min(p => p.ArrivalTime);
                    continue;
                }

                // Lấy tiến trình có Priority cao nhất (Priority nhỏ nhất) trong readyQueue
                var process = readyQueue.First();

                // Cập nhật thời gian bắt đầu, hoàn thành, turnaround và waiting cho tiến trình
                process.StartTime = currentTime;
                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;

                // Thêm tiến trình vào danh sách đã hoàn thành và xóa khỏi availableProcesses
                completedProcesses.Add(process);
                availableProcesses.Remove(process);

                // Cập nhật thời gian hiện tại
                currentTime = process.CompletionTime;
            }

            // Sao chép các tiến trình hoàn thành trở lại vào danh sách processes để hiển thị kết quả
            processes.Clear();
            processes.AddRange(completedProcesses);
        }

        private void DrawGanttChart(List<Process> processes)
        {
            ganttPanel.Controls.Clear(); // Xóa nội dung cũ trong Panel

            int xPosition = 10; // Vị trí x bắt đầu vẽ, có khoảng cách nhỏ ở cạnh trái
            foreach (var process in processes)
            {
                int width = (process.CompletionTime - process.StartTime) * 20; // Tỉ lệ để chuyển thời gian thành chiều rộng

                // Tạo một Label đại diện cho tiến trình trong sơ đồ Gantt
                Label ganttLabel = new Label
                {
                    Text = process.ProcessID,
                    Width = width,
                    Height = 30,
                    Location = new Point(xPosition, 10),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightBlue // Đặt màu cho nhãn đại diện tiến trình
                };

                // Thêm Label vào Panel
                ganttPanel.Controls.Add(ganttLabel);

                // Thêm một Label nhỏ ở phía dưới để hiển thị thời gian bắt đầu và kết thúc
                Label timeLabel = new Label
                {
                    Text = $"{process.StartTime} - {process.CompletionTime}",
                    Width = width,
                    Height = 15,
                    Location = new Point(xPosition, 45),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                ganttPanel.Controls.Add(timeLabel);

                // Di chuyển vị trí x cho tiến trình tiếp theo
                xPosition += width;
            }
        }
        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            var processes = GetProcessesFromDataGridView();

            if (cmbAlgorithm.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một thuật toán.");
                return;
            }

            switch (cmbAlgorithm.SelectedItem.ToString())
            {
                case "FCFS":
                    FCFS(processes);
                    break;
                case "SJF":
                    SJF(processes);
                    break;
                case "Round Robin":
                    if (!int.TryParse(txtQuantumTime.Text, out int quantumTime) || quantumTime <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập giá trị Quantum Time hợp lệ.");
                        return;
                    }
                    RoundRobin(processes, quantumTime);
                    break;
                case "Priority":
                    PriorityScheduling(processes);
                    break;
                default:
                    MessageBox.Show("Thuật toán không hợp lệ.");
                    return;
            }

            DisplayResults(processes);
            CalculateAverageTimes(processes);
            DrawGanttChart(processes); 
        }

        public class Process
        {
            public string ProcessID { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int CompletionTime { get; set; }
            public int TurnaroundTime { get; set; }
            public int WaitingTime { get; set; }
            public int StartTime { get; set; } = -1;    // Thời gian bắt đầu của tiến trình
            public int Priority { get; set; }     // Chỉ dùng cho Priority Scheduling
            public int RemainingTime { get; set; }  // Thời gian còn lại
            public Process()
            {
                RemainingTime = BurstTime;  // Khởi tạo RemainingTime bằng BurstTime
            }
        }
    }
}
