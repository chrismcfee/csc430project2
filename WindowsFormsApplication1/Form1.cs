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
    using pinfo;
    using linkedlist;
    using taxdata;
    using benefitdatabase;

    public partial class Form1 : Form
    {
        private FileStream input;
        private StreamReader fileReader;
        string fileName;
        private plist data;
        int schoice = 6, trash = 0;
        bool changed = false, ismaximized = false;
        pnode ntemp;
        public taxes[] states = new taxes[100], benefits = new taxes[100];
        benefitdata databenefit = new benefitdata(), datadental = new benefitdata();
        Form2 statetaxform, benefitform;
        CheckWindow checkform;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.button5.Location = new System.Drawing.Point(this.Size.Width/2, 20);
            richTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            label10.Anchor = AnchorStyles.Bottom;
            textBox2.Anchor = AnchorStyles.Bottom;
            textBox3.Anchor = AnchorStyles.Bottom;
            textBox4.Anchor = AnchorStyles.Bottom;
            textBox5.Anchor = AnchorStyles.Bottom;
            textBox6.Anchor = AnchorStyles.Bottom;
            textBox7.Anchor = AnchorStyles.Bottom;
            accountnumtb.Anchor = AnchorStyles.Bottom;
            comboBox2.Anchor = AnchorStyles.Bottom;
            routingnumtb.Anchor = AnchorStyles.Bottom;
            label1.Anchor = AnchorStyles.Bottom;
            label2.Anchor = AnchorStyles.Bottom;
            label3.Anchor = AnchorStyles.Bottom;
            label4.Anchor = AnchorStyles.Bottom;
            label5.Anchor = AnchorStyles.Bottom;
            label12.Anchor = AnchorStyles.Bottom;
            label13.Anchor = AnchorStyles.Bottom;
            label14.Anchor = AnchorStyles.Bottom;
            label15.Anchor = AnchorStyles.Bottom;
            label16.Anchor = AnchorStyles.Bottom;
            checkBox1.Anchor = AnchorStyles.Bottom;
            button1.Anchor = AnchorStyles.Bottom;
            button2.Anchor = AnchorStyles.Bottom;
            button3.Anchor = AnchorStyles.Bottom;
            save.Anchor = AnchorStyles.Bottom;
            cancel.Anchor = AnchorStyles.Bottom;
            label6.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            label7.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            modify.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            delete.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            button4.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            data = new plist();
            MessageBox.Show("Please select the data files that you wish to use (*.txt). \nThe default values are the files listed in the program's directory.", "INFO");
            DialogResult result;

            //reading dental plan data
            try
            {
                input = new FileStream(@System.IO.Directory.GetCurrentDirectory() + @"\taxdata\dentalplandata.DAT", FileMode.Open, FileAccess.Read);
                fileReader = new StreamReader(input);
                int n = 0;
                string[] taxstemp = new string[5];
                while (fileReader.Peek() >= 0)
                {
                    taxstemp = fileReader.ReadLine().Split('\t');
                    datadental.input(taxstemp);
                    n++;
                }
                input.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Error \"dentalplandata.DAT\" reading file");
            }
            //reading benefit data
            try
            {
                input = new FileStream(@System.IO.Directory.GetCurrentDirectory() + @"\taxdata\benefitdata.DAT", FileMode.Open, FileAccess.Read);
                fileReader = new StreamReader(input);
                int n = 0;
                string[] taxstemp = new string[5];
                while (fileReader.Peek() >= 0)
                {
                    taxstemp = fileReader.ReadLine().Split('\t');
                    databenefit.input(taxstemp);
                    n++;

                }
                input.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Error \"benefitdata.DAT\" reading file");
            }


            //reading taxes data
            try
            {
                input = new FileStream(@System.IO.Directory.GetCurrentDirectory() + @"\taxdata\statetax.DAT", FileMode.Open, FileAccess.Read);
                fileReader = new StreamReader(input);
                int n = 0;
                string[] taxstemp = new string[3];
                while (fileReader.Peek() >= 0)
                {
                    taxstemp = fileReader.ReadLine().Split('\t');
                    states[n] = new taxes();
                    states[n].input(taxstemp);
                    n++;
                }
                input.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Error \"statetax.DAT\" reading file");
            }

            //reading benefit(old)
            try
            {
                input = new FileStream(@System.IO.Directory.GetCurrentDirectory() + @"\taxdata\benefit.DAT", FileMode.Open, FileAccess.Read);
                fileReader = new StreamReader(input);
                int n = 0;
                string[] taxstemp = new string[2];
                while (fileReader.Peek() >= 0)
                {
                    taxstemp = fileReader.ReadLine().Split('\t');
                    benefits[n] = new taxes();
                    benefits[n].input(taxstemp);
                    n++;
                }
                input.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Error \"benefit.DAT\" reading file");
            }
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.FileName = "payrolldb.txt";
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            //reading people data
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
                        data.input(info,states,benefits,databenefit,datadental);
                    }
                    richTextBox1.Text = data.display(ismaximized);
                    linkLabel1.Text = fileName;
                    saveFileDialog1.FileName = fileName;
                    input.Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("Error reading file");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
                toolTip1.Show("Please enter information first.", button1, 110, 40);
            else
            {
                string[] temp = new string[9];
                //string line;
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
                if (checkBox1.Checked == false)
                    temp[6] = "NO";
                else temp[6] = "YES";
                if (comboBox2.Text == "")
                    temp[7] = "NY"; 
                else
                    temp[7] = comboBox2.Text;
                temp[8] = accountnumtb.Text;
                data.input(temp, states, benefits,databenefit,datadental);
                searchtb1();
                cleartb();
                changed = true;
            }
        }

        void searchtb1()
        {
            if (textBox1.Text == "")
            {
                richTextBox1.Text = data.display(ismaximized);
                modifycheck(richTextBox1.Text.Split('\n').Length);
            }
            else
            {
                string temp = "";
                temp = data.search(textBox1.Text.ToUpper(), schoice,ismaximized);
                richTextBox1.Text = temp;
                modifycheck(temp.Split('\n').Length);
            }
        }

        void modifycheck(int index)
        {
            if (index == 4)
            {
                modify.Enabled = true;
                delete.Enabled = true;
                button4.Enabled = true;
                ntemp = data.findnode(data.searchnode(textBox1.Text.ToUpper(), schoice) + 1);
                button4.Text = "Print " + ntemp.data.lastname + "'s Check";
            }
            else
            {
                button4.Enabled = false;
                modify.Enabled = false;
                delete.Enabled = false;
                button4.Text = "Print Check";
            }
        }

        void netpaydisplay()
        {
            double gincome, tax, stax, btax;
            string rtnum = "";
            if (textBox5.Text == "")
                tax = 0;
            else tax = Convert.ToDouble(textBox5.Text);
            if (textBox6.Text == "")
                gincome = 0;
            else gincome = Convert.ToDouble(textBox6.Text);
            int i = 0;
            stax = 0;
            btax = 0;
            while (states[i] != null)
            {
                if (states[i].names == comboBox2.Text)
                {
                    stax = states[i].value;
                    rtnum = states[i].routingnum;
                    break;
                }
                i++;
            }

            i = 0;
            while (benefits[i] != null)
            {
                if (benefits[i].names == textBox4.Text.ToUpper())
                {
                    btax = benefits[i].value;
                    break;
                }
                i++;
            }
            double netpay = (gincome - stax - tax) - (gincome * btax/100);
            textBox7.Text = netpay.ToString();
            routingnumtb.Text = rtnum;
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
            schoice = 9;
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
            if (comboBox1.Text == "Check")
                schoice = 7;
            if (comboBox1.Text == "State")
                schoice = 8;
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
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    textBox5.Text = stemp;
                    toolTip1.Show("Please enter a number.", textBox5, 110, 10);
                    textBox5.SelectionStart = textBox5.Text.Length;
                }
                netpaydisplay();
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
                netpaydisplay();
            }
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

        private void delete_Click(object sender, EventArgs e)
        {
            data.deletenode(data.searchnode(textBox1.Text.ToUpper(), schoice)+1);
            textBox1.Text = "";
            modify.Enabled = false;
            delete.Enabled = false;
            changed = true;
        }

        private void modify_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            save.Enabled = true;
            cancel.Enabled = true;
            modify.Enabled = false;
            delete.Enabled = false;
            //ntemp = data.findnode(data.searchnode(textBox1.Text.ToUpper(), schoice)+1);
            textBox2.Text = ntemp.data.lastname;
            textBox3.Text = ntemp.data.firstname;
            textBox4.Text = ntemp.data.benefit;
            textBox5.Text = ntemp.data.tax.ToString();
            textBox6.Text = ntemp.data.gincome.ToString();
            comboBox2.Text = ntemp.data.state;
            accountnumtb.Text = ntemp.data.accnum;
            if (ntemp.data.check == "NO")
                checkBox1.Checked = false;
            else checkBox1.Checked = true;
        }

        void cleartb()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox2.Text = "";
            checkBox1.Checked = false;
            routingnumtb.Text = "";
            accountnumtb.Text = "";
        }

        private void save_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            save.Enabled = false;
            cancel.Enabled = false;
            ntemp.data.lastname = textBox2.Text.ToUpper();
            ntemp.data.firstname = textBox3.Text.ToUpper();
            ntemp.data.benefit = textBox4.Text.ToUpper();
            ntemp.data.tax = Convert.ToDouble(textBox5.Text);
            ntemp.data.gincome = Convert.ToDouble(textBox6.Text);
            if (checkBox1.Checked == false)
                ntemp.data.check = "NO";
            else ntemp.data.check = "YES";
            ntemp.data.state = comboBox2.Text;
            ntemp.data.accnum = accountnumtb.Text;
            textBox1.Text = "";
            cleartb();
            changed = true;   
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            save.Enabled = false;
            cancel.Enabled = false;
            textBox1.Text = "";
            searchtb1();
            cleartb();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed == false) return;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName == "") return;
            fileName = saveFileDialog1.FileName;
            File.WriteAllText(fileName, data.output());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            netpaydisplay();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            netpaydisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (statetaxform != null)
                statetaxform.Close();
            statetaxform = new Form2();
            statetaxform.showlisttax(states);
            statetaxform.Show();
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            if (benefitform != null)
                benefitform.Close();
            benefitform = new Form2();
            benefitform.showlistbenefit(benefits);
            benefitform.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ntemp = data.findnode(data.searchnode(textBox1.Text.ToUpper(), schoice) + 1);
            if (checkform != null)
                checkform.Close();
            checkform = new CheckWindow();
            checkform.setpersondata(ntemp, states, benefits);
            checkform.Show();
        }

        private void accountnumtb_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(accountnumtb.Text) != "")
            {
                string stemp;
                int temp;
                if (!int.TryParse(accountnumtb.Text, out temp))
                {
                    stemp = accountnumtb.Text;
                    stemp = stemp.Substring(0, stemp.Length - 1);
                    accountnumtb.Text = stemp;
                    toolTip1.Show("Please enter a number.", accountnumtb, 110, 10);
                    accountnumtb.SelectionStart = accountnumtb.Text.Length;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AboutWindow aboutform = new AboutWindow();
            aboutform.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            trash++;
            if(this.WindowState == FormWindowState.Maximized)
                ismaximized = true;
            if(this.WindowState == FormWindowState.Normal)
                ismaximized = false;
            this.button5.Location = new System.Drawing.Point(this.Size.Width / 2, 20);
            if (trash > 2)
                searchtb1();
            
        }
        
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



    }
}


namespace linkedlist
{
    using pinfo;
    using taxdata;
    using benefitdatabase;

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
        public void input(string[] info, taxes[] states, taxes[] benefits, benefitdata databenefit, benefitdata datadental)
        {
            if (isEmpty())
            {
                head = new pnode();
                head.data = new person();
                head.next = null;
                head.data.input(info,states,benefits, databenefit, datadental);
                noe++;
            }
            else
            {
                pnode temp;
                findnode(noe).next = new pnode();
                temp = findnode(noe).next;
                temp.next = null;
                temp.data = new person();
                temp.data.input(info, states, benefits, databenefit, datadental);
                noe++;
            }
            
        }

        public int getlastid()
        {
            return findnode(noe).data.getid();
        }

        public int getnoe()
        { return noe; }

        public string display(bool ismaximized)
        {
            string temp = "";
            pnode tempnode = head;
            if (isEmpty())
                return "The list contains NOTHING!";
            if (ismaximized)
                temp = temp + String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,15:D}{9,15:D}{10,15:D}{11,15:D}{12,15:D}{13,8:D}{14,20:D}", "ID", "Last Name", "First Name", "State", "Benefit Brand", "Level", "Type", "Dental Brand", "Level", "Type", "Tax", "Gross Income", "Net Pay", "Check", "Account Number\n\n");
            else
                temp = temp + String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,8:D}{9,20:D}", "ID", "Last Name", "First Name", "State", "Health", "Tax", "Gross Income", "Net Pay", "Check", "Account Number\n\n");
            //temp = temp + String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,10:D}{9,18:D}", "ID", "Last Name", "First Name", "State", "Benefit", "Tax", "Gross Income", "Net Pay", "Check", "Account Number\n\n");
            for (int i = 0; i < noe; i++)
            {
                temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
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
                case 7:
                    for (i = 0; i < noe; i++)
                    {
                        if (tempnode.data.check.Contains(word))
                            return i;
                        tempnode = tempnode.next;
                    }
                    break;
            }
            return i;
        }

        public string search(string word, int choice,bool ismaximized)
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
                            temp = temp + tempnode.data.getInfo(ismaximized)+ "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 1:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.firstname.Contains(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 2:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.benefit.Contains(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 3:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.tax == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 4:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.gincome == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 5:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.npay == Convert.ToDouble(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 6:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.id.Contains(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 7:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.check.Contains(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                case 8:
                    for (int i = 0; i < noe; i++)
                    {
                        if (tempnode.data.state.Contains(word))
                            temp = temp + tempnode.data.getInfo(ismaximized) + "\n";
                        tempnode = tempnode.next;
                    }
                    break;
                //default: temp = "";
            }
            if (temp == "")
                temp = "!No result for your search.";
            else
                if (ismaximized)
                temp = String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,15:D}{9,15:D}{10,15:D}{11,15:D}{12,15:D}{13,8:D}{14,20:D}", "ID", "Last Name", "First Name", "State", "Benefit Brand", "Level", "Type", "Dental Brand", "Level", "Type", "Tax", "Gross Income", "Net Pay", "Check", "Account Number\n\n") + temp;
            else
                temp = String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,8:D}{9,20:D}", "ID", "Last Name", "First Name", "State", "Benefit", "Tax", "Gross Income", "Net Pay", "Check", "Account Number\n\n") + temp;
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
    using taxdata;
    using benefitdatabase;

    //PERSON DETAILS
    public class person
    {
        //private static date dob = new date();
        public string id = "",lastname = "",firstname = "", benefit = "", check = "";
        public string state = "", accnum = "", dental = "";
        public double tax, gincome, npay, stax,btax;
        benefitvalue benefitdetail = new benefitvalue(), dentaldetail = new benefitvalue();
        public void input(string[] source, taxes[] states, taxes[] benefits, benefitdata benefitsource, benefitdata dentalsource)
        {
            id = source[0];
            lastname = source[1];
            firstname = source[2];
            benefit = source[3];
            tax = Convert.ToDouble(source[4]);
            gincome = Convert.ToDouble(source[5]);
            check = source[6];
            state = source[7];
            accnum = source[8];
            //dental = source[9];
            int i = 0;
            while (states[i] != null)
            {
                if (states[i].names == state)
                {
                    stax = states[i].value;
                    break;
                }
                i++;
            }

            benefitdetail.copy(benefitsource.output(benefit));
            dentaldetail.copy(dentalsource.output(dental));

            //new dental and benefit functions needed
            


            //old benefit still here
            i = 0;
            while (benefits[i] != null)
            {
                if (benefits[i].names == state)
                {
                    btax = benefits[i].value;
                    break;
                }
                i++;
            }

            //NETPAY calculation update needed
            npay = (gincome - stax - tax) - (gincome*btax/100);
        }
        public int getid()
        {
            return Convert.ToInt32(id);
        }
        public string getInfo(bool ismaximized)
        {
            if(ismaximized)
                return (String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,15:D}{9,15:D}{10,15:D}{11,15:D}{12,15:D}{13,8:D}{14,18:D}", id, lastname, firstname, state, benefitdetail.brand, benefitdetail.level, benefitdetail.type, dentaldetail.brand, dentaldetail.level, dentaldetail.type, tax.ToString(), gincome.ToString(), npay.ToString(), check, accnum));
            else
                return (String.Format("{0,12:D}{1,13:D}{2,16:D}{3,7:D}{4,15:D}{5,15:D}{6,15:D}{7,15:D}{8,8:D}{9,18:D}", id, lastname, firstname, state, benefit, tax.ToString(), gincome.ToString(), npay.ToString(), check, accnum));
        }

        public string output()
        {
            return id + "\t" + lastname + "\t" + firstname + "\t" + benefit + "\t" + tax.ToString() + "\t" + gincome.ToString() + "\t" + check + "\t" + state + "\t" + accnum + "\t" + dental;
        }
    }
}

namespace taxdata
{
    public class taxes
    {
        public string names = "", routingnum = "";
        public double value = 0;
        public void input(string[] index)
        {
            names = index[0];
            if(index[2] != null)
                routingnum = index[2];
            value = Convert.ToDouble(index[1]);
        }
    }
}


//DATABASE FOR BENEFIT
namespace benefitdatabase
{
    public class benefitvalue
    {
        public string code = "NOVALUE", brand = "NA", type = "NA", level = "NA";
        public double value = 0;
        public void input(string[] source)
        {
            code = source[0];
            brand = source[1];
            type = source[2];
            level = source[3];
            //dental = source[9];
            value = Convert.ToDouble(source[4]);
        }

        public void copy(benefitvalue source)
        {
            code = source.code;
            brand = source.brand;
            type = source.type;
            level = source.level;
            value = source.value;
        }
    }

    public class benefitdata
    {
        public benefitvalue[] data = new benefitvalue[200];
        private int noe = 0;

        public string codeoutput(string sbrand, string stype, string slevel)
        {
            for (int i = 0; i < noe; i++)
                if (data[i].brand == sbrand && data[i].type == stype && data[i].level == slevel)
                    return data[i].code;
            return "NOVALUE";
        }

        public double valueoutput(string scode)
        {
            for (int i = 0; i < noe; i++)
                if (data[i].code == scode)
                    return data[i].value;
            return 0;
        }

        public void input(string[] source)
        {
            data[noe] = new benefitvalue();
            data[noe].input(source);
            noe++;
        }

        public benefitvalue output(string scode)
        {
            for (int i = 0; i < noe; i++)
                if (data[i].code == scode)
                    return data[i];
            return new benefitvalue();
        }
    }
}

/// <summary>
/// NEED 2 BE DONE
/// + create class (done)
/// + need to make input function
///     for database(done)
///     for person (done)
/// + output person function (done)
/// + display person function (done)
/// + search function
/// + function to convert the code strings(done)
/// + *clickable table
/// + NETPAY calculation update needed
/// + benefit/dental selection for Summit and Save button
/// </summary>