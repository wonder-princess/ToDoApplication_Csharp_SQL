using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApplication_SQL
{
    class MainPanel : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sekai\source\repos\ToDoApplication_SQL\ToDoApplication_SQL\ToDoData.mdf;Integrated Security=True";

        private Button creatDialogPanel_Add;
        public List<string> ToDoList = new List<string>();

        public MainPanel()
        {
            string str1 = "test";
            ToDoList.Add(str1);

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            try
            {
                string sqlstr = "select todotext from ToDoTable";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                var result = cmd.ExecuteReader();
                while(result.Read())
                {
                    ToDoList.Add($"{result.GetString(0)}");

                }

            }
            finally
            {
                //result.Close();
                con.Close();
            }


            this.Width = 300;
            this.Height = 500;
            if(ToDoList != null && ToDoList.Count > 0)
            {
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    var cb = new CheckBox();
                    cb.Top = 10 + i * 50;
                    cb.Left = 10;
                    cb.Parent = this;

                    var lb = new Label();
                    lb.Text = ToDoList[i];
                    lb.Top = 10 + i * 10;
                    lb.Left = 30;
                    lb.Parent = this;
                    lb.Click += new EventHandler(ClickCreatDialogPanel_Edit);
                }
            }

            creatDialogPanel_Add = new Button();
            creatDialogPanel_Add.Text = "作成";
            creatDialogPanel_Add.Top = 50 + ToDoList.Count * 50;
            creatDialogPanel_Add.Left = 200;
            creatDialogPanel_Add.Parent = this;
            creatDialogPanel_Add.Click += new EventHandler(ClickCreatDialogPanel_Add);

        }


        private void ClickCreatDialogPanel_Add(object sender, EventArgs e)
        {
            var dialog = new DialogPanel_Add();
            dialog.ShowDialog(this);
        }

        private void ClickCreatDialogPanel_Edit(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;
            var dialog = new DialogPanel_Edit(tmp.Text);
            dialog.ShowDialog(this);
        }

    }
}
