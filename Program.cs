// See https://aka.ms/new-console-template for more information
using ARSA;

//This is the main entrance point for the script, however it runs the actual main function in fullStackRun.cs, This may not be best practice.
Console.WriteLine("Welcome to ARSA");
Console.WriteLine("Please enter the subreddit you wish to use");
string subreddit = Console.ReadLine();
Console.WriteLine("Please enter the path to the input file");
string inputPath = Console.ReadLine();
Console.WriteLine("Please enter the path to the output file");
string outputPath = Console.ReadLine();
Console.WriteLine("Please enter the number of videos you wish to create");
int numberofVideos = Convert.ToInt32(Console.ReadLine());
fullStackRun.Main(subreddit, inputPath, outputPath, numberofVideos);