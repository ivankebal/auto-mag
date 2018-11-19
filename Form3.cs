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
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e) {
            Stream myStream;

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if ((myStream = saveFileDialog1.OpenFile()) != null) {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try {
                        for (int i = 0; i < dataGridView1.RowCount; i++) {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++) {
                                if (dataGridView1.Rows[i].Cells[j].Value != null) {
                                    myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                                }
                            }
                            myWritet.WriteLine();
                        }

                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    } finally {
                        myWritet.Close();
                    }

                    myStream.Close();
                }
            }
        }

        private void добавитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e) {
            DataGridViewRow newRow = new DataGridViewRow();

            dataGridView1.Rows.Add(newRow);
        }

        private void удалитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
