using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrack.Business.CodeExamples
{
    class LambdaExamples
    {
        public LambdaExamples()
        {
            Func<string> _stringMethod;
            Func<int,int,string> _sumMethod;
            Func<int, string> _sumOtherMethod;
            _stringMethod = MyMethod;
            _stringMethod = () => { return "test 2"; };
            _stringMethod = () => "test 3";
            _sumMethod = SumMethod;
            _sumOtherMethod = a => a.ToString();
            var sumResult = _sumMethod(1, 2);
            _sumMethod = (number1, number2) => (number1 + number2).ToString();

            var result = _stringMethod();
        }
        
        public string SumMethod(int a, int b)
        {
            return (a + b).ToString();
        }

        public string MyMethod()
        {
            return "test";
        }
    }
}
