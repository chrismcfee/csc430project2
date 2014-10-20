using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using taxdata;

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        string choice;
        string value;
        string kind;

        public void showlisttax(taxes[] source)
        {
            this.Text = "State Tax List";
            label1.Text = "State Tax List";
            choice = "State";
            kind = "Tax";
            value = "$";
            showrtb(source);
        }

        public void showrtb(taxes[] source)
        {
            string temp = "";
            richTextBox1.Text = "\t" + choice + "\t" + kind + "\n\n";
            int i =0;
            while(source[i] != null)
            {
                if (source[i].value.ToString().Length == 1)
                    temp = " ";
                else temp = "";
                richTextBox1.Text = richTextBox1.Text + "\n\t " + source[i].names + "\t" + value + " " + temp + source[i].value.ToString();
                i++;
            }
        }

        public void showlistbenefit(taxes[] source)
        {
            this.Text = "Benefit List";
            label1.Text = "Benefit List";
            choice = "Benefit\t";
            value = "%";
            kind = "Percentage";
            showrtb(source);
            this.ClientSize = new System.Drawing.Size(250, 330);
            this.richTextBox1.Size = new System.Drawing.Size(226, 226);
            this.button1.Location = new System.Drawing.Point(117, 290);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
