using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolCalc
{
    class Calc
    {
        string[] simicolon;
        float[] number;
       
        #region Конструктор
        public Calc(string st)
        { int simicolon_count = 0;
            for (int i = 0; i < st.Length; i++) 
            {
                if (st[i] == '+' || st[i] == '*' || st[i] == '/' || st[i] == '-') 
                {
                    simicolon_count++;
                }
            }
            simicolon = new string[simicolon_count];
            number = new float[simicolon_count+1];
            ParseString(st);
            AnswerMultiplayAndDivided();
            AnswerPlusAndMinus();
            
        }
        #endregion

        #region Парсим строку 
        private void ParseString(string st) 
        {
            int index_number = 0;
            int index_simicolon = 0;

            string temp="";
            for (int i = 0; i < st.Length; i++) 
            {
                if (i == st.Length - 1)
                {
                    temp += st[i].ToString();
                    number[index_number] += float.Parse(temp); 
                }
                if (st[i] == '+' || st[i] == '*' || st[i] == '/' || st[i] == '-' )
                {                  
                    simicolon[index_simicolon] += st[i];
                    number[index_number] += float.Parse(temp);
                    temp = "";
                    index_simicolon++;
                    index_number++;
                }
                else 
                {
                    temp += st[i].ToString();                    
                }
            }
        }
        #endregion

        #region умножение и деление
        private void AnswerMultiplayAndDivided() 
        {
            for (int i = 0; i < simicolon.Length; i++) 
            {
                if (simicolon[i] == '/'.ToString()) 
                {
                    number[i+1] = number[i] / number[i + 1];
                    number[i] = 0;
                    simicolon[i] = '+'.ToString();
                }
                if (simicolon[i] == '*'.ToString()) 
                {
                    number[i+1] = number[i] * number[i + 1];
                    number[i] = 0;
                    simicolon[i] = '+'.ToString();
                }
            }
        }
        #endregion

        private void AnswerPlusAndMinus() 
        {
            for(int i = 0; i<simicolon.Length; i++)
            {
                if(simicolon[i] == '+'.ToString())
                {
                    number[i + 1] = number[i] + number[i + 1];
                }
                if(simicolon[i] == '-'.ToString())
                {
                    number[i + 1] = number[i] - number[i + 1];
                }
            }
        }

        public void Display()
        {
            Console.WriteLine(" Answer " + number[number.Length-1]);
        }
    }
}
