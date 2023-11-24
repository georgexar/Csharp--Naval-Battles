using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naval_Battles
{
    internal static class Program
    {

        private static HashSet<UserShip> USERSHIPS;
        private static HashSet<EnemyShip> ENEMYSHIPS;
        private static List<int> PRESSED_BUTTONS;
        private static List<int> PRESSED_BUTTONS_ENEMY;
        public static string getUsername = "";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initTasks();

            Application.Run(new Trailer());

        }

        private static void initTasks()
        {
            USERSHIPS = new HashSet<UserShip>();
            ENEMYSHIPS = new HashSet<EnemyShip>();
            PRESSED_BUTTONS = new List<int>();
            PRESSED_BUTTONS_ENEMY = new List<int>();
            
    }

        public static HashSet<UserShip> getUserShips() { return USERSHIPS; }
        public static HashSet<EnemyShip> getEnemyShips() { return ENEMYSHIPS; }
        public static List<int> getPressedButtons() { return PRESSED_BUTTONS; }
        public static List<int> getPressedButtonsEnemy() { return PRESSED_BUTTONS_ENEMY; }
    }
}