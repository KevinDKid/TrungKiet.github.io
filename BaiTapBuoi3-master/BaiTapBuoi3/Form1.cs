using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapBuoi3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgvThongTin.ColumnCount = 3;
            dtgvThongTin.Columns[0].Name = "MSNV";
            dtgvThongTin.Columns[1].Name = "Tên";
            dtgvThongTin.Columns[2].Name = "Lương";

            dtgvThongTin.Rows.Add("001", "KevinDeKid", "1000");
            dtgvThongTin.Rows.Add("002", "VenuSs", "1500");
            dtgvThongTin.Rows.Add("003", "Jinn", "2000");
        }

        private void dtgvThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2("", "", ""); // Form thêm mới
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Thêm dữ liệu mới vào DataGridView
                dtgvThongTin.Rows.Add(form.MSNV, form.Ten, form.Luong);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvThongTin.CurrentRow != null)
            {
                // Lấy dữ liệu từ hàng hiện tại
                string msnv = dtgvThongTin.CurrentRow.Cells[0].Value.ToString();
                string ten = dtgvThongTin.CurrentRow.Cells[1].Value.ToString();
                string luong = dtgvThongTin.CurrentRow.Cells[2].Value.ToString();

                Form2 form = new Form2(msnv, ten, luong); // Form sửa
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật dữ liệu hàng hiện tại
                    dtgvThongTin.CurrentRow.Cells[0].Value = form.MSNV;
                    dtgvThongTin.CurrentRow.Cells[1].Value = form.Ten;
                    dtgvThongTin.CurrentRow.Cells[2].Value = form.Luong;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvThongTin.CurrentRow != null)
            {
                dtgvThongTin.Rows.RemoveAt(dtgvThongTin.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
