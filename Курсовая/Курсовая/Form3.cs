using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		List<string> Zagr = new List<string>();
	
		private void Form3_Load(object sender, EventArgs e)
		{
			var column1 = new DataGridViewColumn();
			column1.HeaderText = "Порядковый номер"; //текст в шапке
			column1.Width = 100;
			column1.ReadOnly = true;
			column1.Name = "persnomer";
			column1.Frozen = true;
			column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

			var column2 = new DataGridViewColumn();
			column2.HeaderText = "Номер";
			column2.Width = 100;
			column2.Name = "nomer";
			column2.CellTemplate = new DataGridViewTextBoxCell();

			var column3 = new DataGridViewColumn();
			column3.HeaderText = "Фамилия";
			column3.Width = 100;
			column3.Name = "FIO";
			column3.CellTemplate = new DataGridViewTextBoxCell();

			var column4 = new DataGridViewColumn();
			column4.HeaderText = "Инициалы";
			column4.Width = 80;
			column4.Name = "iniz";
			column4.CellTemplate = new DataGridViewTextBoxCell();

			var column5 = new DataGridViewColumn();
			column5.HeaderText = "Адрес";
			column5.Width = 130;
			column5.Name = "adres";
			column5.CellTemplate = new DataGridViewTextBoxCell();

			dataGridView1.Columns.Add(column1);
			dataGridView1.Columns.Add(column2);
			dataGridView1.Columns.Add(column3);
			dataGridView1.Columns.Add(column4);
			dataGridView1.Columns.Add(column5);
			dataGridView1.AllowUserToAddRows = false;



			string path = "АТСном.txt";
			using (StreamReader fs = new StreamReader(@path))
			{
				while (true)
				{
					// Читаем строку из файла во временную переменную.
					string temp = fs.ReadLine();
					// Если достигнут конец файла, прерываем считывание.
					if (temp == null) break;
					else Zagr.Add(temp);
				}
			}
		}
		
		
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char l = e.KeyChar;
			if (!
	((l >= 'А' && l <= 'я')
	|| l == 'ё'
	|| l == 'Ё'
	|| l == '\b'
	|| l == ' '
	|| l == '-')) { e.Handled = true; }
		}
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true; 
			}
			textBox2.MaxLength = 7;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox8.Text == "пароль")
			{
				//dataGridView1.Rows.Clear();
				string t;
				int k = Zagr.Count;
				t = textBox1.Text;
				textBox1.Text = "";
				int i = 1, n = 1, c = 0;
				while (i < k)
				{
					if (t == Zagr[i])
					{
						dataGridView1.Rows.Add(n, Zagr[i - 1], Zagr[i], Zagr[i + 1], Zagr[i + 2]);
						c++;
					}
					i = i + 4;
					n++;
				}
				textBox3.Text = Convert.ToString(c);
			}
			textBox8.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox8.Text == "пароль")
			{
				//dataGridView1.Rows.Clear();
				string t;
				int k = Zagr.Count;
				t = textBox2.Text;
				textBox2.Text = "";
				int i = 0, n = 1;
				while (i < k)
				{
					if (t == Zagr[i])
					{
						dataGridView1.Rows.Add(n, Zagr[i], Zagr[i + 1], Zagr[i + 2], Zagr[i + 3]);
					}
					i = i + 4;
					n++;
				}
			}
			textBox8.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox8.Text == "пароль")
			{
				dataGridView1.Rows.Clear();
			int a = Convert.ToInt32(textBox4.Text);
			int b = Convert.ToInt32(textBox5.Text);
			int i = (a-1)*4;
			int j = (b-1)*4;
			string obmen;
			obmen = Zagr[i];
			textBox6.Text = Zagr[i];
			textBox7.Text = Zagr[j];
			Zagr[i] = Zagr[j];
			Zagr[j] = obmen;
			dataGridView1.Rows.Add(a, Zagr[i], Zagr[i + 1], Zagr[i + 2], Zagr[i + 3]);
			dataGridView1.Rows.Add(b, Zagr[j], Zagr[j + 1], Zagr[j + 2], Zagr[j + 3]);
			}
			textBox8.Text = "";

		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true;
			}
			textBox1.MaxLength = 4;
		}
		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true;
			}
			textBox1.MaxLength = 4;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox8.Text == "пароль")
			{
				string path = "АТСном.txt";
				StreamWriter f = new StreamWriter(path);
				int c = Zagr.Count;
				for (int i = 0; i < c; i++)
				{
					f.WriteLine(Zagr[i]);
				}
				f.Close();
			}
			textBox8.Text = "";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (textBox8.Text == "пароль")
			{
				Form2 form2 = new Form2();
				form2.Show();
				this.Close();
			}
		}
	}
}
