using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upload_Utility.Models
{
    public class SheetMetaData
    {     
        public string StudentName{ get; set; }

        public string Gender { get; set; }
        public string Class { get; set; }
        public string State { get; set; }

        public string Major { get; set; }

        public string Activity { get; set; }

        //Student Name	Gender	Class Level	Home State	Major	Extracurricular Activity	
    }
}