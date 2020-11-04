using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pass_Data_Between_Views_MVC.Models
{
   
    public class Messager
    {
        public string Receiver { get; set; }
        public Senderr Senderr { get; set; }
        public string Text { get; set; }
    }
     
    public class Senderr
    {
        public string Name { get; set; }
    }

}