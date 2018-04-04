using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_Scan_TestWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"),);
            int start = Convert.ToInt32(textBox3.Text);
            int end = Convert.ToInt32(textBox4.Text);

            progressBar1.Value = 0;

            progressBar1.Maximum = end - start + 1;

            Cursor.Current = Cursors.WaitCursor;

            for (int i = start; i <= end; i++)
            {
                UdpClient client = new UdpClient();
                string s = textBox1.Text;
                try
                {
                    client.Connect(textBox1.Text, i);
                    //client.Receive(ref s);
                    textBox2.AppendText("Port " + i + " open.\n");
                }
                catch
                {
                    textBox2.AppendText("Port " + i + " closed.\n");
                }

                progressBar1.PerformStep();
            }
            Cursor.Current = Cursors.Arrow;
        }
    }
}
