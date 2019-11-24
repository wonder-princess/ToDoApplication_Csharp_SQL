using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApplication_SQL
{
    class DialogPanel_Add : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sekai\source\repos\ToDoApplication_SQL\ToDoApplication_SQL\ToDoData.mdf;Integrated Security=True";
        private TextBox addNewToDoText;
        private Button addToDo;
        private Button backButton;

        public DialogPanel_Add()
        {

            this.Width = 300;
            this.Height = 200;

            addNewToDoText = new TextBox();
            addNewToDoText.Width = 200;
            addNewToDoText.Top = 10;
            addNewToDoText.Left = 50;

            backButton = new Button();
            backButton.Text = "戻る";
            backButton.Top = 100;
            backButton.Left = 100;
            backButton.Parent = this;
            backButton.Click += new EventHandler(ClickBackButton);

            addToDo = new Button();
            addToDo.Text = "追加";
            addToDo.Top = 100;
            addToDo.Left = 200;
            addToDo.Parent = this;
            addToDo.Click += new EventHandler(ClickAddToDo);

        }

        private void ClickBackButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClickAddToDo(object sender, EventArgs e)
        {
            string str = addNewToDoText.Text;

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            try
            {
                string sqlstr = "INSERT INTO todotext VALUES(${str})";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //result.Close();
                con.Close();
            }
            var dialog = new DialogPanel_Add();
            this.Close();
        }

    }
}
