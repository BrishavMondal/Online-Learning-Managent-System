using Data_Access.Entities;
using Data_Access.Tables;
using Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;


namespace OLMS
{
    public partial class Admin_Panel : Form
    {
        public Admin_Panel()
        {
            InitializeComponent();
            Database db = new Database();
            List<Student> data = db.Student.Get_All_Students();
            dgv_student.DataSource = data;

            Database db1 = new Database();
            List<Teacher> data1 = db1.Teacher.Get_All_Teachers();
            dgv_teacher.DataSource = data1;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void bt_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login_Page().Show();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tb_uname.Text);


            if (rb_teacher.Checked)
            {
                Database db1 = new Database();
                Teacher tea = db1.Teacher.Search(id);
                if (tea == null)
                {
                    MessageBox.Show("Not found.");

                    tb_id.Text = "";
                    tb_uname.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                }
                else
                {
                    tb_uname.Text = tea.Teacher_Id.ToString();
                    tb_id.Text = tea.User_Id.ToString();
                    tb_dept.Text = tea.Department;
                    tb_contact.Text = tea.Contact_Number;
                }
            }

            if (rb_student.Checked)
            {
                Database db = new Database();
                Student stu = db.Student.Search(id);
                if (stu == null)
                {
                    MessageBox.Show("Not found.");
                    tb_id.Text = "";
                    tb_uname.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                    tb_course.Text = "";
                }
                else
                {
                    //tb_uname.Text = stu.Student_Id.ToString();
                    tb_id.Text = stu.User_Id.ToString();
                    tb_dept.Text = stu.Department;
                    tb_contact.Text = stu.Contact_Number;
                    tb_course.Text = stu.Course;
                }
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
     
            if (rb_teacher.Checked)
            {
                int updated_teacherid = int.Parse(tb_uname.Text);
                string updated_contact = tb_contact.Text;
                string updated_department = tb_dept.Text;
                int updated_userid = int.Parse(tb_id.Text);

                Teacher tea = new Teacher();
                tea.Teacher_Id = int.Parse(tb_uname.Text);
                tea.User_Id = int.Parse(tb_id.Text);
                tea.Contact_Number = tb_contact.Text;
                tea.Department = tb_dept.Text;

                Database db = new Database();
                bool r = db.Teacher.Update(tea);
                if (r == true)
                {
                    dgv_teacher.DataSource = db.Teacher.Get_All_Teachers();
                    MessageBox.Show("Updated.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                }
                else
                {
                    MessageBox.Show("Update Error.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                }
            }

            if (rb_student.Checked)
            {
                int updated_teacherid = int.Parse(tb_uname.Text);
                string updated_contact = tb_contact.Text;
                string updated_department = tb_dept.Text;
                string updated_course = tb_course.Text;
                int updated_userid = int.Parse(tb_id.Text);

                Student stu = new Student();
                stu.Student_Id = int.Parse(tb_uname.Text);
                stu.User_Id = int.Parse(tb_id.Text);
                stu.Course = tb_course.Text;
                stu.Contact_Number = tb_contact.Text;
                stu.Department = tb_dept.Text;
                

                Database db1 = new Database();
                bool rs = db1.Student.Update(stu);
                if (rs == true)
                {
                    dgv_student.DataSource = db1.Student.Get_All_Students();
                    MessageBox.Show("Updated.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                    tb_course.Text = "";
                }
                else
                {
                    MessageBox.Show("Update Error.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                    tb_course.Text = "";
                }
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            string User_Id = tb_uname.Text;

            if (rb_teacher.Checked)
            {
                Database db = new Database();
                bool r = db.Teacher.Delete(User_Id);
                if (r)
                {
                    dgv_teacher.DataSource = db.Teacher.Get_All_Teachers();
                    MessageBox.Show("Row Deleted.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                }
                else
                {
                    MessageBox.Show("ERROR.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                }
            }

            if (rb_student.Checked)
            {
                Database db = new Database();
                bool rs = db.Student.Delete(User_Id) ;
                if (rs)
                {
                    dgv_student.DataSource = db.Student.Get_All_Students();
                    MessageBox.Show("Row Deleted.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                    tb_course.Text = "";
                }
                else
                {
                    MessageBox.Show("ERROR.");
                    tb_uname.Text = "";
                    tb_id.Text = "";
                    tb_contact.Text = "";
                    tb_dept.Text = "";
                    tb_course.Text = "";
                }
            }
        }

        private void User_Imfo_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
            new User_info_Edit().Show();
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {

        }

        private void tb_contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_teacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
