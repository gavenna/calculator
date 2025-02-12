using System;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public class Grade
    {
        public string symbol;
        public int level;

        public Grade(string _symbol)
        {
            this.symbol = _symbol;
            if (_symbol == "+" || _symbol == "-")
            {
                level = 1;
            }
            else if (_symbol == "X" || _symbol == "/")
            {
                level = 2;
            }
            else if( _symbol == "!" || _symbol == "genhao")
            {
                level = 3;
            }
        }

        public int Get()
        {
            return level;
        }
        // 用于获得对应操作符应该弹出的操作数数量
        public int GetPopnum()
        {
            if (symbol == "!" || symbol == "genhao")
            {
                return 0;
            }
            else
            {
                return 1;
            }                            
        }

        public int Caculate(int a)
        {
            int temp_layjia = 1;
            if (symbol == "!")
            {
                while (a != 0)
                {
                    temp_layjia *= a--;
                } 
                return temp_layjia;
            }
            else if(symbol == "genhao")
            {
                return (int)Math.Sqrt(a);
            }
            return 0;
        }

        public int Caculate(int a, int b)
        {
            
            if (symbol == "+")
            {
                return a + b;                
            }
            else if (symbol == "-")
            {
                return b - a;
            }
            else if (symbol == "X")
            {
                return a * b;
            }
            else if (symbol == "/")
            {
                return b / a;
            }
            return 0;
        }
    }
}