using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Die
    {
        private int _dieValue;
        public int DieValue
        {
            get => _dieValue; set => _dieValue = value;
        }

        //methods
        public void Roll()
        {
            //give a random number 
            Random random = new Random();
            DieValue = random.Next(1, 7);
        }
    }
}
