using Vueling.Common.Logic;

namespace Vueling.Presentation.WinSite
{
    partial class AlumnoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnoForm));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnOpenShowStudent = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmuES = new System.Windows.Forms.ToolStripMenuItem();
            this.tmuEN = new System.Windows.Forms.ToolStripMenuItem();
            this.tmuCA = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiXML = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbActualFormat = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            // 
            // txtApellidos
            // 
            resources.ApplyResources(this.txtApellidos, "txtApellidos");
            this.txtApellidos.Name = "txtApellidos";
            // 
            // txtDni
            // 
            resources.ApplyResources(this.txtDni, "txtDni");
            this.txtDni.Name = "txtDni";
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.Name = "lblId";
            // 
            // lblNombre
            // 
            resources.ApplyResources(this.lblNombre, "lblNombre");
            this.lblNombre.Name = "lblNombre";
            // 
            // lblApellidos
            // 
            resources.ApplyResources(this.lblApellidos, "lblApellidos");
            this.lblApellidos.Name = "lblApellidos";
            // 
            // lblDni
            // 
            resources.ApplyResources(this.lblDni, "lblDni");
            this.lblDni.Name = "lblDni";
            // 
            // lblFechaNacimiento
            // 
            resources.ApplyResources(this.lblFechaNacimiento, "lblFechaNacimiento");
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            // 
            // dtpFechaNacimiento
            // 
            resources.ApplyResources(this.dtpFechaNacimiento, "dtpFechaNacimiento");
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            // 
            // btnOpenShowStudent
            // 
            resources.ApplyResources(this.btnOpenShowStudent, "btnOpenShowStudent");
            this.btnOpenShowStudent.Name = "btnOpenShowStudent";
            this.btnOpenShowStudent.UseVisualStyleBackColor = true;
            this.btnOpenShowStudent.Click += new System.EventHandler(this.btnOpenShowStudent_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idiomaToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // idiomaToolStripMenuItem
            // 
            resources.ApplyResources(this.idiomaToolStripMenuItem, "idiomaToolStripMenuItem");
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmuES,
            this.tmuEN,
            this.tmuCA});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            // 
            // tmuES
            // 
            resources.ApplyResources(this.tmuES, "tmuES");
            this.tmuES.Name = "tmuES";
            this.tmuES.Click += new System.EventHandler(this.CambiaIdioma_Click);
            // 
            // tmuEN
            // 
            resources.ApplyResources(this.tmuEN, "tmuEN");
            this.tmuEN.Name = "tmuEN";
            this.tmuEN.Click += new System.EventHandler(this.CambiaIdioma_Click);
            // 
            // tmuCA
            // 
            resources.ApplyResources(this.tmuCA, "tmuCA");
            this.tmuCA.Name = "tmuCA";
            this.tmuCA.Click += new System.EventHandler(this.CambiaIdioma_Click);
            // 
            // configurationToolStripMenuItem
            // 
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            // 
            // configuraciónToolStripMenuItem
            // 
            resources.ApplyResources(this.configuraciónToolStripMenuItem, "configuraciónToolStripMenuItem");
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiTXT,
            this.tmiJSON,
            this.tmiXML,
            this.tmiSQL});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            // 
            // tmiTXT
            // 
            resources.ApplyResources(this.tmiTXT, "tmiTXT");
            this.tmiTXT.Name = "tmiTXT";
            this.tmiTXT.Click += new System.EventHandler(this.ChangeFormatConfig);
            // 
            // tmiJSON
            // 
            resources.ApplyResources(this.tmiJSON, "tmiJSON");
            this.tmiJSON.Name = "tmiJSON";
            this.tmiJSON.Click += new System.EventHandler(this.ChangeFormatConfig);
            // 
            // tmiXML
            // 
            resources.ApplyResources(this.tmiXML, "tmiXML");
            this.tmiXML.Name = "tmiXML";
            this.tmiXML.Click += new System.EventHandler(this.ChangeFormatConfig);
            // 
            // tmiSQL
            // 
            resources.ApplyResources(this.tmiSQL, "tmiSQL");
            this.tmiSQL.Name = "tmiSQL";
            this.tmiSQL.Click += new System.EventHandler(this.ChangeFormatConfig);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveEntity);
            // 
            // lbActualFormat
            // 
            resources.ApplyResources(this.lbActualFormat, "lbActualFormat");
            this.lbActualFormat.ForeColor = System.Drawing.Color.Green;
            this.lbActualFormat.Name = "lbActualFormat";
            // 
            // AlumnoForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbActualFormat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenShowStudent);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlumnoForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnOpenShowStudent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmuES;
        private System.Windows.Forms.ToolStripMenuItem tmuEN;
        private System.Windows.Forms.ToolStripMenuItem tmuCA;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmiTXT;
        private System.Windows.Forms.ToolStripMenuItem tmiJSON;
        private System.Windows.Forms.ToolStripMenuItem tmiXML;
        private System.Windows.Forms.ToolStripMenuItem tmiSQL;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbActualFormat;
    }
}