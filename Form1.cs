using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml.Linq;

namespace PWDSAVER
{

    public partial class Form1 : Form
    {
        string t = " ";
        DateTime DTN;

        public Form1()
        {
            InitializeComponent();
        }

        private void text_selectandcopy(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text != null) text.SelectAll();
            text.Copy();
        }

        private void loginadd(object sender, EventArgs e)
        {
            var data = new IniFile("data.ini");
            TextBox login = sender as TextBox;
            if (login != null)
            {
                InputBoxResult test = InputBox.Show("Пожалуйста, введите логин и нажмите 'ОК'",
                         "Введите логин",
                     "noname", 100, 0);
                if (test.ReturnCode == DialogResult.OK)
                    login.Text = test.Text;
                data.Write(login.Name, login.Text, "Logins");
            }

        }

        private void passwordadd(object sender, EventArgs e)
        {
            var data = new IniFile("data.ini");
            TextBox password = sender as TextBox;
            if (password != null)
            {
                InputBoxResult pass = InputBox.Show("Пожалуйста, введите пароль и нажмите 'OK'",
                    "Введите пароль",
                    "unknown", 100, 0);
                if (pass.ReturnCode == DialogResult.OK)
                    password.Text = pass.Text;
                data.Write(password.Name, password.Text, "Passwords");
            }
        }

        private void nameadd(object sender, EventArgs e)
        {
            var data = new IniFile("data.ini");
            Label name = sender as Label;
            if (name != null)
            {
                InputBoxResult names = InputBox.Show("Пожалуйста, введите имя и нажмите 'OK'",
                    "Введите имя",
                    "unnamed", 100, 0);
                if (names.ReturnCode == DialogResult.OK)
                    name.Text = names.Text;
                data.Write(name.Name, name.Text, "Names");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t == " ")
                t = ":";
            else
                t = " ";
            DTN = DateTime.Now;
            status.Text = DTN.Hour.ToString().PadLeft(2, '0') + t +
                DTN.Minute.ToString().PadLeft(2, '0') + t +
                    DTN.Second.ToString().PadLeft(2, '0');
            if (loader.Enabled == false)
            {
                Text = "Twinx";
            }
        }

        private void mouseover(object sender, EventArgs e)
        {
            hintbox.Text = "Один клик - копировать";
        }

        private void mouseoff(object sender, EventArgs e)
        {
            hintbox.Text = "";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void savesettings()
        {
            //Сохранение настроек приложения
            var settings = new IniFile("settings.ini");
            settings.Write("Top", Top.ToString(), "Settings");
            settings.Write("Left", Left.ToString(), "Settings");
            settings.Write("Program", Text, "Settings");
        }

        private void writedatatoini()
        {
            //Сохранение данных в ini файл
            var data = new IniFile("data.ini");
            //page 1-12 
            load.Value = 16;
            for (int i = 1; i <= 12; i++)
            {
                data.Write(tabPage1.Controls["name" + Convert.ToString(i)].Name, tabPage1.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage1.Controls["login" + Convert.ToString(i)].Name, tabPage1.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage1.Controls["password" + Convert.ToString(i)].Name, tabPage1.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            //page 13-24
            load.Value = 32;
            for (int i = 13; i <= 24; i++)
            {
                data.Write(tabPage2.Controls["name" + Convert.ToString(i)].Name, tabPage2.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage2.Controls["login" + Convert.ToString(i)].Name, tabPage2.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage2.Controls["password" + Convert.ToString(i)].Name, tabPage2.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            //page 25-36
            load.Value = 48;
            for (int i = 25; i <= 36; i++)
            {
                data.Write(tabPage3.Controls["name" + Convert.ToString(i)].Name, tabPage3.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage3.Controls["login" + Convert.ToString(i)].Name, tabPage3.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage3.Controls["password" + Convert.ToString(i)].Name, tabPage3.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            //page 37-48
            load.Value = 64;
            for (int i = 37; i <= 48; i++)
            {
                data.Write(tabPage4.Controls["name" + Convert.ToString(i)].Name, tabPage4.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage4.Controls["login" + Convert.ToString(i)].Name, tabPage4.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage4.Controls["password" + Convert.ToString(i)].Name, tabPage4.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            //page 49-60
            load.Value = 80;
            for (int i = 49; i <= 60; i++)
            {
                data.Write(tabPage5.Controls["name" + Convert.ToString(i)].Name, tabPage5.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage5.Controls["login" + Convert.ToString(i)].Name, tabPage5.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage5.Controls["password" + Convert.ToString(i)].Name, tabPage5.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            //page 61-72
            load.Value = 96;
            for (int i = 61; i <= 72; i++)
            {
                data.Write(tabPage6.Controls["name" + Convert.ToString(i)].Name, tabPage6.Controls["name" + Convert.ToString(i)].Text, "Names");
                data.Write(tabPage6.Controls["login" + Convert.ToString(i)].Name, tabPage6.Controls["login" + Convert.ToString(i)].Text, "Logins");
                data.Write(tabPage6.Controls["password" + Convert.ToString(i)].Name, tabPage6.Controls["password" + Convert.ToString(i)].Text, "Passwords");
            }
            load.Value = 100;
            loader.Enabled = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            //Сохранение настроек приложения и данных
            savesettings();
            writetoxml();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void trayicon_MouseClick(object sender, MouseEventArgs e)
        {
            //this.Show();
        }

        private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Загрузка настроек приложения
            if (File.Exists("settings.ini"))
            {
                var settings = new IniFile(@"settings.ini");
                Top = Convert.ToInt32(settings.Read("Top", "Settings"));
                Left = Convert.ToInt32(settings.Read("Left", "Settings"));
            }
            else
            {
                Top = 300;
                Left = 600;
            }

            //Загрузка данных
            if (File.Exists("data.xml"))
            {
                loadfromxml();
            }
            else
            {
                MessageBox.Show("Первый запуск приложения. Будут созданы файлы с настройками и данными.");
                savesettings();
                writetoxml();
            }


        }

        private void updatedata()
        {
            //load data
            var data = new IniFile(@"data.ini");
            load.Visible = true;
            load.Value = 16;
            for (int i = 1; i <= 12; i++)
            {
                tabPage1.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage1.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage1.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage1.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage1.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage1.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 32;
            for (int i = 13; i <= 24; i++)
            {
                tabPage2.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage2.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage2.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage2.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage2.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage2.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 48;
            for (int i = 25; i <= 36; i++)
            {
                tabPage3.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage3.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage3.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage3.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage3.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage3.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 64;
            for (int i = 37; i <= 48; i++)
            {
                tabPage4.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage4.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage4.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage4.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage4.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage4.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 80;
            for (int i = 49; i <= 60; i++)
            {
                tabPage5.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage5.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage5.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage5.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage5.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage5.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 96;
            for (int i = 61; i <= 72; i++)
            {
                tabPage6.Controls["name" + Convert.ToString(i)].Text = data.Read(tabPage6.Controls["name" + Convert.ToString(i)].Name, "Names");
                tabPage6.Controls["login" + Convert.ToString(i)].Text = data.Read(tabPage6.Controls["login" + Convert.ToString(i)].Name, "Logins");
                tabPage6.Controls["password" + Convert.ToString(i)].Text = data.Read(tabPage6.Controls["password" + Convert.ToString(i)].Name, "Passwords");
            }
            load.Value = 100;
            loader.Enabled = true;

        }

        private void writetoxml()
        {
            //Запись данных в xml файл
            XDocument xDoc = new XDocument();
            XElement xroot = new XElement("Database");

            //Создаем первый элемент
            for (int i = 1; i <= 12; i++)
            {
                xroot.Add(
                    new XElement("Account",
                        new XAttribute("name", tabPage1.Controls["name" + i].Text),
                        new XElement("login", tabPage1.Controls["login" + i].Text),
                        new XElement("password", tabPage1.Controls["password" + i].Text)
                    ));
            }

            for (int i = 13; i <= 24; i++)
            {
                xroot.Add(
                   new XElement("Account",
                       new XAttribute("name", tabPage2.Controls["name" + i].Text),
                       new XElement("login", tabPage2.Controls["login" + i].Text),
                       new XElement("password", tabPage2.Controls["password" + i].Text)
                   ));
            }

            for (int i = 25; i <= 36; i++)
            {
                xroot.Add(
                   new XElement("Account",
                       new XAttribute("name", tabPage3.Controls["name" + i].Text),
                       new XElement("login", tabPage3.Controls["login" + i].Text),
                       new XElement("password", tabPage3.Controls["password" + i].Text)
                   ));
            }

            for (int i = 37; i <= 48; i++)
            {
                xroot.Add(
                  new XElement("Account",
                      new XAttribute("name", tabPage4.Controls["name" + i].Text),
                      new XElement("login", tabPage4.Controls["login" + i].Text),
                      new XElement("password", tabPage4.Controls["password" + i].Text)
                  ));
            }

            for (int i = 49; i <= 60; i++)
            {
                xroot.Add(
                  new XElement("Account",
                      new XAttribute("name", tabPage5.Controls["name" + i].Text),
                      new XElement("login", tabPage5.Controls["login" + i].Text),
                      new XElement("password", tabPage5.Controls["password" + i].Text)
                  ));
            }

            for (int i = 61; i <= 72; i++)
            {
                xroot.Add(
                    new XElement("Account",
                        new XAttribute("name", tabPage6.Controls["name" + i].Text),
                        new XElement("login", tabPage6.Controls["login" + i].Text),
                        new XElement("password", tabPage6.Controls["password" + i].Text)
                    ));
            }
            xroot.Add(xroot);
            xDoc.Add(xroot);
            xDoc.Save("data.xml");
        }

        private void loadfromxml()
        {
            //Загрузка данных из xml файла
            XDocument xDoc = XDocument.Load("data.xml");            
            try
            {
                int i = 1;                
                foreach (XElement account in xDoc.Element("Database").Elements("Account"))
                {                    
                        XAttribute name = account.Attribute("name");
                        XElement login = account.Element("login");
                        XElement password = account.Element("password");

                    load.Visible = true;
                    load.Value = 10;
                      if (i > 0 && i <= 12)
                        {
                            tabPage1.Controls["name" + i].Text = name.Value;
                            tabPage1.Controls["login" + i].Text = login.Value;
                            tabPage1.Controls["password" + i].Text = password.Value;
                        }
                    load.Value = 25;
                      if (i > 12 && i <= 24)
                        {
                            tabPage2.Controls["name" + i].Text = name.Value;
                            tabPage2.Controls["login" + i].Text = login.Value;
                            tabPage2.Controls["password" + i].Text = password.Value;
                        }
                    load.Value = 35;
                      if (i > 24 && i <= 36)
                        {
                            tabPage3.Controls["name" + i].Text = name.Value;
                            tabPage3.Controls["login" + i].Text = login.Value;
                            tabPage3.Controls["password" + i].Text = password.Value;
                        }
                    load.Value = 50;
                      if (i > 36 && i <= 48)
                        {
                            tabPage4.Controls["name" + i].Text = name.Value;
                            tabPage4.Controls["login" + i].Text = login.Value;
                            tabPage4.Controls["password" + i].Text = password.Value;
                        }
                    load.Value = 60;
                      if (i > 48 && i <= 60)
                        {
                            tabPage5.Controls["name" + i].Text = name.Value;
                            tabPage5.Controls["login" + i].Text = login.Value;
                            tabPage5.Controls["password" + i].Text = password.Value;
                        }
                    load.Value = 75;
                      if (i > 60 && i <= 72)
                        {
                            tabPage6.Controls["name" + i].Text = name.Value;
                            tabPage6.Controls["login" + i].Text = login.Value;
                            tabPage6.Controls["password" + i].Text = password.Value;
                        }
                    i++;
                    load.Value = 100;
                    loader.Enabled = true;
                }
            }                      
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
          //  updatedata();
            loadfromxml();
        }

        private void loader_Tick(object sender, EventArgs e)
        {

            if (load.Value == load.Maximum)
            {
                Text = "Twinx [данные загружены]";
                load.Visible = false;
                loader.Enabled = false;
                
            }
        }

        private void trayicon_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form2 prop = new Form2();
          //  prop.Show(this);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AboutFrm about = new AboutFrm();
            about.Show(this);
        }

        private void автозагразкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Автозагразука приложения
        }

        private void сохранятьВINIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сохранение данных в файл INI
        }

        private void сохранятьВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сохранение данных в файл XML
        }
    }
}
