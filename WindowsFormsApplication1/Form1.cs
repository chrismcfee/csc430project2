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
    using pinfo;
    using linkedlist;

    public partial class Form1 : Form
    {
        private FileStream input;
        private StreamReader fileReader;
        string fileName;
        private plist data;
        int schoice = 6;
        pnode ntemp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            data = new plist();
            MessageBox.Show("Please open the database file to begin editing.", "ATTENTION");
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
                    textBox7.Text = idgen();
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
            if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
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
                temp[0] = idgen();
                temp[1] = textBox2.Text.ToUpper();
                temp[2] = textBox3.Text.ToUpper();
                temp[3] = textBox4.Text.ToUpper();
                temp[4] = textBox5.Text;
                temp[5] = textBox6.Text;
                if (textBox5.Text == "")
                    temp[4] = "00";
                if (textBox6.Text == "")
                    temp[5] = "00";
                data.input(temp);

                line = temp[0] + "\t" +temp[1] + "\t" + temp[2] + "\t" + temp[3] + "\t" + temp[4] +"\t" + temp[5];
                //File.AppendAllText(fileName, Environment.NewLine + line);
                searchtb1();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        void searchtb1()
        {
            if (textBox1.Text == "")
                richTextBox1.Text = data.display();
            else
            {
                string temp = "";
                temp = data.search(textBox1.Text.ToUpper(), schoice);
                richTextBox1.Text = temp;
                modifycheck(temp.Split('\n').Length);
            }
        }

        void modifycheck(int index)
        {
            if (index == 2)
            {
                modify.Enabled = true;
                delete.Enabled = true;
            }
            else
            {
                modify.Enabled = false;
                delete.Enabled = false;
            }
        }

        string idgen()
        {
            string index = "0000000000";
            int noe = data.getlastid(), count = 0;
            while(noe > 1)
            {
                noe = noe / 10;
                count++;
            }

            index = index.Substring(0, index.Length - count);
            count = data.getlastid();
            count++;
            index = index + count.ToString();
            return index;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchtb1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 15;
            schoice = 7;
            if (comboBox1.Text == "Last Name")
                schoice = 0;
            if (comboBox1.Text == "First Name")
                schoice = 1;
            if (comboBox1.Text == "Benefit")
                schoice = 2;
            if (comboBox1.Text == "Tax")
                schoice = 3;
            if (comboBox1.Text == "Gross Income")
                schoice = 4;
            if (comboBox1.Text == "Net Pay")
                schoice = 5;
            if (comboBox1.Text == "ID")
                schoice = 6;
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
                double temp;
                if (!double.TryParse(textBox5.Text, out temp))
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
                double temp;
                if (!double.TryParse(textBox6.Text, out temp))
                {
                    stemp = textBox6.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox6.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox6, 110, 10);
                    textBox6.SelectionStart = textBox6.Text.Length;
                }
            }
        }
        /*
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
            if (Convert.ToString(textBox9.Text) != "")
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
            }
        }*/

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

        private void delete_Click(object sender, EventArgs e)
        {
            data.deletenode(data.searchnode(textBox1.Text.ToUpper(), schoice)+1);
            textBox1.Text = "";
            modify.Enabled = false;
            delete.Enabled = false;
        }

        private void modify_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            save.Enabled = true;
            cancel.Enabled = true;
            modify.Enabled = false;
            delete.Enabled = false;
            ntemp = data.findnode(data.searchnode(textBox1.Text.ToUpper(), schoice));
            textBox2.Text = ntemp.data.lastname;
            textBox3.Text = ntemp.data.firstname;
            textBox4.Text = ntemp.data.benefit;
            textBox5.Text = ntemp.data.tax.ToString();
            textBox6.Text = ntemp.data.gincome.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            save.Enabled = false;
            cancel.Enabled = false;
            ntemp.data.lastname = textBox2.Text;
            ntemp.data.firstname = textBox3.Text;
            ntemp.data.benefit = textBox4.Text;
            ntemp.data.tax = Convert.ToDouble(textBox5.Text);
            ntemp.data.gincome = Convert.ToDouble(textBox6.Text);
            textBox1.Text = "";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            save.Enabled = false;
            cancel.Enabled = false;
            textBox1.Text = "";
            searchtb1();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(fileName, data.output());
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


    }
}


namespace linkedlist
{
    using pinfo;

    public class pnode
    {
        public pnode next = null;
        public person data = new person();
    }

    public class plist
    {
        private pnode head = null;
        private int noe = 0;
        public bool isEmpty()
        {
            return (head == null);
        }
        public void input(string[] info)
        {
            if (isEmpty())
            {
                head = new pnode();
                head.data = new person();
                head.next = null;
                head.data.input(info);
                noe++;
            }
            else
            {
                pnode temp;
                findnode(noe).next = new pnode();
                temp = findnode(noe).next;
                temp.next = null;
                temp.data = new person();
                temp.data.input(info);
                noe++;
            }
            
        }

        public int getlastid()
        {
            return findnode(noe).data.getid();
        }

        public int getnoe()
        { return noe; }

        public string display()
        {
            string temp = "";
            pnode tempnode = head;
            if (isEmpty())
                return "The list contains NOTHING!";
            for (int i = 0; i < noe; i++)
            {
                temp = temp + tempnode.data.getInfo() + "\n";
                tempnode = tempnode.next;
            }
            return temp;

        }

        public pnode findnode(int pos)
        {
            pnode temp = head;
            if (isEmpty())
                return null;
            else
                if (noe == 1)
                    return head;
                else
                {
                    for (int i = 0; i < pos-1; i++)
                    {
                        if (i >= noe)
                        {
                            MessageBox.Show("Returned the last posistion", "The position is larger than the size");
                            break;
                        }
                        temp = temp.next;
                    }
                    return temp;
                }
            
        }

        public void deletenode(int pos)
        {
            pnode temp;
            temp = findnode(pos);
            if (pos == noe)
                findnode(pos - 1).next = null;
            else
                findnode(pos - 1).next = temp.next;
            noe--;
        }

        public int searchnode(string word, int choice)
        {
            pnode tempnode = head;
            int i = -1;
            switch (choice)
            {
                case 0:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.lastname.Contains(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 1:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.firstname.Contains(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 2:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.benefit.Contains(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 3:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.tax == Convert.ToDouble(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 4:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.gincome == Convert.ToDouble(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 5:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.npay == Convert.ToDouble(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
                case 6:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.id.Contains(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
            }
            return i;
        }

        public string search(string word, int choice)
        {
            string temp = "";
            pnode tempnode = head;
            if (isEmpty())
                return "The list contains NOTHING!";
            switch (choice)
            {
                case 0:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.lastname.Contains(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 1:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.firstname.Contains(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 2:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.benefit.Contains(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 3:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.tax == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 4:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.gincome == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 5:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.npay == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 6:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.id.Contains(word))
                            temp = temp + tempnode.data.getInfo() + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                //default: temp = "";
            }
            if (temp == "")
                temp = "!No result for your search.";
            return temp;
        }

        public string output()
        {
            string temp = "";
            pnode tempnode = head;

            for (int i = 0; i < noe; i++)
            {
                if (i == 0)
                    temp = tempnode.data.output();
                else
                    temp = temp + Environment.NewLine + tempnode.data.output();
                tempnode = tempnode.next;
            }

            return temp;
        }
        
    }
}

namespace pinfo
{
    public class person
    {
        //private static date dob = new date();
        public string id = "",lastname = "",firstname = "", benefit = "";
        public double tax, gincome, npay;
        public void input(string[] source)
        {
            id = source[0];
            lastname = source[1];
            firstname = source[2];
            benefit = source[3];
            tax = Convert.ToDouble(source[4]);
            gincome = Convert.ToDouble(source[5]);
            npay = gincome - tax;
        }
        public int getid()
        {
            return Convert.ToInt32(id);
        }
        public string getInfo()
        {
            return (String.Format("{0,17:D}{1,13:D}{2,6:D}{3,15:D}{4,9:D}{5,15:D}", id, lastname, firstname, benefit, tax.ToString(), gincome.ToString()));
        }

        public string output()
        {
            return id + "\t" + lastname + "\t" + firstname + "\t" + benefit + "\t" + tax.ToString() + "\t" + gincome.ToString();
        }
    }
}
