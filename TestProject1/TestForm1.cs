using TestProject1.Classes;
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
using System.Net;
using System.Net.Mail;

namespace TestProject1
{
    public partial class TestForm1 : Form
    {
        //private string[] allUsers = new string[] { "21837", "21838" };

        List<string> vsiUseri = null;
        string path = "seznam.txt";

        public TestForm1()
        {
            InitializeComponent();
            vsiUseri = new List<string>();
            readUsers();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zazeni()
        {
            displayList.Items.Clear();
            for (int j = 0; j < vsiUseri.Count; j++)
            {
                string usr = vsiUseri[j];
                Connections vrni = new Connections(usr);
                //MessageBox.Show(vrni.Shrani);
                //listview = hrani podatke
                object[] tmp = vrni.Seznam;
                ListViewItem logs = new ListViewItem(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                if (tmp == null)
                {
                    logs.SubItems.Add("Error: No results found for user ID " + usr);
                    logList.Items.Add(logs);
                    logList.Items[logList.Items.Count - 1].EnsureVisible();
                }
                else
                {
                    List<int> tipid = (List<int>)tmp[0];
                    List<string> users = (List<string>)tmp[1];
                    List<string> links = (List<string>)tmp[2];
                    for (int i = 0; i < tipid.Count; i++)
                    {
                        ListViewItem newtmp = new ListViewItem(tipid[i].ToString());
                        newtmp.SubItems.Add(users[i].ToString());
                        newtmp.SubItems.Add(links[i].ToString());
                        displayList.Items.Add(newtmp);
                    }
                    logs.SubItems.Add("List for user "+ usr +" has been updated!");
                    logList.Items.Add(logs);
                    logList.Items[logList.Items.Count - 1].EnsureVisible();
                }
            }
        }

        private void startRefresh()
        {
            zazeni();
            timerRefresh.Interval = int.Parse(timeSeconds.Text) * 1000;
            timerRefresh.Start();
        }
        private void stopRefresh()
        {
            timerRefresh.Stop();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            startRefresh();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startRefresh();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            zazeni();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopRefresh();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            stopRefresh();
            startRefresh();
        }

        private void updateNowButton_Click(object sender, EventArgs e)
        {
            zazeni();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopRefresh();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm userlist = new UsersForm();
            if (userlist.ShowDialog() == DialogResult.OK)
            {
                vsiUseri.Clear();
                for(int i = 0; i < userlist.usersList.Items.Count; i++)
                {
                    vsiUseri.Add(userlist.usersList.Items[i].ToString());
                }
            }
        }

        private void readUsers()
        {
            vsiUseri.Clear();
            if (File.Exists(path))
            {
                StreamReader tr = new StreamReader(path);
                string prazno = "";
                while ((prazno = tr.ReadLine()) != null)
                {
                    vsiUseri.Add(prazno);
                }
                tr.Close();
            }
        }
    }
}
