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
        private static readonly string EncodedKey = "a2V2aW5yYW1pcmV6Y3MxOTk3QGdtYWlsLmNvbS90b2tlbjpraHJiWkJVYXJ4dWlwZlVRdEZNS09sOVltTUV3RDZoMU8zWjc3UXRZ";
        private static readonly string BaseUrl = "https://zcctickets.zendesk.com";
        private static readonly string TicketPageSize = "25";
        private static Root TicketsRoot;

        public async Task<IActionResult> Index()
        {
            TicketsRoot = await GetTicketsFirstPageAsync();

            return View(TicketsRoot);
        }

        public async Task<IActionResult> TicketsNext()
        {
            TicketsRoot = await GetTicketsNextPageAsync();

            return View("Index", TicketsRoot);
        }

        public async Task<IActionResult> TicketsPrev()
        {
            TicketsRoot = await GetTicketsPrevPageAsync();

            return View("Index", TicketsRoot);
        }


        public IActionResult ViewTicket(int id)
        {
            return View(TicketsRoot.tickets[id]);
        }

        public static async Task<Root> GetTicketsFirstPageAsync()
        {
                RestClient client = new RestClient($"{BaseUrl}/api/v2");
                RestRequest request = new RestRequest($"/tickets.json?page[size]={TicketPageSize}", Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Basic {EncodedKey}");

                var response = await client.ExecuteAsync(request);

                var Tickets = JsonConvert.DeserializeObject<Root>(response.Content);

                return Tickets;
        }

        public static async Task<Root> GetTicketsNextPageAsync()
        { 
            if(TicketsRoot.meta.has_more)
            {
                RestClient client = new RestClient($"{BaseUrl}/api/v2");
                RestRequest request = new RestRequest($"{TicketsRoot.links.next}"[38..], Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Basic {EncodedKey}");

                var response = await client.ExecuteAsync(request);
                var Tickets = JsonConvert.DeserializeObject<Root>(response.Content);

                return Tickets;
            }
            return null;
        }

        public static async Task<Root> GetTicketsPrevPageAsync()
        {
                RestClient client = new RestClient($"{BaseUrl}/api/v2");
                RestRequest request = new RestRequest($"{TicketsRoot.links.prev}"[38..], Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Basic {EncodedKey}");

                var response = await client.ExecuteAsync(request);
                var Tickets = JsonConvert.DeserializeObject<Root>(response.Content);

                return Tickets;
        }

    }
}
