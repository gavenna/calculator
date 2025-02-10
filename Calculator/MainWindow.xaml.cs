using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        char[] Stack_Operator = new char[10];
        string[] Stack_Operators = new string[10];
        int[] Stack_Nums = new int[10];
        static int index_opera = 0;
        static int index_Nums = 0;
        string temp_input;
        int result = 0;
        int put_state = 0;

        public MainWindow()
        {
            InitializeComponent();

        }
        // 清空
        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            tbInput.Text = string.Empty;
            temp_input = string.Empty;
            tbResult.Text = string.Empty;
        }

        // 即时显示 + buttonNums
        private void btData_Input(object sender, RoutedEventArgs e)
        {
            
            string ad = sender.ToString().Substring(sender.ToString().Length - 1);
            Console.WriteLine(sender.ToString());
            if (ad[0] == 'o')
            {
                string newstr = $"√({tbInput.Text[tbInput.Text.Length - 1]})";
                tbInput.Text = tbInput.Text.Remove(tbInput.Text.Length - 1) + newstr;
            }
            else
                tbInput.Text += ad;
            
            if( (ad[0] < 48 || ad[0] > 57 )&& put_state == 0)
            {             
                put_state = 1;
                temp_input += ' ';
                temp_input += ad;

            }
            else if((ad[0] >= 48 || ad[0] <= 57) && put_state ==1)
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
        // 入栈
        private static int push_StackNums(int[] objer, int val)
        {
            if (index_Nums == (objer.Length - 1))
            {
                //NULL
                MessageBox.Show("To much  nums args!!!");
                return -1;
            }
            else
            {
                //YU
                objer[++index_Nums] = val;
                return 0;
            }
        }

        // 出栈
        private static int pop_StackNums(int[] objer)
        {
            if (index_Nums == 0)
            {
                //NULL
                MessageBox.Show("no more nums args!!!");
                return -1;

            }
            else
            {
                //YU
                //objer.SetValue(val, index_opera);
                index_Nums--;
                return 0;
            }
        }
        // 操作符入栈
        private static int push_Stackopera(string[] objer, string val)
        {
            if (index_opera == (objer.Length - 1))
            {
                //NULL
                MessageBox.Show("To much opear args!!!");
                return -1;
            }
            else
            {
                //YU
                objer[++index_opera] = val;
                return 0;
            }
        }
        // 操作符出栈
        private static int pop_Stackopera(string[] objer)
        {
            if (index_opera == 0)
            {
                //NULL
                MessageBox.Show("no more opera args!!!");
                return -1;
            }
            else
            {
                //YU
                //objer.SetValue(val, index_opera);
                index_opera--;
                return 0;
            }
        }
        // if empty
        private static bool ifOperaEmpty()
        {
            if (index_opera == 0)
                return true;
            else return false;

        }

        // if button =
        private void btEqual_Click(object sender, RoutedEventArgs e)
        {
            analo(temp_input);            
        }       

        // 解析字符串，将*/运算解决
        public  void analo(string obj)
        {
            int result = 0, a = 0, b;            
            string[] numsary = obj.Split(' ');
            int temp_index = 0;
            foreach (var ny in numsary)
            {
                int temp=0;
                if(int.TryParse(ny,out temp) == true)
                {
                    push_StackNums(Stack_Nums, temp);
                }
                else
                {
                    if (index_opera == 0)
                        push_Stackopera(Stack_Operators, ny);
                    else
                    {
                        while(!ifOperaEmpty())
                        {
                            int levelcur = 0, levellast = 0;
                            if (ny == "+" || ny == "-")
                            {
                                levelcur = 1;
                            }
                            else
                            {
                                levelcur = 2;
                            }
                            pop_Stackopera(Stack_Operators);
                            string operalast = Stack_Operators[index_opera + 1];
                            if (operalast == "+" || operalast == "-")
                            {
                                levellast = 1;
                            }
                            else
                            {
                                levellast = 2;
                            }


                            if (levelcur <= levellast)
                            {
                                //pop_Stackopera(Stack_Operators);
                                if (operalast == "+")
                                {
                                    pop_StackNums(Stack_Nums);
                                    a = Stack_Nums[index_Nums + 1];
                                    pop_StackNums(Stack_Nums);
                                    b = Stack_Nums[index_Nums + 1];
                                    push_StackNums(Stack_Nums, a + b);
                                }
                                else if (operalast == "-")
                                {
                                    pop_StackNums(Stack_Nums);
                                    a = Stack_Nums[index_Nums + 1];
                                    pop_StackNums(Stack_Nums);
                                    b = Stack_Nums[index_Nums + 1];
                                    push_StackNums(Stack_Nums, b - a);
                                }
                                else if (operalast == "X")
                                {
                                    pop_StackNums(Stack_Nums);
                                    a = Stack_Nums[index_Nums + 1];
                                    pop_StackNums(Stack_Nums);
                                    b = Stack_Nums[index_Nums + 1];
                                    push_StackNums(Stack_Nums, b * a);
                                }
                                else if (operalast == "/")
                                {
                                    pop_StackNums(Stack_Nums);
                                    a = Stack_Nums[index_Nums + 1];
                                    pop_StackNums(Stack_Nums);
                                    b = Stack_Nums[index_Nums + 1];
                                    push_StackNums(Stack_Nums, b / a);
                                }
                            }
                            else
                            {
                                push_Stackopera(Stack_Operators, operalast);
                                push_Stackopera(Stack_Operators, ny);
                                break;
                            }
                        }// while(!ifOperaEmpty())
                        if(ifOperaEmpty())
                        {
                            push_Stackopera(Stack_Operators, ny);
                        }
                    }
                }
                temp_index++;
            }

             
            /*
            for (int i=0;i<obj.Length;i++)
            {
                if ((int)obj[i] >48 && (int)obj[i] < 60)
                {
                    Console.WriteLine(obj[i]);
                    //nums
                    push_StackNums(Stack_Nums, Convert.ToInt32(obj[i])-48);
                    
                }
                else
                {                    
                    //opera
                    if(index_opera==0)
                        push_Stackopera(Stack_Operator, obj[i]);
                    else
                    {
                        // IF PRevilge
                        if((obj[index_opera-1] == '*' || obj[index_opera-1] == '/') || (obj[index_opera] == '-' || obj[index_opera] == '-'))
                        {
                            a  = pop_StackNums(Stack_Nums);
                            b  = pop_StackNums(Stack_Nums);
                            if (obj[index_opera-1] == '*')
                            {
                                push_StackNums(Stack_Nums, a * b);
                            }
                            else
                            {
                                push_StackNums(Stack_Nums, b/a);
                            }
                        }
                        else
                        {
                            push_Stackopera(Stack_Operator, obj[index_opera]);
                        }
                    }
                }
            }*/       
            while(!ifOperaEmpty())
            {
                pop_Stackopera(Stack_Operators);
                if (Stack_Operators[index_opera + 1] == "+")
                {
                    pop_StackNums(Stack_Nums);
                    a = Stack_Nums[index_Nums + 1];
                    pop_StackNums(Stack_Nums);
                    b = Stack_Nums[index_Nums + 1];
                    push_StackNums(Stack_Nums, a + b);
                }
                else if (Stack_Operators[index_opera + 1] == "-")
                {
                    pop_StackNums(Stack_Nums);
                    a = Stack_Nums[index_Nums + 1];
                    pop_StackNums(Stack_Nums);
                    b = Stack_Nums[index_Nums + 1];
                    push_StackNums(Stack_Nums, b - a);
                }
                else if (Stack_Operators[index_opera + 1] == "X")
                {
                    pop_StackNums(Stack_Nums);
                    a = Stack_Nums[index_Nums + 1];
                    pop_StackNums(Stack_Nums);
                    b = Stack_Nums[index_Nums + 1];
                    push_StackNums(Stack_Nums, b * a);
                }
                else if (Stack_Operators[index_opera + 1] == "/")
                {
                    pop_StackNums(Stack_Nums);
                    a = Stack_Nums[index_Nums + 1];
                    pop_StackNums(Stack_Nums);
                    b = Stack_Nums[index_Nums + 1];
                    push_StackNums(Stack_Nums, b / a);
                }
            }                            
            pop_StackNums(Stack_Nums);
            result = Stack_Nums[index_Nums + 1];
            tbResult.Text = result.ToString();
        }
    }
}