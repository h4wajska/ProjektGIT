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

namespace Serwer
{
    public partial class Serwer : Form
    {
        delegate void SetTextCallback(string text);
        private System.Windows.Forms.TextBox[] textBoxes;
        public Serwer()
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
                string[] receivedValues = receivedData.Split(',');

                for (int i = 0; i < receivedValues.Length; i++)
                {
                    if (i < textBoxes.Length)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            textBoxes[i].Text = receivedValues[i];
                        });
                    }
                }
            }
        }

        private void Serwer_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)     //uniemożliwienie wpisania wartości w textboxy
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.ReadOnly = true;
                }
            }

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

        private void connectButton_Click(object sender, EventArgs e)
        {
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
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string dataToSend = string.Join(",", textBoxes.Select(tb => tb.Text).ToArray());
                serialPort1.Write(dataToSend);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Wrzuć")
            {
                if (textBox1.Text == "")
                {
                    textBox1.AppendText("X");
                }
                else  if (textBox7.Text == "")
                    {
                        textBox7.AppendText("X");
                    }
                else if (textBox13.Text == "")
                {
                    textBox13.AppendText("X");
                }
                else if (textBox14.Text == "")
                {
                    textBox14.AppendText("X");
                }
                else if (textBox25.Text == "")
                {
                    textBox25.AppendText("X");
                }
                else if (textBox26.Text == "")
                {
                    textBox26.AppendText("X");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "Wrzuć")
            {
                if (textBox2.Text == "")
                {
                    textBox2.AppendText("X");
                }
                else if (textBox8.Text == "")
                {
                    textBox8.AppendText("X");
                }
                else if (textBox15.Text == "")
                {
                    textBox15.AppendText("X");
                }
                else if (textBox16.Text == "")
                {
                    textBox16.AppendText("X");
                }
                else if (textBox27.Text == "")
                {
                    textBox27.AppendText("X");
                }
                else if (textBox28.Text == "")
                {
                    textBox28.AppendText("X");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Wrzuć")
            {
                if (textBox3.Text == "")
                {
                    textBox3.AppendText("X");
                }
                else if (textBox10.Text == "")
                {
                    textBox10.AppendText("X");
                }
                else if (textBox19.Text == "")
                {
                    textBox19.AppendText("X");
                }
                else if (textBox20.Text == "")
                {
                    textBox20.AppendText("X");
                }
                else if (textBox31.Text == "")
                {
                    textBox31.AppendText("X");
                }
                else if (textBox32.Text == "")
                {
                    textBox32.AppendText("X");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Wrzuć")
            {
                if (textBox4.Text == "")
                {
                    textBox4.AppendText("X");
                }
                else if (textBox9.Text == "")
                {
                    textBox9.AppendText("X");
                }
                else if (textBox17.Text == "")
                {
                    textBox17.AppendText("X");
                }
                else if (textBox18.Text == "")
                {
                    textBox18.AppendText("X");
                }
                else if (textBox29.Text == "")
                {
                    textBox29.AppendText("X");
                }
                else if (textBox30.Text == "")
                {
                    textBox30.AppendText("X");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Wrzuć")
            {
                if (textBox5.Text == "")
                {
                    textBox5.AppendText("X");
                }
                else if (textBox11.Text == "")
                {
                    textBox11.AppendText("X");
                }
                else if (textBox21.Text == "")
                {
                    textBox21.AppendText("X");
                }
                else if (textBox22.Text == "")
                {
                    textBox22.AppendText("X");
                }
                else if (textBox33.Text == "")
                {
                    textBox33.AppendText("X");
                }
                else if (textBox34.Text == "")
                {
                    textBox34.AppendText("X");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Wrzuć")
            {
                if (textBox6.Text == "")
                {
                    textBox6.AppendText("X");
                }
                else if (textBox12.Text == "")
                {
                    textBox12.AppendText("X");
                }
                else if (textBox23.Text == "")
                {
                    textBox23.AppendText("X");
                }
                else if (textBox24.Text == "")
                {
                    textBox24.AppendText("X");
                }
                else if (textBox35.Text == "")
                {
                    textBox35.AppendText("X");
                }
                else if (textBox36.Text == "")
                {
                    textBox36.AppendText("X");
                }
            }
        }

        private void ClearTextBoxes()       //funkcja do czyszczenia wszystkich textboxów
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void btnClear_Click(object sender, EventArgs e) //wywołanie funkcji czyszczenia textboxów
        {
            ClearTextBoxes();
        }
    }
    
}
