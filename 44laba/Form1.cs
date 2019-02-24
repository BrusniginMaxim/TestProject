using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _44laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            filename = " ";
            
        }
        double voz, ves, rost, otvet, otvet1, otvet2, x, x2, x3, y;
        string str;
        string filename;
       

        private void button1_Click(object sender, EventArgs e)
        {
            voz = Convert.ToDouble(textBox1.Text);
            ves = Convert.ToDouble(textBox2.Text);
            rost = Convert.ToDouble(textBox3.Text);

            if (radioButton1.Checked) // мужской
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) + 5) * 1.2;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) + 5) * 1.375;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) + 5) * 1.4625;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }
                else
                {
                    MessageBox.Show("Не выбрана физ. нагрузка");
                    return;
                }
               // str += "Ваш возраст " + textBox1.Text + "\r\nВаш вес " + textBox2.Text + "\r\nВаш рост " + textBox3.Text + "\r\nНе изменяя вес " + textBox4.Text + "\r\nДля похудения " + textBox5.Text + "\r\n";
            }


            if (radioButton2.Checked) // женский
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) - 161) * 1.2;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) - 161) * 1.375;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    otvet = ((10 * ves) + (6.25 * rost) - (5 * voz) - 161) * 1.4625;
                    otvet1 = otvet / 100 * 20; // 20% ot otveta
                    otvet2 = otvet - otvet1;
                    textBox4.Text = otvet.ToString();
                    textBox5.Text = otvet2.ToString();
                }

                else
                {
                    MessageBox.Show("Не выбрана физ. нагрузка");
                    return;
                }

            }
            str += "Ваш возраст " + textBox1.Text + "\r\nВаш вес " + textBox2.Text + "\r\nВаш рост " + textBox3.Text + "\r\nНе изменяя вес " + textBox4.Text + "\r\nДля похудения " + textBox5.Text + "\r\n";
        }
       

       private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog1.Filter = "Text|*.txt|AllFiles|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    filename = saveFileDialog1.FileName;
                    myStream.Close();
                }
                else return;
            }
            else
            {
                MessageBox.Show("Сохранение прервано");
                return;
            }
            File.WriteAllText(filename, str);
        }

       private void button2_Click(object sender, EventArgs e)
       { 
            x = ((((Convert.ToDouble(textBox4.Text)) - (Convert.ToDouble(textBox5.Text))) * 7) / 7700); // вес сброшенный за неделю с учетом нормы разницы веса 15%.
            y = Convert.ToDouble(textBox2.Text); // заданный вес
            for (int i = 1; i < 50; i++)
            {
                y = y - x;
                chart1.Series[0].Points.AddXY(i, y);
            }
        }

       private void button3_Click(object sender, EventArgs e)
       {
           x2 = x / 0.6; // на 60% увелечение сброса всеа за неделю
           y = Convert.ToDouble(textBox2.Text);
           for (int i = 1; i < 50; i++)
           {
               y = y - x2;
               chart1.Series[0].Points.AddXY(i, y);
           }
       }

       private void button4_Click(object sender, EventArgs e)
       {
           x3 = x2/0.6; // на 60% увелечение сброса всеа за неделю
           y = Convert.ToDouble(textBox2.Text);
           for (int i = 1; i < 50; i++)
           {
               y = y - x3;
               chart1.Series[0].Points.AddXY(i, y);
           }
       }

       private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
       {
           MessageBox.Show("Программа разработана студентом НГПУ, факультет ЕМиКН, направление ИСТ,  в рамках курсовой работы по программированию. Бруснигин Максим. 2017 г.");
           return;
       }
    }
 }
