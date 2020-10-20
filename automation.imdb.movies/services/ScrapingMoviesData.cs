using automation.imdb.movies.entities;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace automation.imdb.movies.services
{
    public class ScrapingMoviesData
    {
        public static IRestClient ClientIMDB = new RestClient("https://imdb.com");

        public void Execute(string movieName) 
        {
            var transformMovieName = movieName.Replace(" ", "+");
            var request = new RestRequest($"find?q={transformMovieName}&s=tt&ttype=ft&ref_=fn_ft", Method.GET);

            var response = ClientIMDB.Execute(request);

            var hasResult = false;

            if (response.Content.Contains("Displaying"))
                hasResult = true;

            var listMovies = new List<Movie>();

            if (hasResult)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response.Content);

                var hasTableFindList = htmlDoc.DocumentNode.SelectNodes("//table[@class='findList']") != null;

                if (!hasTableFindList)
                    throw new Exception("Nenhum filme encontrado");

                foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//table[@class='findList']"))
                {                    
                    foreach (HtmlNode row in table.SelectNodes("tr"))
                    {
                        HtmlNodeCollection cells = row.SelectNodes("th|td");

                        if (cells == null)
                        {
                            continue;
                        }

                        foreach (HtmlNode cell in cells)
                        {
                            if (string.IsNullOrEmpty(cell.InnerText.Trim()))
                            {
                                var movie = new Movie();

                                var link = cell.SelectSingleNode(".//a").Attributes["href"].Value;

                                request = new RestRequest(link, Method.GET);

                                ClientIMDB.CookieContainer = new CookieContainer();
                                var responseMovieData = ClientIMDB.Execute(request);                                

                                var codeMovie = link.Substring(link.IndexOf("title/") + 6, link.IndexOf("/?") - 7);

                                request = new RestRequest("tr/", Method.POST);                               
                                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                                request.AddParameter("ref_", "tt_mlpo_pa");
                                request.AddParameter("pt", "title");
                                request.AddParameter("pt", "main");
                                request.AddParameter("ht", "actionOnly");
                                request.AddParameter("const", codeMovie);
                                request.AddParameter("pageAction", "menu-open");

                                var responseMovieDataPTBR = ClientIMDB.Execute(request);

                                request = new RestRequest("tr/", Method.POST);
                                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                                request.AddParameter("ref_", "tt_mlpo_pa");
                                request.AddParameter("pt", "title");
                                request.AddParameter("pt", "main");
                                request.AddParameter("ht", "actionOnly");
                                request.AddParameter("const", codeMovie);
                                request.AddParameter("pageAction", "menu-select-pt-BR");

                                responseMovieDataPTBR = ClientIMDB.Execute(request);

                                request = new RestRequest(link, Method.GET);
                                responseMovieData = ClientIMDB.Execute(request);

                                HtmlDocument htmlMovie = new HtmlDocument();
                                htmlMovie.LoadHtml(responseMovieData.Content);

                                movie.Uri = "https://www.imdb.com" + link.Substring(0, link.IndexOf("?"));
                                movie.Name = htmlMovie.DocumentNode.SelectSingleNode("//div[@class='title_wrapper']/h1").FirstChild.InnerText.Trim().Replace("&nbsp;", "");
                                movie.Grade = float.Parse(htmlMovie.DocumentNode.SelectSingleNode("//div[@class='ratingValue']/strong/span").FirstChild.InnerText.Trim().Replace(".", ","));                                
                                movie.Description = htmlMovie.DocumentNode.SelectSingleNode("//div[@class='summary_text']").InnerText.Trim();
                                movie.Cover = htmlMovie.DocumentNode.SelectSingleNode("//div[@class='poster']/a/img").Attributes["src"].Value.Trim();
                                listMovies.Add(movie);
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
