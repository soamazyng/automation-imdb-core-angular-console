using automation.imdb.movies.services;
using System;

namespace automation.imdb.bot
{

    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    var scrapingMoviesData = new ScrapingMoviesData();
                    scrapingMoviesData.Execute("O Silêncio dos Inocentes");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
