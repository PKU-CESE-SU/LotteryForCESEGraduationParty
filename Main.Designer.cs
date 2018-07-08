namespace LotteryForCESEGraduationParty
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.Location = new System.Drawing.Point(0, 0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(161, 78);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "开 始";
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.Location = new System.Drawing.Point(0, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(161, 78);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "退 出";
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(0, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(100, 23);
            this.textLabel.TabIndex = 2;
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(32F, 68F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Font = new System.Drawing.Font("微软雅黑", 39.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label textLabel;
    }
}

