using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;

namespace TCP_Scan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = Convert.ToInt32(textBox3.Text);
            int end = Convert.ToInt32(textBox4.Text);

            progressBar1.Value = 0;

            progressBar1.Maximum = end - start + 1;

            Cursor.Current = Cursors.WaitCursor;

            for (int i = start; i <= end; i++)
            {
                TcpClient client = new TcpClient();

                try
                {
                    client.Connect(textBox1.Text, i);

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
