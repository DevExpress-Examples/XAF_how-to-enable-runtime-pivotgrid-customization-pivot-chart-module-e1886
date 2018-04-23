using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;

namespace PivotGridCustomization.Module.Win {
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class PivotGridCustomizationWindowsFormsModule : ModuleBase {
        public PivotGridCustomizationWindowsFormsModule() {
            InitializeComponent();
        }
    protected override void RegisterEditorDescriptors(List<DevExpress.ExpressApp.Editors.EditorDescriptor> editorDescriptors) {
            base.RegisterEditorDescriptors(editorDescriptors);
            editorDescriptors.Add(new ViewItemDescriptor(new ViewItemRegistration(typeof(IModelPivotGridCustomizationItem), typeof(PivotGridCustomizationDetailViewItem), true)));
    }

    }
}
