using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace lab82
{
    public partial class Form1 : Form
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";

        public Form1()
        {
            InitializeComponent();
            EditLabel(0);
        }
        void button1_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(1);

        }
        void MainButton(int check)
        {
            if (check == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (check == 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }
        void EditLabel(int check)
        {
            if (check == 0)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SearchBtn.Hide();
                SortName.Hide();
                SortGroup.Hide();
                SortPoint.Hide();
            }
            if (check == 1)
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                button6.Show();
                DeleteBtn.Hide();
                SortName.Hide();
                SortGroup.Hide();
                SortPoint.Hide();
            }
            if (check == 2)
            {
                DeleteBtn.Show();
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                SearchBtn.Hide();
                SortName.Hide();
                SortGroup.Hide();
                SortPoint.Hide();
            }
            if (check == 3)
            {
                SearchBtn.Show();
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SortName.Hide();
                SortGroup.Hide();
                SortPoint.Hide();
            }
            if (check == 4)
            {
                SearchBtn.Hide();
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SortName.Show();
                SortGroup.Show();
                SortPoint.Show();
            }
        }
        void button3_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(3);
        }
        void AddStudent(string name, string city, string success, string point, string ngroup)
        {
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            data.Add(new Students_Data { Name = name, Сity = city, Success = success, Point = point, NGroup = ngroup });
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);


        }
        void DeleteStudent(string name)
        {
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            data.RemoveAll(x => x.Name == name);
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }
        void SearchStudent(string name)
        {
            textBox1.Text = "";
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            Students_Data FoundData = data.Find(found => found.Name == name);
            string info = "      " + FoundData.Name + "         " + FoundData.Сity + "           " + FoundData.Success + "           " + FoundData.Point + "               " + FoundData.NGroup;
            textBox1.AppendText("╔═════════╤═══════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("      Name     │   City     │ Success │    Point    │ Pos in Group");
            textBox1.AppendText(Environment.NewLine); 
            textBox1.AppendText("╠═════════╪═══════╪════════╪════════╪═══════════╣");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(info);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═══════╧════════╧════════╧═══════════╝");

            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddStudent(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchStudent(textBox2.Text);
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteStudent(textBox2.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditLabel(4);
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       City     │ Success │    Point    │ Pos in Group");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + data[i].Name + "          " + data[i].Сity + "           " + data[i].Success + "            " + data[i].Point + "                 " + data[i].NGroup);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortName_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            List<Students_Data> SortData = data.OrderBy(o => o.Name).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       City     │ Success │    Point    │ Pos in Group");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Name + "          " + SortData[i].Сity + "           " + SortData[i].Success + "            " + SortData[i].Point + "                 " + SortData[i].NGroup);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortGroup_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            List<Students_Data> SortData = data.OrderBy(o => o.NGroup).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       City     │ Success │    Point    │ Pos in Group");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Name + "          " + SortData[i].Сity + "           " + SortData[i].Success + "            " + SortData[i].Point + "                 " + SortData[i].NGroup);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortPoint_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Students_Data>>(File.ReadAllText(FilePath));
            List<Students_Data> SortData = data.OrderBy(o => o.Point).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       City     │ Success │    Point    │ Pos in Group");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Name + "          " + SortData[i].Сity + "           " + SortData[i].Success + "            " + SortData[i].Point + "                 " + SortData[i].NGroup);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            EditLabel(0);
            MainButton(1);
        }
    }

    public class Students_Data
    {
        private string name;
        private string city;
        private string point;
        private string success;
        private string nGroup;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Сity
        {
            get { return city; }
            set { city = value; }
        }
        public string Success
        {
            get { return success; }
            set { success = value; }
        }
        public string Point
        {
            get { return point; }
            set { point = value; }
        }
        public string NGroup
        {
            get { return nGroup; }
            set { nGroup = value; }
        }

    }
}
