using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send GET request to formula1.com
            String url = "https://www.formula1.com/en/results.html/2023/races.html";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            
            // Get the Grand Prix location
            var grandPrixElement = htmlDocument.DocumentNode.SelectSingleNode("//a[@data-ajax-url='/content/fom-website/en/results/jcr:content/resultsarchive.html/2023/races/1141/bahrain/race-result.html']");
            var grandPrixLocation = grandPrixElement.InnerText.Trim();
            Console.WriteLine($"Grand Prix Name: {grandPrixLocation}");
            
            //Get the date of Grand Prix
            var gpDateElement = htmlDocument.DocumentNode.SelectSingleNode("//td[@class='dark hide-for-mobile']");
            var gpDate = gpDateElement.InnerText.Trim();
            Console.WriteLine($"Grand Prix Date: {gpDate}");
            
            // Get the Grand Prix winner
            var gpWinnerElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='uppercase hide-for-desktop']");
            var gpWinnerName = gpWinnerElement.InnerText.Trim();
            Console.WriteLine($"Race Winner's Name: {gpWinnerName}");

            // Get the team manufacturer
            var teamNameElement = htmlDocument.DocumentNode.SelectSingleNode("//td[@class='semi-bold uppercase ']");
            var teamName = teamNameElement.InnerText.Trim();
            Console.WriteLine($"Manufacturer: {teamName}");

            // Get the laps completed
            var lapsElement = htmlDocument.DocumentNode.SelectSingleNode("//td[@class='bold hide-for-mobile']");
            var lapsCompleted = lapsElement.InnerText.Trim();
            Console.WriteLine($"Laps Completed: {lapsCompleted}");
            
            // Get the race duration
            var raceDurationElement = htmlDocument.DocumentNode.SelectSingleNode("//td[@class='dark bold hide-for-tablet']");
            var raceDuration = raceDurationElement.InnerText.Trim();
            Console.WriteLine($"Race Duration: {raceDuration}");
            
        }
    }
}