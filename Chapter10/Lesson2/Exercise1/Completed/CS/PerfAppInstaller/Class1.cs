using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Configuration.Install;
using System.ComponentModel;
using System.Collections;

namespace PerfAppInstaller
{
    [RunInstaller(true)]
    public class InstallCounter : Installer
    {
        public InstallCounter()
            : base()
        {
        }

        public override void Commit(IDictionary mySavedState)
        {
            base.Commit(mySavedState);
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            if (!PerformanceCounterCategory.Exists("PerfApp"))
                PerformanceCounterCategory.Create("PerfApp", "Counters for PerfApp",
                    PerformanceCounterCategoryType.SingleInstance,
                    "Clicks", "Times the user has clicked the button.");
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            if (PerformanceCounterCategory.Exists("PerfApp"))
                PerformanceCounterCategory.Delete("PerfApp");
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            if (PerformanceCounterCategory.Exists("PerfApp"))
                PerformanceCounterCategory.Delete("PerfApp");
        }
    }
}
