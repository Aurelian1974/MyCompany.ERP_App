﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCompany.ERP.WinForms.Forms.MainForm;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        this.Text = "MyCompany ERP - Aplicație Principală";
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Inițializare MainForm
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void utilizatoriToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (var frm = new MyCompany.ERP.WinForms.Forms.Administrare.frmUsers())
        {
            frm.ShowDialog(this);
        }
    }
}