using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja
{
    public static class Extension
    {
        public static T Choose<T>(this Random random, params T[] args)
        {
            return args[random.Next(0, args.Length)];
        }
    }
}
