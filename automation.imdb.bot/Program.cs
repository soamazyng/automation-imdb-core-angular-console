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
                    ScrapingMoviesData.Execute("O Silêncio dos Inocentes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
