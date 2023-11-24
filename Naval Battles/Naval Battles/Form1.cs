using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Battles
{
    public partial class Form1 : Form
    {


        // specified ship
        class SelectedShip {

            private Button o;
            
            public SelectedShip(Button o)
            {
                this.o = o;
            }

            public Button getButton()
            {
                return o;
            }

            public void setButton(Button o)
            {
                this.o = o;
            }


            }


        // selected object
        SelectedShip selectedShip;

        // state to replace images on button clicks
        private int button1State = 0;
        private int button2State = 0;
        private int button3State = 0;
        private int button4State = 0;

        // number of space for each ship
        private int button2Space = 2;
        private int button3Space = 3;
        private int button4Space = 4;
        private int button5Space = 5;

        // button has been placed
        private bool isButton2Placed = false;
        private bool isButton3Placed = false;
        private bool isButton4Placed = false;
        private bool isButton5Placed = false;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.getUserShips().Clear();
            selectedShip = new SelectedShip(new Button());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resizeButton(sender);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void shipEnterTable(object sender)
        {

        }


        private void resizeButton(object sender)
        {
            if (sender is Button) {
                Button b = (Button)sender;

                if (getIsPlaced(b)) return;
                

                int oldWidth = b.Width;
                int oldHeight = b.Height;
                b.Width = oldHeight;
                b.Height = oldWidth;

                selectedShip.setButton(b);

                switch (b.Name)
                {
                    case "button2":

                        if (button1State == 0)
                        {
                            button1State = 1;
                            button2.BackgroundImage = Image.FromFile(@"ships_transparent_1 - rotate.png");
                            button2.Tag = "rotated";
                        }
                        else
                        {
                            button1State = 0;
                            button2.BackgroundImage = Image.FromFile(@"ships_transparent_1.png");
                            button2.Tag = "";
                        }
                        break;

                    case "button5":

                        if (button2State == 0)
                        {
                            button2State = 1;
                            button5.BackgroundImage = Image.FromFile(@"ships_transparent_2 - rotate.png");
                            button5.Tag = "rotated";
                        }
                        else
                        {
                            button2State = 0;
                            button5.BackgroundImage = Image.FromFile(@"ships_transparent_2.png");
                            button5.Tag = "";
                        }
                        break;

                    case "button3":

                        if (button3State == 0)
                        {
                            button3State = 1;
                            button3.BackgroundImage = Image.FromFile(@"ships_transparent_3 - rotate.png");
                            button3.Tag = "rotated";
                        }
                        else
                        {
                            button3State = 0;
                            button3.BackgroundImage = Image.FromFile(@"ships_transparent_3.png");
                            button3.Tag = "";
                        }
                        break;

                    case "button4":

                        if (button4State == 0)
                        {
                            button4State = 1;
                            button4.BackgroundImage = Image.FromFile(@"ships_transparent4 - rotate.png");
                            button4.Tag = "rotated";
                        }
                        else
                        {
                            button4State = 0;
                            button4.BackgroundImage = Image.FromFile(@"ships_transparent4.png");
                            button4.Tag = "";
                        }
                        break;
                }


            }
        }

        private int getShipSpaceLegit(object sender)
        {
            if (sender is Button)
            {
                Button a = (Button)sender;
                switch (a.Name)
                {
                    case "button2":
                        return button2Space;

                    case "button3":
                        return button3Space;

                    case "button4":
                        return button4Space;
                    case "button5":
                        return button5Space;

                }
            }
            return -1;
        }

        private int getShipSpace(object sender)
        {
            if (sender is Button)
            {
                Button a = (Button)sender;
                switch (a.Name)
                {
                    case "button2":
                        if (a.Tag == "rotated") { return button2Space + 10; }
                        return button2Space;

                    case "button3":
                        if (a.Tag == "rotated") { return button3Space + 20; }
                        return button3Space;

                    case "button4":
                        if (a.Tag == "rotated") { return button4Space + 30; }
                        return button4Space;
                    case "button5":
                        if (a.Tag == "rotated") { return button5Space + 40; }
                        return button5Space;

                }
            }
            return -1;
        }


        private bool getIsPlaced(object sender)
        {
            if(sender is Button)
            {
                Button a = (Button)sender;
                if(a.Name == "button2")
                {
                    return isButton2Placed;
                }else if(a.Name == "button3")
                {
                    return isButton3Placed;
                } else if(a.Name == "button4")
                {
                    return isButton4Placed;
                } else if(a.Name == "button5")
                {
                    return isButton5Placed;
                }
            }
            return false;
        }

        private void setIsPlaced(object sender)
        {
            if (sender is Button)
            {
                Button a = (Button)sender;
                if (a.Name == "button2")
                {
                    isButton2Placed = true;
                }
                else if (a.Name == "button3")
                {
                    isButton3Placed = true;
                }
                else if (a.Name == "button4")
                {
                    isButton4Placed = true;
                }
                else if (a.Name == "button5")
                {
                    isButton5Placed = true;
                    }
                }
            }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }


        private void button116_Click(object sender, EventArgs e)
        {
            Button ship = null;
            if(selectedShip.getButton() != null) ship = (Button)selectedShip.getButton();
            if (ship == null) return;
            int put = 0;
            foreach (Control b in Controls)
            {
                if (b is Button)
                {

                    if (b.Name != "submarine" && b.Name != "button2" && b.Name != "button3" && b.Name != "button4"
                        && b.Name != "aircraft")
                    {

                        if (sender.Equals(b))
                        {

                            // check for limitations
                            put = int.Parse(b.Name.Replace("button", ""));
                            int limity = put % 10;
                            int limitx = put / 10;
                            bool position = true;

                            if (ship.Tag == "rotated")
                            {                            
                                if (limitx > 11 - getShipSpaceLegit(ship))
                                {
                                    MessageBox.Show("You cant place that here!");
                                    position = false;
                                }
                            }
                            else
                            {
                                if (limity > 10 - getShipSpaceLegit(ship))
                                {
                                    MessageBox.Show("You cant place that here!");
                                    position = false;

                                }
                            }



                            if (position)
                            {
                                bool position2 = true;


                                foreach (Control d in Controls)
                                {
                                    if (d is Button)
                                    {

                                        if (ship.Tag != "rotated")
                                        {
                                            for (int i = put; i < put + getShipSpace(ship); i++)
                                            {

                                                if (d.Name == "button" + i)
                                                {
                                                    if (d.Visible == false)
                                                    {
                                                        position2 = false;
                                                    }
                

                                                }

                                            }

                                        }
                                        else
                                        {
                                            for (int i = put; i < put + getShipSpace(ship); i += 10)
                                            {
                                                if (d.Name == "button" + i)
                                                {
                                                    if (d.Visible == false)
                                                    {
                                                        position2 = false;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }

                                if (position2)
                                {
                                   
                                 if(!getIsPlaced(ship)) ship.Location = b.Location;
                                    setIsPlaced(ship);
                                    selectedShip.setButton(null);

                                    List<int> positions = new List<int>();
                                    bool isRotated = false;
                                    
                                    
                                    if(ship.Tag == "rotated")
                                    {
                                        isRotated = true;
                                    }
                                    
                                    foreach (Control d in Controls)
                                    {
                                        if (d is Button)
                                        {

                                            if (ship.Tag != "rotated")
                                            {
                                                for (int i = put; i < put + getShipSpace(ship); i++)
                                                {

                                                    if (d.Name == "button" + i)
                                                    {
                                                        if (d.Visible == true)
                                                        {
                                                            d.Visible = false;
                                                            positions.Add(i);
                                                        }

                                                    }

                                                }

                                            }
                                            else
                                            {
                                                for (int i = put; i < put + getShipSpace(ship); i += 10)
                                                {
                                                    if (d.Name == "button" + i)
                                                    {
                                                        if (d.Visible == true)
                                                        {
                                                            d.Visible = false;
                                                            positions.Add(i);
                                                        }

                                                    }

                                                }
                                            }
                                        }
                                    }
                                    // Creating custom object userShip to keep in memory the ships locations and initialize them in Game.cs
                                    // Saving object into UserShip Set
                                    UserShip userShip = new UserShip(ship.Name, put, positions, isRotated, ship.Width, ship.Height);
                                    Program.getUserShips().Add(userShip);
  

                                }
                                else
                                {
                                    MessageBox.Show("You cant place that here!");
                                }
                            }
                        }
                    }
                }
            }
        }
    
                           
        private void button2_Click_1(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            resizeButton(sender);
        }

        private void Reset_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Form1().Show();
        }

        private bool isReady()
        {
            
            if(isButton2Placed && isButton3Placed && isButton4Placed && isButton5Placed)
            {
                return true;
            }

            return false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(!(isReady())) {
                MessageBox.Show("Put all the ships before continuing!");
            }
            else
            {
                MessageBox.Show("Good Luck!");
                this.Hide();
                new Game().Show();
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
