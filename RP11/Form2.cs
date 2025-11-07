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


namespace RP11
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ClientSize = new Size(1214, 710);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                            idteacher AS 'ID',
                                            name AS 'Имя',
                                            second_name AS 'Отчество',
                                            last_name AS 'Фамиия',
                                            number_phone AS 'Номер телефона',
                                            adress AS 'Адрес',
                                            experience AS 'Стаж',
                                            post AS 'Должность',
                                            specialization AS 'Специализация'         
                                   FROM teacher";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе: " + ex.Message);
            }
        }

        private void LoadData()
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                            idteacher AS 'ID',
                                            name AS 'Имя',
                                            second_name AS 'Отчество',
                                            last_name AS 'Фамиия',
                                            number_phone AS 'Номер телефона',
                                            adress AS 'Адрес',
                                            experience AS 'Стаж',
                                            post AS 'Должность',
                                            specialization AS 'Специализация'         
                                   FROM teacher";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Ошибка! Обязательные поля - пропущены");
                return;
                
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO teacher (name, second_name, last_name, number_phone, adress, experience, post, specialization) " +
                                   "VALUES (@name, @second, @last, @phone, @adress, @exp, @post, @spec)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@second", textBox3.Text);
                        cmd.Parameters.AddWithValue("@last", textBox4.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                        cmd.Parameters.AddWithValue("@adress", textBox6.Text);
                        cmd.Parameters.AddWithValue("@exp", textBox7.Text);
                        cmd.Parameters.AddWithValue("@post", textBox8.Text);
                        cmd.Parameters.AddWithValue("@spec", textBox9.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Запись добавлена!");

                    
                    LoadData();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "") 
            {
                MessageBox.Show("Введите ID записи, которую хотите изменить!");
                

                return;
            }
            int id; 

            if (!int.TryParse(textBox18.Text, out id))
            {
                MessageBox.Show("ID должен быть числом!");
                return;
            }

            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    
                    List<string> spisok = new List<string>();

                    if (textBox17.Text != "") spisok.Add("name = @name");
                    if (textBox16.Text != "") spisok.Add("second_name = @second");
                    if (textBox15.Text != "") spisok.Add("last_name = @last");
                    if (textBox14.Text != "") spisok.Add("number_phone = @phone");
                    if (textBox13.Text != "") spisok.Add("adress = @adress");
                    if (textBox12.Text != "") spisok.Add("experience = @exp");
                    if (textBox11.Text != "") spisok.Add("post = @post");
                    if (textBox10.Text != "") spisok.Add("specialization = @spec");

                    
                    string запрос = "UPDATE teacher SET " + string.Join(", ", spisok) + " WHERE idteacher = @id";

                    
                    using (MySql.Data.MySqlClient.MySqlCommand команда = new MySql.Data.MySqlClient.MySqlCommand(запрос, conn))
                    {
                        команда.Parameters.AddWithValue("@id", id);
                        команда.Parameters.AddWithValue("@name", textBox17.Text);
                        команда.Parameters.AddWithValue("@second", textBox16.Text);
                        команда.Parameters.AddWithValue("@last", textBox15.Text);
                        команда.Parameters.AddWithValue("@phone", textBox14.Text);
                        команда.Parameters.AddWithValue("@adress", textBox13.Text);
                        команда.Parameters.AddWithValue("@exp", textBox12.Text);
                        команда.Parameters.AddWithValue("@post", textBox11.Text);
                        команда.Parameters.AddWithValue("@spec", textBox10.Text);

                        
                        int измененоСтрок = команда.ExecuteNonQuery();

                        if (измененоСтрок > 0)
                            MessageBox.Show("Запись успешно изменена!");
                        else
                            MessageBox.Show("Запись с таким ID не найдена.");
                    }


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

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string id = textBox19.Text;

                    string query = "DELETE FROM teacher WHERE idteacher = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Запись удалена!");
                        else
                            MessageBox.Show("Запись не найдена!");
                    }

                    textBox19.Text = "";
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
