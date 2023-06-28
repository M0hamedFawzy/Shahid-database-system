using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using WindowsFormsApp1;


namespace Shahid
{
    public partial class Main_Form : Form
    {
        private readonly Timer _timer = new Timer();
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private Button currentBtn ;
       
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(75, 144, 31);
            public static Color color2 = Color.FromArgb(231, 75, 75);
            public static Color color3 = Color.FromArgb(181, 231, 75);
            public static Color color4 = Color.FromArgb(231, 75, 100);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(31, 209, 5);
            public static Color color7 = Color.FromArgb(31, 109, 90);
        }
        public Main_Form()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 39);
            menu_panel.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();

        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            this.KeyDown += Main_Form_KeyDown;
        }
        private void Main_Form_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode != button8.KeyCode)
            {
                // Invoke the DisableButton function
                DisableButton();
            }*/
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // get the current time
            DateTime currentTime = DateTime.Now;
            // format the time as a string
            string timeString = currentTime.ToString("h:mm:ss tt");
            // format the date as a string
            string dateString = currentTime.ToString("ddd, MMM d yyyy");
            // update the label control with the time and date strings
            time_label.Text = $"     {timeString}\n{dateString}";
        }
        
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                
                DisableButton((Button)senderBtn);
                //Button
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = color;
                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = Color.WhiteSmoke;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }




        private void DisableButton(Button b)
        {
            if (b != null)
            {
                b.BackColor = Color.FromArgb(2, 10, 18);
                b.ForeColor = Color.WhiteSmoke;
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.TextImageRelation = TextImageRelation.ImageBeforeText;
                b.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void DisableButton2()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(2, 10, 18);
                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            home_panel.Controls.Add(childForm);
            home_panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reset()
        {
            DisableButton2();
            leftBorderBtn.Visible = false;
        }

        


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        

        

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void title_panel_2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximize_button_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void home_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void time_label_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new form3());
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ADD_PLAN());
            DisableButton(button8);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Form_admin_report());
            DisableButton(button9);
            DisableButton(button8);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new search_by_title());
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button8);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new Find_Actor());
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button8);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new film_actors());
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button8);
            DisableButton(button14);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new Form_user_report());
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button8);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            //ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new admin_introduction());
            DisableButton(button8);
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            currentBtn = new Button();
            //ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new user_introduction());
            DisableButton(button8);
            DisableButton(button9);
            DisableButton(button10);
            DisableButton(button11);
            DisableButton(button12);
            DisableButton(button13);
            DisableButton(button14);
        }
    }
}
