using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write out prompt to the console
            Console.WriteLine("*** TEMPERATURE ANALYSIS ***");
            Console.WriteLine("What is the file name?");

            // Read the filename from the console
            string filePath = Console.ReadLine();

            // Test whether file exists
            if (File.Exists(filePath))
            {

                // If file exists, ask user to provide temperature reading for threshold
                Console.WriteLine("This program will calculate the number of temperatures above and below a threshold temperature");
                Console.WriteLine("What is the threshold?");
                string input = Console.ReadLine();
                int tempThreshold = int.Parse(input);

                // Open the data file
                using (StreamReader sr = File.OpenText(filePath))
                {
                    
                    string line = "";
                    int totalTemp = 0;
                    int amountTemp = 0;
                    int aboveTemp = 0;
                    int belowTemp = 0;


                    // Read each line of the data file into a string
                    // While a line is not null
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Parse each string
                        int temp = int.Parse(line);

                        // Add each string together in totalTemp
                        totalTemp = totalTemp + temp;

                        // For each string add +1 to number of temperatures
                        amountTemp++;

                        if (temp >= tempThreshold)
                        {

                        }

                    }
                    Console.WriteLine(amountTemp);
                    Console.WriteLine(totalTemp);
                }

                
            }


            // temperature data is in temps.txt


            // If the current temperature value >= threshold 
            //      Increment "above" counter by one
            // Else (temperature is below) increment
            //      Increment "below" counter by one
            // If line is null exit loop
            // Calculate the average temp
            //      totalTemp/# of temp
            
            // Give user the results

            // Else (file does not exist) tell user file does not exist
        }
    }
}



// Prompt the use for the name of the data file
// Check that the file exists
// Sum up the number of readings above and below a certain temperature threshold that is provided via Console input
// Prompt the user to provide a temperature reading that will be used as the threshold
// Open the data file
// Read each line of the data file and count the number of temperature readings that are above (or equal) and the number below the threshold
// Calculate the average temperature in the dataset
// Print the results to the Console window