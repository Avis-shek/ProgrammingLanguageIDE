using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgrammingLanguageIDE
{
    internal class Method
    {
        protected internal ArrayList methodList = new ArrayList();
        protected internal ArrayList methodCodeBlockLines = new ArrayList();
        protected internal Dictionary<string, string> methodLocalVar = new Dictionary<string, string>();
        protected internal bool called;
        CommandParser cparser;
        Form1 f1;
        public Method(Form1 f1, CommandParser cp)
        {
            this.cparser = cp;
            this.f1 = f1;
        }

        /// <summary>
        /// Performs action for method to operate
        /// </summary>
        /// <param name="text">contains parameters, statements from within method</param>
        /// <returns></returns>
        public void Operate_Method(string text, bool called, string param)
        {
            if (called)
            {
                this.called = called;
                string[] calledMethod = text.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    for (int i = 1; i <= cparser.Variables.Count; i++)
                    {
                        string key = cparser.Variables.ElementAt(i - 1).Key;
                        cparser.Variables[key] = calledMethod[i];
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (calledMethod.Length > 1)
                        cparser.TraceError($"Invalid Parameter for * Method {calledMethod[1]} *\"\nNumber of parameters required: {cparser.Variables.Count}");
                }

                foreach (string line in methodCodeBlockLines)
                {
                    cparser.ExecuteStatement(line);
                }
                this.called = false;
                return;
            }

            string[] methodStat = text.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (methodStat.Length > 1 && Regex.IsMatch(methodStat[0].Trim().ToUpper(), @"^METHOD{1}"))
            {
                if (Regex.IsMatch(methodStat[1], @"[A-Z]\w?\s?", RegexOptions.IgnoreCase))//method name matching
                {

                    if (Regex.IsMatch(methodStat[1], @"[A-Z]\w\({1}\){1}$")) //works for no param meth
                    {
                        methodStat = methodStat[1].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        methodList.Add(methodStat[0].Trim().ToUpper());
                        cparser.methodStatus = true; //activating the flag
                        if (cparser.ErrorList.Count != 0) cparser.ErrorList.Remove(f1.rowline);
                    }
                    else if (Regex.IsMatch(methodStat[1], @"[A-Z]\w?\s?\({1}[A-Z]+((,.[A-Z]+)+)?\){1}$"))//works for multiple params
                    {
                        methodStat = methodStat[1].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        methodList.Add(methodStat[0].Trim().ToUpper());
                        if (methodStat.Length > 1) //for handling and operating single and multiple parameters
                            for (int i = 1; i < methodStat.Length; i++)
                            {
                                methodStat[i] = methodStat[i].Trim().ToUpper();
                                cparser.Variables.Add(methodStat[i], ""); //adding method's local parameters to arraylist one at a time
                            }

                        cparser.methodStatus = true;
                        //if (cparser.ErrorList.Count != 0) cparser.ErrorList.Remove(f1.rowline);
                    }
                    else
                        cparser.TraceError($"Invalid Parameter for * Method {methodStat[1]} *\nYou are missing () or (param name...)");
                }
                else
                    cparser.TraceError($"Invalid Method Name {methodStat[1]}\nMust Start with an alpha character.");
            }
            else if (Regex.IsMatch(text, @"(\s+|^)ENDMETHOD{1}$", RegexOptions.IgnoreCase)) // works for endmethod termination
            {
                cparser.methodStatus = false;
                return;
            }
            else if (cparser.methodStatus)
                methodCodeBlockLines.Add(text);
            else
                cparser.TraceError($"Invalid Syntax for {methodStat[0]}\nThe Correct Syntax is * Method yourMethodName(<parameter>) *");
        }
    }
}
