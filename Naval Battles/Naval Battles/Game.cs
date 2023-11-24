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
    public partial class Game : Form
    {
        Random random = new Random();
        Random random2 = new Random();
        private int duration;
        private int tries;


        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            init();
            // start db
            Data.init();

            initializeUserShipPositions();
            generateEnemy("button2", 2);
            generateEnemy("button3", 3);
            generateEnemy("button4", 4);
            generateEnemy("button5", 5);

            foreach (UserShip user in Program.getUserShips())
            {
                List<int> list = user.getPositions();

                foreach (int pos in list)
                {
                    foreach (Control a in Controls)
                    {
                        if (a is Button && a.Name.Equals("button" + pos))
                        {
                            a.Tag = user.getName();

                        }
                    }
                }
            }

            foreach (EnemyShip ship in Program.getEnemyShips())
            {
                foreach (int a in ship.getPositions())
                {
                    foreach (Control b in Controls)
                    {
                        if ((b is Button && b.Name.Equals("enemybutton" + a)))
                        {
                            Button c = (Button)b;

                            c.BackColor = Color.Green;
                        }
                    }
                }
            }

        }

        private void init()
        {
            Program.getPressedButtons().Clear();
            Program.getPressedButtonsEnemy().Clear();
            Program.getEnemyShips().Clear();
            duration = 0;
            tries = 0;



        }

        private void initializeUserShipPositions()
        {

            // Loop through all saved ships of the user
            foreach (UserShip userShips in Program.getUserShips())
            {

                // Attributes of all ships each
                int startingPosition = userShips.getStartPosition();
                List<int> positions = userShips.getPositions();
                bool rotated = userShips.getRotated();

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(getImageLocation(userShips, true));
                pictureBox.Visible = true;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(userShips.getWidth(), userShips.getHeight());



                foreach (Control a in this.Controls)
                {

                    foreach (int pos in positions)
                    {

                        if (a is Button && a.Name.Equals("button" + pos))
                        {

                            // button pisw apo  karavi
                            a.Visible = false;
                        }
                    }

                    if (a is Button && a.Name.Equals("button" + startingPosition))
                    {
                        Button button = (Button)a;
                        button.Visible = false;
                        pictureBox.Location = button.Location;

                        this.Controls.Add(pictureBox);
                        pictureBox.BringToFront();
                    }

                }

            }

        }

        private string getImageLocation(UserShip userShip, bool value)
        {
            if (value)
            {
                if (userShip.getName().Equals("button2"))
                {
                    if (userShip.getRotated())
                    {
                        return @"ships_transparent_1 - rotate.png";
                    }
                    else
                    {
                        return @"ships_transparent_1.png";
                    }
                }
                else if (userShip.getName().Equals("button5"))
                {
                    if (userShip.getRotated())
                    {
                        return @"ships_transparent_2 - rotate.png";
                    }
                    else
                    {
                        return @"ships_transparent_2.png";
                    }
                }
                else if (userShip.getName().Equals("button4"))
                {
                    if (userShip.getRotated())
                    {
                        return @"ships_transparent4 - rotate.png";
                    }
                    else
                    {
                        return @"ships_transparent4.png";
                    }
                }
                else if (userShip.getName().Equals("button3"))
                {
                    if (userShip.getRotated())
                    {
                        return @"ships_transparent_3 - rotate.png";
                    }
                    else
                    {
                        return @"ships_transparent_3.png";

                    }
                }

            }
            else
            {
                if (userShip.getName().Equals("button2"))
                {

                    return @"ships_transparent_1.png";

                }
                else if (userShip.getName().Equals("button5"))
                {

                    return @"ships_transparent_2.png";

                }
                else if (userShip.getName().Equals("button4"))
                {


                    return @"ships_transparent4.png";

                }
                else if (userShip.getName().Equals("button3"))
                {


                    return @"ships_transparent_3.png";
                }
            }

            return @"";
        }



        private void generateEnemy(string name, int length)
        {
            List<int> list = new List<int>();
            EnemyShip enemyShip = new EnemyShip(name, length, list);
            int k = 0;
            int rotate = random.Next(2);
            bool case0tf = true;
            switch (rotate)
            {

                // Rotated
                case 0:
                    int randomStartPos = 0;
                    do
                    {
                        case0tf = true;
                        randomStartPos = random.Next(10, ((11 - length) * 10 + 9) + 1);

                        for (int i = randomStartPos; i < randomStartPos + (length * 10); i += 10)
                        {
                            foreach (Control buttons in Controls)
                            {
                                if (buttons is Button && buttons.Name.Equals("enemybutton" + i))
                                {
                                    if (buttons.Tag != null) { case0tf = false; }

                                }
                            }
                        }
                    } while (case0tf == false);

                    for (int i = randomStartPos; i < randomStartPos + (length * 10); i += 10)
                    {
                        foreach (Control buttons in Controls)
                        {
                            if (buttons is Button && buttons.Name.Equals("enemybutton" + i))
                            {
                                buttons.Tag = name;
                                list.Add(i);
                            }
                        }
                    }
                    Program.getEnemyShips().Add(enemyShip);
                    break;

                case 1:

                    int randomStartPos2 = 0;
                    do
                    {
                        case0tf = true;
                        do
                        {

                            randomStartPos2 = random.Next(10, 110);


                        } while (randomStartPos2 % 10 > (10 - length));

                        for (int i = randomStartPos2; i < randomStartPos2 + length; i++)
                        {
                            foreach (Control buttons in Controls)
                            {
                                if (buttons is Button && buttons.Name.Equals("enemybutton" + i))
                                {
                                    if (buttons.Tag != null) { case0tf = false; }

                                }

                            }
                        }
                    } while (case0tf == false);

                    for (int i = randomStartPos2; i < randomStartPos2 + length; i++)
                    {
                        foreach (Control buttons in Controls)
                        {
                            if (buttons is Button && buttons.Name.Equals("enemybutton" + (i)))
                            {

                                buttons.Tag = name;
                                list.Add(i);

                            }

                        }
                    }


                    Program.getEnemyShips().Add(enemyShip);
                    break;




            }

        }



        // Find UserShip via name
        private UserShip findUserShip(string name)
        {
            foreach (UserShip ships in Program.getUserShips())
            {
                if (ships.getName().Equals(name))
                {
                    return ships;
                }
            }
            return null;
        }

        // Find winner of game
        private void findWinner()
        {

        }
        int countertoucounter = 0;
        int counter10 = 0;//lenght gia kathe karavi
        int counter11 = 0;
        int counter12 = 0;
        int counter13 = 0;
        private void runCPU()
        {
            int pos;
            do
            {
                pos = random2.Next(10, 110);
            } while (Program.getPressedButtonsEnemy().Contains(pos));
            Program.getPressedButtonsEnemy().Add(pos);
            foreach (Control a in Controls)
            {
                if (a is Button && a.Name.Equals("button" + pos))
                {
                    Button cast = (Button)a;
                    cast.Visible = true;
                    if (cast.Tag != null)
                    {
                        cast.Font = new Font(cast.Font.FontFamily, 25);
                        cast.ForeColor = Color.Red;
                        cast.Text = "X";
                        cast.BringToFront();
                        if (cast.Tag == "button2")
                        {
                            counter10++; if (counter10 == 2)
                            {
                                countertoucounter++;
                                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox10.Image = Image.FromFile(getImageLocation(findUserShip("button2"), false));

                            }
                        }
                        if (cast.Tag == "button3")
                        {
                            counter11++; if (counter11 == 3)
                            {
                                countertoucounter++;
                                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox10.Image = Image.FromFile(getImageLocation(findUserShip("button3"), false));

                            }
                        }
                        if (cast.Tag == "button4")
                        {
                            counter12++; if (counter12 == 4)
                            {
                                countertoucounter++;
                                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox10.Image = Image.FromFile(getImageLocation(findUserShip("button4"), false));

                            }
                        }
                        if (cast.Tag == "button5")
                        {
                            counter13++; if (counter13 == 5)
                            {
                                countertoucounter++;
                                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox10.Image = Image.FromFile(getImageLocation(findUserShip("button5"), false));

                            }
                        }
                        if (countertoucounter == 4)
                        {

                            // KERDIZEI O YPOLOGISTHS

                            Data.saveData(false, duration);
                            this.Hide();
                            RestartMenu rm = new RestartMenu();
                            rm.label1.Text = "Λυπούμαστε Έχασες!";
                            rm.label2.Text = "Duration: " + duration + " (seconds)";
                            rm.label5.Text = "Tries: " + tries;
                            rm.label3.Text = "Wins: " + Data.getWins();
                            rm.label4.Text = "Loses: " + Data.getLoses();
                            rm.Show();

                            


                        }



                        break;
                    }

                    cast.Font = new Font(cast.Font.FontFamily, 30);
                    cast.ForeColor = Color.Green;
                    cast.Text = "-";
                    cast.BringToFront();
                    break;
                }
            }
        }

        private void checkIfEnemyShipFound(Button button)
        {
            if (button == null || button.Name == null || button.Tag == null) return;

            string name = button.Tag.ToString();

            if (name == null) return;

            EnemyShip enemy = null;
            // Find specific ship by button Tag
            foreach (EnemyShip enemyShip in Program.getEnemyShips())
            {
                if (enemyShip.getName().Equals(name))
                {
                    enemy = enemyShip;
                }
            }

            if (enemy == null) return;
            List<int> positionsList = enemy.getPositions();
            int count = 0;
            foreach (int pos in positionsList)
            {
                if (Program.getPressedButtons().Contains(pos))
                {
                    count++;

                    if (count == enemy.getLength())
                    {
                        pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox11.Image = Image.FromFile(getImageLocation(findUserShip(enemy.getName()), false));

                       /* if (Program.getPressedButtons().ToArray().Length >= 14)
                        {
                            Hide();
                            new RestartMenu().Show();
                        } */

                        break;

                    }



                }
            }

        } 
        int countertoucounter2 = 0;
        int counter20 = 0;//lenght gia kathe karavi
        int counter21 = 0;
        int counter22 = 0;
        int counter23 = 0;
        private void enemybutton98_Click(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button button = (Button)sender;
                foreach (Control a in Controls)
                {
                    if (a is Button && a.Name.StartsWith("enemybutton") && a.Equals(button))
                    {
                        int num = int.Parse(button.Name.Replace("enemybutton", ""));

                        if (Program.getPressedButtons().Contains(num)) break;

                        runCPU();
                        Program.getPressedButtons().Add(num);
                        checkIfEnemyShipFound(button);
                        tries++;

                        if (button.Tag == null)
                        {
                            button.Font = new Font(button.Font.FontFamily, 30);
                            button.ForeColor = Color.Green;
                            button.Text = "-";
                            break;

                        }
                        else
                        {

                            button.Font = new Font(button.Font.FontFamily, 25);
                            button.ForeColor = Color.Red;
                            button.Text = "X";
                            if(button.Tag == "button2")  { counter20++; if (counter20 == 2) { countertoucounter2++; } }
                            if (button.Tag == "button3") { counter21++; if (counter21 == 3) { countertoucounter2++; } }
                            if (button.Tag == "button4") { counter22++; if (counter22 == 4) { countertoucounter2++; } }
                            if (button.Tag == "button5") { counter23++; if (counter23 == 5) { countertoucounter2++; } }
                            if (countertoucounter2 == 4)
                            {
                                // KERDIZEI O PAIKTHS
                                Data.saveData(true, duration);
                                this.Hide();
                                RestartMenu rm = new RestartMenu();
                                rm.label1.Text = "Μπράβο Νίκησες!";
                                rm.label2.Text = "Duration: " + duration + " (seconds)";
                                rm.label5.Text = "Tries: " + tries;
                                rm.label3.Text = "Wins: " + Data.getWins();
                                rm.label4.Text = "Loses: " + Data.getLoses();
                                rm.Show();

                            }

                            break;

                        }


                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration++;
        }
    }
}
