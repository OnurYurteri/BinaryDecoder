using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace binaryDecoder
{
    class Utilities
    {
        public static Structure ReadStr(FileInfo readedStr) {
            string line;
            ArrayList str = new ArrayList();
            System.IO.StreamReader sr = new StreamReader(readedStr.FullName);
            while ((line = sr.ReadLine()) != null) {
                str.Add(line);
            }
            sr.Close();
            return new Structure(readedStr.Name,str);
        }
    }
}
