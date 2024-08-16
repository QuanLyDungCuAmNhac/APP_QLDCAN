using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhTrangItem
    {
        public string Value { get; set; }
        public string Display { get; set; }

        public TinhTrangItem(string value, string display)
        {
            Value = value;
            Display = display;
        }
    }
}
