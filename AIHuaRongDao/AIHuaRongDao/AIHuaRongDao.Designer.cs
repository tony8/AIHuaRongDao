namespace AIHuaRongDao
{
    partial class AIHuaRongDao
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGuanyu = new System.Windows.Forms.Panel();
            this.panelS4 = new System.Windows.Forms.Panel();
            this.panelS3 = new System.Windows.Forms.Panel();
            this.panelS1 = new System.Windows.Forms.Panel();
            this.panelS2 = new System.Windows.Forms.Panel();
            this.panelHuangzhong = new System.Windows.Forms.Panel();
            this.panelMachao = new System.Windows.Forms.Panel();
            this.panelzhangfei = new System.Windows.Forms.Panel();
            this.panelZhaoyun = new System.Windows.Forms.Panel();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxtimeShow = new System.Windows.Forms.TextBox();
            this.lblTimeshow = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtShowCount = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblSearchCount = new System.Windows.Forms.Label();
            this.panelChaoC = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGuanyu
            // 
            this.panelGuanyu.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B2;
            this.panelGuanyu.Location = new System.Drawing.Point(110, 250);
            this.panelGuanyu.Name = "panelGuanyu";
            this.panelGuanyu.Size = new System.Drawing.Size(200, 100);
            this.panelGuanyu.TabIndex = 9;
            // 
            // panelS4
            // 
            this.panelS4.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B10;
            this.panelS4.Location = new System.Drawing.Point(310, 450);
            this.panelS4.Name = "panelS4";
            this.panelS4.Size = new System.Drawing.Size(100, 100);
            this.panelS4.TabIndex = 7;
            // 
            // panelS3
            // 
            this.panelS3.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B9;
            this.panelS3.Location = new System.Drawing.Point(10, 450);
            this.panelS3.Name = "panelS3";
            this.panelS3.Size = new System.Drawing.Size(100, 100);
            this.panelS3.TabIndex = 6;
            // 
            // panelS1
            // 
            this.panelS1.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B7;
            this.panelS1.Location = new System.Drawing.Point(110, 350);
            this.panelS1.Name = "panelS1";
            this.panelS1.Size = new System.Drawing.Size(100, 100);
            this.panelS1.TabIndex = 5;
            // 
            // panelS2
            // 
            this.panelS2.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B8;
            this.panelS2.Location = new System.Drawing.Point(210, 350);
            this.panelS2.Name = "panelS2";
            this.panelS2.Size = new System.Drawing.Size(100, 100);
            this.panelS2.TabIndex = 3;
            // 
            // panelHuangzhong
            // 
            this.panelHuangzhong.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B6;
            this.panelHuangzhong.Location = new System.Drawing.Point(310, 250);
            this.panelHuangzhong.Name = "panelHuangzhong";
            this.panelHuangzhong.Size = new System.Drawing.Size(100, 200);
            this.panelHuangzhong.TabIndex = 2;
            // 
            // panelMachao
            // 
            this.panelMachao.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B5;
            this.panelMachao.Location = new System.Drawing.Point(10, 250);
            this.panelMachao.Name = "panelMachao";
            this.panelMachao.Size = new System.Drawing.Size(100, 200);
            this.panelMachao.TabIndex = 2;
            // 
            // panelzhangfei
            // 
            this.panelzhangfei.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B4;
            this.panelzhangfei.Location = new System.Drawing.Point(310, 50);
            this.panelzhangfei.Name = "panelzhangfei";
            this.panelzhangfei.Size = new System.Drawing.Size(100, 200);
            this.panelzhangfei.TabIndex = 2;
            // 
            // panelZhaoyun
            // 
            this.panelZhaoyun.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B3;
            this.panelZhaoyun.Location = new System.Drawing.Point(10, 50);
            this.panelZhaoyun.Name = "panelZhaoyun";
            this.panelZhaoyun.Size = new System.Drawing.Size(100, 200);
            this.panelZhaoyun.TabIndex = 1;
            // 
            // btnBFS
            // 
            this.btnBFS.Location = new System.Drawing.Point(12, 12);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(95, 25);
            this.btnBFS.TabIndex = 11;
            this.btnBFS.Text = "广度优先搜索";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.Location = new System.Drawing.Point(247, 12);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(102, 25);
            this.btnDFS.TabIndex = 12;
            this.btnDFS.Text = "深度优先搜索";
            this.btnDFS.UseVisualStyleBackColor = true;
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(129, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 25);
            this.button3.TabIndex = 13;
            this.button3.Text = "启发式搜索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxtimeShow);
            this.groupBox1.Controls.Add(this.lblTimeshow);
            this.groupBox1.Controls.Add(this.btnMove);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.txtShowCount);
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Controls.Add(this.lblSearchCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 94);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结果展示";
            // 
            // textBoxtimeShow
            // 
            this.textBoxtimeShow.Location = new System.Drawing.Point(262, 59);
            this.textBoxtimeShow.Name = "textBoxtimeShow";
            this.textBoxtimeShow.Size = new System.Drawing.Size(86, 21);
            this.textBoxtimeShow.TabIndex = 17;
            // 
            // lblTimeshow
            // 
            this.lblTimeshow.AutoSize = true;
            this.lblTimeshow.Location = new System.Drawing.Point(185, 60);
            this.lblTimeshow.Name = "lblTimeshow";
            this.lblTimeshow.Size = new System.Drawing.Size(53, 12);
            this.lblTimeshow.TabIndex = 16;
            this.lblTimeshow.Text = "总耗时：";
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(182, 21);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(76, 28);
            this.btnMove.TabIndex = 15;
            this.btnMove.Text = "开始移动";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(76, 56);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(85, 21);
            this.txtPath.TabIndex = 14;
            // 
            // txtShowCount
            // 
            this.txtShowCount.Location = new System.Drawing.Point(76, 21);
            this.txtShowCount.Name = "txtShowCount";
            this.txtShowCount.Size = new System.Drawing.Size(85, 21);
            this.txtShowCount.TabIndex = 13;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(17, 61);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(53, 12);
            this.lblPath.TabIndex = 12;
            this.lblPath.Text = "路径长度";
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.AutoSize = true;
            this.lblSearchCount.Location = new System.Drawing.Point(15, 27);
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(53, 12);
            this.lblSearchCount.TabIndex = 11;
            this.lblSearchCount.Text = "搜索次数";
            // 
            // panelChaoC
            // 
            this.panelChaoC.BackgroundImage = global::AIHuaRongDao.Properties.Resources.B1;
            this.panelChaoC.Location = new System.Drawing.Point(110, 50);
            this.panelChaoC.Name = "panelChaoC";
            this.panelChaoC.Size = new System.Drawing.Size(200, 200);
            this.panelChaoC.TabIndex = 15;
            // 
            // AIHuaRongDao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 664);
            this.Controls.Add(this.panelChaoC);
            this.Controls.Add(this.panelGuanyu);
            this.Controls.Add(this.btnBFS);
            this.Controls.Add(this.btnDFS);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelS1);
            this.Controls.Add(this.panelS4);
            this.Controls.Add(this.panelS3);
            this.Controls.Add(this.panelS2);
            this.Controls.Add(this.panelHuangzhong);
            this.Controls.Add(this.panelMachao);
            this.Controls.Add(this.panelzhangfei);
            this.Controls.Add(this.panelZhaoyun);
            this.Name = "AIHuaRongDao";
            this.Text = "华容道   童伟圆";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelZhaoyun;
        private System.Windows.Forms.Panel panelzhangfei;
        private System.Windows.Forms.Panel panelMachao;
        private System.Windows.Forms.Panel panelHuangzhong;
        private System.Windows.Forms.Panel panelS2;
        private System.Windows.Forms.Panel panelS1;
        private System.Windows.Forms.Panel panelS3;
        private System.Windows.Forms.Panel panelS4;
        private System.Windows.Forms.Panel panelGuanyu;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnDFS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtShowCount;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblSearchCount;
        private System.Windows.Forms.Panel panelChaoC;
        private System.Windows.Forms.TextBox textBoxtimeShow;
        private System.Windows.Forms.Label lblTimeshow;
    }
}

