using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//******************************************************************************
//  ･ｯ･鬣ｹﾃ・｣ｺFrmSearch
//  ﾗﾉﾕﾟ｡｡ ｣ｺ処ﾍ
//  ﾗﾉﾈﾕ｡｡ ｣ｺ2007-10-22
//  Иﾀ朗ﾚﾈﾝ ｣ｺ量ﾋﾃ､ﾎ･ﾕ･ｩｩ`･・
//  ｸ・ﾂﾂﾄ嘖 ｣ｺ
//******************************************************************************

namespace Win.YMK.Controls.Grids
{
    public partial class FrmSearch : Form
    {
        private string _find;                       //量ﾋﾎﾎﾄﾗﾖﾁﾐ
        private bool _isClickCancel;                //･ｭ･罕ｻ･・ﾜ･ｿ･ｯ･・ﾃ･ｯ､ｫ､ﾉ､ｦ､ｫ

        public FrmSearch()
        {
            InitializeComponent();

            _find = "";
        }

        /// <summary>
        /// 量ﾋﾎﾎﾄﾗﾖﾁﾐ
        /// </summary>
        public string Find
        {
            get
            {
                return _find;
            }
            set
            {
                _find = value;
            }
        }

        /// <summary>
        /// ･ｳ･ﾜ･ﾜ･ﾃ･ｯ･ｹ(ﾄﾚﾈﾝ｣ｺ･ｰ･・ﾃ･ﾉ､ﾎ･ｳ･鬣狹﨤ﾆ)
        /// </summary>
        public ComboBox CmbCol
        {
            get
            {
                return cmbCol;
            }
            set
            {
                cmbCol = value;
            }
        }
        /// <summary>
        /// 量ﾋﾎﾎﾄﾗﾖﾁﾐ
        /// </summary>
        public bool IsClickCancel
        {
            get
            {
                return _isClickCancel;
            }
            set
            {
                _isClickCancel = value;
            }
        }

        /// <summary>
        /// 量ﾋﾜ･ｿ･ﾎ･ｯ･・ﾃ･ｯ･､･ﾙ･ﾈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.Find = txtSearch.Text;
            this.Close();
            //this.Hide();
        }

        /// <summary>
        /// ･ｭ･罕ｻ･・ﾜ･ｿ･ﾎ･ｯ･・ﾃ･ｯ･､･ﾙ･ﾈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalcel_Click(object sender, EventArgs e)
        {
            this.IsClickCancel = true;
            this.Close();
            //this.Hide();
        }
    }
}