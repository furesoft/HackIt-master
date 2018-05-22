using HackIt.Core;

namespace HackIt.Tools.Dialogs
{
    public class DownloadDialog :  DialogForm
    {
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Button okButton;

        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.okButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.Black;
            this.okButton.Location = new System.Drawing.Point(264, 143);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 46);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Get File";
            this.okButton.UseVisualStyleBackColor = false;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.filenameLabel.Location = new System.Drawing.Point(19, 68);
            this.filenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(81, 20);
            this.filenameLabel.TabIndex = 5;
            this.filenameLabel.Text = "Filename";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 106);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(341, 29);
            this.progressBar.TabIndex = 6;
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filenameTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameTextBox.Location = new System.Drawing.Point(108, 66);
            this.filenameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(255, 27);
            this.filenameTextBox.TabIndex = 7;
            // 
            // DownloadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.ClientSize = new System.Drawing.Size(379, 209);
            this.Controls.Add(this.filenameTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.okButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DownloadDialog";
            this.Title = "Download File";
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.filenameLabel, 0);
            this.Controls.SetChildIndex(this.progressBar, 0);
            this.Controls.SetChildIndex(this.filenameTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public DownloadDialog()
        {
            InitializeComponent();

            ServiceLocator.Subscribe("LocaleChanged", _ =>
            {
                Title = ServiceLocator._("Download File");
                okButton.Text = ServiceLocator._("Download");
            });
        }
    }
}
