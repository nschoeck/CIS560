namespace CIS560
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
            this.uiTabControl = new System.Windows.Forms.TabControl();
            this.uiAddressTab = new System.Windows.Forms.TabPage();
            this.uiCustomerTab = new System.Windows.Forms.TabPage();
            this.uiDriverTab = new System.Windows.Forms.TabPage();
            this.uiMenuItemTab = new System.Windows.Forms.TabPage();
            this.uiOrderTab = new System.Windows.Forms.TabPage();
            this.uiOrderMenuItemTab = new System.Windows.Forms.TabPage();
            this.uiRestaurantTab = new System.Windows.Forms.TabPage();
            this.uiTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl
            // 
            this.uiTabControl.Controls.Add(this.uiAddressTab);
            this.uiTabControl.Controls.Add(this.uiCustomerTab);
            this.uiTabControl.Controls.Add(this.uiDriverTab);
            this.uiTabControl.Controls.Add(this.uiMenuItemTab);
            this.uiTabControl.Controls.Add(this.uiOrderTab);
            this.uiTabControl.Controls.Add(this.uiOrderMenuItemTab);
            this.uiTabControl.Controls.Add(this.uiRestaurantTab);
            this.uiTabControl.Location = new System.Drawing.Point(-2, -2);
            this.uiTabControl.Name = "uiTabControl";
            this.uiTabControl.SelectedIndex = 0;
            this.uiTabControl.Size = new System.Drawing.Size(590, 315);
            this.uiTabControl.TabIndex = 0;
            // 
            // uiAddressTab
            // 
            this.uiAddressTab.Location = new System.Drawing.Point(4, 22);
            this.uiAddressTab.Name = "uiAddressTab";
            this.uiAddressTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiAddressTab.Size = new System.Drawing.Size(582, 289);
            this.uiAddressTab.TabIndex = 0;
            this.uiAddressTab.Text = "Address";
            this.uiAddressTab.UseVisualStyleBackColor = true;
            // 
            // uiCustomerTab
            // 
            this.uiCustomerTab.Location = new System.Drawing.Point(4, 22);
            this.uiCustomerTab.Name = "uiCustomerTab";
            this.uiCustomerTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiCustomerTab.Size = new System.Drawing.Size(582, 289);
            this.uiCustomerTab.TabIndex = 1;
            this.uiCustomerTab.Text = "Customer";
            this.uiCustomerTab.UseVisualStyleBackColor = true;
            // 
            // uiDriverTab
            // 
            this.uiDriverTab.Location = new System.Drawing.Point(4, 22);
            this.uiDriverTab.Name = "uiDriverTab";
            this.uiDriverTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiDriverTab.Size = new System.Drawing.Size(582, 289);
            this.uiDriverTab.TabIndex = 2;
            this.uiDriverTab.Text = "Driver";
            this.uiDriverTab.UseVisualStyleBackColor = true;
            // 
            // uiMenuItemTab
            // 
            this.uiMenuItemTab.Location = new System.Drawing.Point(4, 22);
            this.uiMenuItemTab.Name = "uiMenuItemTab";
            this.uiMenuItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiMenuItemTab.Size = new System.Drawing.Size(582, 289);
            this.uiMenuItemTab.TabIndex = 3;
            this.uiMenuItemTab.Text = "Menu Item";
            this.uiMenuItemTab.UseVisualStyleBackColor = true;
            // 
            // uiOrderTab
            // 
            this.uiOrderTab.Location = new System.Drawing.Point(4, 22);
            this.uiOrderTab.Name = "uiOrderTab";
            this.uiOrderTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiOrderTab.Size = new System.Drawing.Size(582, 289);
            this.uiOrderTab.TabIndex = 4;
            this.uiOrderTab.Text = "Order";
            this.uiOrderTab.UseVisualStyleBackColor = true;
            // 
            // uiOrderMenuItemTab
            // 
            this.uiOrderMenuItemTab.Location = new System.Drawing.Point(4, 22);
            this.uiOrderMenuItemTab.Name = "uiOrderMenuItemTab";
            this.uiOrderMenuItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiOrderMenuItemTab.Size = new System.Drawing.Size(582, 289);
            this.uiOrderMenuItemTab.TabIndex = 5;
            this.uiOrderMenuItemTab.Text = "Order Menu Item";
            this.uiOrderMenuItemTab.UseVisualStyleBackColor = true;
            // 
            // uiRestaurantTab
            // 
            this.uiRestaurantTab.Location = new System.Drawing.Point(4, 22);
            this.uiRestaurantTab.Name = "uiRestaurantTab";
            this.uiRestaurantTab.Padding = new System.Windows.Forms.Padding(3);
            this.uiRestaurantTab.Size = new System.Drawing.Size(582, 289);
            this.uiRestaurantTab.TabIndex = 6;
            this.uiRestaurantTab.Text = "Restaurant";
            this.uiRestaurantTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.uiTabControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.uiTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiTabControl;
        private System.Windows.Forms.TabPage uiAddressTab;
        private System.Windows.Forms.TabPage uiCustomerTab;
        private System.Windows.Forms.TabPage uiDriverTab;
        private System.Windows.Forms.TabPage uiMenuItemTab;
        private System.Windows.Forms.TabPage uiOrderTab;
        private System.Windows.Forms.TabPage uiOrderMenuItemTab;
        private System.Windows.Forms.TabPage uiRestaurantTab;
    }
}

