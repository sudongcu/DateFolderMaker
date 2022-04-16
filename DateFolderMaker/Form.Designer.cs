namespace DateFolderMaker
{
	partial class DateFolderMaker
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateFolderMaker));
			this.path_label = new System.Windows.Forms.Label();
			this.text_path = new System.Windows.Forms.TextBox();
			this.btn_load = new System.Windows.Forms.Button();
			this.text_new = new System.Windows.Forms.TextBox();
			this.newpath_label = new System.Windows.Forms.Label();
			this.btn_newload = new System.Windows.Forms.Button();
			this.btn_create = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.btn_clear = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// path_label
			// 
			this.path_label.AutoSize = true;
			this.path_label.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.path_label.Location = new System.Drawing.Point(12, 13);
			this.path_label.Name = "path_label";
			this.path_label.Size = new System.Drawing.Size(34, 12);
			this.path_label.TabIndex = 0;
			this.path_label.Text = "Path";
			this.path_label.DoubleClick += new System.EventHandler(this.path_label_DoubleClick);
			// 
			// text_path
			// 
			this.text_path.BackColor = System.Drawing.SystemColors.Control;
			this.text_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.text_path.Location = new System.Drawing.Point(52, 9);
			this.text_path.Name = "text_path";
			this.text_path.ReadOnly = true;
			this.text_path.Size = new System.Drawing.Size(592, 21);
			this.text_path.TabIndex = 1;
			// 
			// btn_load
			// 
			this.btn_load.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_load.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_load.Location = new System.Drawing.Point(650, 9);
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(75, 21);
			this.btn_load.TabIndex = 2;
			this.btn_load.Text = "Load";
			this.btn_load.UseVisualStyleBackColor = true;
			this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
			// 
			// text_new
			// 
			this.text_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.text_new.CausesValidation = false;
			this.text_new.Location = new System.Drawing.Point(52, 36);
			this.text_new.Name = "text_new";
			this.text_new.ReadOnly = true;
			this.text_new.Size = new System.Drawing.Size(592, 21);
			this.text_new.TabIndex = 4;
			// 
			// newpath_label
			// 
			this.newpath_label.AutoSize = true;
			this.newpath_label.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.newpath_label.Location = new System.Drawing.Point(12, 40);
			this.newpath_label.Name = "newpath_label";
			this.newpath_label.Size = new System.Drawing.Size(34, 12);
			this.newpath_label.TabIndex = 3;
			this.newpath_label.Text = "New";
			this.newpath_label.DoubleClick += new System.EventHandler(this.newpath_label_DoubleClick);
			// 
			// btn_newload
			// 
			this.btn_newload.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_newload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_newload.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_newload.Location = new System.Drawing.Point(650, 36);
			this.btn_newload.Name = "btn_newload";
			this.btn_newload.Size = new System.Drawing.Size(75, 21);
			this.btn_newload.TabIndex = 5;
			this.btn_newload.Text = "Load";
			this.btn_newload.UseVisualStyleBackColor = true;
			this.btn_newload.Click += new System.EventHandler(this.btn_newload_Click);
			// 
			// btn_create
			// 
			this.btn_create.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(119)))));
			this.btn_create.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_create.FlatAppearance.BorderSize = 0;
			this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_create.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
			this.btn_create.Location = new System.Drawing.Point(731, 9);
			this.btn_create.Name = "btn_create";
			this.btn_create.Size = new System.Drawing.Size(92, 49);
			this.btn_create.TabIndex = 6;
			this.btn_create.Text = "Create";
			this.btn_create.UseVisualStyleBackColor = false;
			this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(14, 64);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 23;
			this.dataGridView.Size = new System.Drawing.Size(711, 453);
			this.dataGridView.TabIndex = 7;
			// 
			// btn_clear
			// 
			this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_clear.FlatAppearance.BorderSize = 0;
			this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_clear.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
			this.btn_clear.Location = new System.Drawing.Point(731, 64);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(92, 49);
			this.btn_clear.TabIndex = 8;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = false;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(14, 523);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(711, 23);
			this.progressBar.TabIndex = 9;
			// 
			// DateFolderMaker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.ClientSize = new System.Drawing.Size(839, 554);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.btn_create);
			this.Controls.Add(this.btn_newload);
			this.Controls.Add(this.text_new);
			this.Controls.Add(this.newpath_label);
			this.Controls.Add(this.btn_load);
			this.Controls.Add(this.text_path);
			this.Controls.Add(this.path_label);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DateFolderMaker";
			this.Text = "DateFolderMaker";
			this.Load += new System.EventHandler(this.DateFolderMaker_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label path_label;
		private System.Windows.Forms.TextBox text_path;
		private System.Windows.Forms.Button btn_load;
		private System.Windows.Forms.TextBox text_new;
		private System.Windows.Forms.Label newpath_label;
		private System.Windows.Forms.Button btn_newload;
		private System.Windows.Forms.Button btn_create;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}

