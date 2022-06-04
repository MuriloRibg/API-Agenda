using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Comum.Enums
{
    public class EnumValue
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            var value = obj as EnumValue;
            return value != null &&
                   Value == value.Value &&
                   Description == value.Description;
        }
    }
}
