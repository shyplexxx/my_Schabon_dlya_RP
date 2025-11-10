using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace RP12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ClientSize = new Size(1114, 710);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp12;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                            idguest AS 'ID',
                                            name AS 'Имя',
                                            second_name AS 'Отчество',
                                            last_name AS 'Фамиия',
                                            number_phone AS 'Номер телефона',
                                            series_pasport AS 'Серия паспорта',
                                            number_pasport AS 'Номер паспорта',
                                            adress AS 'Адрес',
                                            room_number AS 'Номер команты'         
                                   FROM guest";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                    if (dataGridView1.Columns.Contains("ID"))
                    {
                        dataGridView1.Columns["ID"].Visible = false;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе: " + ex.Message);
            }
        }

        private void LoadData()
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp12;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                            idguest AS 'ID',
                                            name AS 'Имя',
                                            second_name AS 'Отчество',
                                            last_name AS 'Фамиия',
                                            number_phone AS 'Номер телефона',
                                            series_pasport AS 'Серия паспорта',
                                            number_pasport AS 'Номер паспорта',
                                            adress AS 'Адрес',
                                            room_number AS 'Номер команты'         
                                   FROM guest";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                    if (dataGridView1.Columns.Contains("ID"))
                    {
                        dataGridView1.Columns["ID"].Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp12;";
            


            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Ошибка! Обязательные поля - пропущены");
                return;
                
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO guest (name, second_name, last_name, number_phone, series_pasport, number_pasport, adress, room_number) " +
                                   "VALUES (@name, @second, @last, @phone, @ser, @num, @adress, @room)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@second", textBox3.Text);
                        cmd.Parameters.AddWithValue("@last", textBox4.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                        cmd.Parameters.AddWithValue("@ser", textBox6.Text);
                        cmd.Parameters.AddWithValue("@num", textBox7.Text);
                        cmd.Parameters.AddWithValue("@adress", textBox8.Text);
                        cmd.Parameters.AddWithValue("@room", textBox9.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Запись добавлена!");

                    
                    LoadData();
                   
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "+7";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            

            string connStr = "server=127.0.0.1;user=root;password=root;database=rp12;";

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                try
                {
                    
                    string query = @"DELETE FROM guest WHERE idguest = @ID";


                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", textBox18.Text);
                    cmd.Parameters.AddWithValue("@name", textBox17.Text);
                    cmd.Parameters.AddWithValue("@second_name", textBox16.Text);
                    cmd.Parameters.AddWithValue("@last_name", textBox15.Text);
                    cmd.Parameters.AddWithValue("@number_phone", textBox14.Text);
                    cmd.Parameters.AddWithValue("@adress", textBox13.Text);
                    cmd.Parameters.AddWithValue("@experience", textBox12.Text);
                    cmd.Parameters.AddWithValue("@post", textBox11.Text);
                    cmd.Parameters.AddWithValue("@specialization", textBox10.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно Удалена");


                    LoadData();
                    textBox18.Text = "";
                    textBox17.Text = "";
                    textBox16.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                    textBox12.Text = "";
                    textBox11.Text = "";
                    textBox10.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при работе с базой данных:\n" + ex.Message);
                }

            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox2.Text))
            {

            }
            else
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.Text.Length;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox3.Text))
            {

            }
            else
            {
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox4.Text))
            {

            }
            else
            {
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            Regex regex = new Regex("^[0-9+]*$");
            if (regex.IsMatch(textBox5.Text))
            {

            }
            else
            {
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
                textBox5.SelectionStart = textBox5.Text.Length;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox6.Text))
            {

            }
            else
            {
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
                textBox6.SelectionStart = textBox6.Text.Length;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox7.Text))
            {

            }
            else
            {
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
                textBox7.SelectionStart = textBox7.Text.Length;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я0-9 ]*$");
            if (regex.IsMatch(textBox8.Text))
            {

            }
            else
            {
                textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
                textBox8.SelectionStart = textBox8.Text.Length;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox9.Text))
            {

            }
            else
            {
                textBox9.Text = textBox9.Text.Remove(textBox9.Text.Length - 1);
                textBox9.SelectionStart = textBox9.Text.Length;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;

                // Проверяем, сколько у нас столбцов и заполняем TextBox'ы по порядку
                if (row.Cells.Count >= 1) textBox18.Text = row.Cells[0].Value?.ToString() ?? "";
                if (row.Cells.Count >= 2) textBox17.Text = row.Cells[1].Value?.ToString() ?? "";
                if (row.Cells.Count >= 3) textBox16.Text = row.Cells[2].Value?.ToString() ?? "";
                if (row.Cells.Count >= 4) textBox15.Text = row.Cells[3].Value?.ToString() ?? "";
                if (row.Cells.Count >= 5) textBox14.Text = row.Cells[4].Value?.ToString() ?? "";
                if (row.Cells.Count >= 6) textBox13.Text = row.Cells[5].Value?.ToString() ?? "";
                if (row.Cells.Count >= 7) textBox12.Text = row.Cells[6].Value?.ToString() ?? "";
                if (row.Cells.Count >= 8) textBox11.Text = row.Cells[7].Value?.ToString() ?? "";
                if (row.Cells.Count >= 9) textBox10.Text = row.Cells[8].Value?.ToString() ?? "";

            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox17.Text))
            {

            }
            else
            {
                textBox17.Text = textBox17.Text.Remove(textBox17.Text.Length - 1);
                textBox17.SelectionStart = textBox17.Text.Length;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox16.Text))
            {

            }
            else
            {
                textBox16.Text = textBox16.Text.Remove(textBox16.Text.Length - 1);
                textBox16.SelectionStart = textBox16.Text.Length;
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я]*$");
            if (regex.IsMatch(textBox15.Text))
            {

            }
            else
            {
                textBox15.Text = textBox15.Text.Remove(textBox15.Text.Length - 1);
                textBox15.SelectionStart = textBox15.Text.Length;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9+]*$");
            if (regex.IsMatch(textBox14.Text))
            {

            }
            else
            {
                textBox14.Text = textBox14.Text.Remove(textBox14.Text.Length - 1);
                textBox14.SelectionStart = textBox14.Text.Length;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox13.Text))
            {

            }
            else
            {
                textBox13.Text = textBox13.Text.Remove(textBox13.Text.Length - 1);
                textBox13.SelectionStart = textBox13.Text.Length;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox12.Text))
            {

            }
            else
            {
                textBox12.Text = textBox12.Text.Remove(textBox12.Text.Length - 1);
                textBox12.SelectionStart = textBox12.Text.Length;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я0-9 ]*$");
            if (regex.IsMatch(textBox11.Text))
            {

            }
            else
            {
                textBox11.Text = textBox11.Text.Remove(textBox11.Text.Length - 1);
                textBox11.SelectionStart = textBox11.Text.Length;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (regex.IsMatch(textBox10.Text))
            {

            }
            else
            {
                textBox10.Text = textBox10.Text.Remove(textBox10.Text.Length - 1);
                textBox10.SelectionStart = textBox10.Text.Length;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();


            form3.Show();


            this.Dispose();
        }
    }
}
