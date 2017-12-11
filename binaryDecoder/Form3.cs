using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace binaryDecoder
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList str = new ArrayList();
            if (textBox1.Text != "" && listBox1.Items.Count > 0) {
                if (!System.IO.File.Exists(@"C:\BinaryDecoder\" + textBox1.Text))
                {
                    //System.IO.File.Create(@"C:\BinaryDecoder\" + textBox1.Text + ".txt");
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\BinaryDecoder\" + textBox1.Text+".txt"))
                        {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                            {
                                file.WriteLine(listBox1.Items[i]);
                            }
                        file.Close();
                        }
                        
                    MessageBox.Show("Structure saved successfully!");
                    Program.form.RefreshStr();
                    this.Hide();
                }
                else
                {
                    Console.WriteLine("Structure \"{0}\" already exists.", textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Please fill all necessary fields.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Enabled = false;
            if (comboBox1.SelectedItem.ToString() != "INT" && comboBox1.SelectedItem.ToString() != "ENDLOOP") {
                textBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Enabled = false;
            if (comboBox2.SelectedItem.ToString() != "INT" && comboBox2.SelectedItem.ToString() != "ENDLOOP")
            {
                textBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.SelectedItem + textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items[listBox1.SelectedIndex] = comboBox2.SelectedItem + textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
