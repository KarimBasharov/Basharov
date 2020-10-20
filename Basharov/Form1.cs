using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basharov
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Label lbl;
        Button btn = new Button();
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //button
            tn.Nodes.Add(new TreeNode("Sint-Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Raadionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("Pildikast-PictureBox"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));
            tree.Nodes.Add(tn);
            MenuItem menuitem1 = new MenuItem("File");
            this.Controls.Add(tree);

        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Sint-Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendaja";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);



                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;


                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Raadionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);

                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                //text = File.ReadAllText(@"C:\Users\karim\source\repos\Basharov\Dio.txt");
                //txt_box.Text = File.ReadAllText(@"C:\Users\karim\source\repos\Basharov\Dio.txt");
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "Wry";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 100;
                txt_box.Height = 100;
                using (var sr = new StreamReader(@"C:\Users\karim\source\repos\Basharov\Dio.txt"))
                {
                    var str = sr.ReadToEnd();
                    txt_box.Text = str.ToString();
                }
                this.Controls.Add(txt_box);


            }
            else if (e.Node.Text == "Pildikast-PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("mops.gif");
                picture.Location = new Point(900, 200);
                picture.Size = new Size(450, 450);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(500, 500);
                tabControl.Size = new Size(200, 200);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                this.Controls.Add(tabControl);
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                tabControl.SelectedIndex = 0;
                page1.BackColor = Color.FromArgb(255, 232, 232);
                page2.BackColor = Color.FromArgb(255, 221, 240);
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige listsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }

            }
            else if (e.Node.Text == "ListBox")
            {
                string[] Colors_nimetused = new string[] { "Sinine", "Kollane", "Roheline", "Punane" };
                lbox = new ListBox();
                foreach (var item in Colors_nimetused)
                {
                    lbox.Items.Add(item);
                }
                lbox.Location = new Point(150, 300);
                lbox.Width = 50;
                lbox.Height = Colors_nimetused.Length * 16;
                lbox.SelectedValueChanged += Lbox_SelectedValueChanged;
                this.Controls.Add(lbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("..//..//cdproject.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(600, 200);
                dgv.Width = 250;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "CD";
                dgv.DataSource = dataSet;
                this.Controls.Add(dgv);


            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuitem1 = new MenuItem("File");
                menuitem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
                menuitem1.MenuItems.Add("Restart", new EventHandler(menuitem1_Restart));
                menu.MenuItems.Add(menuitem1);
                this.Menu = menu;
            }
        }
        private void menuitem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindal?","Küsimus",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private void menuitem1_Restart(object sender, EventArgs e)
        {
             Application.Restart();
        }
        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }
        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                this.Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }
        private void Lbox_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectt = lbox.SelectedItem;
            if (selectt == "Sinine")
            {
                lbox.BackColor = Color.Blue;
            }
            if (selectt == "Roheline")
            {
                lbox.BackColor = Color.Green;
            }
            if (selectt == "Kollane")
            {
                lbox.BackColor = Color.Yellow;
            }
            if (selectt == "Punane")
            {
                lbox.BackColor = Color.Red;
            }
            if (selectt == "Pruun")
            {
                lbox.BackColor = Color.Brown;
            }
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.Wheat;
            }
            else
            {

                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.Wheat;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}
