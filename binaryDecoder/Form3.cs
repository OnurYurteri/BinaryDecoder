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

        private bool IsInt(string s)
        {
            int x = 0;
            return int.TryParse(s, out x);
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
            if (comboBox1.SelectedItem.ToString() != "INT" && comboBox1.SelectedItem.ToString() != "ENDLOOP" && comboBox1.SelectedItem.ToString() != "FLOAT" && comboBox1.SelectedItem.ToString() != "STRING") {
                textBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Enabled = false;
            if (comboBox2.SelectedItem.ToString() != "INT" && comboBox2.SelectedItem.ToString() != "ENDLOOP" && comboBox2.SelectedItem.ToString() != "FLOAT" && comboBox2.SelectedItem.ToString() != "STRING")
            {
                textBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Enabled)
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    if (!textBox2.Text.Equals("") && IsInt(textBox2.Text))
                    {
                        listBox1.Items.Add(comboBox1.SelectedItem + "-" + textBox2.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter count");
                    }
                }
                else
                {
                    MessageBox.Show("Please select type");
                }
            }
            else
            {
                if (comboBox1.SelectedIndex>-1)
                {
                    listBox1.Items.Add(comboBox1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Please select type");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Enabled)
            {
                if (comboBox2.SelectedIndex>-1)
                {
                    if (!textBox3.Text.Equals("") && IsInt(textBox3.Text))
                    {
                        listBox1.Items[listBox1.SelectedIndex] = comboBox2.SelectedItem + "-" + textBox3.Text;
                    }
                    else
                    {
                        MessageBox.Show("Please enter count");
                    }
                }
                else
                {
                    MessageBox.Show("Please select type");
                }
            }
            else
            {
                if (comboBox2.SelectedIndex >-1)
                {
                    if (listBox1.SelectedIndex>-1)
                    {
                        listBox1.Items[listBox1.SelectedIndex] = comboBox2.SelectedItem;
                    }
                    else
                    {
                        MessageBox.Show("Please select type that you wanted to change");
                    }
                }
                else
                {
                    MessageBox.Show("Please select type");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select type that you wanted to delete");
            }
        }
    }
}
