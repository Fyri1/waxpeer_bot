using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VillBot2.blyad;
using System.Threading;

namespace VillBot2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            UpdateUi();


        }
        private void UpdateUi()
        {

        }

        private Bot _bot = new Bot("waxpeer api", "Steam api");

        

        private void button1_Click(object sender, EventArgs e)
        {


            int minPrice = (Convert.ToInt32(textBox1.Text) * 1000);
            int maxPrice = (Convert.ToInt32(textBox2.Text))*1000;
            int margin = Convert.ToInt32(textBox3.Text);
            int timeout = Convert.ToInt32(textBox4.Text);

            _bot.Start(minPrice, maxPrice, margin, timeout);
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
