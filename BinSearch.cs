/* 
AppName: "Simple Binary Search Engine";
File: BinSearch.cs
Version: "1.0.0";
Date: "9/23/2018";
Author: Stefan Djurkic;
Contact: stefandjurkic@gmail.com
*/
using System;

namespace Binary_Search_Engine
{
    class BSearch
    {   
        // Binary search algorithm, accepts an integer array and an integer search value
        public static string BinarySearch(int[] num, int searchValue)
            {
                int midV;                                        // Declare three integers to represent right, left, and middle values
                int leftV = 0;                                      
                int rightV = num.Length - 1;

                while (leftV <= rightV)                                 
                {
                    midV = leftV + ((rightV - leftV) / 2);      // Exclude a range, at the start of the loop set mid value to left value plus the difference of right and left divided by 2 
                                                                        
                    if (num[midV] == searchValue)               // If the search value matches our mid value, return a message indicating position
                {
                        return ("Found the value '" + searchValue + "' at index: " + midV);  
                    }
                    else
                    {
                        if (num[midV] > searchValue)                    
                        {
                            rightV = midV - 1;                  // If our mid is greater than the search value, we know the value stays on the right side and give it more power in the initial equation
                        }
                        else
                        {
                            leftV = midV + 1;                   // Just as above, but we add 1 instead of detracting 1. These changes ensure we move along the corresponding side
                        }
                    }
                }
                return "Failed to find your number!";           // Return a message to indicate the function failed
            }

        // SetArray sets an array to a specified parameter, fills it and returns it
        public static int[] SetArray(int size)
        {
            int[] numArray = new int[size];                  // Create an array from a specified size
            for(int i = 0; i < numArray.Length; ++i)         // Fill the array
            {
                numArray[i] = i+1;                           // Add one to i since we want to exclude the number 0 from our array
            }
            return numArray;
        }

        // TakeInput displays a message from a parameter then accepts user input into a string, and if it is numeric returns that integer
        public static int TakeInput(string message)
        {
            string checks;                                    // Declare a string object checks which we store into some input to be converted to an int
            int reValue = -1;                                 // Initialize an integer return value "reValue" to -1 which ensures we are looping and nothing was converted
            while (reValue == -1)
            {
                checks = "";                                  // Reset checks to "" for the following loop
                while (checks.Length <= 0 || checks.Length >= 10)
                {
                    Console.Write(message);                   // Displays our desired message
                    checks = Console.ReadLine();              // Accepts input 
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(checks, "[0-9]"))  // Verify the checks variable is numeric through regex
                {
                    reValue = Convert.ToInt32(checks);        // If the value is numeric we convert checks and transfer the value to reValue
                }                       
            }
            return reValue;
        }

        static void Main()
        {
            string appName = "Simple Binary Search Engine";                                      // Setting up variables to display program information
            string appVersion = "1.0.0";
            string appDate = "9/23/2018";
            string appAuthor = "Stefan Djurkic";

            Console.ForegroundColor = ConsoleColor.Blue;                                                   // Set a color for our program info display
            Console.WriteLine("{0} \n{1} \n{2} \n{3}", appName, appVersion, appDate, appAuthor);           // display program info
            Console.ResetColor();                                                                          // reset the color

            int searchSize = TakeInput("Enter an integer less than 10 digits long to create an array: ");  // Pass through Takeinput() function a message, set searchSize to return value
            int[] num = SetArray(searchSize);                                                              // define an array based on return value of setArray with searchSize parameter
            int searchNumber = TakeInput("Enter an integer less than 10 digits long that you wish to search: ");   
            Console.WriteLine(BinarySearch(num, searchNumber));                                            // Write to console the result of our search based on searchNumber int 
            Console.ReadKey();                                                                             // Don't close that window just yet!
        }
    }
}

