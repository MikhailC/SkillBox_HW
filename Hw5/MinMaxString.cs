using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Hw5
{
    public class MinMaxString
    {
        private int _maxLength = -1;
        private int _minLength = -1;

        private List<string> words = new List<string>();

        public MinMaxString()
        {
        }

        public MinMaxString(string inputString)
        {
            var stringArray = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

           

            foreach (var s in stringArray)
            {
                String = s;
            }
    
        }
        public string[] GetMinWords()
        {
            List<string> result = new List<string>();
            foreach (var w in words)
            {
                if(w.Length==_minLength) result.Add(w);
            }

            return result.ToArray();
        }
        
        public string[] GetMaxWords()
        {
            List<string> result = new List<string>();
            foreach (var w in words)
            {
                if(w.Length==_maxLength) result.Add(w);
            }

            return result.ToArray();
        }
        

        public string String
        {
            set
            {
                int len = value.Length;
                if (len > _maxLength)
                {
                     
                    _maxLength = len;
                }

                if (len < _minLength || _minLength == -1)
                {
                    
                    _minLength = len;
                }
                
                words.Add(value);


            }
        }
        
        


        public override string ToString()
        {
            var mw = GetMinWords();

            string isword = " is";
            
            if (mw.Length == 0) return "No words found";
            if (mw.Length != 1) isword = "s are"; 
            string res = $"Minimal length word{isword} ";
            
            foreach (var w in GetMinWords())
            {
                res += w + ", ";
            }

            mw = GetMaxWords();
             isword = " is";
            if (mw.Length != 1) isword = "s are";
            
                
            res += $" maximum length word{isword} ";
            foreach (var w in GetMaxWords())
            {
                res += w + ", ";
            }

            return res.Substring(0,res.Length-2);

        }

        public string GetFirstMinString() => words.FirstOrDefault(x => x.Length == _minLength);
    }
    }
