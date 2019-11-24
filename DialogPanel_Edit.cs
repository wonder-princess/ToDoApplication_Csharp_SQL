using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApplication_SQL
{
    class DialogPanel_Edit : Form
    {
        private TextBox addNewToDoText;
        private Button deleteButton;
        private Button backButton;
        private Button editToDoButton;

        public DialogPanel_Edit(string editText)
        {

            this.Width = 300;
            this.Height = 200;

            addNewToDoText = new TextBox();
            addNewToDoText.Width = 200;
            addNewToDoText.Top = 10;
            addNewToDoText.Left = 50;
            addNewToDoText.Text = editText;

            deleteButton = new Button();
            deleteButton.Text = "削除";
            deleteButton.Top = 100;
            deleteButton.Left = 200;
            deleteButton.Parent = this;
            deleteButton.Click += new EventHandler(ClickDeleteButton);

            backButton = new Button();
            backButton.Text = "戻る";
            backButton.Top = 100;
            backButton.Left = 100;
            backButton.Parent = this;
            backButton.Click += new EventHandler(ClickBackButton);

            editToDoButton = new Button();
            editToDoButton.Text = "編集";
            editToDoButton.Top = 100;
            editToDoButton.Left = 200;
            editToDoButton.Parent = this;
            editToDoButton.Click += new EventHandler(ClickEditToDoButton);

        }
        private void ClickDeleteButton(object sender, EventArgs e)
        {
             string str = addNewToDoText.Text;
            /*
             * SQL　DELETE処理
             */
            var dialog = new DialogPanel_Add();
            this.Close();
        }

        private void ClickBackButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClickEditToDoButton(object sender, EventArgs e)
        {
            string str = addNewToDoText.Text;
            /*
             * SQL　UPDATE処理
             */
            this.Close();
        }

    }
}
