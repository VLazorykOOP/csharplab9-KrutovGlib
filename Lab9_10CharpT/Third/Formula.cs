using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT.Third
{
    public class Formula : IEnumerable, IComparable, ICloneable
    {
        private ArrayList elements;
     
        public Formula(string formulaString)
        {
            elements = new ArrayList();
            ParseFormula(formulaString);
        }

        private void ParseFormula(string formulaString)
        {
            foreach (char c in formulaString)
            {
                if (c == '(' || c == ')' || c == ',' || char.IsDigit(c))
                {
                    elements.Add(c);
                }
                else if (c == 'p')
                {
                    elements.Add('+');
                }
                else if (c == 'm')
                {
                    elements.Add('-');
                }
            }
        }

        public int Evaluate()
        {
            ArrayList numbers = new ArrayList();
            ArrayList operators = new ArrayList();

            foreach (object obj in elements)
            {
                if (obj is char)
                {
                    char c = (char)obj;
                    if (c == '(')
                    {
                        operators.Add(c);
                    }
                    else if (char.IsDigit(c))
                    {
                        numbers.Add((int)char.GetNumericValue(c));
                    }
                    else if (c == 'p')
                    {
                        operators.Add('+');
                    }
                    else if (c == 'm')
                    {
                        operators.Add('-');
                    }
                    else if (c == ')')
                    {
                        while (operators.Count > 0 && (char)operators[operators.Count - 1] != '(')
                        {
                            int num2 = (int)numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            int num1 = (int)numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            char op = (char)operators[operators.Count - 1];
                            operators.RemoveAt(operators.Count - 1);

                            if (op == '+')
                            {
                                numbers.Add(num1 + num2);
                            }
                            else if (op == '-')
                            {
                                numbers.Add(num1 - num2);
                            }
                        }

                        operators.RemoveAt(operators.Count - 1); 
                    }
                }
            }

            return (int)numbers[0]; 
        }

        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        public int CompareTo(object obj)
        {
            Formula other = obj as Formula;
            if (other == null)
            {
                throw new ArgumentException("Object is not a Formula");
            }
            return this.Evaluate().CompareTo(other.Evaluate());
        }

        public object Clone()
        {
            Formula clone = new Formula("");
            clone.elements.AddRange(this.elements);
            return clone;
        }
    }
}
