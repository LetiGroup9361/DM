using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class N
    {
        private int top { get; set; } 
        private List<ushort> digits = new List<ushort>();
        public N()
        {
            top = 0;
        }//Конструктор по умолчанию
        public N(N temp)
        {
            this.top = temp.top;
            this.digits = temp.digits;
        }//Конструктор копирования 
        public N(int top, string digits)
        {
            this.top = top - 1;//Не удалять блэт
            this.top = SetDigits(digits);
        }//Параметрический конструктор
        public static N operator +(N n1, N n2)
        {
            return ADD_NN_N(n1, n2);
        }
        public static N operator -(N n1, N n2)
        {
            return SUB_NN_N(n1, n2);
        }
        public static N operator *(N n1, N n2)
        {
            return MUL_NN_N(n1, n2);
        }
        public static N operator /(N n1, N n2)
        {
            return DIV_NN_N(n1, n2, 1);
        }
        public static N operator %(N n1, N n2)
        {
            return DIV_NN_N(n1, n2, 2);
        }
        public static bool operator ==(N n1, N n2)
        {
            if (COM_NN_D(n1, n2) == 0) return true;
            else return false;
        }
        public static bool operator !=(N n1, N n2)
        {
            if (COM_NN_D(n1, n2) == 0) return false;
            else return true;
        }
        public static bool operator >(N n1, N n2)
        {
            if (COM_NN_D(n1, n2) == 2) return true;
            else return false;
        }
        public static bool operator <(N n1, N n2)
        {
            if (COM_NN_D(n1, n2) == 1) return true;
            else return false;
        }
        public void SetTop()
        {
            top = this.digits.Count - 1;
        }// Установить больший разряд (top)
        public int SetDigits(string digits) 
        {
            digits = digits.Trim();
            ushort temp;
            bool isNull = true;
            for (int i = 0; i <= top; ++i)
            {

                temp = (ushort)(Char.GetNumericValue(digits[i]));
                if (temp != 0 || i == top)
                {
                    isNull = false;
                }
                if (!isNull)
                {
                    this.digits.Add(temp);
                }
            }
            return (this.digits.Count - 1);
        }// Заполнить массив цифр из строки
        public ushort this[int index]
        {
            get
            {
                return this.digits[index];
            }
            set
            {
            }
        }//Индексатор для массива цифр 
        public bool IsN(string digits)// Проверка на натуральность !!! Отдельная функция
        {
            for (int i = 0; i <= top; ++i)
            {
                if (!Char.IsDigit(digits[i])) return false;
            }
            return true;
        }
        public virtual void Print(TextBox tb)
        {
            tb.Clear();
            foreach (ushort el in this.digits)
            {
                tb.Text += el;
            }
        }//Вывод значения переменной
        public static (N, int) Split(int index, N bigger, N less)
        {
            N temp = new N();
            string value = "";
            while (true)
            {
                value = "";
                for (int i = 0; i <= index; ++i)
                {
                    value += Convert.ToString(bigger[i]);
                }
                temp = new N(value.Length, value);
                if (COM_NN_D(less, temp) == 2)
                {
                    index += 1;
                    continue;
                }
                else break;
            }
            return (new N(value.Length, value), bigger.digits.Count - value.Length);
        }//Вырезать часть числа
        public static int COM_NN_D(N n1,N n2)
        {
            n1.SetTop();
            n2.SetTop();
            if (n1.top > n2.top) return 2;
            else if (n1.top < n2.top) return 1;
            else
            {
                if (n2.digits == n1.digits) return 0;
                for (int i = 0; i <= n1.top; ++i)
                {
                    if (n1.digits[i] > n2.digits[i])
                    {
                        return 2;
                    }
                    else if (n1.digits[i] < n2.digits[i])
                    {
                        return 1;
                    }
                    else continue;
                }
                return 0;
            }
        }// Сравнение
        public bool NZER_N_B()
        {
            if (digits.Count == 1 && digits[0] == 0) return false;
            else return true;
        }//Проверка на ноль 
        public static N ADD_NN_N(N n1, N n2)
        {
            N a = n1;
            N b = n2;
            a.SetTop();
            b.SetTop();
            N res = new N();
            int s = 0;
            int cmp = COM_NN_D(n1, n2);
            if (cmp == 1)
            {
                b = n1;
                a = n2;
            }
            a.digits.Reverse();
            b.digits.Reverse();
            for (int i = 0; i <= b.top; ++i)
            {
                res.digits.Add((ushort)((a[i] + b[i] + s) % 10));
                s = (a[i] + b[i] + s) / 10;
            }
            for (int i = b.top + 1; i <= a.top; ++i)
            {
                res.digits.Add((ushort)((a[i] + s) % 10));
                s = (a[i] + s) / 10;
            }
            if (s > 0)
            {
                res.digits.Add((ushort)s);
            }
            res.digits.Reverse();
            res.SetTop();
            return res;
        }// Сложение
        public N ADD_1N_N()
        {
            this.SetTop();
            return ADD_NN_N(this, new N(1, "1"));
        }// Прибавить единицу
        public static N SUB_NN_N(N n1, N n2)
        {
            N a = n1;
            N b = n2;
            a.SetTop();
            b.SetTop();
            int cmp = COM_NN_D(n1, n2);
            if (cmp == 1)
            {
                b = n1;
                a = n2;
            }
            else if (cmp == 0)
            {
                return new N(1, "0");
            }
            a.digits.Reverse();
            b.digits.Reverse();
            for (int i = 0; i <= b.top; ++i)
            {
                if (a.digits[i] < b.digits[i])
                {
                    a.digits[i] = (ushort)(a.digits[i] + 10 - b.digits[i]);
                    for (int j = i + 1; j <= a.top; ++j)
                    {
                        if (a.digits[j] == 0) a.digits[j] = 9;
                        else
                        {
                            a.digits[j] -= 1;
                            break;
                        }
                    }
                }
                else
                {
                    a.digits[i] = (ushort)(a.digits[i] - b.digits[i]);
                }
            }
            a.digits.Reverse();
            int k = 0;
            while (true)
            {
                if (a.digits[k] == 0) a.digits.RemoveAt(k);
                else break;
            }
            a.SetTop();
            return a;
        }// Вычитание 
        public static N MUL_ND_N(N n1, N n2)
        {
            n1.SetTop();
            n2.SetTop();
            int s = 0;
            N res = new N();
            n1.digits.Reverse();
            for (int i = 0; i <= n1.top; ++i)
            {
                res.digits.Add((ushort)((n1[i] * n2[0] + s) % 10));
                s = (ushort)((n1[i] * n2[0] + s) / 10);
            }
            if (s > 0)
            {
                res.digits.Add((ushort)s);
            }
            n1.digits.Reverse();
            res.digits.Reverse();
            res.SetTop();
            return res;
        }// Умножение на цифру (N)
        public static N MUL_ND_N(N n1, ushort d)
        {
            n1.SetTop();
            int s = 0;
            N res = new N();
            n1.digits.Reverse();
            for (int i = 0; i <= n1.top; ++i)
            {
                res.digits.Add((ushort)((n1[i] * d + s) % 10));
                s = (ushort)((n1[i] * d + s) / 10);
            }
            if (s > 0)
            {
                res.digits.Add((ushort)s);
            }
            res.digits.Reverse();
            n1.digits.Reverse();
            res.SetTop();
            return res;
        }//Умножение на литерал
        public static N MUL_Nk_N(N n1, N k)
        {
            n1.SetTop();
            k.SetTop();
            for (int i = 0; i <= (k.digits.Count - 1); ++i)
            {
                for (Int64 j = 0; j < k.digits[i] * (int)Math.Pow(10, k.digits.Count - 1 - i); ++j)
                {
                    n1.digits.Add(0);
                }
            }
            n1.SetTop();
            return n1;
        }// Умножение на 10^k
        public static N MUL_Nk_N(N n1, ushort k)
        {
            for (int i = 0; i < k; ++i)
            {
                n1.digits.Add(0);
            }
            n1.SetTop();
            return n1;
        }// Перегрузка
        public static (N, int) DIV_NN_Dk(N n1, N n2)
        {
            n1.SetTop();
            n2.SetTop();
            int resind;
            ushort index;
            N temp = new N();
            N temp1 = new N();
            if (COM_NN_D(n1, n2) == 2)
            {
                (temp, resind) = Split(n2.top, n1, n2);
            }
            else (temp, resind) = Split(n1.top, n2, n1);
            temp.top = temp.digits.Count - 1;
            index = 9;
            while (true)
            {
                temp1 = MUL_ND_N(n2, index);
                temp1.top = temp1.digits.Count - 1;
                if (COM_NN_D(temp, temp1) == 1)
                {
                    index -= 1;
                }
                else break;
            }

            return (new N(index.ToString().Length, index.ToString()) ,resind);

        }// Первая цифра от деления
        public static N MUL_NN_N(N n1, N n2)
        {
            N c = new N(1, "0");
            for (int i = 0; i <= n2.top; i++)
            {
                c = ADD_NN_N(c,MUL_Nk_N(MUL_ND_N(n1, n2[n2.top - i]), (ushort)i));
            }
            c.SetTop();
            return c;
        }//Умножение
        public static N SUB_NDN_N(N n1, N n2, N digit)
        {
            N temp = new N();
            int res;
            temp = MUL_ND_N(n2, digit);
            res = COM_NN_D(n1, temp);
            return SUB_NN_N(n1, temp);
        }// Вычитание умноженного
        public static N DIV_NN_N(N n1, N n2, int mode = 1)
        {
            N digit = new N();
            int pow;
            N temp = new N();
            N delta = new N();
            N res = new N();
            while(COM_NN_D(n1,n2)!=1)
            {
                (digit, pow) = DIV_NN_Dk(n1, n2);
                temp = MUL_ND_N(n2, digit);
                delta = MUL_Nk_N(temp, (ushort)pow);
                n1 = n1 - delta;
                res = res + MUL_Nk_N(digit, (ushort)pow);
                n1.SetTop();
            }
            res.SetTop();
            if (mode == 2)
            {
                return n1;
            }
            else 
            {
                return res;
            }
        }// Деление
        public static N GCF_NN_N(N n1, N n2)
        {
            N a = n1;
            N b = n2;
            if(n2 > n1)
            {
                b = n1;
                a = n2;
            }
            if (a%b == new N(1,"0"))
            {
                return b;
            }
            else
            {
                return GCF_NN_N(a % b, b);
            }
        }//НОД
        public static N LCM_NN_N(N n1, N n2)
        {
            return (n1 * n2 / GCF_NN_N(n1, n2));
        }
    }
}
