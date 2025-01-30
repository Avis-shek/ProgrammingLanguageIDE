using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    internal class NameRepo:NameRepository
    {
        static String[] OperaterDelimiter = { "==", "<=", "<", ">", ">=", "!=" };
        public override Iterator GetIterator()
        {
            return new NameIterator();
        }
        public class NameIterator : NIterator
        {
            int index;
            public override bool HasNext()
            {
                if (index < OperaterDelimiter.Length)
                {
                    return true;
                }
                return false;

            }

            public override Object Next()
            {

                if (this.HasNext())
                {
                    return OperaterDelimiter[index++];
                }
                return null;
            }
        }
    }
}
