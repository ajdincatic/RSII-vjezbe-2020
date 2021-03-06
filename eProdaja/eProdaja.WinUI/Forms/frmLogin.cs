﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Forms
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("JediniceMjere");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.username = txtUsername.Text;
                APIService.password = txtPassword.Text;
                await _service.GetAll<dynamic>(null);

                frmIndex frm = new frmIndex();
                frm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
