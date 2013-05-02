using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Collections;
using System.IO;
using System.Configuration.Install;
using System.ComponentModel;

namespace Hello
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    [RunInstaller(true)]
    public class HelloInstaller : Installer
    {
        public HelloInstaller()
            : base()
        {
        }

        public override void Commit(IDictionary mySavedState)
        {
            base.Commit(mySavedState);
            System.IO.File.CreateText("Commit.txt");
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            System.IO.File.CreateText("Install.txt");
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete("Commit.txt");
            File.Delete("Install.txt");
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            File.Delete("Install.txt");
        }
    }

}
