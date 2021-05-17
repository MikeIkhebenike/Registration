using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа_1
{
    public partial class Form1 : Form
    {
        public static Form1 FORMA { get; set; }
        public static Users USER { get; set; }
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //проверка на ввод только  букв и цифр, и backspace
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        //проверка на ввод только  букв и цифр, и backspace
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            FORMA = this;
            this.Hide();
            f.Show();

        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Нужно ввести логин и пароль!");
                return;
            }
            //поиск уч. записи в БД
            Users usr = db.Users.Find(textBox1.Text);
            //если данные найдены запускается одна из следующих форм
            if ((usr != null) && (usr.psw == textBox2.Text))
            {
                USER = usr;
                FORMA = this;
                //форма директора
                if (usr.role == "Директор")
                {
                    Form3 frm = new Form3();
                    frm.Show();
                    this.Hide();
                }
                //форма менеджера
                else if (usr.role == "Менеджер")
                {
                    Form4 frm = new Form4();
                    frm.Show();
                    this.Hide();
                }
                //форма заказчика
                else if (usr.role == "Заказчик")
                {
                    Form5 frm = new Form5();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Роли {usr.role} в системе нет!");
                    return;
                }
            }

        }

    }
}

//if (!(e.KeyChar < '0' || e.KeyChar > '9')) // если символ не цифра  
/*e.Handled = true; */  // нажатый символ не вводится
//тоже самое
//if (!Char.IsDigit(e.KeyChar))
//   e.Handled = true;
//	проверка на ввод символов букв русского или английского алфавита:
//if (!Char.IsLetter(e.KeyChar))
//    e.Handled = true; 
//	проверка на ввод символов букв или цифр:
//if (!Char.IsLetterOrDigit(e.KeyChar))
//    e.Handled = true;
//	проверка на ввод символов русского алфавита (следует учесть, что коды символов упорядочены следующим образом: A < B < C < … < Z < a < b < c < … < z < А < Б < В < … < Я < а < б < в < … < я)
//      if (e.KeyChar < 'А' || e.KeyChar > 'я') // если не русская буква
//    e.Handled = true;
// e.KeyChar != 8 - Backspace; e.KeyChar != 32 - пробел




