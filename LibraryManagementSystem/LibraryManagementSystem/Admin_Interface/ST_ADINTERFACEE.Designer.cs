namespace LibraryManagementSystem
{
    partial class ST_ADINTERFACEE
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
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.S_NAME = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DEPARTMENT = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PASS3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SR_CODE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ADD3 = new System.Windows.Forms.TextBox();
            this.ST_ID = new System.Windows.Forms.TextBox();
            this.PHNUM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(678, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "STUDENT_ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(679, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "PASSWORD";
            // 
            // S_NAME
            // 
            this.S_NAME.Location = new System.Drawing.Point(775, 289);
            this.S_NAME.Name = "S_NAME";
            this.S_NAME.Size = new System.Drawing.Size(179, 22);
            this.S_NAME.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(694, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "SR-CODE";
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.Location = new System.Drawing.Point(775, 340);
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.Size = new System.Drawing.Size(179, 22);
            this.DEPARTMENT.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(775, 545);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PASS3
            // 
            this.PASS3.Location = new System.Drawing.Point(775, 503);
            this.PASS3.Name = "PASS3";
            this.PASS3.Size = new System.Drawing.Size(179, 22);
            this.PASS3.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(880, 545);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(672, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(649, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "STUDENT_NAME";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(695, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "ADDRESS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(729, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "STUDENTS";
            // 
            // SR_CODE
            // 
            this.SR_CODE.Location = new System.Drawing.Point(775, 237);
            this.SR_CODE.Name = "SR_CODE";
            this.SR_CODE.Size = new System.Drawing.Size(179, 22);
            this.SR_CODE.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(669, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "DEPARTMENT";
            // 
            // ADD3
            // 
            this.ADD3.Location = new System.Drawing.Point(775, 448);
            this.ADD3.Name = "ADD3";
            this.ADD3.Size = new System.Drawing.Size(179, 22);
            this.ADD3.TabIndex = 20;
            // 
            // ST_ID
            // 
            this.ST_ID.Location = new System.Drawing.Point(775, 188);
            this.ST_ID.Name = "ST_ID";
            this.ST_ID.Size = new System.Drawing.Size(179, 22);
            this.ST_ID.TabIndex = 16;
            // 
            // PHNUM
            // 
            this.PHNUM.Location = new System.Drawing.Point(775, 394);
            this.PHNUM.Name = "PHNUM";
            this.PHNUM.Size = new System.Drawing.Size(179, 22);
            this.PHNUM.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(646, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "PHONE NUMBER";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(-9, 563);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 33);
            this.button4.TabIndex = 9;
            this.button4.Text = "<< BACK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(6, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(634, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(121, 163);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(236, 22);
            this.searchTextBox.TabIndex = 11;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.SearchButton.Location = new System.Drawing.Point(6, 158);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(109, 31);
            this.SearchButton.TabIndex = 25;
            this.SearchButton.Text = "Search:";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::LibraryManagementSystem.Properties.Resources.httpsbatstate_u_edu1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.S_NAME);
            this.panel3.Controls.Add(this.searchTextBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.DEPARTMENT);
            this.panel3.Controls.Add(this.SearchButton);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.PASS3);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.PHNUM);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.ST_ID);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.ADD3);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.SR_CODE);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 645);
            this.panel3.TabIndex = 26;
            // 
            // ST_ADINTERFACEE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagementSystem.Properties.Resources.Untitled_design;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 645);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Name = "ST_ADINTERFACEE";
            this.Text = "ST_ADINTERFACEE";
            this.Load += new System.EventHandler(this.ST_ADINTERFACEE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox S_NAME;
        private System.Windows.Forms.TextBox DEPARTMENT;
        private System.Windows.Forms.TextBox SR_CODE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ST_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PHNUM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PASS3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ADD3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Panel panel3;
    }
}