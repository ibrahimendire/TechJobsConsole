using System;
using System.Collections.Generic;

namespace TechJobsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Dictionary vars to hold info for menu and data

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>();
            columnChoices.Add("core competency", "𝐒𝐤𝐢𝐥𝐥");
            columnChoices.Add("employer", "𝔼𝕞𝕡𝕝𝕠𝕪𝕖𝕣");
            columnChoices.Add("location", "𝕷𝖔𝖈𝖆𝖙𝖎𝖔𝖓");
            columnChoices.Add("position type", "🄿🄾🅂🄸🅃🄸🄾🄽 🅃🅈🄿🄴");
            columnChoices.Add("all", "𝔸𝕝𝕝");

            Console.WriteLine("Welcome to LaunchCode's TechJobs App!");

            // Allow user to search/list until they manually quit with ctrl+c
            while (true)
            {

                string actionChoice = GetUserSelection("View Jobs", actionChoices);

                if (actionChoice.Equals("list"))
                {
                    string columnChoice = GetUserSelection("List", columnChoices);

                    if (columnChoice.Equals("all"))
                    {


                        PrintJobs(JobData.FindAll());
                    }
                    else
                    {
                        List<string> results = JobData.FindAll(columnChoice);

                        Console.WriteLine("\n*** All " + columnChoices[columnChoice] + " Values ***");
                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine("\nSearch term: ");
                    string searchTerm = Console.ReadLine();


                    List<Dictionary<string, string>> searchResults;

                    // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        PrintJobs(JobData.FindAll());
                        //Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults);
                    }
                }
            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        private static string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        {
            int choiceIdx;
            bool isValidChoice = false;
            string[] choiceKeys = new string[choices.Count];

            int i = 0;
            foreach (KeyValuePair<string, string> choice in choices)
            {
                choiceKeys[i] = choice.Key;
                i++;
            }

            do
            {
                Console.WriteLine("\n" + choiceHeader + " by:");

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]);
                }

                string input = Console.ReadLine();
                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        {
            //Console.WriteLine("PrintJobs is not implemented yet");

            if (someJobs.Count > 0)
            {
                foreach (Dictionary<string, string> job in someJobs)
                {

                    foreach (KeyValuePair<string, string> item in job)
                    {

                        Console.WriteLine("{0}: {1}", item.Key, item.Value);

                    }

                    Console.WriteLine("********************");

                }
            }
            else
            {
                Console.WriteLine("ℕ𝕠 𝕣𝕖𝕤𝕦𝕝𝕥𝕤 𝕗𝕠𝕦𝕟𝕕 𝕞𝕒𝕥𝕔𝕙 𝕪𝕠𝕦𝕣 𝕤𝕖𝕒𝕣𝕔𝕙 𝕥𝕖𝕣𝕞");

            }

        }


    }
}