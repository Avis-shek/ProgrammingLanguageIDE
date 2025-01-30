using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProgrammingLanguageIDE
{
    public class CommandParser
    {
        Shape s;
        int x, y, size;
        ShapeFactory sf;
        Color myColor;
        Pen pen;
        Form1 f1;
        internal protected bool if_state = false;
        internal protected bool multiLineIf = false;
        public bool MoveToCurrentStatus;
        public String MoveObject;
        public int moveXcor, moveYcor;

        public bool while_status = false;
        public  List<String> WhileStatement = new List<String>();
        public List<String> MultiIfStatement = new List<String>();
        String[] OperaterDelimiter = { "==", "<=", "<", ">", ">=", "!=" };
        String[] arithmeticOperator = { "+", "-", "/", "*" };
        public Dictionary<String, String> Variables = new Dictionary<String, String>();
        protected internal String PreError ;
        protected internal int PreErrorLine;
        public Dictionary<int, String> ErrorList = new Dictionary<int, String>();
        protected internal int count_while = 0;
        protected internal int count_if = 0;
        protected internal bool methodStatus = false;
        public CommandParser(Form1 f1)
        {
            sf = new ShapeFactory();
            this.f1 = f1;
        }

        /// <summary>
        /// This method is used to create different shape according to the user command.
        /// </summary>
        /// <param name="command">A string array containing the command and its parameters</param>
        /// <returns>A shape object corresponding to the specified command</returns>
        public Shape CommadParam(String[] command)
        {
            if (command.Length == 1)
            {
                TraceError($"\t error occured :\n\t\t Missing paramater for {command[0]}");
            }
            else
            {
                string method = command[0].Trim().ToUpper();
                string parameters = command[1].Trim().ToUpper();
                if(method.Equals("PEN"))
                    {
                    f1.penValidation(parameters);
                    
                }
                if(method.Equals("FILL"))
                    {
                    f1.fillValidation(parameters);
                }

             
                if (String.IsNullOrEmpty(parameters))
                {
                    TraceError($"\t error occured: \n\t\t Missing paramater for {method}");
                }
                else
                {
                    string[] paraStr = parameters.Split(',');
                    int[] paraInt = new int[paraStr.Length];
                        try
                        {
                            for (int i = 0; i < paraStr.Length; i++)
                            {
                                if (int.TryParse(paraStr[i], out _))
                                {
                                    paraInt[i] = int.Parse(paraStr[i]);
                                }
                                else
                                {
                                    paraInt[i] = int.Parse(Variables[paraStr[i].Trim()]);
                                }
                            }
                        try
                        {
                            switch (method)
                            {

                                case "CIRCLE":
                                    if (paraStr.Length == 1)
                                    {
                                        s = sf.getShape("CIRCLE");
                                        s.set(x, y, paraInt[0]);
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires only one parameter");
                                    }
                                    break;

                                case "RECTANGLE":
                                    if (paraStr.Length == 2)
                                    {
                                        s = sf.getShape("RECTANGLE");
                                        s.set(x, y, paraInt[0], paraInt[1]);
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires two parameter");
                                    }

                                    break;

                                case "SQUARE":
                                    if (paraStr.Length == 1)
                                    {
                                        s = sf.getShape("SQUARE");
                                        s.set(x, y, paraInt[0]);
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters}  for {method}\n\t\t It requires one parameter");
                                    }
                                    break;

                                case "TRIANGLE":
                                    if (paraStr.Length == 3)
                                    {
                                        s = sf.getShape("TRIANGLE");
                                        s.set(x, y, paraInt[0], paraInt[1], paraInt[2]);                                       
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires three parameter");
                                    }

                                    break;

                                case "MOVETO":
                                    if (paraStr.Length == 2)
                                    {
                                            x = paraInt[0];
                                            y = paraInt[1];
                                            s = sf.getShape("CIRCLE");
                                            s.set(x, y, 1);
                                        moveXcor = x;
                                        moveYcor = y;
                                        MoveToCurrentStatus = true;
                                        
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires two parameter");
                                    }

                                    break;

                                case "PEN":
                                    if(paraStr.Length == 1)
                                    {
                                        s = sf.getShape("CIRCLE");
                                        s.set(x, y, 0);
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires one parameter");
                                    }
                                    break;
                                case "DRAWTO":
                                    if (paraStr.Length == 2)
                                    {
                                        s = sf.getShape("DRAWTO");
                                        s.set(x, y, paraInt[0], paraInt[1]);
                                    }
                                    else
                                    {
                                        TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires two parameter");
                                    }

                                    break;

                                default:
                                    TraceError("\t error occured :\n\t\t Invalid parameter");
                                    break;
                            }
                            //if (method.Equals("MOVETO"))
                            //{
                            //    recentMoveTo.Add(s);
                            //}
                        }
                        catch (IndexOutOfRangeException)
                        {
                            TraceError($"\t error occured :\n\t\t Invalid parameter {parameters} for {method}\n\t\t It requires two parameter");
                        }

                    }
                    catch (Exception ex)
                    {
                        if (method != "PEN" && method != "FILL")
                        {
                            TraceError($"\tError occured :\n\t Variable {parameters} has not been initilized");
                        }
                    }
                } 
            }
            return s;
        }
        //To check if the given line is while statement
        /// <summary>
        /// This method is used to verify a while statement and to know when the reading is done.
        /// </summary>
        /// <param name="Statement">The condition of the while statement.</param>
        /// <param name="lastStatement">The last statement of the code block.</param>
        /// <returns>A boolean value indicating whether the while statement is still active or not.</returns>
        public bool verify_while_statement(string Statement, String lastStatement)// to know when the reading is done
        {
            if (Statement.Contains("WHILE"))
            {
                while_status = true;
            }
            if (WhileStatement.FirstOrDefault() != null)
            {
                if (WhileStatement.Last() == "ENDLOOP")
                {
                    while_status = false;
                }
            }

            if (while_status == true)
            {
                WhileStatement.Add(Statement);
                if(WhileStatement.Count == 1)
                {
                    While_state_validation(WhileStatement);
                } 
                if(WhileStatement.Count > 1 && WhileStatement.Last() != "ENDLOOP")
                {
                    ExecuteStatement(WhileStatement[count_while]);
                }
                count_while++;
            }
            if (WhileStatement.FirstOrDefault() != null)
            {
                if (WhileStatement.Last() == "ENDLOOP" || WhileStatement.Last() == lastStatement)

                {
                    While_state_validation(WhileStatement);
                }
            }
            return while_status;
        }

        public void While_state_validation(List<String> While_statement)
        {

            string[] delimiter_space = { " " };
            String[] while_condition = While_statement[0].Trim().Split(delimiter_space, 2, StringSplitOptions.RemoveEmptyEntries);
            if (while_condition.Length == 1)
            {
                TraceError($"\tError occured :\n\t Missing condition for while loop \n\t" +
                    $"Valid syntax for while : \n\t" +
                    $"while <condition> \n\t" + $"statement(n)\n\t" +
                    $"endloop" + $"");
            }
            else
            {
                for (int i = 0; i < OperaterDelimiter.Length; i++)
                {
                    if (while_condition[1].Trim().Contains(OperaterDelimiter[i]))
                    {
                        f1.ErrorRichBox.Text = "";
                        String[] w_condition = while_condition[1].Trim().Split(OperaterDelimiter, StringSplitOptions.RemoveEmptyEntries);
                        if (w_condition.Length <= 1)
                        {
                            TraceError($"\tError occured :\n\t invalid syntaxt{while_condition[1]}, Missing Condition or invalid Operator" +
                           $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                        }
                        else
                        { 
                                    f1.ErrorRichBox.Text = "";
                                    String leftVale = w_condition[0].Trim();
                                    String rightVale = w_condition[1].Trim();
                                    String Operator = OperaterDelimiter[i].Trim();
                                    whileOperation(leftVale, rightVale, Operator, While_statement);

                                
                            break;
                        }
                    }
                    //else
                    //{
                    //    TraceError($"\tError occured :\n\t invalid syntaxt {while_condition[1]}" +
                    //    $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                    //}
                }

            }
        }
       /// <summary>
       /// This method is to check if the given varibale is direct value or a varibale. If it is direct value then this methods convert it into integer and if it's a varibale it gives the correspondng value to that varibale
       /// </summary>
       /// <param name="Variablevalue">A varible that holds value and is here to be converted into string</param>
       /// <returns></returns>
        public int ConvertValueIntoInt(String Variablevalue)
        {
            int VarValue = 0;
            try
            {
                if (int.TryParse(Variablevalue.Trim(), out _))
                {
                    VarValue = int.Parse(Variablevalue.Trim());
                }
                else
                {
                    VarValue = int.Parse(Variables[Variablevalue.Trim()]);
                }


            }
            catch (Exception e)
            {
                if (VarValue == 0)
                {
                    TraceError($"\tError occured :\n\t Variable {Variablevalue} has not been initilized yet");
                }
            }
            return VarValue;
        }
        /// <summary>
        /// This method is used to perform operations within a while loop.
        /// </summary>
        /// <param name="left_value">The left value in the comparison statement</param>
        /// <param name="right_value">The right value in the comparison statement</param>
        /// <param name="Operator">The operator used in the comparison statement</param>
        /// <param name="statement">A list of statements to be executed within the while loop</param>
        public void whileOperation(String left_value, String right_value, String Operator, List<String> statement)
        {
            int LeftValue = 0, valueToBeCompared = 0;
            if (count_while == 0 || f1.validation_flag == false)
            {
                LeftValue = ConvertValueIntoInt(left_value);
                valueToBeCompared = ConvertValueIntoInt(right_value);
            }
            if (statement.Last() != "ENDLOOP")
            {
                if (count_while > 0)
                {
                    TraceError($"\tError occured :\n\t While loop is never termineted");
                }

            }
            else
            {
                List<String> Statements_while = new List<String>();
                for (int i = 0; i < statement.Count; i++)
                {
                    if (i != 0 && i != statement.Count - 1)
                    {
                        Statements_while.Add(statement[i]);
                    }
                }

                if (f1.validation_flag == false)
                {
                    switch (Operator)
                    {
                        case "==":
                            while (LeftValue == valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }

                            break;

                        case ">":
                            while (LeftValue > valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }
                            break;

                        case ">=":
                            while (LeftValue >= valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }
                            break;

                        case "<":
                            while (LeftValue < valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }
                            break;

                        case "<=":
                            while (LeftValue <= valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }
                            break;

                        case "!=":
                            while (LeftValue != valueToBeCompared)
                            {
                                foreach (String statements in Statements_while)
                                {
                                    ExecuteStatement(statements.Trim());
                                    LeftValue = ConvertValueIntoInt(left_value);
                                    valueToBeCompared = ConvertValueIntoInt(right_value);
                                }
                            }
                            break;
                        default:
                            TraceError($"\tError occured :\n\t invalid Operator {Operator}" +
                                       $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                            break;
                    }
                }
            }
        }
        // TO check if the given line is if statement or not
        /// <summary>
        /// This method is used to verify an if statement and to know when the reading is done.
        /// </summary>
        /// <param name="variable">The condition of the if statement.</param>
        /// <param name="lastStatement">The last statement of the code block.</param>
        /// <returns>A boolean value indicating whether the if statement is still active or not.</returns>
        public bool verify_if_statement(string variable, String lastStatement)
        {
            
            List<String> mulIfStatement = new List<String>();
            if (variable.Contains("IF") || multiLineIf == true)
            {
                if_state = true;
                if (variable.Contains("IF") && variable.Contains("THEN"))
                {
                    one_line_if_statement(variable);
                }
                else
                {
                    multiLineIf = true;
                    if (MultiIfStatement.FirstOrDefault() != null) // return false if IF statement is complete
                    {
                        if(MultiIfStatement.Last() == "ENDIF")
                        {
                            if_state = false;
                            multiLineIf =false;
                        }
                    }


                    if(multiLineIf == true) // adding statement for IF statement
                    {
                        MultiIfStatement.Add(variable);
                        if (MultiIfStatement.Count == 1)
                        {
                            MultiLine_if_statement(MultiIfStatement);
                        }
                        if (MultiIfStatement.Count > 1 && MultiIfStatement.Last() != "ENDIF")
                        {
                            ExecuteStatement(MultiIfStatement[count_if]);
                        }
                        count_if++;
                    }

                    if (MultiIfStatement.FirstOrDefault() != null)
                    {
                        if (MultiIfStatement.Last() == "ENDIF" || MultiIfStatement.Last() == lastStatement)

                        {
                            MultiLine_if_statement(MultiIfStatement);
                        }
                    }
                }
            }
            return if_state;
        }


        /// <summary>
        /// his method is used to handle one-line if statement.
        /// </summary>
        /// <param name="variable">The if statement in string format.</param>
        public void one_line_if_statement(string variable)
        {
            String[] DelimiterIf = { " " };
            String[] SplitedIf = variable.Trim().Split(DelimiterIf, 2, StringSplitOptions.RemoveEmptyEntries);
            String[] DelimiterThen = { "THEN" };
            String[] SplitedCondition = SplitedIf[1].Trim().Split(DelimiterThen, StringSplitOptions.RemoveEmptyEntries);
            if (SplitedCondition.Length < 1)
            {
                TraceError($"\tError occured :\n\t invalid Syntax for IF statement {SplitedIf} \n\t The Syntax must be If <Condition> Then <task>");
            }
            else
            {

                if (SplitedCondition.Length == 1)
                {
                    TraceError( $"\tError occured :\n\t invalid Syntax for IF statement {SplitedIf[1]}, Invalid Operator or Missing Condition \n\t The Syntax must be If <Condition> Then <statement>");
                }
                else
                {
                    String ifCondition = SplitedCondition[0].Trim();
                    for (int i = 0; i < OperaterDelimiter.Length; i++)
                    {
                        if (ifCondition.Contains(OperaterDelimiter[i]))
                        {
                            String[] varValue = ifCondition.Split(OperaterDelimiter, 2, StringSplitOptions.RemoveEmptyEntries);
                            String Variable = varValue[0].Trim();
                            String value = varValue[1].Trim();
                            if (!int.TryParse(Variable, out _) || !int.TryParse(value, out _)) //if both variable and value are int
                            {
                                if (Variables.ContainsKey(Variable) || Variables.ContainsKey(varValue[1]))
                                {

                                    String Operator = OperaterDelimiter[i].Trim();
                                    String[] splitted_ifCondition = SplitedCondition[0].Trim().Split(OperaterDelimiter, StringSplitOptions.RemoveEmptyEntries);
                                    List<String> task = new List<string>();
                                     task.Add(SplitedCondition[1].Trim());
                                    f1.ErrorRichBox.Text = "";
                                    ifOperation(Variable, value, Operator, task,"single");
                                }
                                else
                                {
                                    TraceError($"\tError occured :\n\t Variable {Variable} is undeclared variable");
                                }
                            }
                            else
                            {
                                String Operator = OperaterDelimiter[i].Trim();
                                String[] splitted_ifCondition = SplitedCondition[0].Trim().Split(OperaterDelimiter, StringSplitOptions.RemoveEmptyEntries);
                                List<String> task = new List<string>();
                                task.Add(SplitedCondition[1].Trim());
                                f1.ErrorRichBox.Text = "";
                                ifOperation(Variable, value, Operator, task,"single");
                            }
                            break;
                        }
                        else
                        {
                            TraceError($"\tError occured :\n\t invalid syntaxt {ifCondition}, Missing condition or Invalid Operator" +
                                $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// his method is for handling a multi-line if statement.
        /// </summary>
        /// <param name="MulIfStatement">The multi if statement in string format</param>
        public void MultiLine_if_statement(List<String> MulIfStatement)
        {
            string[] delimiter_space = { " " };
            String[] Mul_if_condition = MulIfStatement[0].Trim().Split(delimiter_space, 2, StringSplitOptions.RemoveEmptyEntries);
                if (Mul_if_condition.Length == 1)
                {
                TraceError($"\tError occured :\n\t Missing condition for If Statement \n\t" +
                        $"Valid syntax for If Statement : \n\t" +
                        $"if <condition> \n\t" + $"statement(n)\n\t" +
                        $"endif" + $"");
                }
         
                else
                {
                    for (int i = 0; i < OperaterDelimiter.Length; i++)
                    {
                        if (Mul_if_condition[1].Trim().Contains(OperaterDelimiter[i]))
                        {
                            //f1.ErrorRichBox.Text = "";
                            String[] if_condition = Mul_if_condition[1].Trim().Split(OperaterDelimiter, StringSplitOptions.RemoveEmptyEntries);
                            if (if_condition.Length <= 1)
                            {
                            TraceError($"\tError occured :\n\t invalid syntaxt, Missing operator or Invalid Condition for {Mul_if_condition[1]}" +
                               $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                            }
                            else
                            {
                                    ErrorList.Remove(f1.rowline);
                                    String leftVale = if_condition[0].Trim();
                                    String rightVale = if_condition[1].Trim();
                                    String Operator = OperaterDelimiter[i].Trim();
                                // seperating task of if statement
                                ifOperation(leftVale, rightVale, Operator, MulIfStatement,"multi");
                                }
                        break;
                        }
                        //else
                        //{
                        //   TraceError($"\tError occured :\n\t invalid syntaxt, Missing operator or Invalid Condition for {Mul_if_condition[1]}" +
                        //   $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                        //}
                    }
                }
            }
        /// <summary>
        /// executing all the statemet between if and endif
        /// </summary>
        /// <param name="Variable"></param>
        /// <param name="value"></param>
        /// <param name="Operator"></param>
        /// <param name="task"></param>
        /// <param name="source"></param>
        public void ifOperation(String Variable, String value, String Operator,  List<String> task,String source)
        {
            List<String> Statements_if = new List<String>();
            int VariableValue = 0, valueToBeCompared = 0;
            if (count_if == 0 || f1.validation_flag == false)
            {
                VariableValue = ConvertValueIntoInt(Variable);
                valueToBeCompared = ConvertValueIntoInt(value);
            }
            if (task.Last() != "ENDIF")
            {
                if (count_if > 0)
                {
                    TraceError($"\tError occured :\n\t If statement was never termineted");
                }
            }
            else
            {
               
                for (int i = 0; i < task.Count; i++)
                {
                    if (i != 0 && i != task.Count - 1)
                    {
                        Statements_if.Add(task[i]);
                    }
                }
            }

            if (source =="single")
            {
                
                for (int i = 0; i < task.Count; i++)
                {
                    Statements_if.Add(task[i]);
                }
             }
                     if (f1.validation_flag == false)
                        {
                            switch (Operator)
                            {
                                case "==":
                                    if (VariableValue == valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                case "<":
                                    if (VariableValue < valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                case ">":
                                    if (VariableValue > valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                case "<=":
                                    if (VariableValue <= valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                case ">=":
                                    if (VariableValue >= valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                case "!=":
                                    if (VariableValue != valueToBeCompared)
                                    {
                                        foreach (String statement in Statements_if)
                                        {
                                            ExecuteStatement(statement);
                                        }
                                    }
                                    break;
                                default:
                                    TraceError($"\tError occured :\n\t invalid syntaxt {Operator}" +
                                                $" \n\tThe valid Operators are '==' OR '<' OR '<=' OR  '>' OR '>='  OR '!='.");
                                    break;
                            }
                        }
                    
        }
        /// <summary>
        /// Verify if the given statement  is varibale and assign it to the given value
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool verify_store_variable(string variable)
        {
            bool v_status = false;
            char[] chars = variable.ToCharArray();
            foreach (char line in chars)
            {
                if (line.Equals('='))
                {
                    v_status = true;
                    String[] variables = variable.Split('=');
                    if (variables.Length == 2)
                    {

                        if (int.TryParse(variables[0].Trim(), out _))
                        {
                            TraceError($"\tError occured :\n\t invalid variable name {variables[0]} \n\t varible must be alphabetic word or character.");
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(variables[1].Trim()) || Regex.IsMatch(variables[1].Trim(),@"\s+?"))
                            {
                                TraceError($"\tError occured :\n\t Can not assign {variables[0]} to null.");
                            }
                            else
                            {
                                String Key = variables[0].Trim();
                                String Value = variables[1].Trim();
                                for (int i = 0; i < arithmeticOperator.Length; i++)
                                {
                                    if (variables[1].Trim().Contains(arithmeticOperator[i].Trim()))
                                    {
                                        String[] Operation = Value.Trim().Split(arithmeticOperator, 2, StringSplitOptions.RemoveEmptyEntries);

                                        String Left_Operand = Operation[0].Trim();
                                        String Right_Operand = Operation[1].Trim();
                                        String ArithmeticOperator = arithmeticOperator[i];
                                        if (!String.IsNullOrEmpty(Right_Operand))
                                        {
                                            int value = Calculate(Left_Operand, Right_Operand, ArithmeticOperator);
                                            if (value == 0)
                                            {
                                                Value = null;
                                            }
                                            else
                                            {
                                                Value = Convert.ToString(value);
                                            }

                                        }
                                        else
                                        {
                                            TraceError($"\tError occured :\n\t invalid Operands{Operation} to perform calculation");
                                        }

                                        break;
                                    }
                                    else
                                    {
                                        TraceError( $"\tError occured :\n\t Invalid Arithmetic operator,\n\t valid Operators are : \n\t '+' For Addition" +
                                            $"\n\t '-' For Subtraction" +
                                            $"\n\t '/' For Division" +
                                            $"\n\t '*' For Multiplication");
                                    }
                                }
                                if (Value != null)
                                {
                                    try
                                    {
                                        Variables.Add(Key.Trim(), Value.Trim());
                                        f1.ErrorRichBox.Text = "";
                                        if (ErrorList.Count != 0)
                                        {
                                            ErrorList.Remove(f1.rowline);
                                        }
                                    }
                                    catch (ArgumentException e)
                                    {
                                        Variables[Key] = Value.Trim();
                                        f1.ErrorRichBox.Text = "";
                                        if (ErrorList.Count != 0)
                                        {
                                            ErrorList.Remove(f1.rowline);
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        TraceError($"\tError occured :\n\t invalid command {variables}");
                    }
                    break;
                }
            }
            return v_status;
        }
        /// <summary>
        /// execute the statement given by various method
        /// </summary>
        /// <param name="statement"></param>
        public void ExecuteStatement(String statement)
        {
            bool var_status = false;
            String[] SpaceDelimeter = { " " };
            var_status = verify_store_variable(statement);
          
                    var_status = verify_store_variable(statement);
                    if (var_status == false)
                    {
                        f1.commandWithParam = statement.Split(SpaceDelimeter, 2, StringSplitOptions.RemoveEmptyEntries);
                        f1.CommandCheck(f1.commandWithParam);
                    }
        }

       /// <summary>
       /// perform the opereation on the base of given operator
       /// </summary>
       /// <param name="Left_operand"></param>
       /// <param name="right_operand"></param>
       /// <param name="Operator"></param>
       /// <returns></returns>
        public int Calculate(String Left_operand, String right_operand, String Operator)
        {
            float LeftValue = 0, RightValue = 0;
            int Result = 0;
            LeftValue = ConvertValueIntoInt(Left_operand);
            RightValue = ConvertValueIntoInt(right_operand);

            switch (Operator)
            {
                case "+":
                    Result = (int)Math.Round(LeftValue + RightValue);
                    break;
                case "-":
                    Result = (int)Math.Round(LeftValue - RightValue);
                    break;
                case "/":
                    Result = (int)Math.Round(LeftValue / RightValue);
                    break;
                case "*":
                    Result = (int)Math.Round(LeftValue * RightValue);
                    break;
                default:
                    TraceError($"\tError occured :\n\t Invalid Arithmetic operator,\n\t valid Operators are : \n\t '+' For Addition" +
                                            $"\n\t '-' For Subtraction" +
                                            $"\n\t '/' For Division" +
                                            $"\n\t '*' For Multiplication");
                    break;
            }
            return Result;
        }
        /// <summary>
        /// Strore all the trrown erros and store it to the dictionary
        /// </summary>
        /// <param name="ErrorMessage"></param>
        public void TraceError(String ErrorMessage)
        {
            String ErrorLine = $"Error at Line No. {f1.rowline}";
            String Error = $"{ErrorLine}\n {ErrorMessage.Trim()}\n\n";
            try
            {
                ErrorList.Add(f1.rowline, Error.Trim());
            }
            catch(Exception e) 
            {

                ErrorList[f1.rowline] = Error.Trim();
            }
           
           
            
            //if(PreError != ErrorMessage && PreErrorLine != f1.rowline)
            //{
            //    PreError = ErrorMessage;
            //    PreErrorLine = f1.rowline;
            //    f1.ErrorRichBox.Text += $"{ErrorLine}\n {ErrorMessage}\n\n";
            //}else if (PreErrorLine != f1.rowline && f1.typeCodeRichText.Lines.ElementAt(f1.rowline - 1) != "")
            //{
            //    PreError = ErrorMessage;
            //    PreErrorLine = f1.rowline;
            //    f1.ErrorRichBox.Text += $"{ErrorLine}\n {ErrorMessage}\n\n";
            //}else if (PreError == ErrorMessage && PreErrorLine != f1.rowline && f1.keyBack == true)
            //{
            //    PreError = ErrorMessage;
            //    PreErrorLine = f1.rowline;
            //    f1.ErrorRichBox.Text += $"{ErrorLine}\n {ErrorMessage}\n\n";
            //}

        }

    }
}
