using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;
using System.Drawing;

namespace WindowsFormsApplication85
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            var list = new BindingList<Item>();
            for (int i = 0; i < 5; i++)
                list.Add(new Item() { CategoryID = i, CategoryName = "Test name" + i, Description = "Description" + i, Picture = imageCollection1.Images[i] });
            gridControl1.DataSource = list;
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridControl1) return;
            ToolTipControlInfo info = null;
            SuperToolTip sTooltip1 = new SuperToolTip();
            try
            {
                GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
                if (view == null) return;
                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                if (hi.HitTest == GridHitTest.RowIndicator)
                {
                    info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                    ToolTipTitleItem titleItem1 = new ToolTipTitleItem();
                    Image im = view.GetRowCellValue(hi.RowHandle, "Picture") as Image;
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
    }
    public class Item
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Image Picture { get; set; }
    }
}
