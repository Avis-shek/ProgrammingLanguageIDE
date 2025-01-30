using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    public abstract class NameRepository : Container
    {
        public abstract Iterator GetIterator();
    }

    public abstract class NIterator : Iterator
    {
        public abstract bool HasNext();

        public abstract Object Next();
    }
}
