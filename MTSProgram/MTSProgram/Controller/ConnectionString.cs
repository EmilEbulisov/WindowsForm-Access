using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MTSProgram.Controller
{
    internal class ConnectionString
    {
        public static string ConnStr
            {
                get 
                {
                return
                ConfigurationManager.ConnectionStrings["MTSProgram.Properties.Settings.ConnStr"].ConnectionString;
                }
            }
    }
}
