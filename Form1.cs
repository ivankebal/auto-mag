using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Выбор_автомобилей {
    public partial class Form1 : Form {
        String openFile;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            if(openFile == null) {
                MessageBox.Show("Нет открытого файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form2 newMDIChild = new Form2();
            
            string auto = (string)comboBox1.SelectedItem;
            string cost = (string)comboBox2.SelectedItem;
            string rate = (string)comboBox3.SelectedItem;
            string realibility = (string)comboBox4.SelectedItem;
            string comfort = (string)comboBox5.SelectedItem;
            int i = 0;
            foreach (var line in openFile.Split('\n')) {
                var array = line.Split();
                //проверяет, есть ли в строке 6 колонок, если да то выводит
                if (array.Length == 6) {
                    if ((auto == array[0] || auto == null) &&
                        (cost == array[1] || cost == null) &&
                        (rate == array[2] || rate == null) &&
                        (realibility == array[3] || realibility == null) &&
                        (comfort == array[4] || comfort == null)) {
                        newMDIChild.dataGridView2.Rows.Add(array);
                        newMDIChild.dataGridView2.Rows[i].HeaderCell.Value = (i + 1).ToString();
                        i++;
                    }
                } 
            }

            newMDIChild.Show();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) {
            Form3 newMDIChild = new Form3();
            // Задать дочернюю форму
            newMDIChild.Owner = this;
            //Заполняем DataGridView1 из файла
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                openFile = "";
                try {

                    if ((myStream = openFileDialog1.OpenFile()) != null) {
                        //открываем 
                        using (myStream) {
                            int ch = 0;
                            //читаем символ за символом и сохраняем в string openFile
                            while (true) {
                                ch = myStream.ReadByte();
                                if (ch == -1) {
                                    break;
                                }
                                openFile += (char)ch; 
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                } 
                //показываем форму с открытым файлом
                int i = 0;
                foreach (var line in openFile.Split('\n')) {
                    //проверяет, есть ли в строке 6 колонок, если да то выводит
                    if (line.Split().Length == 6) {
                        newMDIChild.dataGridView1.Rows.Add(line.Split());
                        newMDIChild.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                        i++;
                    }
                }

                newMDIChild.Show();

            }

        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) {
            Form3 newMDIChild = new Form3();
            // Задать дочернюю форму
            newMDIChild.Owner = this;

            newMDIChild.dataGridView1.Rows.Clear();

            newMDIChild.Show();



        }
    }
}

