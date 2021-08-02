using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zcc_tickets.Models;

namespace zcc_tickets.Controllers
{
    public class TicketsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var TicketsRoot = await GetTicketsAsync();
            return View(TicketsRoot);
        }

        public static async Task<Root> GetTicketsAsync()
        {
            const string EncodedKey = "a2V2aW5yYW1pcmV6Y3MxOTk3QGdtYWlsLmNvbS90b2tlbjpraHJiWkJVYXJ4dWlwZlVRdEZNS09sOVltTUV3RDZoMU8zWjc3UXRZ";
            const string BaseUrl = "https://zcctickets.zendesk.com";

            RestClient client = new RestClient($"{BaseUrl}/api/v2");
            RestRequest request = new RestRequest($"/tickets.json?page[size]=25", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {EncodedKey}");

            var response = await client.ExecuteAsync(request);
            var Tickets = JsonConvert.DeserializeObject<Root>(response.Content); 

            return Tickets;
        }

    }
}
