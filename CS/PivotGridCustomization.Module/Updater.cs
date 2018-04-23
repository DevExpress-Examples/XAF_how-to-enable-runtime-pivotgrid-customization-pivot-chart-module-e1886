using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace PivotGridCustomization.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            TestObject testObject = ObjectSpace.FindObject<TestObject>(CriteriaOperator.Parse("Name == 'First'"));
            if (testObject == null) {
                TestObject first = ObjectSpace.CreateObject<TestObject>();
                first.Name = "First";
                first.Value = 5;
                first.AnotherValue = 10;
                first.Save();
                TestObject second = ObjectSpace.CreateObject<TestObject>();
                second.Name = "Second";
                second.Value = 15;
                second.AnotherValue = 3;
                second.Save();
                TestObject third = ObjectSpace.CreateObject<TestObject>();
                third.Name = "Third";
                third.Value = 9;
                third.AnotherValue = 15;
                third.Save();
            }
        }
    }
}
