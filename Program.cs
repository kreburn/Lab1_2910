using Microsoft.VisualBasic;

namespace Lab1_2910_ReburnK
{
    internal class Program
    {
        static void Main(string[] args)
        {            

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = projectFolder + Path.DirectorySeparatorChar + "videogames.csv";

            List<VideoGames> games = new List<VideoGames>();

            using (var sr = new StreamReader(filePath))
            {
                
                string fileHeader = sr.ReadLine();

               
                while (!sr.EndOfStream)
                {
                    
                    string? line = sr.ReadLine();

                    
                    string[] lineElements = line.Split(',');


                    VideoGames v = new VideoGames()
                    {                       
                        Name = lineElements[0],
                        Platform = lineElements[1],
                        Year = Int32.Parse(lineElements[2]),
                        Genre = lineElements[3],
                        Publisher = lineElements[4],
                        NA_Sales = Double.Parse(lineElements[5]),
                        EU_Sales = Double.Parse(lineElements[6]),
                        JP_Sales = Double.Parse(lineElements[7]),
                        Other_Sales = Double.Parse(lineElements[8]),
                        Global_Sales = Double.Parse(lineElements[9]),

                        
                    };

                    games.Add(v); //this will be for when i put them into any kind of actual list
                }

            } // end using

            games.Sort();

            /*var Nintendo = games.Where(x => x.Publisher == "Nintendo");
            foreach (var game in Nintendo) Console.WriteLine(game);
            ///////////////////////////////////////////////////////////           
            double numGames = games.Count();

            var nintendoGames = new List<VideoGames>();

            foreach (VideoGames v in games)
            {
                if (v.Publisher == "Nintendo") nintendoGames.Add(v);
            }
           
            double numNintendo = nintendoGames.Count();

            var publishPercent = Math.Round(numNintendo / numGames * 100, 2);

            Console.WriteLine($"\nOut of {numGames} games, {numNintendo} are published by Nintendo.");
            Console.WriteLine($"{publishPercent}% of all games are made by Nintendo.\n");*/



            //////////////////////////////////////////////////
            /*var rp = games.Where(x => x.Genre == "Role-Playing");
            foreach (var game in rp) Console.WriteLine(game);

            /////////////////////////////////////////////////
           

            var rpAmount = new List<VideoGames>();
            foreach (VideoGames v in games)
            {
                if (v.Genre == "Role-Playing") rpAmount.Add(v);
            }

            double numRP = rpAmount.Count();
            var rpPercent = Math.Round(numRP / numGames * 100, 2);

            Console.WriteLine($"Out of {numGames} games, {numRP} are Role-Playing games.");
            Console.WriteLine($"{rpPercent}% of games are in the Role-Playing genre.");*/
            ///////////////////////////////////////////////////
            

            Console.Write("Enter the publisher you'd like to search for: ");
            string publisherInput = Console.ReadLine();

            PublisherData(games, publisherInput);

            Console.Write("Enter the genre you'd like to search for: ");
            string genreInput = Console.ReadLine();

            GenreData(games, genreInput);

        }

       static void PublisherData(List<VideoGames> games, string publisherInput)
       {
            double numGames = games.Count();

            var somethingVariableIDontCare = games.Where(x => x.Publisher == publisherInput);
            foreach (var game in somethingVariableIDontCare) Console.WriteLine(game);

            var publisherGames = new List<VideoGames>();

            foreach (VideoGames v in games)
            {
                if (v.Publisher == publisherInput) publisherGames.Add(v);
            }

            double numPub = publisherGames.Count();
            var percent = Math.Round(numPub / numGames * 100, 2);

            Console.WriteLine($"\nOut of {numGames} games, {numPub} are published by {publisherInput}.");
            Console.WriteLine($"{percent}% of all games are made by {publisherInput}.\n");
       }

        static void GenreData(List<VideoGames> games, string genreInput)
        {
            double numGames = games.Count();

            var somethingVariableIDontCare = games.Where(x => x.Genre == genreInput);
            foreach (var game in somethingVariableIDontCare) Console.WriteLine(game);

            var genreGames = new List<VideoGames>();

            foreach (VideoGames v in games)
            {
                if (v.Genre == genreInput) genreGames.Add(v);
            }

            double numGenre = genreGames.Count();
            var percent = Math.Round(numGenre/ numGames * 100, 2);

            Console.WriteLine($"\nOut of {numGames} games, {numGenre} are {genreInput}.");
            Console.WriteLine($"{percent}% of all games are {genreInput}.\n");
        }
    }
}