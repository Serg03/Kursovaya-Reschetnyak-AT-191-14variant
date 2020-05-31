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
	public partial class Form4 : Form
	{
		public Form4()
		{
			InitializeComponent();
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
		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
		
		List<string> Zagr = new List<string>();
		private void Form4_Load(object sender, EventArgs e)
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
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			if (textBox5.Text == "пароль")
			{
				int x = Convert.ToInt32(textBox1.Text);
				int a = (x - 1) * 4;
				int k = 0;
				int i = Zagr.Count;
				dataGridView1.Rows.Add(x, Zagr[a], Zagr[a + 1], Zagr[a + 2], Zagr[a + 3]);
				if (textBox2.Text != "") 
				{
					for (int j = 0; j < i; j++)
					{

						if (textBox2.Text == Zagr[j]) { k++; }
					}
					if (k < 2)
					{
						Zagr[a] = textBox2.Text;
					}
				}
				if (textBox3.Text != "")
				{
					Zagr[a + 1] = textBox3.Text;
				}
				if (textBox4.Text != "")
				{
					Zagr[a + 2] = textBox4.Text;
				}
				if (textBox6.Text != "")
				{
					Zagr[a + 3] = textBox6.Text;
				}
				dataGridView1.Rows.Add(x, Zagr[a], Zagr[a + 1], Zagr[a + 2], Zagr[a + 3]);
				textBox5.Text = "";
			}
		}
		private void button2_Click(object sender, EventArgs e)
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

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox5.Text == "пароль")
			{
				Form2 form2 = new Form2();
			form2.Show();
			this.Close();
			}
		}
	}
}
