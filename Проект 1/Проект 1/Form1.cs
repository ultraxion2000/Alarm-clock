using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_1
{
    public partial class Form1 : Form
    {

        private int Music = 0;
        private string NameFile = "";

        private string Hour = "";
        private string Minutes = "";
        private string Seconds = "";

        private string HourNow = "";
        private string MinutesNow = "";
        private string SecondsNow = "";

        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 500;
            timer1.Tick += new EventHandler(Timer1_Tick);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            Hour = DateTime.Now.Hour.ToString();
            Minutes = DateTime.Now.Minute.ToString();
            Seconds = DateTime.Now.Second.ToString();

            if (Hour.Length == 1)
            {
                Hour = "0" + Hour;
            }

            if (Minutes.Length == 1)
            {
                Minutes = "0" + Minutes;
            }

            if (Seconds.Length == 1)
            {
                Seconds = "0" + Seconds;
            }

            textBox1.Text = Hour;
            textBox2.Text = Minutes;
            textBox3.Text = Seconds;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string extension = "";

            if (Music == 0)
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    NameFile = openFileDialog1.FileName;
                    extension = Path.GetExtension(NameFile);

                    if (extension != ".mp3")
                    {
                        MessageBox.Show("Файл должен иметь расширение mp3");
                        return;
                    }

                    button1.Text = NameFile.Substring(0, 14) + "...";
                }
            }
            else
            {
                WMP.controls.stop();
                button1.Text = NameFile.Substring(0, 14) + "...";
                Music = 0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(button2.Text == "Стоп")
            {
                if(Music == 1)
                {
                    WMP.controls.stop();
                    button1.Text = NameFile.Substring(0, 14) + "...";
                    Music = 0;
                }

                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;

                timer1.Enabled = false;

                button2.BackColor = Color.MintCream;
                button2.Text = "Запустить";
            }
            else 
          { 
            if(textBox1.Text == "")
            {
                MessageBox.Show("Поле часы пусто");
                    return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Поле минуты пусто");
                    return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Поле секунды пусто");
                    return;
            }

            if(!(Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text)<= 23))
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }

            if (!(Convert.ToInt32(textBox2.Text) >= 0 && Convert.ToInt32(textBox2.Text) <= 59))
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }

            if (!(Convert.ToInt32(textBox3.Text) >= 0 && Convert.ToInt32(textBox3.Text) <= 59))
                {
                    MessageBox.Show("Некорректный ввод");
                    return;
                }


                if (button1.Text == "Выбрать песню mp3")
                {
                    MessageBox.Show("Выберете песню mp3");
                }
                else
                {
                    button2.BackColor = Color.LavenderBlush;
                    button2.Text = "Стоп";

                    Hour = textBox1.Text;
                    Minutes = textBox2.Text;
                    Seconds = textBox3.Text;

                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                }
                timer1.Enabled = true;
          }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            HourNow = DateTime.Now.Hour.ToString();
            MinutesNow = DateTime.Now.Minute.ToString();
            SecondsNow = DateTime.Now.Second.ToString();

            if(HourNow.Length == 1)
            {
                HourNow = "0" + HourNow;
            }

            if (MinutesNow.Length == 1)
            {
                MinutesNow = "0" + MinutesNow;
            }

            if (SecondsNow.Length == 1)
            {
                SecondsNow = "0" + SecondsNow;
            }

            if(Hour == HourNow && Minutes == MinutesNow && Seconds == SecondsNow)
            {
                WMP.URL = NameFile;
                WMP.settings.volume = 100;
                WMP.controls.play();

                Music = 1;

                button1.Text = "Выключить Музыку";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if(textBox1.Text.Length >=0 && textBox1.TextLength <=1)
                {
                    return;
                }
            }
            
            if(Char.IsControl (e.KeyChar))
            {
                if(e.KeyChar == (char) Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (textBox2.Text.Length >= 0 && textBox2.TextLength <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (textBox3.Text.Length >= 0 && textBox3.TextLength <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 1)
            {
                textBox1.Text = "0" + textBox1.Text;
            }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
            {
                textBox2.Text = "0" + textBox2.Text;
            }
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 1)
            {
                textBox3.Text = "0" + textBox3.Text;
            }
        }

     
    }
}
