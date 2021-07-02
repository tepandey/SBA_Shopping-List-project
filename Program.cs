using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace SBA_Shopping_List_project
{
    public class Program:Shopping
    {
        static void Main(string[] args)
        {
            


            Shopping myshoppingList = new Shopping();
            List<List<string>> shoppingList = new List<List<string>>(); // List which saves all the data
            string thisDay = DateTime.UtcNow.ToString("MM-dd-yy");
            string datepurchased = "";
            string sortedby = "None";
            int itemspurchased = 0;

            // Adding Intial Data to the table
            shoppingList.Add(new List<string> { "Phone", "Tech", "High", thisDay, datepurchased });
            shoppingList.Add(new List<string> { "Umbrella", "Clothing", "Low", thisDay, datepurchased });
            shoppingList.Add(new List<string> { "Apple", "Food", "Low", "05-08-20", datepurchased });
            shoppingList.Add(new List<string> { "Laptop", "Tech", "High", "04-21-21", datepurchased });
            shoppingList.Add(new List<string> { "Gold", "Jewelrey", "Low", "03-08-21", datepurchased });
            shoppingList.Add(new List<string> { "Laptop", "Tech", "High", "02-09-21", datepurchased });
            string yourChoice = "";

            //Printing The Welcome Bar

            do
            {
                // Main Frame Title

                Console.WriteLine("*******************************************************************************");

                Console.WriteLine("          Welcome to the Shopping List Manager \n           You have " + shoppingList.Count + " items in your list");
                Console.WriteLine("*******************************************************************************");

                // screen delay
                System.Threading.Thread.Sleep(3000);

                // List Title Frame

                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*  Showing All the Items: " + 
                    shoppingList.Count + " Pending: " + (shoppingList.Count -itemspurchased) +
                    "     Purchased:  " +itemspurchased +
                    "      Sorting: " + sortedby);
                Console.WriteLine("*******************************************************************************");
                
                //printing Table Frame

                myshoppingList.printTheTable(shoppingList);

                yourChoice = menuOption(shoppingList).ToUpper(); // Displays the menu option and return the input. Changing input to UpperCase

                if (yourChoice == "A")
                {
                    myshoppingList.addAnItem(shoppingList);

                }
                else if (yourChoice == "R")
                {
                    myshoppingList.removeAnItem(shoppingList);

                }
                else if (yourChoice == "E")
                {
                    myshoppingList.editItem(shoppingList);
                    

                }
                else if (yourChoice == "P")
                {
                    myshoppingList.purchaseItem(shoppingList);
                    itemspurchased += 1;

                }
                else if (yourChoice == "S")
                {
                  string input = myshoppingList.sortbyinput();
                  shoppingList = myshoppingList.sorttheList(shoppingList, input);
                  sortedby = myshoppingList.sortedbytype(input);

                }
                else if (yourChoice == "T")
                {
                    Console.WriteLine("Enter item Name:\n");
                    string input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("******************************************");
                    Console.WriteLine("*               Feature Coming Soon      *");
                    Console.WriteLine("******************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (yourChoice == "Q" || yourChoice == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid entry");
                    Console.ReadLine();
                    yourChoice = "refresh";
                    Console.Clear();
                }


            } while (yourChoice != "Q" || yourChoice != "q");
            
           




        }

        //meru Item

        private static string menuOption(List<List<string>> shoppingList)
        {
            
            Console.WriteLine("********************************************************");
            Console.WriteLine("Menu Options: \n * \n * A  Add a new item \n * R  Remove an item  \n * E  Edit an item \n" +
                " * P  Mark an item as purchased \n * S  Sort the list \n * T  Toggle display of purchased items \n * Q  Quit the program \n");
            Console.WriteLine("********************************************************");
            Console.WriteLine("Your Choice: ");
            string yourChoice = Console.ReadLine();
            return yourChoice;
        }

    }
}
