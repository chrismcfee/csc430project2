using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//displays a check window

namespace WindowsFormsApplication1
{
    using linkedlist;
    using pinfo;
    using taxdata;
    using benefitdatabase;

    public partial class CheckWindow : Form
    {
        public CheckWindow()
        {
            InitializeComponent();
        }

        private string data = "";
        private Checkform form = new Checkform();
        public person pdata;

        private void CheckWindow_Load(object sender, EventArgs e)
        {
            richTextBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
           
        }

        public void setpersondata(pnode source, taxes[] states, benefitdata databenefit, benefitdata datadental)
        {
                     
            string stax = "";
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
            data = data + "State Tax:\t$ " + stax + "\n\n";

            data = data + "Benefit Code:\t" + source.data.benefit + "\n";
            data = data + "Benefit Brand:\t " + source.data.benefitdetail.brand + "\n";
            data = data + "Benefit Type:\t " + source.data.benefitdetail.type + "\n";
            data = data + "Benefit Level:\t " + source.data.benefitdetail.level + "\n";
            data = data + "Benefit Value:\t$ " + source.data.benefitdetail.value.ToString() + "\n\n";

            data = data + "Dental Code:\t" + source.data.dental + "\n";
            data = data + "Dental Brand:\t " + source.data.dentaldetail.brand + "\n";
            data = data + "Dental Type:\t " + source.data.dentaldetail.type + "\n";
            data = data + "Dental Level:\t " + source.data.dentaldetail.level + "\n";
            data = data + "Dental Value:\t$ " + source.data.dentaldetail.value.ToString() + "\n\n";

            data = data + "Employee Tax:\t$ " + source.data.tax.ToString() +"\n";
            data = data + "Routing Number:\t" + rtnum + "\n";
            data = data + "Account Number:\t" + source.data.accnum + "\n";
            data = data + "Net Pay:\t\t" + source.data.npay.ToString();
            richTextBox1.Text = data;
            richTextBox1.Enabled = false;
            label1.Text = source.data.firstname + " " + source.data.lastname + "'s Information:";
            this.Text = source.data.firstname + " " + source.data.lastname;


            pdata = new person();
            pdata = source.data;
            if (pdata.check == "YES")
            {
                button2.Enabled = true;
                form.indata(pdata);
                form.rtnum = rtnum;
            }
            else
                button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form.ShowDialog();
        }

        
    }
}
