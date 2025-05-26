using System.Windows.Forms;

namespace DemoDocuments
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLogin = new System.Windows.Forms.Label();
            this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
            this.dataGridViewPrograms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonContract = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.comboBoxSave = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrograms)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(500, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(0, 20);
            this.labelLogin.TabIndex = 0;
            // 
            // dataGridViewPersons
            // 
            this.dataGridViewPersons.AllowUserToAddRows = false;
            this.dataGridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersons.Location = new System.Drawing.Point(10, 50);
            this.dataGridViewPersons.Name = "dataGridViewPersons";
            this.dataGridViewPersons.ReadOnly = true;
            this.dataGridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPersons.Size = new System.Drawing.Size(600, 200);
            this.dataGridViewPersons.TabIndex = 1;
            // 
            // dataGridViewPrograms
            // 
            this.dataGridViewPrograms.AllowUserToAddRows = false;
            this.dataGridViewPrograms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrograms.Location = new System.Drawing.Point(10, 285);
            this.dataGridViewPrograms.Name = "dataGridViewPrograms";
            this.dataGridViewPrograms.ReadOnly = true;
            this.dataGridViewPrograms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrograms.Size = new System.Drawing.Size(600, 200);
            this.dataGridViewPrograms.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ученики";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Программы";
            // 
            // buttonContract
            // 
            this.buttonContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonContract.Location = new System.Drawing.Point(10, 500);
            this.buttonContract.Name = "buttonContract";
            this.buttonContract.Size = new System.Drawing.Size(250, 60);
            this.buttonContract.TabIndex = 5;
            this.buttonContract.Text = "Создать контракт";
            this.buttonContract.UseVisualStyleBackColor = true;
            this.buttonContract.Click += new System.EventHandler(this.buttonContract_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPay.Location = new System.Drawing.Point(10, 566);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(250, 60);
            this.buttonPay.TabIndex = 6;
            this.buttonPay.Text = "Создать квитанцию";
            this.buttonPay.UseVisualStyleBackColor = true;
            // 
            // comboBoxSave
            // 
            this.comboBoxSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSave.FormattingEnabled = true;
            this.comboBoxSave.Location = new System.Drawing.Point(265, 530);
            this.comboBoxSave.Name = "comboBoxSave";
            this.comboBoxSave.Size = new System.Drawing.Size(224, 63);
            this.comboBoxSave.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 661);
            this.Controls.Add(this.comboBoxSave);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.buttonContract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPrograms);
            this.Controls.Add(this.dataGridViewPersons);
            this.Controls.Add(this.labelLogin);
            this.Name = "MainForm";
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrograms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.DataGridView dataGridViewPersons;
        private System.Windows.Forms.DataGridView dataGridViewPrograms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Button buttonContract;
        private Button buttonPay;
        private ComboBox comboBoxSave;
    }
}

