using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//This application consists of a list of values pertaining to shares(amount, price, date).
//The overall purpose of this application is to read in teh values of a share being sold by the
//  user and calculating the cost price of the sold share, gain/loss, number of remaining shares,
//  and cost price of remaining shares using the FIFO Cost Method (first in first out)
namespace Cost_Price_Calculation
{

    public partial class Form1 : Form
    {
        //stores the collection of shares in a list
        List<Share> ShareList = new List<Share>();
        
        //these variables hold what the user enters in the application
        DateTime dateSold;
        int amountSold;
        float priceSold;

        public Form1()
        {
            InitializeComponent();
                       
        }

        //Event Hadler for the Calculate Button
        private void calculate_button_Click(object sender, EventArgs e)
        {
            
            //calls method that fills values into the array
            FillList();

            try
            {
                //gets and converts values from user
                //convert string to date variable
                int day, month, year;
                string[] dateString = sellDate_tb.Text.Split('/');
                day = int.Parse(dateString[0]);
                month = int.Parse(dateString[1]);
                year = int.Parse(dateString[2]);
                dateSold = new DateTime(year, month, day);

                //get price and amount of sold share from user
                priceSold = float.Parse(pricePerShare_tb.Text);
                amountSold = int.Parse(sharesSold_tb.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("There was a problem reading your data. Try again.");
            }

            //sort list by date (earliest date in front)
            ShareList.Sort((x, y) => DateTime.Compare(x.date, y.date));

            //FIFO cost method
            FIFO();

            /*insert calls to other cost methods here once they are defined
            ...
            */
                
            //emptys the text boxes for the next entry
            sharesSold_tb.Text = "";
            pricePerShare_tb.Text = "";
            sellDate_tb.Text = "";
            
        }

        private void FIFO()
        {
            

            //calculate the cost price
            //fifo will return the earliest price of the share in the list based off the date
            float costPrice = ShareList[0].getPrice();
            costSold_label.Text = costPrice.ToString();

            //calculate the gain/loss
            //find the difference between the cost price (found above) and the costPrice sold
            // which is defined by the user
            float diff = priceSold - costPrice;
            gainLoss_label.Text = diff.ToString();

            //calculate remaining shares
            //find the total of all shares by parsing through the list. Then find the difference
            //  between that total and the number of shares sold
            int total = 0, remain;
            foreach(Share s in ShareList)
            {
                total += s.getNumber();
            }
            remain = total - amountSold;
            numberRemain_label.Text = remain.ToString();

            //calculate cost price of remaining shares
            //given the cost price of the sold share (fifo) the cost price will be the
            //  same since it is the earliest price of the share we have in the collection
            priceRemain_label.Text = costPrice.ToString();
        }

        //This functions purpose is only to hard code the values into the list
        private void FillList()
        {
            DateTime d1 = new DateTime(2005, 1, 1);
            DateTime d2 = new DateTime(2005, 2, 2);
            DateTime d3 = new DateTime(2005, 3, 3);
            Share s1 = new Share(100, 10, d1);
            Share s2 = new Share(40, 12, d2);
            Share s3 = new Share(50, 11, d3);

            ShareList.Add(s1);
            ShareList.Add(s2);
            ShareList.Add(s3);
        }
    }
}
