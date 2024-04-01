using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Вычисление функции G(x, y) оформить в виде отдельной функции (метода) с обработкой вычислительных ошибок? 
//обработать огранияения на ввод исх данных

namespace TechProg5_5a
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            CreatePages();
        }
        private void CreatePages()
        {
            //Добавить проверки на ввод
            TabPage tabPages = new TabPage(" " + (tabControl1.TabCount + 1));

            Random random = new Random();

            //Lables
            System.Windows.Forms.Label Label1 = new System.Windows.Forms.Label();
            Label1.Location = label1.Location;
            Label1.Size = label1.Size;
            Label1.Text = label1.Text;

            System.Windows.Forms.Label Label2 = new System.Windows.Forms.Label();
            Label2.Location = label2.Location;
            Label2.Size = label2.Size;
            Label2.Text = label2.Text;

            System.Windows.Forms.Label Label3 = new System.Windows.Forms.Label();
            Label3.Location = label3.Location;
            Label3.Size = label3.Size;
            Label3.Text = label3.Text;

            System.Windows.Forms.Label Label4 = new System.Windows.Forms.Label();
            Label4.Location = label4.Location;
            Label4.Size = label4.Size;
            Label4.Text = label4.Text;

            System.Windows.Forms.Label Label5 = new System.Windows.Forms.Label();
            Label5.Location = label5.Location;
            Label5.Size = label5.Size;
            Label5.Text = label5.Text;

            //textBoxes
            System.Windows.Forms.TextBox TextBox1 = new System.Windows.Forms.TextBox();
            TextBox1.Location = textBox1.Location;
            TextBox1.Size = textBox1.Size;
            double randomValue1 = Math.Round(random.NextDouble() * (200 - (-101)) + (-101), 2);

            System.Windows.Forms.TextBox TextBox2 = new System.Windows.Forms.TextBox();
            TextBox2.Location = textBox2.Location;
            TextBox2.Size = textBox2.Size;
            double randomValue2 = Math.Round(random.NextDouble() * (1000 - (-40)) + (-40), 2);

            if (randomValue1 >= randomValue2)
            {
                double temp = randomValue1;
                randomValue1 = randomValue2;
                randomValue2 = temp;
            }
            TextBox1.Text = randomValue1.ToString();
            TextBox2.Text = randomValue2.ToString();

            System.Windows.Forms.TextBox TextBox3 = new System.Windows.Forms.TextBox();
            TextBox3.Location = textBox3.Location;
            TextBox3.Size = textBox3.Size;
            TextBox3.Text = random.Next(2, 100).ToString();

            System.Windows.Forms.TextBox TextBox4 = new System.Windows.Forms.TextBox();
            TextBox4.Location = textBox4.Location;
            TextBox4.Size = textBox4.Size;
            TextBox4.Text = random.Next(2, 5).ToString();

            System.Windows.Forms.TextBox TextBox5 = new System.Windows.Forms.TextBox();
            TextBox5.Location = textBox5.Location;
            TextBox5.Size = textBox5.Size;
            TextBox5.Text = random.Next(2, 5).ToString();

            int count;
            if (int.TryParse(TextBox4.Text, out count))
            {
                List<double> numbers = new List<double>();
                for (int k = 0; k < count; k++)
                {
                    double number = Math.Round(random.NextDouble() * 100, 2);
                    numbers.Add(number);
                }
                numbers.Sort(); // сортировка чисел по возрастанию
                TextBox5.Text = string.Join(" ", numbers);
            }
            else
            {
                TextBox5.Text = "0";
            }


            /*button1.Click += (sender, e) =>
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    string tabName = tabPage.Text;
                    double x0 = Convert.ToDouble(TextBox1.Text);
                    double xk = Convert.ToDouble(TextBox2.Text);
                    int Nx = Convert.ToInt32(TextBox3.Text);
                    int Ny = Convert.ToInt32(TextBox4.Text);
                    string[] yValues = TextBox5.Text.Split(' ');

                    for (int j = 0; j < Nx; j++)
                    {
                        double xi = x0 + j * (xk - x0) / (Nx - 1);

                        for (int k = 0; k < Ny; k++)
                        {
                            double yj = Convert.ToDouble(yValues[k]);
                            double functionValue = xi / Math.Exp(yj);
                            Console.WriteLine("TabPage: " + tabName + ", G(" + xi + ", " + yj + ") = " + functionValue);
                        }
                    }
                }
            };*/

            /*button1.Click += (sender, e) =>
            {
                int currentTab = tabControl1.SelectedIndex + 1;
                Console.WriteLine(currentTab);
                double x0 = Convert.ToDouble(TextBox1.Text);
                double xk = Convert.ToDouble(TextBox2.Text);
                int Nx = Convert.ToInt32(TextBox3.Text);
                int Ny = Convert.ToInt32(TextBox4.Text);
                string[] yValues = TextBox5.Text.Split(' ');


                for (int j = 0; j < Nx; j++)
                {
                    double xi = x0 + j * (xk - x0) / (Nx - 1);

                    for (int k = 0; k < Ny; k++)
                    {
                        double yj;
                        if (!double.TryParse(yValues[k], out yj))
                        {
                            Console.WriteLine("G(" + xi + ", " + yValues[k] + ") = NaN");

                        }
                        else
                        {
                            double functionValue = xi / Math.Exp(yj);
                            //Console.WriteLine("G(" + xi + ", " + yj + ") = " + functionValue);
                            Console.WriteLine("G(" + xi + ", " + yj + ") = " + functionValue);

                        }
                    }
                }
                //OutputToFiles();
            };*/

            List<TabData> tabDataList = new List<TabData>();

            /*button1.Click += (sender, e) =>
            {
                TabData tabData = new TabData(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text), Convert.ToInt32(TextBox3.Text), TextBox5.Text.Split(' ').Select(double.Parse).ToList());
                tabDataList.Add(tabData);
                foreach (var data in tabDataList)
                {
                    Console.WriteLine($"Tab Data: X0={data.X0}, Xk={data.Xk}, Nx={data.Nx}, YValues={string.Join(" ", data.YValues)}");
                }
            };*/

            /*int fileIndex = 1;
            foreach (var data in tabDataList)
            {
                string fileName = $"G{fileIndex:D4}.dat"; // Создание имени файла
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int j = 0; j < data.Nx; j++)
                    {
                        double xi = data.X0 + j * (data.Xk - data.X0) / (data.Nx - 1);
                        for (int k = 0; k < data.YValues.Count; k++)
                        {
                            double yj = data.YValues[k];
                            double functionValue = xi / Math.Exp(yj);
                            writer.WriteLine($"G({xi}, {yj}) = {functionValue}");
                        }
                    }
                }
                fileIndex++;
            }*/

            /*button1.Click += (sender, e) =>
            {
                int fileCount = 1;
                TabData tabData = new TabData(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text), Convert.ToInt32(TextBox3.Text), TextBox5.Text.Split(' ').Select(double.Parse).ToList());
                tabDataList.Add(tabData);

                foreach (var data in tabDataList)
                {
                    string fileName = $"G{fileCount:D4}.dat";
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {

                        for (int q = 0; q < data.Nx; q++)
                        {
                            double xi = data.X0 + q * (data.Xk - data.X0) / (data.Nx - 1);
                            foreach (var yj in data.YValues)
                            {
                                double result = xi / Math.Exp(yj);
                                writer.WriteLine($"G({xi}, {yj}) = {result}");
                            }
                        }
                    }
                    fileCount++;
                }
                                
            };*/

            button1.Click += (sender, e) =>
            {
                int fileCount = 1;
                foreach (var data in tabDataList)
                {
                    string fileName = $"G{fileCount:D4}.dat";
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        for (int q = 0; q < data.Nx; q++)
                        {
                            double xi = data.X0 + q * (data.Xk - data.X0) / (data.Nx - 1);
                            foreach (var yj in data.YValues)
                            {
                                double result = xi / Math.Exp(yj);
                                writer.WriteLine($"G({xi}, {yj}) = {result}");
                            }
                        }
                    }
                    fileCount++;
                }
            };

            tabPages.Controls.Add(TextBox1);
            tabPages.Controls.Add(Label1);
            tabPages.Controls.Add(TextBox2);
            tabPages.Controls.Add(Label2);
            tabPages.Controls.Add(TextBox3);
            tabPages.Controls.Add(Label3);
            tabPages.Controls.Add(TextBox4);
            tabPages.Controls.Add(Label4);
            tabPages.Controls.Add(TextBox5);
            tabPages.Controls.Add(Label5);
            tabPages.Controls.Add(Label4);

            tabControl1.TabPages.Add(tabPages);

        }

        /*static void OutputToFiles()
        {
            int fileCount = 1;
            string fileName = "G" + fileCount.ToString("D4") + ".dat";
            StreamWriter writer = new StreamWriter(fileName);
            Console.ReadLine();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.Contains("1"))
                {
                    writer.Close();
                    fileCount++;
                    fileName = "G" + fileCount.ToString("D4") + ".dat";
                    writer = new StreamWriter(fileName);
                }

                writer.WriteLine(line);
            }

            writer.Close();
        }*/

        /*static void OutputToFiles()
        {
            string line;
            int fileNumber = 1;
            StreamWriter currentFile = new StreamWriter($"G{fileNumber:D4}.dat");

            while ((line = Console.ReadLine()) != null)
            {
                if (line.Contains("1"))
                {
                    currentFile.Close();
                    fileNumber++;
                    currentFile = new StreamWriter($"G{fileNumber:D4}.dat");
                }
                else
                {
                    currentFile.WriteLine(line);
                }
            }

            currentFile.Close();
        }*/
    
        private void button3_Click(object sender, System.EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        
        private void button5_Click(object sender, System.EventArgs e)
        {
            //CreateMyProgram();

        }
        
        private void CreateMyProgram()
        {
            string logFileName = "myProgram.log";
            string logfilePath = Path.Combine(Environment.CurrentDirectory, logFileName); // Путь к файлу

            if (File.Exists(logfilePath))
            {
                File.Delete(logfilePath);
            }

            string programInfo = "Название программы: TechProg5_4a\nНомер варианта: 24\n";

            string startTime = $"Дата и время начала выполнения расчёта: {DateTime.Now}\n";

            string function = "Рассчитываемая функция: G(x) = x / Math.Exp(y);\n";

            StringBuilder resultFiles = new StringBuilder();
            for (int i = 1; i < tabControl1.TabPages.Count; i++)
            {
                resultFiles.Append($"G{i:D4}.dat\n");
            }

            string logContent = programInfo + startTime + function + resultFiles.ToString();

            // Запись содержимого в файл
            using (StreamWriter writer = new StreamWriter(logFileName))
            {
                writer.Write(logContent);
            }

            Console.WriteLine("Файл myProgram.log создан.");
        }

        /*private void CreateMyErrors(double xi, double yj)
        {
            try
            {
                double result = CalculateFunction(xi, yj);
            }
            catch (Exception ex)
            {
                string fileName = $"G{tabControl1.SelectedIndex + 1:D4}.dat";
                string functionName = "G(xi, yj) = xi / exp(yj)";
                string arguments = $"xi = {xi}, yj = {yj}";
                string errorType = ex.GetType().Name;

                string errorInfo = $"File: {fileName}\nFunction: {functionName}\nArguments: {arguments}\nError Type: {errorType}\n\n";

                string logFilePath = Path.Combine(Environment.CurrentDirectory, "myErrors.log");

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(errorInfo);
                }
            }
        }
*/
        
    }
}
