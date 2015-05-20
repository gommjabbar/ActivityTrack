using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrack.Business
{
    public static class ExtensionMethods
    {
        public static string ToExt(this object obj)
        {
            return "Ext";
        }

        public ExtensionMethods()
        {
            var o = new Object();
            var res = o.ToExt();
        }
    }
}
