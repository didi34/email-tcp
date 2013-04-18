using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace TCP_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Socket sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private void button1_Click(object sender, EventArgs e)
        {
            sock1.Bind(new IPEndPoint(IPAddress.Any, 56657));
            sock1.Listen(5);
            sock = sock1.Accept();
            MessageBox.Show("Accepted!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //213.165.64.21
            sock.Connect("127.0.0.1", 25);
            do
            {

            }
            while (sock.Connected == false);
            MessageBox.Show("Connected!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            sock.Send(Encoding.ASCII.GetBytes(msg + '\n'));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.Close();
            sock1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[1024*1024];
            int l = sock.Receive(b);
            MessageBox.Show(Encoding.ASCII.GetString(b, 0, l));
        }
    }
}
