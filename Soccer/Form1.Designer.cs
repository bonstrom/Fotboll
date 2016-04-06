namespace Soccer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.homeTeamList = new System.Windows.Forms.ComboBox();
            this.awayTeamList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.seasonList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataTableLeague = new System.Windows.Forms.DataGridView();
            this.leagueInfo = new System.Windows.Forms.Label();
            this.Pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Played = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Draw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsAgainst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLeague)).BeginInit();
            this.SuspendLayout();
            // 
            // homeTeamList
            // 
            this.homeTeamList.FormattingEnabled = true;
            this.homeTeamList.Location = new System.Drawing.Point(306, 99);
            this.homeTeamList.Name = "homeTeamList";
            this.homeTeamList.Size = new System.Drawing.Size(121, 21);
            this.homeTeamList.TabIndex = 0;
            this.homeTeamList.SelectedIndexChanged += new System.EventHandler(this.homeTeamList_SelectedIndexChanged);
            // 
            // awayTeamList
            // 
            this.awayTeamList.FormattingEnabled = true;
            this.awayTeamList.Location = new System.Drawing.Point(461, 99);
            this.awayTeamList.Name = "awayTeamList";
            this.awayTeamList.Size = new System.Drawing.Size(121, 21);
            this.awayTeamList.TabIndex = 1;
            this.awayTeamList.SelectedIndexChanged += new System.EventHandler(this.awayTeamList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Home";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Away";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1193, 754);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.leagueInfo);
            this.tabPage1.Controls.Add(this.dataTableLeague);
            this.tabPage1.Controls.Add(this.seasonList);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1185, 728);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tabel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // seasonList
            // 
            this.seasonList.FormattingEnabled = true;
            this.seasonList.Location = new System.Drawing.Point(22, 36);
            this.seasonList.Name = "seasonList";
            this.seasonList.Size = new System.Drawing.Size(163, 21);
            this.seasonList.TabIndex = 0;
            this.seasonList.SelectedIndexChanged += new System.EventHandler(this.seasonList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "League";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.homeTeamList);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.awayTeamList);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1185, 728);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataTableLeague
            // 
            this.dataTableLeague.AllowUserToOrderColumns = true;
            this.dataTableLeague.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableLeague.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pos,
            this.Team,
            this.Played,
            this.Win,
            this.Draw,
            this.Loss,
            this.GoalsFor,
            this.GoalsAgainst,
            this.GoalDiff,
            this.Points});
            this.dataTableLeague.Location = new System.Drawing.Point(22, 74);
            this.dataTableLeague.Name = "dataTableLeague";
            this.dataTableLeague.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataTableLeague.Size = new System.Drawing.Size(560, 461);
            this.dataTableLeague.TabIndex = 7;
            // 
            // leagueInfo
            // 
            this.leagueInfo.AutoSize = true;
            this.leagueInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leagueInfo.Location = new System.Drawing.Point(222, 36);
            this.leagueInfo.Name = "leagueInfo";
            this.leagueInfo.Size = new System.Drawing.Size(0, 20);
            this.leagueInfo.TabIndex = 8;
            // 
            // Pos
            // 
            this.Pos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Pos.HeaderText = "Pos";
            this.Pos.Name = "Pos";
            this.Pos.Width = 30;
            // 
            // Team
            // 
            this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Team.HeaderText = "Team";
            this.Team.Name = "Team";
            this.Team.Width = 59;
            // 
            // Played
            // 
            this.Played.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Played.HeaderText = "Played";
            this.Played.Name = "Played";
            this.Played.Width = 64;
            // 
            // Win
            // 
            this.Win.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Win.HeaderText = "Win";
            this.Win.Name = "Win";
            this.Win.Width = 51;
            // 
            // Draw
            // 
            this.Draw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Draw.HeaderText = "Draw";
            this.Draw.Name = "Draw";
            this.Draw.Width = 57;
            // 
            // Loss
            // 
            this.Loss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Loss.HeaderText = "Loss";
            this.Loss.Name = "Loss";
            this.Loss.Width = 54;
            // 
            // GoalsFor
            // 
            this.GoalsFor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GoalsFor.HeaderText = "GF";
            this.GoalsFor.Name = "GoalsFor";
            this.GoalsFor.Width = 46;
            // 
            // GoalsAgainst
            // 
            this.GoalsAgainst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GoalsAgainst.HeaderText = "GA";
            this.GoalsAgainst.Name = "GoalsAgainst";
            this.GoalsAgainst.Width = 47;
            // 
            // GoalDiff
            // 
            this.GoalDiff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GoalDiff.HeaderText = "GD";
            this.GoalDiff.Name = "GoalDiff";
            this.GoalDiff.Width = 48;
            // 
            // Points
            // 
            this.Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Points.HeaderText = "Pts";
            this.Points.Name = "Points";
            this.Points.Width = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 757);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLeague)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox homeTeamList;
        private System.Windows.Forms.ComboBox awayTeamList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox seasonList;
        private System.Windows.Forms.DataGridView dataTableLeague;
        private System.Windows.Forms.Label leagueInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Played;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win;
        private System.Windows.Forms.DataGridViewTextBoxColumn Draw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loss;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalsFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalsAgainst;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    }
}

