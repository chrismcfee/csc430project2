using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    //using pinfo;
    using cdata;
    using pinfo;


    public partial class Form1 : Form
    {
        private FileStream input;
        private StreamReader fileReader;
        string fileName;
        private people data;
        int schoice = 6;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            data = new people();
            MessageBox.Show("Please open a database (text file)", "INFO");
            DialogResult result;
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }
            if (result == DialogResult.OK)
            {
                try
                {

                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    fileReader = new StreamReader(input);
                    string[] info;
                    while (fileReader.Peek() >= 0)
                    {
                        info = fileReader.ReadLine().Split('\t');
                        data.input(info);
                    }
                    richTextBox1.Text = data.display();
                    linkLabel1.Text = fileName;
                    input.Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("error reading file");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox8.Text == "")
                toolTip1.Show("Please enter information first.", button1, 110, 40);
            else
            {
                string[] temp = new string[8];
                string line;
                if (textBox2.Text == "")
                    textBox2.Text = "NA";
                if (textBox3.Text == "")
                    textBox3.Text = "NA";
                if (textBox4.Text == "")
                    textBox4.Text = "NA";
                temp[0] = textBox2.Text.ToUpper();
                temp[1] = textBox3.Text.ToUpper();
                temp[2] = textBox4.Text.ToUpper();
                temp[3] = textBox5.Text;
                temp[4] = textBox6.Text;
                temp[5] = textBox7.Text;
                temp[6] = textBox8.Text;
                //temp[7] = textBox9.Text;
                if (textBox5.Text == "")
                    temp[3] = "NA";
                if (textBox6.Text == "")
                    temp[4] = "NA";
                if (textBox7.Text == "")
                    temp[5] = "NA";
                if (textBox8.Text == "")
                    temp[6] = "NA";
                //if (textBox9.Text == "")
                  //  temp[7] = "NA";
                data.input(temp);

                line = temp[0] + "\t" + temp[1] + "\t" + temp[2] + "\t" + temp[3] + "\t" + temp[4] + "\t" + temp[5] + "\t" + temp[6] + "\t" + temp[7];
                File.AppendAllText(fileName, Environment.NewLine + line);
                searchtb1();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                //textBox9.Text = "";
            }
        }

        void searchtb1()
        {
            if (textBox1.Text == "")
                richTextBox1.Text = data.display();
            else
            {
                richTextBox1.Text = data.search(textBox1.Text.ToUpper(), schoice);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchtb1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 15;
            schoice = 6;
            if (comboBox1.Text == "ID")
                schoice = 1;
            if (comboBox1.Text == "Name")
                schoice = 0;
            if (comboBox1.Text == "Benfits")
                schoice = 2;
            if (comboBox1.Text == "Telephone")
                schoice = 3;
            if (comboBox1.Text == "Floor")
            {
                schoice = 4;
                textBox1.MaxLength = 1;
            }
            if (comboBox1.Text == "Birth Month")
            {
                schoice = 5;
                textBox1.MaxLength = 2;
            }
            searchtb1();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox5.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(textBox5.Text, out temp))
                {
                    stemp = textBox5.Text;
                    stemp = stemp.Substring(0,stemp.Length - 1);
                    textBox5.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox5, 110, 10);
                    textBox5.SelectionStart = textBox5.Text.Length;
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox6.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(textBox6.Text, out temp))
                {
                    stemp = textBox6.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox6.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox6, 110, 10);
                    textBox6.SelectionStart = textBox6.Text.Length;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox7.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(textBox7.Text, out temp))
                {
                    stemp = textBox7.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox7.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox7, 110, 10);
                    textBox7.SelectionStart = textBox7.Text.Length;
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox8.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(textBox8.Text, out temp))
                {
                    stemp = textBox8.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox8.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox8, 110, 10);
                    textBox8.SelectionStart = textBox8.Text.Length;
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            /*if (Convert.ToString(textBox9.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(textBox9.Text, out temp))
                {
                    stemp = textBox9.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox9.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox9, 110, 10);
                    textBox9.SelectionStart = textBox9.Text.Length;
                }
            }*/
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", fileName);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Enter search word here", textBox1, 50, 20);
        }

        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Click to Open the file", linkLabel1, 300, 20);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace cdata
{
    using pinfo;
    public class people
    {
        public person[] infos = new person[100];
        public int noe = 0;
        public bool isFull() { return (noe == 100); }
        public string display()
        {
            string temp = "";
            for (int i = 0; i < noe; i++)
                temp = temp + infos[i].getInfo() + "\n";
            return temp;
            
        }

        public void input(string[] info)
        {
            if (isFull())
            {
                MessageBox.Show("!The data is full");
                return;
            }
            infos[noe] = new person();
            for (int i = 0; i <= 4; i++)
                infos[noe].info[i] = info[i];
            infos[noe].date.m = info[5];
            infos[noe].date.d = info[6];
            infos[noe].date.y = info[7];
            noe++;
        }

        public string search(string word, int choice)
        {
            string temp = "";
            if (choice <= 3)
            {
                for (int i = 0; i < noe; i++)
                {
                    if (infos[i].info[choice].Contains(word))
                        temp = temp + infos[i].getInfo() + "\n";
                }
            }
            else
                if (choice == 4)
                {
                    for (int i = 0; i < noe; i++)
                    {
                        if (infos[i].info[choice][0] == word[0])
                            temp = temp + infos[i].getInfo() + "\n";
                    }
                }
                else
                    if (choice == 5)
                    {
                        for (int i = 0; i < noe; i++)
                        {
                            if (infos[i].date.m == word)
                                temp = temp + infos[i].getInfo() + "\n";
                        }
                    }
                    else
                        return "!Please select a search method.";
            if (temp == "")
                temp = "!No result for your search.";
            return temp;
        }
    }

}

namespace pinfo
{
    public class person
    {
        public class cdate
        {
            public string m;
            public string d;
            public string y;
            public string printdate()
            {
                string tempm = m, tempd = d;
                if (m.Length < 2)
                    tempm = "0" + m;
                if (d.Length < 2)
                    tempd = "0" + d;
               return (tempm + "/" + tempd + "/" + y);
            }
        }
        public cdate date = new cdate();
        //private static date dob = new date();
        public string[] info = new string[5];

        public string getInfo()
        {
            return (String.Format("{0,17:D}{1,13:D}{2,6:D}{3,15:D}{4,9:D}{5,15:D}", info[0], info[1], info[2], info[3], info[4], date.printdate()));
        }
    }
}
