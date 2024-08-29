<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128632546/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E301)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Display popup images for grid rows (row indicator)

This example shows how to display super tooltips with images when a user hovers over a row indicator.

See the implementation of the [ToolTipController.GetActiveObjectInfo](https://docs.devexpress.com/WindowsForms/DevExpress.Utils.ToolTipController.GetActiveObjectInfo) event:

```csharp
private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
    if (e.SelectedControl != gridControl1) return;
    ToolTipControlInfo info = null;
    SuperToolTip sTooltip1 = new SuperToolTip();
    try {
        GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
        if (view == null) return;
        GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
        if (hi.HitTest == GridHitTest.RowIndicator) {
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
    finally {
        e.Info = info;
    }
}
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Data Grid Tooltips](https://docs.devexpress.com/WindowsForms/3512/controls-and-libraries/data-grid/data-grid-tooltips)
* [Hit Information](https://docs.devexpress.com/WindowsForms/3511/controls-and-libraries/data-grid/hit-information)
* [Hints and Tooltips](https://docs.devexpress.com/WindowsForms/2398/common-features/tooltips)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-popup-image-on-mouse-hover&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-display-popup-image-on-mouse-hover&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
