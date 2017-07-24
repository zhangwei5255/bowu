using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Win.YMK.Controls.Grids.Behaviors;

namespace JPBook2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridViewExt1.ColumnHeaderRowCount = 2;
            this.gridViewExt1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridViewExt1.ColumnHeadersHeight = gridViewExt1.ColumnHeadersHeight * gridViewExt1.ColumnHeaderRowCount;
            this.gridViewExt1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            HeaderCell[] hds = { new HeaderCell(0, 0, 1, 2, "Category1"), new HeaderCell(0, 2, 1, 2, "Category2"), new HeaderCell(0, 4, 2, 1, "コラム5") };
            gridViewExt1.HeaderCells = hds;  
        }
    }
}
