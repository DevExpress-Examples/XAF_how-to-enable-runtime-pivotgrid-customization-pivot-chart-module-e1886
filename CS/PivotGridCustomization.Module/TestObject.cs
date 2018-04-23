using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace PivotGridCustomization.Module {
    [DefaultClassOptions]
    [VisibleInReports]
    public class TestObject : BaseObject {
        public TestObject(Session session) : base(session) { }

        string name;
        private int value;
        private int anotherValue;

        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        public int Value {
            get { return value; }
            set { SetPropertyValue("Value", ref this.value, value); }
        }
        public int AnotherValue {
            get { return anotherValue; }
            set { SetPropertyValue("AnotherValue", ref this.anotherValue, value); }
        }
    }
}
