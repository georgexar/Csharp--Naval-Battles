using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naval_Battles
{
    public class EnemyShip
    {

        private string name;
        private int length;
        private List<int> positions;

        public EnemyShip(string name, int length, List<int> positions)
        {
            this.name = name;
            this.length = length;
            this.positions = positions;
        }

        public string getName() { return this.name; }
        public int getLength() { return this.length; }
        public List<int> getPositions() { return this.positions; }
        public void setLength(int a) { this.length = a; }

    }
}
