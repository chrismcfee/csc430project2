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
    using linkedlist;
    using pinfo;
    using taxdata;

    public partial class CheckWindow : Form
    {
        public CheckWindow()
        {
            InitializeComponent();
        }

        private string data = "";

        private void CheckWindow_Load(object sender, EventArgs e)
        {

        }

        public void setpersondata(pnode source, taxes[] states, taxes[] benefits)
        {
            string stax = "";
            string bene = "";
            string rtnum = "";
            int i = 0;
            data = data + "First Name:\t" + source.data.firstname + "\n";
            data = data + "Last Name:\t" + source.data.lastname + "\n";
            data = data + "Gross Income:\t$ " + source.data.gincome.ToString() + "\n";
            while (states[i] != null)
            {
                if (states[i].names == source.data.state)
                {
                    stax = states[i].value.ToString();
                    rtnum = states[i].routingnum;
                    break;
                }
                i++;
            }
            data = data + "State:\t\t" + source.data.state + "\n";
            data = data + "State Tax:\t$ " + stax + "\n";
            //data = data + "Local Tax:\t" + "N/A" + "\n";
            data = data + "Benefit Type:\t" + source.data.benefit + "\n";
            i = 0;
            while (benefits[i] != null)
            {
                if (benefits[i].names == source.data.benefit)
                {
                    bene = benefits[i].value.ToString();
                    break;
                }
                i++;
            }
            data = data + "Benefit:\t\t% " + bene + "\n";
            data = data + "Employee Tax:\t$ " + source.data.tax.ToString() +"\n";
            data = data + "Routing Number:\t" + rtnum + "\n";
            data = data + "Account Number:\t" + source.data.accnum + "\n";
            data = data + "Net Pay:\t\t" + source.data.npay.ToString();
            richTextBox1.Text = data;
            richTextBox1.Enabled = false;
            label1.Text = source.data.firstname + " " + source.data.lastname + "'s Information:";
            this.Text = source.data.firstname + " " + source.data.lastname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
