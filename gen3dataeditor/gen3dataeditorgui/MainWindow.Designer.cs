namespace gen3dataeditorgui
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.button_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_get = new System.Windows.Forms.RadioButton();
            this.rb_set = new System.Windows.Forms.RadioButton();
            this.cb_isstring = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_rompath = new System.Windows.Forms.TextBox();
            this.button_exec = new System.Windows.Forms.Button();
            this.tb_setvalue = new System.Windows.Forms.TextBox();
            this.label_setvalue = new System.Windows.Forms.Label();
            this.cb_printhex = new System.Windows.Forms.CheckBox();
            this.tb_structname = new System.Windows.Forms.TextBox();
            this.tb_offsetname = new System.Windows.Forms.TextBox();
            this.tb_index = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_console = new System.Windows.Forms.TextBox();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_liststructs = new System.Windows.Forms.Button();
            this.button_listoffsets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(546, 311);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(75, 23);
            this.button_browse.TabIndex = 0;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected ROM:";
            // 
            // rb_get
            // 
            this.rb_get.AutoSize = true;
            this.rb_get.Location = new System.Drawing.Point(12, 12);
            this.rb_get.Name = "rb_get";
            this.rb_get.Size = new System.Drawing.Size(71, 17);
            this.rb_get.TabIndex = 3;
            this.rb_get.TabStop = true;
            this.rb_get.Text = "Get value";
            this.rb_get.UseVisualStyleBackColor = true;
            this.rb_get.CheckedChanged += new System.EventHandler(this.rb_get_CheckedChanged);
            // 
            // rb_set
            // 
            this.rb_set.AutoSize = true;
            this.rb_set.Location = new System.Drawing.Point(12, 36);
            this.rb_set.Name = "rb_set";
            this.rb_set.Size = new System.Drawing.Size(70, 17);
            this.rb_set.TabIndex = 4;
            this.rb_set.TabStop = true;
            this.rb_set.Text = "Set value";
            this.rb_set.UseVisualStyleBackColor = true;
            this.rb_set.CheckedChanged += new System.EventHandler(this.rb_set_CheckedChanged);
            // 
            // cb_isstring
            // 
            this.cb_isstring.AutoSize = true;
            this.cb_isstring.Location = new System.Drawing.Point(12, 60);
            this.cb_isstring.Name = "cb_isstring";
            this.cb_isstring.Size = new System.Drawing.Size(103, 17);
            this.cb_isstring.TabIndex = 5;
            this.cb_isstring.Text = "Value is a string.";
            this.cb_isstring.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // tb_rompath
            // 
            this.tb_rompath.Location = new System.Drawing.Point(397, 311);
            this.tb_rompath.Name = "tb_rompath";
            this.tb_rompath.Size = new System.Drawing.Size(143, 20);
            this.tb_rompath.TabIndex = 7;
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(13, 311);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(75, 23);
            this.button_exec.TabIndex = 8;
            this.button_exec.Text = "Execute";
            this.button_exec.UseVisualStyleBackColor = true;
            this.button_exec.Click += new System.EventHandler(this.button_exec_Click);
            // 
            // tb_setvalue
            // 
            this.tb_setvalue.Location = new System.Drawing.Point(12, 113);
            this.tb_setvalue.Name = "tb_setvalue";
            this.tb_setvalue.Size = new System.Drawing.Size(100, 20);
            this.tb_setvalue.TabIndex = 9;
            // 
            // label_setvalue
            // 
            this.label_setvalue.AutoSize = true;
            this.label_setvalue.Location = new System.Drawing.Point(118, 116);
            this.label_setvalue.Name = "label_setvalue";
            this.label_setvalue.Size = new System.Drawing.Size(52, 13);
            this.label_setvalue.TabIndex = 10;
            this.label_setvalue.Text = "Set value";
            // 
            // cb_printhex
            // 
            this.cb_printhex.AutoSize = true;
            this.cb_printhex.Location = new System.Drawing.Point(12, 84);
            this.cb_printhex.Name = "cb_printhex";
            this.cb_printhex.Size = new System.Drawing.Size(67, 17);
            this.cb_printhex.TabIndex = 11;
            this.cb_printhex.Text = "Print hex";
            this.cb_printhex.UseVisualStyleBackColor = true;
            this.cb_printhex.CheckedChanged += new System.EventHandler(this.cb_printhex_CheckedChanged);
            // 
            // tb_structname
            // 
            this.tb_structname.Location = new System.Drawing.Point(12, 140);
            this.tb_structname.Name = "tb_structname";
            this.tb_structname.Size = new System.Drawing.Size(100, 20);
            this.tb_structname.TabIndex = 12;
            // 
            // tb_offsetname
            // 
            this.tb_offsetname.Location = new System.Drawing.Point(12, 167);
            this.tb_offsetname.Name = "tb_offsetname";
            this.tb_offsetname.Size = new System.Drawing.Size(100, 20);
            this.tb_offsetname.TabIndex = 13;
            // 
            // tb_index
            // 
            this.tb_index.Location = new System.Drawing.Point(13, 194);
            this.tb_index.MaxLength = 4;
            this.tb_index.Name = "tb_index";
            this.tb_index.Size = new System.Drawing.Size(36, 20);
            this.tb_index.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Struct name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Offset name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Index";
            // 
            // tb_console
            // 
            this.tb_console.Location = new System.Drawing.Point(314, 12);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.Size = new System.Drawing.Size(307, 222);
            this.tb_console.TabIndex = 18;
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(354, 240);
            this.tb_value.Name = "tb_value";
            this.tb_value.ReadOnly = true;
            this.tb_value.Size = new System.Drawing.Size(267, 20);
            this.tb_value.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Value:";
            // 
            // button_liststructs
            // 
            this.button_liststructs.Location = new System.Drawing.Point(95, 311);
            this.button_liststructs.Name = "button_liststructs";
            this.button_liststructs.Size = new System.Drawing.Size(75, 23);
            this.button_liststructs.TabIndex = 21;
            this.button_liststructs.Text = "List Structs";
            this.button_liststructs.UseVisualStyleBackColor = true;
            this.button_liststructs.Click += new System.EventHandler(this.button_liststructs_Click);
            // 
            // button_listoffsets
            // 
            this.button_listoffsets.Location = new System.Drawing.Point(176, 311);
            this.button_listoffsets.Name = "button_listoffsets";
            this.button_listoffsets.Size = new System.Drawing.Size(75, 23);
            this.button_listoffsets.TabIndex = 22;
            this.button_listoffsets.Text = "List Offsets";
            this.button_listoffsets.UseVisualStyleBackColor = true;
            this.button_listoffsets.Click += new System.EventHandler(this.button_listoffsets_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 346);
            this.Controls.Add(this.button_listoffsets);
            this.Controls.Add(this.button_liststructs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.tb_console);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_index);
            this.Controls.Add(this.tb_offsetname);
            this.Controls.Add(this.tb_structname);
            this.Controls.Add(this.cb_printhex);
            this.Controls.Add(this.label_setvalue);
            this.Controls.Add(this.tb_setvalue);
            this.Controls.Add(this.button_exec);
            this.Controls.Add(this.tb_rompath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_isstring);
            this.Controls.Add(this.rb_set);
            this.Controls.Add(this.rb_get);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_browse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Gen3RomDataEditor 0.3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_get;
        private System.Windows.Forms.RadioButton rb_set;
        private System.Windows.Forms.CheckBox cb_isstring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_rompath;
        private System.Windows.Forms.Button button_exec;
        private System.Windows.Forms.TextBox tb_setvalue;
        private System.Windows.Forms.Label label_setvalue;
        private System.Windows.Forms.CheckBox cb_printhex;
        private System.Windows.Forms.TextBox tb_structname;
        private System.Windows.Forms.TextBox tb_offsetname;
        private System.Windows.Forms.TextBox tb_index;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_console;
        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_liststructs;
        private System.Windows.Forms.Button button_listoffsets;
    }
}