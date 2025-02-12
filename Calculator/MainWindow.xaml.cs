using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{   
    public partial class MainWindow : Window
    {        
        string temp_input; // 处理数据来源
        int put_state = 0; // 用于调整接受包结构
        private StackRestorer operaStack = new StackRestorer(); // 用于存放操作符的栈
        private StackRestorer numStack = new StackRestorer(); // 用于存放操作数的栈
        public MainWindow()
        {
            InitializeComponent();            
        }
        // 清空显示区，重置包结构
        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Text = string.Empty;
            temp_input = string.Empty;
            tbResult.Text = string.Empty;
            put_state = 0;
        }

        // 即时显示 + buttonNums
        private void btData_Input(object sender, RoutedEventArgs e)
        {
            ReceiveData(sender.ToString());
        }        

        // 计算并显示结果
        private void btEqual_Click(object sender, RoutedEventArgs e)
        {
            DataHandle();
        }

        // 接收包逻辑
        public void ReceiveData(string str)
        {
            string ad = str.Substring(str.LastIndexOf(' ') + 1);

            Console.WriteLine(ad);
            if (ad == "genhao")
            {
                string newstr = $"√({tbInput.Text[tbInput.Text.Length - 1]})";
                tbInput.Text = tbInput.Text.Remove(tbInput.Text.Length - 1) + newstr;
            }
            else
                tbInput.Text += ad;

            if ((ad[0] < 48 || ad[0] > 57) && put_state == 0)
            {
                put_state = 1;
                temp_input += ' ';
                temp_input += ad;

            }
            else if ((ad[0] >= 48 || ad[0] <= 57) && put_state == 1)
            {
                temp_input += ' ';
                temp_input += ad;
                put_state = 0;
            }
            else
            {
                temp_input += ad;
            }
        }

        // 数据处理逻辑
        public void DataHandle()
        {
            int num;
            string[] numsary = temp_input.Split(' ');
            foreach (string cur in numsary)
            {
                Grade Current = new Grade(cur);
                if (int.TryParse(cur, out num))
                {
                    numStack.Push((int)num);
                }
                else
                {
                    if (operaStack.GetDataCount() == 0)
                    {
                        operaStack.Push((string)cur);
                    }
                    else
                    {
                        while (operaStack.GetDataCount() > 0)
                        {
                            string last = (string)operaStack.Pop();
                            Grade Last = new Grade(last);

                            if (Current.level > Last.level)
                            {
                                operaStack.Push((string)last);
                                operaStack.Push((string)cur);
                                break;
                            }
                            else
                            {
                                int a = Last.GetPopnum();
                                if (a == 0)
                                {
                                    numStack.Push((int)Last.Caculate((int)numStack.Pop()));
                                }
                                else
                                {
                                    int c = (int)numStack.Pop();
                                    int d = (int)numStack.Pop();
                                    numStack.Push((int)Last.Caculate(c, d));
                                    Console.WriteLine($"{c} || {d}");
                                }
                            }
                        }
                        if (operaStack.GetDataCount() == 0)
                        {
                            operaStack.Push((string)cur);
                        }
                    }
                }
            }

            while (operaStack.GetDataCount() > 0)
            {
                string last = (string)operaStack.Pop();
                Grade Last = new Grade(last);
                int a = Last.GetPopnum();
                if (a == 0)
                {
                    numStack.Push((int)Last.Caculate((int)numStack.Pop()));
                }
                else
                {
                    int c = (int)numStack.Pop();
                    int d = (int)numStack.Pop();
                    numStack.Push((int)Last.Caculate(c, d));
                    Console.WriteLine($"{c} || {d}");
                }
            }

            tbResult.Text = numStack.Pop().ToString();
        }
    }
}