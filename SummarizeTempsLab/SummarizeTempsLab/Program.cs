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

            int loopNumber = 1;

            // Test whether file exists
            if (File.Exists(filePath))
            {

                Console.WriteLine("This program will calculate the number of temperatures above and below a threshold temperature");

                bool wantsToContinue = true;
                while (wantsToContinue == true)
                {

                    // If file exists, ask user to provide temperature reading for threshold
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

                            // If the current temperature value >= threshold 
                            //      Increment "above" counter by one
                            if (temp >= tempThreshold)
                            {
                                aboveTemp++;
                            }
                            // Else (temperature is below) increment
                            //      Increment "below" counter by one
                            else
                            {
                                belowTemp++;
                            }

                        }
                        string resultNumber = "*** Result Number " + loopNumber + " ***";
                        string thresholdString = "There are " + aboveTemp + " temperatures above the threshold and " + belowTemp + " temperatures below the threshold.";
                        string averageString = "The average temperature is " + totalTemp / amountTemp + " degrees.";

                        string[] results = { resultNumber, thresholdString, averageString };

                        Array.ForEach(results, Console.WriteLine);


                        Console.WriteLine("Would you like to save the results to a file? Enter yes or no");
                        string saveResults = Console.ReadLine();

                        if (saveResults == "yes")
                        {
                            Console.WriteLine("What would you like to name the file?");
                            string resultFileName = Console.ReadLine();

                            string docPath = @"C:\Users\Samuel Harvey\Documents\GitHub\SummarizeTempsLab\SummarizeTempsLab\SummarizeTempsLab\Results";

                            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, resultFileName + ".txt")))
                            {
                                foreach (string result in results)
                                    outputFile.WriteLine(result);
                            }

                            Console.WriteLine("The results have been successfully saved to " + resultFileName + ".txt. This file can be found in the Results folder.");
                        }
                        else
                        {

                        }
                    }


                    Console.WriteLine("Do you want to calculate more results? Enter yes or no.");
                    string inputyesno = Console.ReadLine();
                    if (inputyesno == "yes")
                    {
                        loopNumber++;
                    }
                    else
                    {
                        wantsToContinue = false;
                    }

                }
            }

            // Else (file does not exist) tell user file does not exist
            else
            {
                Console.WriteLine("That file cannot be found");
            }

            Console.WriteLine("Exiting program...");

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