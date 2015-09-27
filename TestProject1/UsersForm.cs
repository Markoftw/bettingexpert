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

namespace TestProject1
{
    public partial class UsersForm : Form
    {
        string path = "seznam.txt";

        public UsersForm()
        {
            InitializeComponent();
            updateList();
        }

        private void updateList()
        {
            if (File.Exists(path))
            {
                StreamReader tr = new StreamReader(path);
                string prazno = "";
                while((prazno = tr.ReadLine()) != null)
                {
                    usersList.Items.Add(prazno);
                }
                tr.Close();
            }
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddUserForm userid = new AddUserForm();
            if(userid.ShowDialog() == DialogResult.OK)
            {
                usersList.Items.Add(userid.idBox.Text);
            }
        }

        private void remUser_Click(object sender, EventArgs e)
        {
            int tmp = usersList.SelectedIndex;
            if (tmp < 0)
            {
                return;
            }
            usersList.Items.RemoveAt(tmp);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StreamWriter tw = new StreamWriter(path, false);
            for(int i = 0; i < usersList.Items.Count; i++)
            {
                tw.WriteLine(usersList.Items[i]);
            }
            tw.Close();

            DialogResult = DialogResult.OK;
        }

    }
}
