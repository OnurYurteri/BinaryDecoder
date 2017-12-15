using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryDecoder
{
    class Decoding
    {
        public File file;
        public Structure str;

        public Decoding(File _file,Structure _str) {
            this.file = _file;
            this.str = _str;
        }

        public string Decode() {
            string result="";
            FileStream readStream = new FileStream(file.directory,FileMode.Open);
            BinaryReader readBinary = new BinaryReader(readStream);
            
            for (int i = 0; i < str.structure.Count; i++)
            {
                if (str.structure[i].ToString().Split('-')[0].Equals("INT"))
                {
                    result += readBinary.ReadInt32();
                }
                else if (str.structure[i].ToString().Split('-')[0].Equals("FLOAT"))
                {
                    result += readBinary.ReadDouble();
                }
                else if (str.structure[i].ToString().Split('-')[0].Equals("CHAR"))
                {
                    result += new String(readBinary.ReadChars(Int32.Parse(str.structure[i].ToString().Split('-')[1])));
                }
                else if (str.structure[i].ToString().Split('-')[0].Equals("EMPTY"))
                {
                    readBinary.ReadBytes(Int32.Parse(str.structure[i].ToString().Split('-')[1]));
                }
                else if (str.structure[i].ToString().Split('-')[0].Equals("STARTLOOP"))
                {
                    result += DecodeLoop(Int32.Parse(str.structure[i].ToString().Split('-')[1]), i + 1, readBinary);
                    for (int j = i; j < str.structure.Count; j++)
                    {
                        if (str.structure[j].ToString().Split('-')[0].Equals("ENDLOOP"))
                        {
                            i += j - i;
                            break;
                        }
                    }
                }
            }
            readBinary.Close();
            readStream.Close();
            return result;
        }

        private string DecodeLoop(int _count,int _index, BinaryReader readBinary)
        {
            string result = "";
            int index = _index;
            //FileStream readStream = new FileStream(file.directory, FileMode.Open);
            //BinaryReader readBinary = new BinaryReader(readStream);
            for (int j = 0; j < _count; j++)
            {
                while (!str.structure[index].ToString().Split('-')[0].Equals("ENDLOOP"))
                {
                    if (str.structure[index].ToString().Split('-')[0].Equals("INT"))
                    {
                        result += readBinary.ReadInt32();
                    }
                    else if (str.structure[index].ToString().Split('-')[0].Equals("FLOAT"))
                    {
                        result += readBinary.ReadDouble();
                    }
                    else if (str.structure[index].ToString().Split('-')[0].Equals("CHAR"))
                    {
                        result += new String(readBinary.ReadChars(Int32.Parse(str.structure[index].ToString().Split('-')[1])));
                    }
                    else if (str.structure[index].ToString().Split('-')[0].Equals("EMPTY"))
                    {
                        readBinary.ReadBytes(Int32.Parse(str.structure[index].ToString().Split('-')[1]));
                    }
                    else if (str.structure[index].ToString().Split('-')[0].Equals("STARTLOOP"))
                    {
                        result += DecodeLoop(Int32.Parse(str.structure[index].ToString().Split('-')[1]), index+1,readBinary);
                    }
                    index++;
                }
                index = _index;
            }
            return result;
        }
    }
}
