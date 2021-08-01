using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zcc_tickets.Models;

namespace zcc_tickets.Controllers
{
    public class TicketsController : Controller
    {
        private readonly (string Email, string AccessToken) ApiCredentials = ("kevinramirezcs1997@gmail.com", "khrbZBUarxuipfUQtFMKOl9YmMEwD6h1O3Z77QtY");
        private readonly string BaseUrl = "https://zcctickets.zendesk.com";

        public IActionResult Index()
        {
            return View();
        }

        // figuring this out
        public static async Task< List<Ticket> > GetTicketsAsync((string Email, string AccessToken) ApiCredentials, string BaseUrl)
        {
            //RestClient client = new RestClient($"{BaseUrl}/api/v2");
            //RestRequest request = new RestRequest($"/tickets.json?page[size]=25 -u {ApiCredentials.Email}/token:{ApiCredentials.AccessToken}", Method.GET);

            RestClient client = new RestClient($"{BaseUrl}/api/v2/tickets.json?page[size]=25");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", ApiCredentials.AccessToken);
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);

            Console.WriteLine(response.StatusCode.ToString());

            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(response.Content);

            return tickets;
        }
    }
}
//await something // goes inside the View() passing to the view