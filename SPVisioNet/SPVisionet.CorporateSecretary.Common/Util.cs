using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SPVisionet.CorporateSecretary.Common
{
    public class Util
    {
        public static void RegisterStartupScript(Page Page, string Key, string script)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), Key, script, true);
        }
    }
}
