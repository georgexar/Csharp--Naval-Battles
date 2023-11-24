using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naval_Battles
{
    public class UserShip
    {

        private string name;
        private int startPosition;
        private List<int> positions;
        private bool rotated;
        private int width;
        private int height;


        public UserShip(string name, int startPosition, List<int> positions, bool rotated, int width, int height)
        {
            this.name = name;
            this.startPosition = startPosition;
            this.positions = positions;
            this.rotated = rotated;
            this.width = width;
            this.height = height;
        }

        public string getName()
        {
            return this.name;
        }

        public List<int> getPositions()
        {
            return this.positions;
        }

        public bool getRotated() { return this.rotated; }

        public int getStartPosition()
        {
            return this.startPosition;
        }

        public int getWidth() { return this.width; }
        public int getHeight() { return this.height; } 

        public void setName(string name) { this.name = name; }
        public void setStartPosition(int start) { this.startPosition = start; }
        public void setRotated(bool value) { this.rotated = value; }
        public void setWidth(int width) { this.width = width; }
        public void setHeight(int height) { this.height = height; }


    }
}
