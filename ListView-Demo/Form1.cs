using ListView_Demo.Data;
using ListView_Demo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListView_Demo
{
    public partial class Form1 : Form
    {

      // static List<Student> students = new List<Student>();
        static List<Student> studentsSearch = new List<Student>();

        static int index = -1;
       static Student studentUpdate = null;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            listViewStudent.View = View.Details;
            // Allow the user to edit item text.
            listViewStudent.LabelEdit = true;
            // Allow the user to rearrange columns.
          //  listViewStudent.AllowColumnReorder = true;
            // Display check boxes.
            listViewStudent.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listViewStudent.FullRowSelect = true;
            // Display grid lines.
            listViewStudent.GridLines = true;
            // Sort the items in the list in ascending order.
           // listViewStudent.Sorting = SortOrder.Ascending;
            listViewStudent.Columns.Add("Index", -2, HorizontalAlignment.Left);
            listViewStudent.Columns.Add("StudentCode", -2, HorizontalAlignment.Left);
            listViewStudent.Columns.Add("StudentName", -2, HorizontalAlignment.Left);
            listViewStudent.Columns.Add("Address", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("Phone", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("GPA", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("Status", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("Gender", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("BirthDay", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("Class", -2, HorizontalAlignment.Center);
            listViewStudent.Columns.Add("Major", -2, HorizontalAlignment.Center);

            // Khoi tao doi tuong List Student 

          /*  for(int i = 0; i < 10; i++)
            {
                // Them 10 Student vao studentList 
                Student student = new Student();
                student.Index = i+1;
                student.StudentCode = "BH001";
                student.StudentName = "Nguyen Tuan Manh";
                student.Address = "Ha Noi";
                student.Phone = "0945312678";
                student.GPA = 8.0;
                student.Status = 1;
                student.Gender = true;
                student.BirthDay = "2004-06-12";
                student.Class = "SE06012";
                student.Major = "Computer Science";

                students.Add(student);

            }*/

            foreach (Student s in StaticData.students)
            {
                listViewStudent.Items.Add(
               new ListViewItem(new[] {
                   s.Index+"", 
                   s.StudentCode+"", 
                   s.StudentName+"", 
                   s.Address+"",
                   s.Phone,s.GPA+"",
                   s.Status+"",
                   s.Gender+"",
                   s.BirthDay+"",
                   s.Class+"",
                   s.Major }));
            }




            cbx_Major.Items.Add("Computer Science");
            cbx_Major.Items.Add("Graphic");
            cbx_Major.Items.Add("Marketing-PR");

            cbx_Staus.Items.Add("Off");
            cbx_Staus.Items.Add("On");
            cbx_Staus.Items.Add("Warning");


            // this.Controls.Add(listViewStudent);


            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listViewStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
             index = listViewStudent.FocusedItem.Index;

            studentUpdate  = StaticData.students[index];
            /* Student s = students[index];*/

            tbx_StudentCode.Text = studentUpdate.StudentCode;
            tbx_StudentName.Text = studentUpdate.StudentName;
            tbx_Address.Text = studentUpdate.Address;
            txb_PhoneNumber.Text = studentUpdate.Phone;

            // MessageBox.Show(index + "");


            // int index = listViewStudent.SelectedItems.IndexOf(selectedItems);

        }


        private List<Student> searchByKeyword(string keyword)
        {

            if(keyword == "")
            {
                return StaticData.students;
            }
          List<Student> studentsSearch = new List<Student>();

            for(int i = 0;i< StaticData.students.Count; i++)
            {

                Student student = StaticData.students[i];

                if (student.StudentName.Contains(keyword))
                {
                    studentsSearch.Add(student);
                }
            }

         /*   foreach(Student student in students)
            {
                if (student.StudentName.Contains(keyword))
                {
                    studentsSearch.Add(student);
                }

            }*/
            return studentsSearch;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // In this example, we will simply display the current text in a label
           // this.label1.Text = ((TextBox)sender).Text;

            string keyword = ((System.Windows.Forms.TextBox)sender).Text;

            studentsSearch = searchByKeyword(keyword);
            Display(studentsSearch);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            UserInputForm userInput = new UserInputForm();
            userInput.ShowDialog();

/*
            string studentCode = tbx_StudentCode.Text;
            string studentName = tbx_StudentName.Text;
            string address = tbx_Address.Text;
            string phone = txb_PhoneNumber.Text;

            Student student = new Student();
            student.StudentCode = studentCode;
            student.StudentName = studentName;
            student.Address = address;
            student.Phone = phone;

            students.Add(student);
            listViewStudent.Items.Clear();
            int i = 0;

            foreach (Student s in students)
            {
                listViewStudent.Items.Add(
               new ListViewItem(new[] {
                   s.Index+"" + (i+1),
                   s.StudentCode+"",
                   s.StudentName+"",
                   s.Address+"",
                   s.Phone,s.GPA+"",
                   s.Status+"",
                   s.Gender+"",
                   s.BirthDay+"",
                   s.Class+"",
                   s.Major }));
                i++;
            }

            MessageBox.Show("Insert student sucessful");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                StaticData.students.RemoveAt(index);

                listViewStudent.Items.Clear();
                int i = 0;

                foreach (Student s in StaticData.students)
                {
                    listViewStudent.Items.Add(
                   new ListViewItem(new[] {
                   s.Index+"" + (i+1),
                   s.StudentCode+"",
                   s.StudentName+"",
                   s.Address+"",
                   s.Phone,s.GPA+"",
                   s.Status+"",
                   s.Gender+"",
                   s.BirthDay+"",
                   s.Class+"",
                   s.Major }));
                    i++;
                }
                listViewStudent.Refresh();
            }
            catch(Exception ex)
            {

            }

           
        }

        private void Display(List<Student> displayList)
        {
            listViewStudent.Items.Clear();
            int i = 0;

            foreach (Student s in displayList)
            {
                listViewStudent.Items.Add(
               new ListViewItem(new[] {
                   s.Index+"" + (i+1),
                   s.StudentCode+"",
                   s.StudentName+"",
                   s.Address+"",
                   s.Phone,s.GPA+"",
                   s.Status+"",
                   s.Gender+"",
                   s.BirthDay+"",
                   s.Class+"",
                   s.Major }));
                i++;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Student s = students[index];

            StaticData.students[index].StudentCode = tbx_StudentCode.Text;
            StaticData.students[index].StudentName = tbx_StudentName.Text;
            StaticData.students[index].Address = tbx_Address.Text;
            StaticData.students[index].Phone = txb_PhoneNumber.Text;

            listViewStudent.Items.Clear();
            int i = 0;

            foreach (Student s in StaticData.students)
            {
                listViewStudent.Items.Add(
               new ListViewItem(new[] {
                   s.Index+"" + (i+1),
                   s.StudentCode+"",
                   s.StudentName+"",
                   s.Address+"",
                   s.Phone,s.GPA+"",
                   s.Status+"",
                   s.Gender+"",
                   s.BirthDay+"",
                   s.Class+"",
                   s.Major }));
                i++;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display(StaticData.students);
        }
    }
}
