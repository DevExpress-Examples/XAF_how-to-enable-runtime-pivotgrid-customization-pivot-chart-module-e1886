namespace PivotGridCustomization.Module.Win {
    partial class PivotGridCustomizationWindowsFormsModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            // 
            // PivotGridCustomizationWindowsFormsModule
            // 
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.Analysis));
            this.RequiredModuleTypes.Add(typeof(PivotGridCustomization.Module.PivotGridCustomizationModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule));

        }

        #endregion
    }
}
