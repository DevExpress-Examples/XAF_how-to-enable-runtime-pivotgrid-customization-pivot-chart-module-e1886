using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotChart.Win;

namespace PivotGridCustomization.Module.Win {
    public class PivotGridCustomizationDetailViewItemBindingController : AnalysisViewControllerBase {
        private PivotGridCustomizationDetailViewItem FindPivotGridCustomizationItem() {
            DetailView view = (DetailView)View;
            IList<PivotGridCustomizationDetailViewItem> items = view.GetItems<PivotGridCustomizationDetailViewItem>();
            if (items.Count != 0) {
                return items[0];
            }
            return null;
        }
        private void BindPivotGridCustomizationItemToEditor(AnalysisEditorWin analysisEditor) {
            PivotGridCustomizationDetailViewItem customizationItem = FindPivotGridCustomizationItem();
            if (customizationItem != null) {
                customizationItem.SetAnalysisEditor(analysisEditor);
            }
        }
        protected override void OnAnalysisControlCreated() {
            base.OnAnalysisControlCreated();
            BindPivotGridCustomizationItemToEditor((AnalysisEditorWin)analysisEditor);
        }
        protected override void OnDeactivated() {
            BindPivotGridCustomizationItemToEditor(null);
            base.OnDeactivated();
        }
    }
}
