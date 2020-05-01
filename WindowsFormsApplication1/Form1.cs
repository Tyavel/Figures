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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            avtomat.onEvent += event1.EventControl;       //подписка события 1
            avtomat.onEvent2 += event2.EventControl2;     //подписка события 2
            avtomat1.onEvent += event1.EventControl;      //подписка события 1
            avtomat1.onEvent2 += event2.EventControl2;
        }

        Kofe avtomat = new Kofe();         //Экземпляр класса
        Events event1 = new Events();      //Экземпляр класса с событием 1
        Events2 event2 = new Events2();    //Экземпляр класса с событием 2
        Kofe2 avtomat1 = new Kofe2();
        double x = 0;                    //
        double x1 = 0;                   //
        double k, k1;                     // Переменные для работы
        int piccc = 0;                   //
        int piccc1 = 0;                  //
        int model = 0;                   //
        int model1 = 0;                  //

        private void timer1_Tick(object sender, EventArgs e)     //каждая секунда таймера
        {
            if (x > 0)   //если время приготовление больше 0
            {
                avtomat.Round = 100 / avtomat.time;                                     //Значение, которое нужно вычитать каждую секунду
                avtomat.Vtimer();                                                    //Вычитаем
                textBox3.Text = Convert.ToString(avtomat.Voda);                         //Присваиваем значение воды в текстбокс
                x = x - 1;                                                           //Вычитаем из времени приготовления 1
            }
            else
            {
                timer1.Stop();                         //остановка таймера
                k = k - 100;                           //удостоверяемся, что вычитание выполнилось правильно
                avtomat.Voda = k;
                avtomat.FullVoda = avtomat.FullVoda - 100;
                textBox3.Text = Convert.ToString(k);   //Присваем воду воду текстбокс
                textBox4.Text = Convert.ToString(0);   //Обнуляем текстбокс чашек
                avtomat.Cups = 0;                         //Обнуляем Свойство чашек
                pictureBox1.Visible = false;       //картинки и кнопки
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                avtomat.Eventus();
                avtomat.Eventus2();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)   //Создать кофемашину 1
        {
            if ((String.IsNullOrEmpty(textBox1.Text)) || (Convert.ToDouble(textBox1.Text) <= 0))
            {
                MessageBox.Show("Не верно введена вместимость!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToDouble(textBox1.Text) % 100 == 0)
                {
                    if (piccc == 0)  //загружаем картинки в пикчер боксы
                    {
                        System.IO.FileStream fs = new System.IO.FileStream("Images\\" + 1 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                        pictureBox1.Image = img;
                        System.IO.FileStream fs1 = new System.IO.FileStream("Images\\" + 2 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img1 = System.Drawing.Image.FromStream(fs1);
                        pictureBox2.Image = img1;
                        System.IO.FileStream fs2 = new System.IO.FileStream("Images\\" + 3 + ".gif", System.IO.FileMode.Open);
                        System.Drawing.Image img2 = System.Drawing.Image.FromStream(fs2);
                        pictureBox3.Image = img2;
                        System.IO.FileStream fs3 = new System.IO.FileStream("Images\\" + 4 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img3 = System.Drawing.Image.FromStream(fs3);
                        pictureBox4.Image = img3;
                        piccc = 1;
                    }
                    model = model + 1;                                   //Увеличение номера модели
                    label5.Text = "Модель №" + Convert.ToString(model);  //Присваиваем номера модели в лэйбл
                    avtomat.vodaMax = Convert.ToInt32(textBox1.Text);    //Присваиваем полю ВодаМакс
                    x = avtomat.time;                                    //Присваиваеем иксу поле тайм
                    textBox3.Text = Convert.ToString(0);                 //Обнуление текстбокса воды
                    textBox4.Text = Convert.ToString(0);                 //Обнуление текстбокса чашек
                    avtomat.Voda = 0;                                       //Обнуление свойству Вода
                    avtomat.Cups = 0;                                       //Обнуление свойству Чашки
                    button1.Enabled = true;               //Дальше блокировка кнопок и вызов картинок
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
                else
                {
                    MessageBox.Show("Вместимость не кратна 100!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)   //Налить воды в кофемашину 1
        {
            if (avtomat.vodaMax > avtomat.Voda)
            {
                avtomat.Fill();                               // метод наливания воды
                textBox3.Text = Convert.ToString(avtomat.Voda);  //присваивание этого в текстбокс
                avtomat.FullVoda = avtomat.Voda;                    //присваиваем полной воде значение воды
            }
            else
            {
                MessageBox.Show("Достигнута максимальная вместимость!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)   //Поставить чашку в кофемашину 1
        {
            if (Convert.ToDouble(textBox4.Text) == 0)
            {
                pictureBox1.Visible = false;   //вызов картинок
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                avtomat.AddCup();                            //метод добавления чашек
                textBox4.Text = Convert.ToString(avtomat.Cups); //присваивание кол-ва чашек в текстбокс

            }
            else
            {
                MessageBox.Show("Кружка уже есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e) //Сделать кофе в кофемашине 1
        {
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false) && (radioButton4.Checked == false))
            {
                MessageBox.Show("не выбран вид кофе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (Convert.ToDouble(textBox3.Text) < 100)
                {
                    MessageBox.Show("Недостаточно воды!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToDouble(textBox4.Text) == 0)
                    {
                        MessageBox.Show("Нет чашки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (radioButton1.Checked == true)
                        {
                            x = 2;
                            avtomat.time = x;
                        }
                        if (radioButton2.Checked == true)
                        {
                            x = 4;
                            avtomat.time = x;
                        }
                        if (radioButton3.Checked == true)
                        {
                            x = 5;
                            avtomat.time = x;
                        }
                        if (radioButton4.Checked == true)
                        {
                            x = 8;
                            avtomat.time = x;
                        }
                        k = avtomat.Voda;        //Присваиваем k значение воды
                        pictureBox1.Visible = false;  //блок кнопок и вызов картинок
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = true;
                        pictureBox4.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        timer1.Start();  //включение таймера
                    }
                }
        }
        



        //НАСЛЕДОВАНИЕ//



        private void button8_Click(object sender, EventArgs e)  //Купить кофемашину 2
        {
            if ((String.IsNullOrEmpty(textBox8.Text)) || (Convert.ToDouble(textBox8.Text) <= 0))
            {
                MessageBox.Show("Не верно введена вместимость!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToDouble(textBox8.Text) % 100 == 0)
                {
                    if (piccc1 == 0)  //загружаем картинки в пикчер боксы
                    {
                        System.IO.FileStream fs = new System.IO.FileStream("Images\\" + 11 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                        pictureBox5.Image = img;
                        System.IO.FileStream fs1 = new System.IO.FileStream("Images\\" + 22 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img1 = System.Drawing.Image.FromStream(fs1);
                        pictureBox6.Image = img1;
                        System.IO.FileStream fs2 = new System.IO.FileStream("Images\\" + 33 + ".gif", System.IO.FileMode.Open);
                        System.Drawing.Image img2 = System.Drawing.Image.FromStream(fs2);
                        pictureBox7.Image = img2;
                        System.IO.FileStream fs3 = new System.IO.FileStream("Images\\" + 44 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img3 = System.Drawing.Image.FromStream(fs3);
                        pictureBox8.Image = img3;
                        System.IO.FileStream fs4 = new System.IO.FileStream("Images\\" + 55 + ".png", System.IO.FileMode.Open);
                        System.Drawing.Image img4 = System.Drawing.Image.FromStream(fs4);
                        pictureBox9.Image = img4;
                        piccc1 = 1;
                    }
                    model1 = model1 + 1;                                   //Увеличение номера модели
                    label6.Text = "Модель №" + Convert.ToString(model1);   //Присваиваем номера модели в лэйбл
                    avtomat1.vodaMax = Convert.ToInt32(textBox8.Text);     //Присваиваем полю ВодаМакс
                    x1 = avtomat1.time;                                    //Присваиваеем иксу поле тайм
                    textBox6.Text = Convert.ToString(0);                   //Обнуление текстбокса воды
                    textBox5.Text = Convert.ToString(0);                   //Обнуление текстбокса чашек
                    avtomat1.Voda = 0;                                        //Обнуление свойству Вода
                    avtomat1.Cups = 0;                                        //Обнуление свойству Чашки
                    button5.Enabled = true;                   //Дальше блокировка кнопок и вызов картинок
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                }
                else
                {
                    MessageBox.Show("Вместимость не кратна 100!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (avtomat1.vodaMax > avtomat.Voda)
            {
                avtomat1.Fill();                               // метод наливания воды
                textBox6.Text = Convert.ToString(avtomat.Voda);   //присваивание этого в текстбокс
                avtomat1.FullVoda = avtomat1.Voda;                     //присваиваем полной воде значение воды
            }
            else
            {
                MessageBox.Show("Достигнута максимальная вместимость!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((Convert.ToDouble(textBox5.Text) == 1) || (Convert.ToDouble(textBox5.Text) == 0))
            {
                pictureBox5.Visible = false;   //вызов картинок
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = true;
                avtomat1.AddCup();                            //метод добавления чашек
                textBox5.Text = Convert.ToString(avtomat.Cups); //присваивание кол-ва чашек в текстбокс
                if (Convert.ToDouble(textBox5.Text) == 2)
                {
                    pictureBox5.Visible = false;   //вызов картинок
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = false;
                    pictureBox8.Visible = false;
                    pictureBox9.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Максимальное кол-во чашек!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((radioButton5.Checked == false) && (radioButton6.Checked == false) && (radioButton7.Checked == false) && (radioButton8.Checked == false))
            {
                MessageBox.Show("не выбран вид кофе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToDouble(textBox6.Text) < 200)
                {
                    MessageBox.Show("Недостаточно воды!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToDouble(textBox5.Text) == 0)
                    {
                        MessageBox.Show("Нет чашки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Convert.ToDouble(textBox5.Text) == 1)
                        {
                            MessageBox.Show("Нужна вторая чашка!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            if (radioButton5.Checked == true)
                            {
                                x1 = 2;
                                avtomat1.time = x1;
                            }
                            if (radioButton6.Checked == true)
                            {
                                x1 = 4;
                                avtomat1.time = x1;
                            }
                            if (radioButton7.Checked == true)
                            {
                                x1 = 5;
                                avtomat1.time = x1;
                            }
                            if (radioButton8.Checked == true)
                            {
                                x1 = 8;
                                avtomat1.time = x1;
                            }
                            k1 = avtomat.Voda;        //Присваиваем k значение воды
                            pictureBox5.Visible = false;  //блок кнопок и вызов картинок
                            pictureBox6.Visible = false;
                            pictureBox7.Visible = true;
                            pictureBox8.Visible = false;
                            pictureBox9.Visible = false;
                            button5.Enabled = false;
                            button6.Enabled = false;
                            button7.Enabled = false;
                            button8.Enabled = false;
                            timer2.Start();  //включение таймера
                        }
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (x1 > 0)                                //если время приготовление больше 0
            {
                avtomat1.Round = 100 / avtomat1.time;                                     //Значение, которое нужно вычитать каждую секунду
                avtomat1.Vtimer();                                                     //Вычитаем
                textBox6.Text = Convert.ToString(avtomat1.Voda);                          //Присваиваем значение воды в текстбокс
                x1 = x1 - 1;                                                           //Вычитаем из времени приготовления 1
            }
            else
            {
                timer2.Stop();                           //остановка таймера
                k1 = k1 - 200;
                avtomat1.FullVoda = avtomat1.FullVoda - 200;
                avtomat1.Voda = k1;                         //Присваем Свойству вода значение воды
                textBox6.Text = Convert.ToString(k1);    //Присваем воду воду текстбокс
                textBox5.Text = Convert.ToString(0);     //Обнуляем текстбокс чашек
                avtomat1.Cups = 0;                          //Обнуляем Свойство чашек
                pictureBox5.Visible = false;             //картинки и кнопки
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
                pictureBox9.Visible = false;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                avtomat1.Eventus();
                avtomat1.Eventus2();
            }
        }

    }
}
    


   



