using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVN_Buoi7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.schoolDBDataSet.Students);

        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một dòng dữ liệu mới
                DataRow newRow = schoolDBDataSet.Students.NewRow();

                // Gán giá trị từ các điều khiển vào dòng mới
                newRow["Student"] = int.Parse(txtStudentID.Text);
                newRow["FullName"] = txtFullName.Text;
                newRow["Age"] = int.Parse(txtAge.Text);
                newRow["Major"] = cmbMajor.Text;

                // Thêm dòng mới vào DataTable
                schoolDBDataSet.Students.Rows.Add(newRow);

                // Lưu dữ liệu xuống cơ sở dữ liệu
                studentsTableAdapter.Update(schoolDBDataSet.Students);

                MessageBox.Show("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy chỉ số của dòng hiện tại
                int currentIndex = bindingNavigatorPositionItem.Text == "" ? 0 : int.Parse(bindingNavigatorPositionItem.Text) - 1;

                // Kiểm tra xem chỉ số có hợp lệ không
                if (currentIndex >= 0 && currentIndex < schoolDBDataSet.Students.Rows.Count)
                {
                    // Xóa dòng hiện tại
                    schoolDBDataSet.Students.Rows[currentIndex].Delete();

                    // Lưu lại thay đổi vào cơ sở dữ liệu
                    studentsTableAdapter.Update(schoolDBDataSet.Students);

                    MessageBox.Show("Xóa sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }

        private void bindingNavigatorUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy chỉ số của dòng hiện tại
                int currentIndex = bindingNavigatorPositionItem.Text == "" ? 0 : int.Parse(bindingNavigatorPositionItem.Text) - 1;

                // Kiểm tra xem chỉ số có hợp lệ không
                if (currentIndex >= 0 && currentIndex < schoolDBDataSet.Students.Rows.Count)
                {
                    // Cập nhật dữ liệu
                    DataRow currentRow = schoolDBDataSet.Students.Rows[currentIndex];
                    currentRow["FullName"] = txtFullName.Text;
                    currentRow["Age"] = int.Parse(txtAge.Text);
                    currentRow["Major"] = cmbMajor.Text;

                    // Lưu lại thay đổi vào cơ sở dữ liệu
                    studentsTableAdapter.Update(schoolDBDataSet.Students);

                    MessageBox.Show("Cập nhật sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên: " + ex.Message);
            }
        }
    }
}
