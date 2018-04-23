using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotChart.Win;

namespace PivotGridCustomization.Module.Win {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        private void CreateTestAnalysis() {
            Analysis testAnalysis = Session.FindObject<Analysis>(CriteriaOperator.Parse("Name='Test Analysis'"));
            if (testAnalysis == null) {
                testAnalysis = new Analysis(Session);
                testAnalysis.Name = "Test Analysis";
                testAnalysis.ObjectTypeName = typeof(TestObject).FullName;
                using (AnalysisControlWin control = new AnalysisControlWin()) {
                    control.DataSource = new AnalysisDataSource(testAnalysis, new XPCollection<TestObject>(testAnalysis.Session));
                    control.Fields["Name"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                    control.Fields["Value"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                    control.Fields["AnotherValue"].Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
                    PivotGridSettingsHelper.SavePivotGridSettings(new PivotGridControlSettingsStore((control.PivotGrid)), testAnalysis);
                }
                testAnalysis.Save();
            }
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            CreateTestAnalysis();
        }
    }
}
