using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PWDSAVER
{
    public partial class Form2 : Form
    {
        string autorun;
        const string name = "PWDSAVER";
        public bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var settings = new IniFile(@"settings.ini");
            autorun = settings.Read("Autorun", "Settings");
            if (autorun == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var settings = new IniFile(@"settings.ini");

            this.Close();
        }

        private void blend_bar_Scroll(object sender, EventArgs e)
        {
       
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var settings = new IniFile(@"settings.ini");

            if (checkBox1.Checked != false)
            {
                SetAutorunValue(true);
                checkBox1.Checked = true;
                settings.Write("Autorun", (checkBox1.Checked).ToString(), "Settings");
            }
            else
            {
                SetAutorunValue(false);
                checkBox1.Checked = false;
                settings.Write("Autorun", (checkBox1.Checked).ToString(), "Settings");
            }
        }
    }
}
