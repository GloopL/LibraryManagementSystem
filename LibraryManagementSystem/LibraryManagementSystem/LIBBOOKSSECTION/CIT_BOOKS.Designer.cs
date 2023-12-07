namespace LibraryManagementSystem.LIBBOOKSSECTION
{
    partial class CIT_BOOKS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.AUTHOR = new System.Windows.Forms.TextBox();
            this.QTY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PUB = new System.Windows.Forms.TextBox();
            this.searchtextBox = new System.Windows.Forms.TextBox();
            this.addBook = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.REMOVE_BUTTON = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BOOKID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BNAME = new System.Windows.Forms.TextBox();
            this.EDIT_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(20, 422);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 24);
            this.button1.TabIndex = 67;
            this.button1.Text = "<< BACK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AUTHOR
            // 
            this.AUTHOR.Location = new System.Drawing.Point(560, 219);
            this.AUTHOR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AUTHOR.Name = "AUTHOR";
            this.AUTHOR.Size = new System.Drawing.Size(147, 20);
            this.AUTHOR.TabIndex = 54;
            // 
            // QTY
            // 
            this.QTY.Location = new System.Drawing.Point(560, 292);
            this.QTY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QTY.Name = "QTY";
            this.QTY.Size = new System.Drawing.Size(147, 20);
            this.QTY.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(497, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 59;
            this.label4.Text = "Publisher";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(434, 243);
            this.dataGridView1.TabIndex = 51;
            // 
            // PUB
            // 
            this.PUB.Location = new System.Drawing.Point(560, 254);
            this.PUB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PUB.Name = "PUB";
            this.PUB.Size = new System.Drawing.Size(147, 20);
            this.PUB.TabIndex = 55;
            // 
            // searchtextBox
            // 
            this.searchtextBox.Location = new System.Drawing.Point(101, 132);
            this.searchtextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchtextBox.Name = "searchtextBox";
            this.searchtextBox.Size = new System.Drawing.Size(187, 20);
            this.searchtextBox.TabIndex = 64;
            this.searchtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchtextBox_KeyDown);
            // 
            // addBook
            // 
            this.addBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.addBook.FlatAppearance.BorderSize = 0;
            this.addBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addBook.Location = new System.Drawing.Point(477, 352);
            this.addBook.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addBook.Name = "addBook";
            this.addBook.Size = new System.Drawing.Size(79, 32);
            this.addBook.TabIndex = 60;
            this.addBook.Text = "Add";
            this.addBook.UseVisualStyleBackColor = false;
            this.addBook.Click += new System.EventHandler(this.addBook_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(20, 124);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(76, 27);
            this.searchButton.TabIndex = 63;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            this.searchButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchButton_KeyDown);
            // 
            // REMOVE_BUTTON
            // 
            this.REMOVE_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.REMOVE_BUTTON.FlatAppearance.BorderSize = 0;
            this.REMOVE_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REMOVE_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REMOVE_BUTTON.Location = new System.Drawing.Point(644, 352);
            this.REMOVE_BUTTON.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.REMOVE_BUTTON.Name = "REMOVE_BUTTON";
            this.REMOVE_BUTTON.Size = new System.Drawing.Size(79, 32);
            this.REMOVE_BUTTON.TabIndex = 62;
            this.REMOVE_BUTTON.Text = "Remove";
            this.REMOVE_BUTTON.UseVisualStyleBackColor = false;
            this.REMOVE_BUTTON.Click += new System.EventHandler(this.REMOVE_BUTTON_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(503, 293);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 65;
            this.label5.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(513, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 58;
            this.label3.Text = "Author";
            // 
            // BOOKID
            // 
            this.BOOKID.Location = new System.Drawing.Point(560, 152);
            this.BOOKID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BOOKID.Name = "BOOKID";
            this.BOOKID.Size = new System.Drawing.Size(147, 20);
            this.BOOKID.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(480, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 57;
            this.label2.Text = "Book_Name";
            // 
            // BNAME
            // 
            this.BNAME.Location = new System.Drawing.Point(560, 185);
            this.BNAME.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BNAME.Name = "BNAME";
            this.BNAME.Size = new System.Drawing.Size(147, 20);
            this.BNAME.TabIndex = 53;
            // 
            // EDIT_BUTTON
            // 
            this.EDIT_BUTTON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(29)))), ((int)(((byte)(54)))));
            this.EDIT_BUTTON.FlatAppearance.BorderSize = 0;
            this.EDIT_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EDIT_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EDIT_BUTTON.Location = new System.Drawing.Point(560, 352);
            this.EDIT_BUTTON.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDIT_BUTTON.Name = "EDIT_BUTTON";
            this.EDIT_BUTTON.Size = new System.Drawing.Size(79, 32);
            this.EDIT_BUTTON.TabIndex = 61;
            this.EDIT_BUTTON.Text = "Edit";
            this.EDIT_BUTTON.UseVisualStyleBackColor = false;
            this.EDIT_BUTTON.Click += new System.EventHandler(this.EDIT_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "Book ID";
            // 
            // CIT_BOOKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagementSystem.Properties.Resources._5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AUTHOR);
            this.Controls.Add(this.QTY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PUB);
            this.Controls.Add(this.searchtextBox);
            this.Controls.Add(this.addBook);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.REMOVE_BUTTON);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BOOKID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BNAME);
            this.Controls.Add(this.EDIT_BUTTON);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CIT_BOOKS";
            this.Text = "CIT_BOOKS";
            this.Load += new System.EventHandler(this.CIT_BOOKS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox AUTHOR;
        private System.Windows.Forms.TextBox QTY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox PUB;
        private System.Windows.Forms.TextBox searchtextBox;
        private System.Windows.Forms.Button addBook;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button REMOVE_BUTTON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BOOKID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BNAME;
        private System.Windows.Forms.Button EDIT_BUTTON;
        private System.Windows.Forms.Label label1;
    }
}