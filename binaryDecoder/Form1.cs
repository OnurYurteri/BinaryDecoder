using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace binaryDecoder
{
    public partial class Form1 : Form
    {
        private bool isFileSelected = false;
        private bool isStructureSelected = false;
        private File currFile = new File();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                textBox1.Text = "";
                textBox1.Text = openFileDialog1.FileName;
                currFile.directory = openFileDialog1.FileName;
                currFile.fileName = openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length-1];
                sr.Close();
                isFileSelected = true;
                ChangeDecodeBtnState();
            }
        }

        private void ChangeDecodeBtnState()
        {
            if(isFileSelected==true && isStructureSelected == true)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void ChangeModifyBtnState()
        {
            if (isStructureSelected == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(listBox1.SelectedIndex < 0))
            {
                isStructureSelected = true;
                ChangeDecodeBtnState();
                ChangeModifyBtnState();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshStr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formCreate = new Form3();
            formCreate.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 formModify = new Form2((Structure)listBox1.SelectedItem);
            formModify.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshStr();
        }

        public void RefreshStr()
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(@"c:\BinaryDecoder");
            if (dir.Exists)
            {
                FileInfo[] readedStr = dir.GetFiles();
                for (int i = 0; i < readedStr.Length; i++)
                {
                    listBox1.Items.Add(Utilities.ReadStr(readedStr[i]));
                }
                
            }
            else
            {
                Directory.CreateDirectory(@"c:\BinaryDecoder");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Decoding decoder = new Decoding(currFile, (Structure)listBox1.SelectedItem);
            richTextBox1.Text = decoder.Decode();
        }
    }
}
