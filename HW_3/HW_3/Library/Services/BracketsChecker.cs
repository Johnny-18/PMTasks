using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class BracketsChecker
    {
        private readonly string _opening = "([{<";
        private readonly string _closing = ")]}>";
    
        private bool _cantBeBalanced;
        public int Index { get; private set; }

        private readonly Stack<(int, int)> _opened = new Stack<(int, int)>();
    
        public bool Balanced => !_cantBeBalanced && !_opened.Any();
    
        public void Put(char[] arr)
        {
            
            for(int i = 0; i < arr.Length;i++)
            {
                int index = _opening.IndexOf(arr[i]);
                if (index != -1)
                {
                    _opened.Push((i, index));
                    continue;
                }

                index = _closing.IndexOf(arr[i]);

                if (index != -1)
                {
                    if (!_opened.Any() || _opened.Peek().Item2 != index)
                    {
                        Index = i;
                        _cantBeBalanced = true;
                        _opened.Clear();
                        _opened.TrimExcess();
                        break;
                    }

                    _opened.Pop();
                }
                
                if(_opened.Any())
                    Index = _opened.Peek().Item1;
            }
        }
    }
}