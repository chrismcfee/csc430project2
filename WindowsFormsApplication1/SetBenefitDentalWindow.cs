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
    using benefitdatabase;
    public partial class SetBenefitDentalWindow : Form
    {

        public benefitdata benefits;
        public benefitdata dentals;
        public string benefitcode = "NOVALUE";
        public string dentalcode = "NOVALUE";
        public bool iscancelled;

        public SetBenefitDentalWindow()
        {
            InitializeComponent();
        }

        private void SetBenefitDentalWindow_Load(object sender, EventArgs e)
        {
            iscancelled = true;
        }

        public void inputdata(benefitdata databenefit, benefitdata datadental, string benefitin = "", string dentalin = "")
        {
            benefits = new benefitdata();
            benefits.copydata(databenefit);
            dentals = new benefitdata();
            dentals.copydata(datadental);
            //addItem(comboBox6, "INDIVIDUAL");
            //addItem(comboBox6, "GROUP");
            for(int i = 0; i < benefits.noe; i++)
            {
                if (i == 0)
                    addItem(comboBox1, benefits.data[i].brand);
                else
                    if (benefits.data[i].brand != benefits.data[i - 1].brand)
                        addItem(comboBox1, benefits.data[i].brand);
            }
            for (int i = 0; i < dentals.noe; i++)
            {
                if (i == 0)
                    addItem(comboBox4, dentals.data[i].brand);
                else
                    if (dentals.data[i].brand != dentals.data[i - 1].brand)
                        addItem(comboBox4, dentals.data[i].brand);
            }

            if (benefitin == "")
            {
                comboBox1.Text = "NA";
                comboBox2.Text = "NA";
                comboBox3.Text = "NA";
            }
            else
            {
                benefitvalue temp = new benefitvalue();
                temp = benefits.output(benefitin);
                comboBox1.Text = temp.brand;
                comboBox2.Text = temp.level;
                comboBox3.Text = temp.type;
            }

            if (dentalin == "")
            {
                comboBox4.Text = "NA";
                comboBox5.Text = "NA";
                comboBox6.Text = "NA";
            }
            else
            {
                benefitvalue temp = new benefitvalue();
                temp = dentals.output(dentalin);
                comboBox4.Text = temp.brand;
                comboBox5.Text = temp.level;
                comboBox6.Text = temp.type;
            }


            getvalue();
        }


        private void addItem(ComboBox source, string text)
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = text;
            item.Value = source.Items.Count;
            source.Items.Add(item);
        }

        public string benefitcodeout()
        {
            return benefitcode;
        }

        public string dentalcodeout()
        {
            return dentalcode;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text == "NA")
            {
                comboBox3.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Text = "NA";
                comboBox2.Text = "NA";
            }
            else
            {
                comboBox3.Items.Clear();
                comboBox2.Items.Clear();
                addItem(comboBox3, "INDIVIDUAL");
                addItem(comboBox3, "GROUP");
                comboBox3.Text = "INDIVIDUAL";
                for (int i = benefits.noe - 1; i >= 0; i--)
                    if (benefits.data[i].brand == comboBox1.Text && benefits.data[i].type != "GROUP" && benefits.data[i].brand != "NA")
                    {
                        addItem(comboBox2, benefits.data[i].level);
                        comboBox2.Text = benefits.data[i].level;
                    }
            }
            getvalue();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            if (comboBox4.Text == "NA")
            {
                comboBox6.Items.Clear();
                comboBox5.Items.Clear();
                comboBox6.Text = "NA";
                comboBox5.Text = "NA";
            }
            else
            {
                comboBox6.Items.Clear();
                comboBox5.Items.Clear();
                addItem(comboBox6, "INDIVIDUAL");
                addItem(comboBox6, "GROUP");
                comboBox6.Text = "INDIVIDUAL";
                for (int i = dentals.noe - 1; i >= 0; i--)
                    if (dentals.data[i].brand == comboBox4.Text && dentals.data[i].type != "GROUP" && dentals.data[i].brand != "NA")
                    {
                        addItem(comboBox5, dentals.data[i].level);
                        comboBox5.Text = dentals.data[i].level;
                    }
            }
            getvalue();
        }

        private void getvalue()
        {
            benefitcode = benefits.codeoutput(comboBox1.Text, comboBox3.Text, comboBox2.Text);
            textBox2.Text = benefitcode;
            textBox1.Text = "$ " + benefits.valueoutput(benefitcode).ToString();

            dentalcode = dentals.codeoutput(comboBox4.Text, comboBox6.Text, comboBox5.Text);
            textBox3.Text = dentalcode;
            textBox4.Text = "$ " + dentals.valueoutput(dentalcode).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalue();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalue();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalue();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            getvalue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iscancelled = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iscancelled = true;
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
