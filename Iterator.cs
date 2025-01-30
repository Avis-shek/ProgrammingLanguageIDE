using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    public interface Iterator
    {
        bool HasNext();
        Object Next();

    }

    public interface Container
    {
         Iterator GetIterator();
    }
}
