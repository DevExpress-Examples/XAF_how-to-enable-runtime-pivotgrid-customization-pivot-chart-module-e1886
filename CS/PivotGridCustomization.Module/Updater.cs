using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace PivotGridCustomization.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            TestObject testObject = Session.FindObject<TestObject>(CriteriaOperator.Parse("Name == 'First'"));
            if (testObject == null) {
                TestObject first = new TestObject(Session);
                first.Name = "First";
                first.Value = 5;
                first.AnotherValue = 10;
                first.Save();
                TestObject second = new TestObject(Session);
                second.Name = "Second";
                second.Value = 15;
                second.AnotherValue = 3;
                second.Save();
                TestObject third = new TestObject(Session);
                third.Name = "Third";
                third.Value = 9;
                third.AnotherValue = 15;
                third.Save();
            }
        }
    }
}
