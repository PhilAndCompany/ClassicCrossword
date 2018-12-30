using ClassicCrossword.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCrossword.Model
{
    class Other
    {
        public static void AboutAuthors()
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == "AboutAuthor")
                    return;
            AboutAuthors form = new AboutAuthors();
            form.Show();
        }

        public static void UserManual()
        {
            //get current folderpath of the .exe
            string ProgramPath = AppDomain.CurrentDomain.BaseDirectory;
            //jump back relative to the .exe-Path to the Resources Path
            string FileName = string.Format("{0}Resources\\crosswordGuide.chm"
                , Path.GetFullPath(Path.Combine(ProgramPath, @"..\..\")));

            //Open PDF
            // System.Diagnostics.Process.Start(@"" + FileName + "");
            if (System.IO.File.Exists(FileName))
            {
                System.Diagnostics.Process.Start(FileName);
            }

        }

    /*    public static void Help()
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == "HelpUser")
                    return;
            HelpUser form = new HelpUser();
            form.Show();
        }*/
    }
}
