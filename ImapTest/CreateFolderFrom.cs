using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImapTest
{
    public partial class CreateFolderFrom : Form
    {
        public string FolderName = "";

        public CreateFolderFrom()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbFolderName.Text))
            {
                FolderName = tbFolderName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
