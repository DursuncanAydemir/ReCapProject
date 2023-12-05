using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.GuidHelper
{
    public class GuidHelperManager
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }

}
