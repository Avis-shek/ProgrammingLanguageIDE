using AngleSharp.Media.Dom;
using AngleSharp.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup.Localizer;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace ProgrammingLanguageIDE
{
    public partial class Form1 : Form
    {
        // Store valid possible commands to a string for validating entered commands
        String[] CommandToRun = { "RUN", "CLEAR", "RESET" };
        String[] shapes = { "CIRCLE", "RECTANGLE", "TRIANGLE", "DRAWTO", "MOVETO", "PEN", "SQUARE","FILL","RUN","CLEAR","RESET"};
        // create object to a class "Command Parser" so that the method created in that class will be accessciable on this class
        CommandParser cparser;
        // Shape varibale to store shape returned by shape factory 
        Shape ShapeToBeDrawn;
        // color variable to store user choice color
        public  Color userColor;
        // bool to strore the decison if the user want to fill the shape or not
        public bool fill;
        // ArrayList to store avilable colors
        ArrayList ColorList = new ArrayList();
        public String[] commandWithParam;
        // counter to activate timer1
        int counter;
        // to store the current line of the given chunk of code 
        protected internal int rowline = 1;
        int Rline = 0;
        // create an object for both bitmap and graphics
        Bitmap bm;
        Graphics g;
        // bool to check if the codes are executed for validation or Run
        protected internal bool validation_flag = false;
        Method method;
        List<Shape> drawnShape = new List<Shape>();
        protected internal Thread f_Thread;
        public Form1()
        {
            InitializeComponent();
            cparser = new CommandParser(this); // Object of an class "cpmmand parser"
            bm = new Bitmap(OutputArea.Width, OutputArea.Height); // setting bitmap
            g = Graphics.FromImage(bm); // setting graphics
            userColor = Color.White; // making white color as a defult color
            method = new Method(this,cparser);


            // adding color to colorlist
            ColorList.Add("RED");
            ColorList.Add("GREEN");
            ColorList.Add("BLUE");
            ColorList.Add("YELLOW");
            ColorList.Add("ORANGE");
            ColorList.Add("PINK");
            ColorList.Add("WHITE");

        }
        /// <summary>
        /// A method to exit from the application if user wish to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit the programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)// Asking for confirmation if the user really want to exit the programm
            {
                if(f_Thread!= null) f_Thread.Abort();
                
                Application.Exit();
            }
        }

        /// <summary>
        /// Reset varibales or dictionary or list, Read everything from programming area  and send each statement to the respective methods to identify the statement type and execute accordingly
        /// </summary>
        /// <param name="Source">To identify the source</param>
        private void ReadProgrammingArea(String Source)
        {
            // Resseting all varibale, List and dictionary to default value
            if(Source == "Validation")
            {
                validation_flag = true;
            }

            cparser.while_status = false; // setting while status false as default
            cparser.if_state = false; // setting if status false as default
            cparser.multiLineIf = false; // setting multiline if statement to false as default
            bool variable_status= false;
            cparser.Variables.Clear(); // clearing the Dictionary that holds variable and values
            cparser.WhileStatement.Clear(); // clearing A arraylist that holds statement for while loops
            cparser.MultiIfStatement.Clear();// Clearing a arraylist that holds statement of multi line if
            cparser.ErrorList.Clear(); // clearing a dictionary  that holds all occured errors
            rowline = 1; // ressting rowline to 1
            Rline = 0; // resetting Rline to 0
            cparser.count_while = 0; // resetting count_while
            cparser.count_if = 0; // resetting count_if
            g.Clear(Color.Transparent); // Clear the graphic
            String[] SpaceDelimeter = { " " }; // Creating a string array to strore delimiter so that it can be used to split string 
            if (cparser != null)
            {
                // Setting pen position to 0,0 when run button is clicked
                ShapeToBeDrawn = cparser.CommadParam(new string[] { "MOVETO", "0,0" });
                fill = false;
                userColor = Color.White;
            }
            String[] lines = typeCodeRichText.Text.ToUpper().Trim().Split('\n'); // Gets everything from programming area

            if (lines.Length == 0 || lines[0] == "")
            {// Showing errors if the programming area is empty
                cparser.TraceError("\tError occured :\n\tEnter codes in programming area first to execute the program...\n");
            }
            else
            {
                // Foreach loop to access each line and send it to respective method to identify if the statement is while statement or single line if or multiline if or variable or method with or without parameteres or a shape that is sent to be drawn 
                foreach (String line in lines)
                {
                    if(Rline >= 1)
                    {
                        rowline++;
                    }


                    if (Regex.IsMatch(line.Trim().ToUpper(), @"^\s?METHOD{1}") || cparser.methodStatus || Regex.IsMatch(line, @"^ENDMETHOD$"))
                    {
                        method.Operate_Method(line.Trim().ToUpper(), false, ""); //false = not called
                        continue;
                    }
                    else
                    {
                        string[] calledMethod = line.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (method.methodList.Contains(calledMethod[0].Trim().ToUpper()))
                        {
                            if (Regex.IsMatch(line, @"[A-Z]\w+?\s?\({1}[0-9]+((,.[0-9]+)+)?\){1}$", RegexOptions.IgnoreCase))
                            {
                                method.Operate_Method(line.Trim().ToUpper(), true, "YesParams"); //true = called
                                continue;
                            }
                            else if (Regex.IsMatch(line, @"[A-Z]\w+?\s?\({1}\){1}$", RegexOptions.IgnoreCase)) //works for no param meth
                            {
                                method.Operate_Method(line.Trim().ToUpper(), true, "NoParams");
                                continue;
                            }
                        }


                        if (cparser.verify_while_statement(line, lines[lines.Length - 1]) == false)
                        {
                            if (cparser.verify_if_statement(line, lines[lines.Length - 1]) == false)
                            {
                                variable_status = cparser.verify_store_variable(line);
                                if (variable_status == false)
                                {
                                    commandWithParam = line.Split(SpaceDelimeter, 2, StringSplitOptions.RemoveEmptyEntries);
                                    CommandCheck(commandWithParam);
                                }
                            }
                        }
                    }

                    
                    Rline++;
                }
            }
        }
/// <summary>
/// setting given color to pen pen color so that user can draw and fill shapes in different color
/// </summary>
/// <param name="color"> A variable that contains user selected color</param>
        public void setPenColor(String color)
        {
            //Get color choice from user and set it
            switch (color)
            {
                case "RED":
                    userColor = Color.Red;
                    break;
                case "GREEN":
                    userColor = Color.Green;
                    break;
                case "BLUE":
                    userColor = Color.Blue;
                    break;
                case "YELLOW":
                    userColor = Color.Yellow;
                    break;
                case "ORANGE":
                    userColor = Color.Orange;
                    break;
                case "PINK":
                    userColor = Color.Pink;
                    break;
                case "WHITE":
                    userColor = Color.White;
                    break;
            }
        }
        /// <summary>
        /// setting fill status that is on or off
        /// </summary>
        /// <param name="Fillstatus">A variable that holds fill status/param>
        public void setFillStatus(String Fillstatus)
        {
            if(Fillstatus.Equals("ON"))
                {
                fill = true;
            }
            if (Fillstatus.Equals("OFF"))
            {
                fill = false;
            }

        }
        /// <summary>
        /// validates the fill command and thrwos error if there any and set the fill status accordingly 
        /// </summary>
        /// <param name="FillWithParam"> A variable that contains fill status to be validated </param>
        public void fillValidation(String FillWithParam)
        {
            if(!int.TryParse(FillWithParam, out _))
            {
                if (FillWithParam.Equals("ON"))
                {
                    setFillStatus(FillWithParam);
                }
                else if(FillWithParam.Equals("OFF"))
                {
                    setFillStatus(FillWithParam);
                }
                else
                {
                    cparser.TraceError("\tError occured :\n\t invalid fill status");
                }
            }
            else
            {
                cparser.TraceError("\tError occured :\n\t invalid fill status");
            }
        }
        /// <summary>
        /// validates the pen command, Throw error if there any and set the pen color accordingly
        /// </summary>
        /// <param name="color"> A varibale that holds user given color to be validate</param>
     public void penValidation(String color)
        {
            if(!int.TryParse(color, out _))
            {
                if(ColorList.Contains(color))
                {
                    setPenColor(color);
                }
                else
                {
                    cparser.TraceError("\tError occured :\n\t Invalid color, Please select one of the following :" +
                        " \n\t 1. Red" +
                        "\n\t 2. Green" +
                        "\n\t 3. Blue " +
                        "\n\t 3. Yellow " +
                        "\n\t 3. Orange " +
                        "\n\t 3. Pink " +
                        "\n\t 3.  White");
                }
            }
            else
            {
                cparser.TraceError("\tError occured :\n\t invalid color name");
            }
        }
        /// <summary>
        /// This method is to validate the user given command and act on it accordingly, For example if user give command like circle<radius> the the circle will be drawn with the size of given radius, And also throw errors if there any
        /// /// </summary>
        /// <param name="command"> A varibale that holds command to be executed as drawn</param>
        public void CommandCheck(String[] command)
        {
            // dispose method is treating bm as a garbage aftern first use so reinitializing the bm 
           OutputArea.Image = new Bitmap(OutputArea.Width, OutputArea.Height);

            string method = command[0].Trim().ToUpper();

           // string parameters = command[1].Trim().ToUpper();
            if (cparser.MoveToCurrentStatus == true)
            {
                if (cparser.moveXcor != null && cparser.moveYcor != null)
                {
                    Shape shapemove = new Circle();
                    shapemove.set(cparser.moveXcor, cparser.moveYcor, 1);
                    shapemove.draw(g, false, Color.Black);

                }
            }
            cparser.CommadParam(command);
            if (validation_flag == false)
            {
                switch (method)
                {
                    case "RUN":
                        ReadProgrammingArea("Run");
                        break;
                    case "CLEAR":
                        if (OutputArea.Image != null)
                        {
                            OutputArea.Image.Dispose();
                            OutputArea.Image = null;
                            ShapeToBeDrawn = null;
                            commandWithParam = null;
                            g.Clear(Color.Transparent);
                            ErrorRichBox.Text = "";



                        }
                        break;
                    case "RESET":
                        if (cparser != null)
                        {
                            ShapeToBeDrawn = cparser.CommadParam(new string[] { "MOVETO", "0,0" });
                            fill = false;
                            userColor = Color.White;
                            counter = 0;
                            msgPopup("Success, Position reset to 0,0");
                            ErrorRichBox.Text = "";
                        }
                        break;
                    case "GREENYELLOW":
                        f_Thread = new Thread(() =>
                        {
                            Flashthecolor(true, Color.Green, Color.Yellow);
                        });
                        f_Thread.Start();
                        break;
                    case "REDGREEN":
                        f_Thread = new Thread(() =>
                        {
                            Flashthecolor(true, Color.Red, Color.Green);
                        });
                        f_Thread.Start();
                        break;
                    case "BLUEYELLOW":
                        f_Thread = new Thread(() =>
                        {
                            Flashthecolor(true, Color.Blue, Color.Yellow);
                        });
                        f_Thread.Start();
                        break;
                    case "WHITEGREEN":
                        f_Thread = new Thread(() =>
                        {
                            Flashthecolor(true, Color.White, Color.Green);
                        });
                        f_Thread.Start();
                        break;


                    default:
                        //ErrorRichBox.Text = "";
                        switch (method)
                        {

                            case "CIRCLE":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;
                                    drawnShape.Add(ShapeToBeDrawn);

                                }
                                break;
                            case "RECTANGLE":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;
                                    drawnShape.Add(ShapeToBeDrawn);
                                }
                                break;
                            case "TRIANGLE":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;
                                    drawnShape.Add(ShapeToBeDrawn);

                                }
                                break;
                            case "DRAWTO":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;
                                    drawnShape.Add(ShapeToBeDrawn);

                                }
                                break;
                            case "MOVETO":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;

                                }
                                break;
                            case "PEN":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;

                                }
                                break;
                            case "SQUARE":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {
                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;
                                    drawnShape.Add(ShapeToBeDrawn);
                                }
                                break;
                            case "FILL":
                                ShapeToBeDrawn = cparser.CommadParam(command);


                                if (ShapeToBeDrawn != null && OutputArea.Image != null)
                                {

                                    ShapeToBeDrawn.draw(g, fill, userColor);
                                    OutputArea.Image = bm;

                                }
                                break;

                            default:
                                cparser.TraceError("\terror occured :\n\t Invalid command");
                                break;
                        }
                        break;
                }
            }
        }
        int flag = 0;
        public void Flashthecolor(bool flash,Color color1, Color color2)
        {
            while (flash)
            {
                foreach (Shape s in drawnShape)
                {
                    try
                    {
                        if (flag % 2 == 0)
                        {
                            s.draw(g, fill, color1);
                            Invoke(new MethodInvoker(delegate () {
                                OutputArea.Image = bm;
                            }));
                        }
                        else
                        {
                            s.draw(g, fill, color2);
                            Invoke(new MethodInvoker(delegate () {
                                OutputArea.Image = bm;
                            }));
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                       f_Thread.Abort();
                    }
                    catch (InvalidOperationException)
                    {
                        f_Thread.Abort();
                    }
                }
                flag++;
                Thread.Sleep(1000);
            }
        }
       
       /// <summary>
       /// Get text from commandline if the user press enter and act on it accordingly
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                String[] commandLines = CommandLine.Text.ToUpper().Split('\n');
                String commands = commandLines[commandLines.Length - 1];
                if(String.IsNullOrEmpty(commands))
                {
                    cparser.TraceError("\tError occured :\n\t\tCommandLine is empty");
                }
                else
                {
                    String[] command = commands.Split(' ');
                    CommandCheck(command);
                }
                //CommandLine.Text += "\n";
                CommandLine.Select(CommandLine.Text.Length, 0);
            }
        }

        /// <summary>
        /// This method allows user to minimize the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// This method allows user to maximize the application window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
            }

            //maximises window
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.CenterToScreen();
            }
        }

      

      /// <summary>
      /// This method allow user to save the written code on programming area as .cs file
      /// </summary>
        private void saveFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(typeCodeRichText.Text))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "Untitled";
                    saveFileDialog.Filter = ".cs files only (*.cs) | *.cs";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(s))
                        {
                            sw.Write(typeCodeRichText.Text);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error", "Cannot Save empty file.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// This methoid is to open .cs file on application, Read everything from it and write it on the programming area 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "cs file only|*.cs" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            typeCodeRichText.Text = await sr.ReadToEndAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Error while reading file.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// This method calls another method which saves the written code on programming area and save it as .cs file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        /// <summary>
        /// This method is to clear commandline when mouse is clicked on it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_MouseDown(object sender, MouseEventArgs e)
        {

            if (CommandLine.Text == "Type Command Here\n")
            {
                CommandLine.Text = "";
            }
        }
        /// <summary>
        /// This method stops the timer after 3 second 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter == 3)
            {
                timer1.Stop();
                SuccessMessagePnl.Visible = false;
                successMgxPicBox.Enabled = false;

            }
        }
        /// <summary>
        /// This method is for popUp on application window when user give the commad "RESET" and also to enable and start the timer 
        /// </summary>
        /// <param name="text">A text to displayed on popup</param>
        public void msgPopup(string text)
        {
            successMgxPicBox.Enabled = true;
            timer1.Enabled = true;
            timer1.Start();
            SuccessMessagePnl.Visible = true;
            PopUpBtn.Text = text;
        }
        /// <summary>
        /// This methos is written to execute everythig that is typed on programming area 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void executeBtn_Click_1(object sender, EventArgs e)
        {
            method.methodLocalVar.Clear();
            String source = "Run";
            validation_flag = false;
            ReadProgrammingArea(source);

        }
        /// <summary>
        /// This method is written to validate every single line that is written on programming area before execution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate_Click(object sender, EventArgs e)
        {
            method.methodLocalVar.Clear();
            String source = "Validation";
            ReadProgrammingArea(source);
            if(cparser.ErrorList.Count > 0)
            {
                ErrorRichBox.Text = "";
                foreach (var value in cparser.ErrorList.Values)
                {
                    ErrorRichBox.Text += (value +"\n\n");
                }
            }
        }

        private void typeCodeRichText_SelectionChanged(object sender, EventArgs e)
        {

        }

        //int Counter = 0; // For Live Validation
        //bool ErrorFlagFromKeydown = false;
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    Counter++;
        //    Console.WriteLine(Counter.ToString());
        //    if(Counter == 2)
        //    {
        //        if(ErrorRichBox.Text != null && ErrorFlagFromKeydown == false)
        //        {
        //            ErrorRichBox.Text = "";
        //        }
        //        ReadProgrammingArea();
        //        timer2.Stop();
        //    }
        //}

        //private void typeCodeRichText_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(Keys.Enter== e.KeyCode)
        //    {
        //        rowline = typeCodeRichText.Lines.Count(); 
        //        Counter = 0;
        //        //ReadProgrammingArea();
        //        //if (ErrorRichBox.Text != "") 
        //        //{
        //        //    ErrorFlagFromKeydown = true;
        //        //}
        //    }
        //    if(Keys.Back == e.KeyCode)
        //    {
        //        rowline = typeCodeRichText.Lines.Count();

        //        if (typeCodeRichText.Lines.Length == 0)
        //        {
        //            cparser.PreError = "";
        //            cparser.PreErrorLine = 0;

        //        }
        //        else
        //        {
        //            ErrorRichBox.Text = "";
        //            Counter = 0;
        //            timer2.Enabled = true;
        //            timer2.Start();
        //            ReadProgrammingArea();
        //            keyBack = true;
        //            if (ErrorRichBox.Text != "")
        //            {
        //                ErrorFlagFromKeydown = true;
        //            }
        //        }
        //    }
        //    //clearStatus = true;
        //}

        //private void typeCodeRichText_MouseClick(object sender, MouseEventArgs e)
        //{
        //    timer2.Enabled = true;
        //    rowline = typeCodeRichText.Lines.Count();
        //}

        //private void typeCodeRichText_TextChanged(object sender, EventArgs e)
        //{
        //    timer2.Start();
        //    Counter = 0;
        //    rowline = typeCodeRichText.Lines.Length;
        //}
    }
}
