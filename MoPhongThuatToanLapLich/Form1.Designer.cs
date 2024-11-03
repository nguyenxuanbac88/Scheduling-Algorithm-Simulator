namespace MoPhongThuatToanLapLich
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProcesses = new DataGridView();
            ProcessID = new DataGridViewTextBoxColumn();
            ArrivalTime = new DataGridViewTextBoxColumn();
            BurstTime = new DataGridViewTextBoxColumn();
            Priority = new DataGridViewTextBoxColumn();
            dgvResults = new DataGridView();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtQuantumTime = new TextBox();
            btnRunAlgorithm = new Button();
            cmbAlgorithm = new ComboBox();
            lblAvgTurnaroundTime = new Label();
            lblAvgWaitingTime = new Label();
            ganttPanel = new Panel();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProcesses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProcesses
            // 
            dgvProcesses.BackgroundColor = SystemColors.ControlLightLight;
            dgvProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcesses.Columns.AddRange(new DataGridViewColumn[] { ProcessID, ArrivalTime, BurstTime, Priority });
            dgvProcesses.Location = new Point(12, 72);
            dgvProcesses.Name = "dgvProcesses";
            dgvProcesses.Size = new Size(446, 160);
            dgvProcesses.TabIndex = 0;
            // 
            // ProcessID
            // 
            ProcessID.HeaderText = "Process ID";
            ProcessID.Name = "ProcessID";
            // 
            // ArrivalTime
            // 
            ArrivalTime.HeaderText = "Arrival Time";
            ArrivalTime.Name = "ArrivalTime";
            // 
            // BurstTime
            // 
            BurstTime.HeaderText = "Burst Time";
            BurstTime.Name = "BurstTime";
            // 
            // Priority
            // 
            Priority.HeaderText = "Priority";
            Priority.Name = "Priority";
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.BackgroundColor = SystemColors.ControlLightLight;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(12, 271);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.Size = new Size(535, 187);
            dgvResults.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtQuantumTime);
            groupBox1.Controls.Add(btnRunAlgorithm);
            groupBox1.Controls.Add(cmbAlgorithm);
            groupBox1.Location = new Point(464, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 169);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thao Tác";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 73);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 7;
            label2.Text = "Thuật Toán";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 39);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 6;
            label1.Text = "Quantum Time";
            // 
            // txtQuantumTime
            // 
            txtQuantumTime.Location = new Point(137, 36);
            txtQuantumTime.Name = "txtQuantumTime";
            txtQuantumTime.Size = new Size(132, 23);
            txtQuantumTime.TabIndex = 5;
            // 
            // btnRunAlgorithm
            // 
            btnRunAlgorithm.Location = new Point(110, 123);
            btnRunAlgorithm.Name = "btnRunAlgorithm";
            btnRunAlgorithm.Size = new Size(121, 23);
            btnRunAlgorithm.TabIndex = 2;
            btnRunAlgorithm.Text = "Chạy Thuật Toán";
            btnRunAlgorithm.UseVisualStyleBackColor = true;
            btnRunAlgorithm.Click += btnRunAlgorithm_Click;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Items.AddRange(new object[] { "FCFS", "SJF", "Round Robin", "Priority-Pre" });
            cmbAlgorithm.Location = new Point(137, 65);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(132, 23);
            cmbAlgorithm.TabIndex = 1;
            // 
            // lblAvgTurnaroundTime
            // 
            lblAvgTurnaroundTime.AutoSize = true;
            lblAvgTurnaroundTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvgTurnaroundTime.Location = new Point(553, 298);
            lblAvgTurnaroundTime.Name = "lblAvgTurnaroundTime";
            lblAvgTurnaroundTime.Size = new Size(168, 15);
            lblAvgTurnaroundTime.TabIndex = 3;
            lblAvgTurnaroundTime.Text = "Turnaround Time Trung Bình:";
            // 
            // lblAvgWaitingTime
            // 
            lblAvgWaitingTime.AutoSize = true;
            lblAvgWaitingTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvgWaitingTime.Location = new Point(553, 269);
            lblAvgWaitingTime.Name = "lblAvgWaitingTime";
            lblAvgWaitingTime.Size = new Size(147, 15);
            lblAvgWaitingTime.TabIndex = 4;
            lblAvgWaitingTime.Text = "Waiting Time Trung Bình:";
            // 
            // ganttPanel
            // 
            ganttPanel.BackColor = SystemColors.ControlLightLight;
            ganttPanel.Location = new Point(12, 464);
            ganttPanel.Name = "ganttPanel";
            ganttPanel.Size = new Size(683, 74);
            ganttPanel.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 39);
            label3.Name = "label3";
            label3.Size = new Size(67, 30);
            label3.TabIndex = 6;
            label3.Text = "Input";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 238);
            label4.Name = "label4";
            label4.Size = new Size(84, 30);
            label4.TabIndex = 7;
            label4.Text = "Output";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(780, 562);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(ganttPanel);
            Controls.Add(lblAvgWaitingTime);
            Controls.Add(lblAvgTurnaroundTime);
            Controls.Add(groupBox1);
            Controls.Add(dgvResults);
            Controls.Add(dgvProcesses);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvProcesses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProcesses;
        private DataGridView dgvResults;
        private GroupBox groupBox1;
        private ComboBox cmbAlgorithm;
        private Label lblAvgTurnaroundTime;
        private Label lblAvgWaitingTime;
        private Button btnRunAlgorithm;
        private TextBox txtQuantumTime;
        private Label label2;
        private Label label1;
        private Panel ganttPanel;
        private DataGridViewTextBoxColumn ProcessID;
        private DataGridViewTextBoxColumn ArrivalTime;
        private DataGridViewTextBoxColumn BurstTime;
        private DataGridViewTextBoxColumn Priority;
        private Label label3;
        private Label label4;
    }
}
