using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.Models
{
    public class Make
    {
        public int Id { get;}
        public string MakeName { get; }

        public Make(int id, string makeName)
        {
            Id = id;
            MakeName = makeName;
        }
    }
}
