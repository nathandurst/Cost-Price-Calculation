using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//This class stores the values of the shares that will then be
//  stored in a collection (list).
//There are currently no setter methods, the values are set as the object
//  is being instantiated (using the constructor)
namespace Cost_Price_Calculation
{
    class Share
    {
        private int number;
        private float price;
        public DateTime date;

        public Share(int n, float p, DateTime d)
        {
            number = n;
            price = p;
            date = d;
        }

        public int getNumber()
        {
            return number;
        }

        public float getPrice()
        {
            return price;
        }

        public DateTime getDate()
        {
            return date;
        }

    }
}
