using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCF_Domain
{
    public class DataItems
    {
        private string name;
        private string details;

        public string Name
        {
            get { return name; }
        }

        public string Details
        {
            get { return details; }
        }

        public DataItems(string name, string details)
        {
            this.name = name;
            this.details = details;
        }
    }
}
