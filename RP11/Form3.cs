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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.ClientSize = new Size(997, 390);
            string connStr = "server=127.0.0.1;user=root;password=root;database=rp11;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT 
                                            
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();


            form1.Show();


            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Dispose();
        }
    }
}
