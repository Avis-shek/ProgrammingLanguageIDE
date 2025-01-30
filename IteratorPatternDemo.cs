using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace ProgrammingLanguageIDE
{
    public class IteratorPatternDemo
    {
        public  IteratorPatternDemo()
        {
            NameRepo nameRepo = new NameRepo();
            for (Iterator iter = nameRepo.GetIterator(); iter.HasNext();)
            {
                String name = (String)iter.Next();
                Console.WriteLine("Name : " + name);
            }
        }
    }
}

