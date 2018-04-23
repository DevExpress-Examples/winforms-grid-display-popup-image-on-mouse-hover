using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;

namespace WindowsFormsApplication85
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
            //this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);
            nwindDataSet.ReadXml(@"..\..\Categories");

        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridControl1) return;
            ToolTipControlInfo info = null;

            SuperToolTip sTooltip1 = new SuperToolTip();
       

            try
            {
                GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
                if (view == null) return;
                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                //if (hi.InRowCell)
                //{
                //    info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), GetCellHintText(view, hi.RowHandle, hi.Column));
                //    return;
                //}
                //if (hi.Column != null)
                //{
                //    info = new ToolTipControlInfo(hi.Column, GetColumnHintText(hi.Column));
                //    return;
                //}
                //if (hi.HitTest == GridHitTest.GroupPanel)
                //{
                //    info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                //    return;
                //}

                if (hi.HitTest == GridHitTest.RowIndicator)
                {
                    info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                    ToolTipTitleItem titleItem1 = new ToolTipTitleItem();
                    byte[] cellIm = view.GetRowCellValue(hi.RowHandle, "Picture") as byte[];
                    Image im = null;
                    if (cellIm != null)
                    {
                        MemoryStream ms = new MemoryStream(cellIm);

                        im = Image.FromStream(ms);
                    }
                    
                    ToolTipItem item1 = new ToolTipItem();
                    item1.Image = im;
                    sTooltip1.Items.Add(item1);
                }
                info = new ToolTipControlInfo(hi.HitTest, "");
                info.SuperTip = sTooltip1;
            }
            finally
            {
                e.Info = info;
            }
        }

        private string GetColumnHintText(DevExpress.XtraGrid.Columns.GridColumn gridColumn)
        {
            throw new NotImplementedException();
        }

        private string GetCellHintText(GridView view, int p, DevExpress.XtraGrid.Columns.GridColumn gridColumn)
        {
            throw new NotImplementedException();
        }

    }
}
