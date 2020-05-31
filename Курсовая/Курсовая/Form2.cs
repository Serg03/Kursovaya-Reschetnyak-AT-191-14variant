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
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		List<string> Zagr = new List<string>();

		private void Form2_Load(object sender, EventArgs e)
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
			column4.HeaderText = "Имя Отчество";
			column4.Width = 200;
			column4.Name = "iniz";
			column4.CellTemplate = new DataGridViewTextBoxCell();

			var column5 = new DataGridViewColumn();
			column5.HeaderText = "Адрес";
			column5.Width = 180;
			column5.Name = "adres";
			column5.CellTemplate = new DataGridViewTextBoxCell();
			
			dataGridView1.Columns.Add(column1);
			dataGridView1.Columns.Add(column2);
			dataGridView1.Columns.Add(column3);
			dataGridView1.Columns.Add(column4);
			dataGridView1.Columns.Add(column5);
			dataGridView1.AllowUserToAddRows = false;
			
			string path = "АТСном.txt";
			int k = 0;
			using (StreamReader fs = new StreamReader(@path))
			{
				while (true)
				{
					// Читаем строку из файла во временную переменную.
					string temp = fs.ReadLine();
					// Если достигнут конец файла, прерываем считывание.
					if (temp == null) break;
					else Zagr.Add(temp);
					k++;
				}
			}

			int i = 0, n = 1;
			while (i < k)
			{
				dataGridView1.Rows.Add(n, Zagr[i], Zagr[i + 1], Zagr[i + 2], Zagr[i + 3]);
				i = i + 4; n++;
			}
		}
		
		
	
		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				int i;
				int n = Zagr.Count / 4 + 1;
				i = Zagr.Count;
				int k = 0;
				string nomer = textBox1.Text;
				string fio = textBox2.Text;
				string iniz = textBox4.Text;
				string adres = textBox3.Text;
				if (nomer != "")
				{
					if ((textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") || ((textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")))
					{
						for (int j = 0; j < i; j++)
						{

							if (nomer == Zagr[j]) { k++; }
						}
						if (k < 1)
						{
							//Добавляем строку, указывая значения колонок поочереди слева направо
							dataGridView1.Rows.Add(n, nomer, fio, iniz, adres);
							Zagr.Add(nomer);
							Zagr.Add(fio);
							Zagr.Add(iniz);
							Zagr.Add(adres);

						}
						else { n--; }
					}
				}
				else { n--; }

				textBox1.Text = "";
				textBox2.Text = "";
				textBox3.Text = "";
				textBox4.Text = "";
			}
			textBox5.Text = "";
		}		
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true;
			}
			textBox1.MaxLength = 7;
		}
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			char l = e.KeyChar;
			if (!
	((l >= 'А' && l <= 'я')
	|| l == 'ё'
	|| l == 'Ё'
	|| l == '\b'
	|| l == ' '
	|| l == '-')) { e.Handled = true;}				
		}
		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			char l = e.KeyChar;
			if (!
	((l >= 'А' && l <= 'я')
	|| (l >= '0' && l <= '9')
	|| l == 'ё'
	|| l == 'Ё'
	|| l == '\b'
	|| l == ' '
	|| l == ','
	|| l == '-'
	|| l == '.'
	|| l == '/')) { e.Handled = true; }
		}
		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			char l = e.KeyChar;
			if (!
	((l >= 'А' && l <= 'я')
	|| (l >= '0' && l <= '9')
	|| l == 'ё'
	|| l == 'Ё'
	|| l == '\b'
	|| l == ' '
	|| l == ','
	|| l == '-'
	|| l == '.'
	|| l == '/')) { e.Handled = true; }
		}
		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
			{
				e.Handled = true;
			}
			textBox1.MaxLength = 4;
		}
		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
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
			textBox5.Text = "";
		}
	    private void button2_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				Form3 form3 = new Form3();
				form3.Show();
			}
			textBox5.Text = "";
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{

				if (textBox6.Text != "")
				{
					int y = Convert.ToInt32(textBox6.Text);
					if (y != 0 && y <= Zagr.Count / 4)
					{
						int i = y * 4 - 1;
						Zagr.RemoveAt(i);
						Zagr.RemoveAt(i - 1);
						Zagr.RemoveAt(i - 2);
						Zagr.RemoveAt(i - 3);
						dataGridView1.Rows.Clear();
						i = 0;
						int k = Zagr.Count, n = 1;
						while (i < k)
						{
							dataGridView1.Rows.Add(n, Zagr[i], Zagr[i + 1], Zagr[i + 2], Zagr[i + 3]);
							i = i + 4; n++;
						}
					}
				}
			}
			textBox5.Text = "";
		}
		private void button4_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				Form4 form4 = new Form4();
				form4.Show();
				this.Close();
			}
			textBox5.Text = "";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				dataGridView1.Rows.Clear();
				int k = Zagr.Count;
				int i = 0, n = 1;
				while (i < k)
				{
					dataGridView1.Rows.Add(n, Zagr[i], Zagr[i + 1], Zagr[i + 2], Zagr[i + 3]);
					i = i + 4; n++;
				}
			}
			textBox5.Text = "";
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				this.Close();
				Form1 mp = new Form1();
				mp.Show();
			}
		}
	}
}
