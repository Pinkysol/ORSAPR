
namespace BiteUI
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Diameter = new System.Windows.Forms.TextBox();
            this.WidthOfAdjoiningPart = new System.Windows.Forms.TextBox();
            this.LengthOfStraightConnector = new System.Windows.Forms.TextBox();
            this.LengthOfStraight = new System.Windows.Forms.TextBox();
            this.BiteLength = new System.Windows.Forms.TextBox();
            this.SchemeButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BuildButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Длина биты L(мм) 25-30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Длина прямой части L1(мм) 3-4 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Длина прямой соединительной части L2 (мм) 15-20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ширина прилегающей части носика S(мм) 0.91-0.95";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Диаметр D(мм) 5-6";
            // 
            // Diameter
            // 
            this.Diameter.Location = new System.Drawing.Point(335, 109);
            this.Diameter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Diameter.Name = "Diameter";
            this.Diameter.Size = new System.Drawing.Size(116, 23);
            this.Diameter.TabIndex = 4;
            this.Diameter.TextChanged += new System.EventHandler(this.Diameter_TextChanged);
            // 
            // WidthOfAdjoiningPart
            // 
            this.WidthOfAdjoiningPart.Location = new System.Drawing.Point(335, 84);
            this.WidthOfAdjoiningPart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WidthOfAdjoiningPart.Name = "WidthOfAdjoiningPart";
            this.WidthOfAdjoiningPart.Size = new System.Drawing.Size(116, 23);
            this.WidthOfAdjoiningPart.TabIndex = 3;
            this.WidthOfAdjoiningPart.TextChanged += new System.EventHandler(this.WidthOfAdjoiningPart_TextChanged);
            // 
            // LengthOfStraightConnector
            // 
            this.LengthOfStraightConnector.Location = new System.Drawing.Point(335, 58);
            this.LengthOfStraightConnector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LengthOfStraightConnector.Name = "LengthOfStraightConnector";
            this.LengthOfStraightConnector.Size = new System.Drawing.Size(116, 23);
            this.LengthOfStraightConnector.TabIndex = 2;
            this.LengthOfStraightConnector.TextChanged += new System.EventHandler(this.LengthOfStraightConnector_TextChanged);
            // 
            // LengthOfStraight
            // 
            this.LengthOfStraight.Location = new System.Drawing.Point(335, 33);
            this.LengthOfStraight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LengthOfStraight.Name = "LengthOfStraight";
            this.LengthOfStraight.Size = new System.Drawing.Size(116, 23);
            this.LengthOfStraight.TabIndex = 1;
            this.LengthOfStraight.TextChanged += new System.EventHandler(this.LengthOfStraight_TextChanged);
            // 
            // BiteLength
            // 
            this.BiteLength.Location = new System.Drawing.Point(335, 7);
            this.BiteLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BiteLength.Name = "BiteLength";
            this.BiteLength.Size = new System.Drawing.Size(116, 23);
            this.BiteLength.TabIndex = 0;
            this.BiteLength.TextChanged += new System.EventHandler(this.BiteLength_TextChanged);
            // 
            // SchemeButton
            // 
            this.SchemeButton.Location = new System.Drawing.Point(280, 138);
            this.SchemeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SchemeButton.Name = "SchemeButton";
            this.SchemeButton.Size = new System.Drawing.Size(58, 27);
            this.SchemeButton.TabIndex = 11;
            this.SchemeButton.Text = "Схема";
            this.SchemeButton.UseVisualStyleBackColor = true;
            this.SchemeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(363, 138);
            this.BuildButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(88, 27);
            this.BuildButton.TabIndex = 12;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 169);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.SchemeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Diameter);
            this.Controls.Add(this.WidthOfAdjoiningPart);
            this.Controls.Add(this.LengthOfStraightConnector);
            this.Controls.Add(this.LengthOfStraight);
            this.Controls.Add(this.BiteLength);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "BiteUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Diameter;
        private System.Windows.Forms.TextBox WidthOfAdjoiningPart;
        private System.Windows.Forms.TextBox LengthOfStraightConnector;
        private System.Windows.Forms.TextBox LengthOfStraight;
        private System.Windows.Forms.TextBox BiteLength;
        private System.Windows.Forms.Button SchemeButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BuildButton;
    }
}

