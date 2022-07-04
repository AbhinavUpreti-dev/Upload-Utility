using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upload_Utility.Models
{
    public class SheetDetails
    {
        public string SheetURL { get; set; }

        public List<SheetMetaData> SheetMetaData { get; set; }
    }
}