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
        public SetBenefitDentalWindow()
        {
            InitializeComponent();
        }

        private void SetBenefitDentalWindow_Load(object sender, EventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = "ABC";
            item.Value = 12;
            comboBox1.Items.Add(item);
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
    }
}
