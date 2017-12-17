using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace binaryDecoder
{
    public class Structure
    {
        public string name;
        public ArrayList structure = new ArrayList();

        public Structure(string _name, ArrayList _structure) {
            this.name = _name;
            this.structure = _structure;
        }

        public override string ToString()
        {
            return name.ToString();
        }

    }
}
