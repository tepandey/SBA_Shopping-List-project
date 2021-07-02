using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBA_Shopping_List_project
{
    public class Shopping
    {
        string thisDay = DateTime.UtcNow.ToString("MM-dd-yy");
        string datepurchased ="";

        // method to Add an Item

        public void addAnItem(List<List<string>> shoppingList)
        {
            string input_category = "";
            string input = "";
            bool valid = false;

            
            do
            {
                

                Console.WriteLine("Enter item Name:\n");
                input = Console.ReadLine();
                
                // capitializing the first letter of the input
                input = FirstCharToUpper(input);

                // Option for Category

                Console.WriteLine("Name: " + input + " \n 1: Food \n 2: Clothing \n 3: Furniture \n 4: Household \n 5: Jewerly \n 6: Utilities \n 7: Tech \n");
                Console.WriteLine("Your Choice: ");
                input_category = Console.ReadLine();
                // assigning the numbers a category

                if (input_category == "1") input_category = "Food";
                else if (input_category == "2") input_category = "Clothing";
                else if (input_category == "3") input_category = "Furniture";
                else if (input_category == "4") input_category = "Household";
                else if (input_category == "5") input_category = "Jewelry";
                else if (input_category == "6") input_category = "Utilities";
                else if (input_category == "7") input_category = "Tech";
                else
                {
                    valid = true;
                    Console.WriteLine("Please Enter a valid choice");
                    Console.ReadKey();
                }
            } while (valid);

            // checking for priority

            string input_priority = "";
            do
            {
                valid = false;
                Console.WriteLine(" Name: " + input + " \n Category: " + input_category + "\n L:  Low \n M:  Medium \n H:  High");
                Console.WriteLine("Your Choice: ");
                input_priority = Console.ReadLine().ToUpper(); // saving the input to a variable and changing to Uppercase

                if (input_priority == "L") input_priority = "Low";
                else if (input_priority == "M") input_priority = "Medium";
                else if (input_priority == "H") input_priority = "High";
                else
                {
                    valid = true;
                    Console.WriteLine("Please Enter a valid choice");
                    Console.ReadKey();
                }

            } while (valid);

            //checking for duplicates

            int count = 0;
            foreach (List<string> item in shoppingList)
            {
                if (item[0] == input) count++;
                else count = count;

            }

            if (count > 0)
            {
                Console.WriteLine("Item '" + input + "'is already in the list \n Edit the item (y/n?)");
                string userchoice = Console.ReadLine();
                if (userchoice == "y")
                {
                    editItem(shoppingList);
                }
                if (userchoice == "n")
                {
                    // return to the top
                }
            }
            else
            {
                //If doesn't exist, addes item to List

                shoppingList.Add(new List<string> { input, input_category, input_priority, thisDay, datepurchased });
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("*******************************************");
                Console.WriteLine("   Item '" + input + "' added to the list.");
                Console.WriteLine("*******************************************");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.Clear();



        }
        //method to remove an item
        public void removeAnItem(List<List<string>> shoppingList)
        {
            Console.WriteLine("Select Item # to Remove:\n");
            int input = Convert.ToInt32(Console.ReadLine());
            string itemtoremove = string.Empty;
                if (input > shoppingList.Count())
	            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("         Item Out of Index.        ");
                    Console.WriteLine("*******************************************");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;

	            }
                else
	            {


	        

                     for (int i = input - 1; i < input; i++)
                        {
                        List<string> Itemgroup = shoppingList[i];
                        foreach (string item in Itemgroup)
                        {
                            itemtoremove = item;
                            break;
                        }
                
         

                            Console.WriteLine("Remove '" + itemtoremove + "'from the list? (y/n)'");
                            string yesorno = Console.ReadLine();
                            if (yesorno == "y")
                            {
                                for (int j = input - 1; j < input; j++)
                                {
                                    List<string> Itemgroup1 = shoppingList[j];

                                        shoppingList.Remove(shoppingList[input - 1]);
                                        Console.ForegroundColor = ConsoleColor.Green;

                                        Console.WriteLine("*******************************************");
                                        Console.WriteLine("Item '" + itemtoremove + "'is removed.");
                                        Console.WriteLine("*******************************************");
                                        Console.ReadKey();
                                        Console.ForegroundColor = ConsoleColor.White;
                                }


                            }
                    }
                }
                    
                  
            
            Console.Clear();

        }
        //method to purchaseItem

        public void purchaseItem(List<List<string>> shoppingList)
        {
            string thisDay = DateTime.UtcNow.ToString("MM-dd-yy");
            
            Console.WriteLine("Select the item # to mark as purchased:\n");
            int input = Convert.ToInt32(Console.ReadLine());
            string itemToMarkPurchased = "";
            for (int i = input - 1; i < input; i++)
            {
                List<string> Itemgroup = shoppingList[i];
                foreach (string item in Itemgroup)
                {
                    itemToMarkPurchased = item;
                    break;
                }

            }
            Console.WriteLine("Mark Item '" + itemToMarkPurchased + "'as purchased? (y/n)'");
            string yesorno = Console.ReadLine();
            if (yesorno == "y")
            {
                for (int i = input - 1; i < input; i++)
                {
                    List<string> Itemgroup = shoppingList[i];
                    Itemgroup[4] = thisDay;
                }
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("******************************************************************");
                Console.WriteLine("     Item '" + itemToMarkPurchased + "' has been marked as purchased  ");
                Console.WriteLine("*******************************************************************");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
            }
        }

        

        public int numberTotheItem(List<List<string>> shoppingList)
        {
            int count = 1;
            foreach (List<string> items in shoppingList)
            {
                count++;

            }
            return count;
        }

        public void printTheTable(List<List<string>> shoppingList)
        {
            int count = 0;

            // printint the items in the table 
            Console.WriteLine("#   Name           Category       Priority          Date Added          Purchased");

            //using forloop to count the exact numbers of spaces needed between the entry
            foreach (List<string> items in shoppingList)
            {
                count++;
                int i = 15 - items[0].Length;
                string space = "";
                int k = 15 - items[1].Length;
                string space2 = "";
                string space3 = "";
                int z = 15 - items[2].Length;


                for (int j = 0; j <= i; j++)
                {
                    space = space + " ";
                }
                for (int w = 0; w <= k; w++)
                {
                    space2 = space2 + " ";
                }
                for (int x = 0; x <= z; x++)
                {
                    space3 = space3 + " ";
                }

                //var table = new ConsoleTable(" # ", " Category ", " Priority ", "Date Added", "Date Purchased");

                Console.WriteLine(count + "   " + items[0] + space + items[1] + space2 +
                    items[2] + space3 + items[3] + "          " + items[4]);

            }
            System.Threading.Thread.Sleep(500);

        }
        public void editItem(List<List<string>> shoppingList)
        {
            Console.WriteLine(" Which item # do you want to edit? ");
            Console.WriteLine("");
            Console.WriteLine("your choice: ");
            string input = Console.ReadLine();
            int index = int.Parse(input) - 1;
            for (int i = index; i < index+1; i++)
            {
                List<string> Itemgroup = shoppingList[i];
                Console.WriteLine("Name   :   " + Itemgroup[0]);
                Console.WriteLine("Date Added   :   " + Itemgroup[3]);
                Console.WriteLine("Category   :   " + Itemgroup[1]);
                Console.WriteLine("Priority   :   " + Itemgroup[2]);
                if (Itemgroup[4] == "")
                {
                    Console.WriteLine("Purchase    :   Not Purchased");

                }
                else
                {
                    Console.WriteLine("Purchase    :   " + Itemgroup[4]);

                }
                Console.WriteLine("");
                Console.WriteLine("Leave enteries blank to keep current value");
                Console.WriteLine("");
                Console.WriteLine("New name:   ");
                string newname = Console.ReadLine();
                
                if (newname == null || newname =="")
                {
                    newname = Itemgroup[0];

                }
                else
                {
                    newname =FirstCharToUpper(newname);
                    addAnItem(shoppingList, newname, index);
                }
            }
        }

        //overriding addAnItem to which accepts name and index

        public void addAnItem(List<List<string>> shoppingList, string name, int index)
        {
            string input_category = "";
            string input = "";
            bool valid = false;

            //checking for input category 
            do
            {



                input = name;
                input = FirstCharToUpper(input);
                Console.WriteLine("Name: " + input + " \n 1: Food \n 2: Clothing \n 3: Furniture \n 4: Household \n 5: Jewerly \n 6: Utilities \n 7: Tech \n");
                Console.WriteLine("New Category: ");
                input_category = Console.ReadLine();

                if (input_category == "1") input_category = "Food";
                else if (input_category == "2") input_category = "Clothing";
                else if (input_category == "3") input_category = "Furniture";
                else if (input_category == "4") input_category = "Household";
                else if (input_category == "5") input_category = "Jewelry";
                else if (input_category == "6") input_category = "Utilities";
                else if (input_category == "7") input_category = "Tech";
                else
                {
                    valid = true;
                    Console.WriteLine("Please Enter a valid choice");
                    Console.ReadKey();
                }
            } while (valid);

            // checking for priority

            string input_priority = "";
            do
            {
                valid = false;
                Console.WriteLine(" Name: " + input + " \n Category: " + input_category + "\n L:  Low \n M:  Medium \n H:  High");
                Console.WriteLine("Your Choice: ");
                input_priority = Console.ReadLine();

                if (input_priority == "l" || input_priority == "L") input_priority = "Low";
                else if (input_priority == "M" || input_priority == "m") input_priority = "Medium";
                else if (input_priority == "H" || input_priority == "h") input_priority = "High";
                else
                {
                    valid = true;
                    Console.WriteLine("Please Enter a valid choice");
                    Console.ReadKey();
                }

            } while (valid);



            int count = 0;


            foreach (List<string> item in shoppingList)
            {
                if (item[0] == input) count++;
                else count = count;

            }

            if (count > 0)
            {
                Console.WriteLine("Item '" + input + "'is already in the list \n Edit the item (y/n?)");
                string userchoice = Console.ReadLine();
                if (userchoice == "y")
                {
                    // return to typing the name
                }
                if (userchoice == "n")
                {
                    // return to the top
                }
            }
            else
            {
                shoppingList[index] = new List<string> { input, input_category, input_priority, thisDay, datepurchased };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*******************************************");
                Console.WriteLine("   Item '" + input + "' is edited to the list.");
                Console.WriteLine("*******************************************");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.Clear();



        }
        public List<List<string>> sorttheList(List<List<string>> shoppingList, string input)
        {
            
          
            if (input == "N")
            {
                shoppingList = shoppingList.OrderBy(lst => lst[0]).ToList();
                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("*******************************************");
                Console.WriteLine("*  Sorting changed to Name                *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "C")
            {
                shoppingList = shoppingList.OrderBy(lst => lst[1]).ToList();
                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("*******************************************");
                Console.WriteLine("*  Sorting changed to Category            *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "P")
            {
                Console.WriteLine("Sort by priority:");
                Console.WriteLine("A   Sort ascending");
                Console.WriteLine("D   Sort descending");
                Console.WriteLine("");
                Console.WriteLine("Your Choice: ");
                string inputchoice = Console.ReadLine();
                if (inputchoice == "A")
                {
                   
                    shoppingList = shoppingList.OrderBy(lst => lst[2]).ToList();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("*******************************************");
                    Console.WriteLine("*  Sorting changed to Priority, Ascending *");
                    Console.WriteLine("*                                         *");
                    Console.WriteLine("*******************************************");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (inputchoice == "D")
                {
                    

                    shoppingList = shoppingList.OrderBy(lst => lst[2]).ToList();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("*******************************************");
                    Console.WriteLine("*  Sorting changed to Priority, Ascending *");
                    Console.WriteLine("*                                         *");
                    Console.WriteLine("*******************************************");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.WriteLine("Please input a valid choice");
                }
            }
            if (input == "D")
            {
                Console.ForegroundColor = ConsoleColor.Green;


                shoppingList = shoppingList.OrderBy(lst => lst[3]).ToList();
                Console.WriteLine("*******************************************");
                Console.WriteLine("*  Sorting changed to Date Added          *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.ForegroundColor = ConsoleColor.White;

            }
            if (input == "B")
            {
                shoppingList = shoppingList.OrderBy(lst => lst[4]).ToList();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("*******************************************");
                Console.WriteLine("* Sorting changed to Purchased Date       *");
                Console.WriteLine("*                                         *");
                Console.WriteLine("*******************************************");
                Console.ForegroundColor = ConsoleColor.White;

            }
            Console.ReadKey();
            Console.Clear();
            return shoppingList;

        }

        public string sortbyinput()
        {
            Console.WriteLine("N  Sort by Name");
            Console.WriteLine("C  Sort by Category");
            Console.WriteLine("P  Sort by Priority");
            Console.WriteLine("D  Sort by Date Added");
            Console.WriteLine("B  Sort by Purchase Date \n");
            Console.WriteLine("Your Choice:");
            string input = Console.ReadLine();
            return input;
        }
        public string sortedbytype(string input)
        {

            string sortedby = "";
            if (input == "N")
            {
                
               sortedby = "Name";
            }
            if (input == "C")
            {

                sortedby = "Category";
            }
            if (input == "P")
            {
               sortedby = "Priority: Ascending";
            }
            if (input == "D")
            {
               sortedby = "Date Added";
            }
            if (input == "B")
            {
               sortedby = "Date Purchased";
            }
            
            return sortedby;

        }
        public string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }

}
