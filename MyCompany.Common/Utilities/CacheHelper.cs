using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common.Utilities;

public static class CacheHelper
{
    public static void ClearList<T>(List<T> list)
    {
        list?.Clear();
    }
}
