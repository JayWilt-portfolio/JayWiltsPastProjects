//IT213 Unit 1 Assignment

//

using System;

namespace IT213_Wilt_Unit1
{
    class Program
    {
        static void Main(string[] args)
        {

            //declare string variables
            String name = "John Smith";
            String address = "101 N. Main Street";
            String city = "Anytown";
            String state = "TX";
            String zipCode = "11111";
            String unitsTaken = "19";

            //declare constant numeric variables
            const double pricePerUnit = 100.50;
            const double discount = 150;

            //convert string value unitsTaken to integer
            int intUnitsTaken = Convert.ToInt32(unitsTaken);

            //increment units taken by one
            intUnitsTaken++;

            //Multiply the contstant variable for price per unit by the units take and place the answer in a variable named tuition
            double tuition = pricePerUnit * intUnitsTaken;

            //Subtract the constant discount value from tuition and store the answer in a variable named afterDiscount
            double afterDiscount = tuition - discount;

            //Divide the discounted tuition by 12 and store the answer in a variable named monthlyPayment
            double monthlyPaymer = afterDiscount / 12;

            //display output

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Address: " + adress);
            Console.WriteLine("City: " + city);
            Console.WriteLine("State: " + state);
            Console.WriteLine("Zip Code: " + zipCode);

            Console.WriteLine("The number of units taken is: " + intUnitsTaken);

            //format tuition values and monthly payment as currency and display
            Console.WriteLine(string.Format("The tuition before discount is: {0:C}", tuition));
            Console.WriteLine(string.Format("The tuition after discount is: {0:C}", afterDiscount));
            Console.WriteLine(string.Format("Your monthly payment is: { 0:C}", monthlyPayment));

            //keep console window open
            Console.Read
        }
    }
}