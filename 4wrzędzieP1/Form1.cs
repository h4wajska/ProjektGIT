using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace _4wrzędzieP1
{
    public partial class Klient : Form
    {
        delegate void SetTextCallback(string text);
        private System.Windows.Forms.TextBox[] textBoxes;
        
        public Klient()
        {
            InitializeComponent();
            serialPort1.DataReceived += new
            System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            textBoxes = new System.Windows.Forms.TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36 };

        }
        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort1.ReadExisting();
            if (!string.IsNullOrEmpty(receivedData))
            {
                string[] receivedValues = receivedData.Split(',');  // Tablica oddzielona przecinkami
                for (int i = 0; i < receivedValues.Length; i++)
                {
                    if (i < textBoxes.Length) // W razie czego zeby sie nie wysypalo 
                    {
                        this.Invoke((MethodInvoker)delegate         // zmiana w UI
                        {
                            textBoxes[i].Text = receivedValues[i];
                        });
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] baudRates = { "2400", "9600", "14400", "19200", "38400", "57600", "115200" };
            comboBox2.Items.AddRange(baudRates);
            comboBox2.Text = baudRates[0].ToString();
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.Length > 0)
            {
                do
                {
                    index += 1;
                    comboBox1.Items.Add(ArrayComPortsNames[index]);
                }
                while (!((ArrayComPortsNames[index] == ComPortName) || (index ==
               ArrayComPortsNames.GetUpperBound(0))));
                Array.Sort(ArrayComPortsNames);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == "Połącz")
            {

                serialPort1.PortName = Convert.ToString(comboBox1.Text);
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialPort1.DataBits = Convert.ToInt16(8);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                serialPort1.Handshake = (Handshake)Enum.Parse(typeof(Handshake),
               "None");
                try
                {
                    serialPort1.Open();
                    connectButton.Text = "Zamknij";
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (connectButton.Text == "Zamknij")
            {

                try
                {
                    serialPort1.Close();
                    connectButton.Text = "Połącz";
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string dataToSend = string.Join(",", textBoxes.Select(tb => tb.Text).ToArray()); // tworzy tablice oddzielona przecinkami
                serialPort1.Write(dataToSend);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Wrzuć")
            {
                if (textBox1.Text == "")
                {
                    textBox1.AppendText("O");
                }
                else if (textBox7.Text == "")
                {
                    textBox7.AppendText("O");
                }
                else if (textBox13.Text == "")
                {
                    textBox13.AppendText("O");
                }
                else if (textBox14.Text == "")
                {
                    textBox14.AppendText("O");
                }
                else if (textBox25.Text == "")
                {
                    textBox25.AppendText("O");
                }
                else if (textBox26.Text == "")
                {
                    textBox26.AppendText("O");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "Wrzuć")
            {
                if (textBox2.Text == "")
                {
                    textBox2.AppendText("O");
                }
                else if (textBox8.Text == "")
                {
                    textBox8.AppendText("O");
                }
                else if (textBox15.Text == "")
                {
                    textBox15.AppendText("O");
                }
                else if (textBox16.Text == "")
                {
                    textBox16.AppendText("O");
                }
                else if (textBox27.Text == "")
                {
                    textBox27.AppendText("O");
                }
                else if (textBox28.Text == "")
                {
                    textBox28.AppendText("O");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Wrzuć")
            {
                if (textBox3.Text == "")
                {
                    textBox3.AppendText("O");
                }
                else if (textBox10.Text == "")
                {
                    textBox10.AppendText("O");
                }
                else if (textBox19.Text == "")
                {
                    textBox19.AppendText("O");
                }
                else if (textBox20.Text == "")
                {
                    textBox20.AppendText("O");
                }
                else if (textBox31.Text == "")
                {
                    textBox31.AppendText("O");
                }
                else if (textBox32.Text == "")
                {
                    textBox32.AppendText("O");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (button4.Text == "Wrzuć")
            {
                if (textBox4.Text == "")
                {
                    textBox4.AppendText("O");
                }
                else if (textBox9.Text == "")
                {
                    textBox9.AppendText("O");
                }
                else if (textBox17.Text == "")
                {
                    textBox17.AppendText("O");
                }
                else if (textBox18.Text == "")
                {
                    textBox18.AppendText("O");
                }
                else if (textBox29.Text == "")
                {
                    textBox29.AppendText("O");
                }
                else if (textBox30.Text == "")
                {
                    textBox30.AppendText("O");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Wrzuć")
            {
                if (textBox5.Text == "")
                {
                    textBox5.AppendText("O");
                }
                else if (textBox11.Text == "")
                {
                    textBox11.AppendText("O");
                }
                else if (textBox21.Text == "")
                {
                    textBox21.AppendText("O");
                }
                else if (textBox22.Text == "")
                {
                    textBox22.AppendText("O");
                }
                else if (textBox33.Text == "")
                {
                    textBox33.AppendText("O");
                }
                else if (textBox34.Text == "")
                {
                    textBox34.AppendText("O");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Wrzuć")
            {
                if (textBox6.Text == "")
                {
                    textBox6.AppendText("O");
                }
                else if (textBox12.Text == "")
                {
                    textBox12.AppendText("O");
                }
                else if (textBox23.Text == "")
                {
                    textBox23.AppendText("O");
                }
                else if (textBox24.Text == "")
                {
                    textBox24.AppendText("O");
                }
                else if (textBox35.Text == "")
                {
                    textBox35.AppendText("O");
                }
                else if (textBox36.Text == "")
                {
                    textBox36.AppendText("O");
                }
            }
        }
    }
}
