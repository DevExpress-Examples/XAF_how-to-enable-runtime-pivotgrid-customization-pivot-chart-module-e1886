using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraEditors;
using DevExpress.ExpressApp.PivotChart.Win;
using DevExpress.ExpressApp;
using System.Drawing;
using DevExpress.ExpressApp.Model;

namespace PivotGridCustomization.Module.Win {
    public interface IModelPivotGridCustomizationItem : IModelDetailViewItem {
    }

    [DetailViewItemName("PivotGridCustomizationItem")]
    public class PivotGridCustomizationDetailViewItem : ViewItem {
        private AnalysisEditorWin analysisEditor;
        private CheckEdit showColumnGrandTotalCheckEdit;
        private CheckEdit showRowGrandTotalCheckEdit;

        private void SubscribeEditorEvents() {
            if (analysisEditor != null) {
                analysisEditor.PivotGridSettingsLoaded += new EventHandler(AnalysisEditor_PivotGridSettingsLoaded);
                analysisEditor.IsDataSourceReadyChanged += new EventHandler<EventArgs>(AnalysisEditor_IsDataSourceReadyChanged);
            }
        }
        private void UnsubscribeEditorEvents() {
            if (analysisEditor != null) {
                analysisEditor.PivotGridSettingsLoaded -= new EventHandler(AnalysisEditor_PivotGridSettingsLoaded);
                analysisEditor.IsDataSourceReadyChanged -= new EventHandler<EventArgs>(AnalysisEditor_IsDataSourceReadyChanged);
            }
        }
        private void AnalysisEditor_IsDataSourceReadyChanged(object sender, EventArgs e) {
            bool isEnabled = analysisEditor.IsDataSourceReady;
            showRowGrandTotalCheckEdit.Enabled = isEnabled;
            showColumnGrandTotalCheckEdit.Enabled = isEnabled;
            if (!isEnabled) {
                showRowGrandTotalCheckEdit.Checked = false;
                showColumnGrandTotalCheckEdit.Checked = false;
            }
        }
        private void AnalysisEditor_PivotGridSettingsLoaded(object sender, EventArgs e) {
            showRowGrandTotalCheckEdit.Checked = analysisEditor.Control.PivotGrid.OptionsView.ShowRowGrandTotals;
            showColumnGrandTotalCheckEdit.Checked = analysisEditor.Control.PivotGrid.OptionsView.ShowColumnGrandTotals;
        }
        private void showRowGrandTotalCheckEdit_CheckedChanged(object sender, EventArgs e) {
            if (analysisEditor != null && analysisEditor.Control != null) {
                analysisEditor.Control.PivotGrid.OptionsView.ShowRowGrandTotals = showRowGrandTotalCheckEdit.Checked;
            }
        }
        private void showColumnGrandTotalCheckEdit_CheckedChanged(object sender, EventArgs e) {
            if (analysisEditor != null && analysisEditor.Control != null) {
                analysisEditor.Control.PivotGrid.OptionsView.ShowColumnGrandTotals = showColumnGrandTotalCheckEdit.Checked;
            }
        }
        protected override object CreateControlCore() {
            XtraUserControl control = new XtraUserControl();

            showRowGrandTotalCheckEdit = new CheckEdit();
            showRowGrandTotalCheckEdit.Properties.Caption = "Show Row Grand Total";
            showRowGrandTotalCheckEdit.Location = new Point(0, 0);
            showRowGrandTotalCheckEdit.Size = showRowGrandTotalCheckEdit.CalcBestSize();
            showRowGrandTotalCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            showRowGrandTotalCheckEdit.CalcBestSize();
            showRowGrandTotalCheckEdit.Enabled = false;
            showRowGrandTotalCheckEdit.CheckedChanged += new EventHandler(showRowGrandTotalCheckEdit_CheckedChanged);

            showColumnGrandTotalCheckEdit = new CheckEdit();
            showColumnGrandTotalCheckEdit.Properties.Caption = "Show Column Grand Total";
            showColumnGrandTotalCheckEdit.Location = new Point(0, 20);
            showColumnGrandTotalCheckEdit.Size = showColumnGrandTotalCheckEdit.CalcBestSize();
            showColumnGrandTotalCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            showColumnGrandTotalCheckEdit.CalcBestSize();
            showColumnGrandTotalCheckEdit.Enabled = false;
            showColumnGrandTotalCheckEdit.CheckedChanged += new EventHandler(showColumnGrandTotalCheckEdit_CheckedChanged);

            control.Controls.Add(showColumnGrandTotalCheckEdit);
            control.Controls.Add(showRowGrandTotalCheckEdit);

            control.Size = control.GetPreferredSize(new Size());
            control.MaximumSize = new Size(0, control.Size.Height);
            control.MinimumSize = new Size(0, control.Size.Height);

            return control;
        }
        public PivotGridCustomizationDetailViewItem(Type classType, string id)
            : base(classType, id) {
        }
        public PivotGridCustomizationDetailViewItem(IModelPivotGridCustomizationItem model, Type classType)
            : base(classType, model.Id) {
        }
        public void SetAnalysisEditor(AnalysisEditorWin analysisEditor) {
            UnsubscribeEditorEvents();
            this.analysisEditor = analysisEditor;
            SubscribeEditorEvents();
        }
    }
}
