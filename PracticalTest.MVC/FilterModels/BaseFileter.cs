using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.MVC.FilterModels
{
    public class BaseFileter
    {
        public int Page { get; set; } = 1;
        public string Query { get; set; }
    }
}
