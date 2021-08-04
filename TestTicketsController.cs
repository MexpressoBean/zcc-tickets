using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using zcc_tickets.Controllers;
using zcc_tickets.Models;

namespace UnitTests_zcc_tickets
{
    [TestFixture]
    public class TestTicketsController
    {
        [Test]
        public async Task GetTicketsFirstPageAsync_ShouldReturnFirst25Tickets()
        {
            Root testRoot = await TicketsController.GetTicketsFirstPageAsync();
            Assert.That(testRoot.tickets[0].id == 1);
        }

        [Test]
        public async Task GetTicketsFirstPageAsync_ShouldReturnOnly25Tickets()
        {
            Root testRoot = await TicketsController.GetTicketsFirstPageAsync();
            Assert.That(testRoot.tickets.Count == 25);
        }

        [Test]
        public async Task GetTicketsFirstPageAsync_TicketsListContainsTicketObjects()
        {
            Root testRoot = await TicketsController.GetTicketsFirstPageAsync();
            Assert.IsNotNull(testRoot.tickets);
        }

        [Test]
        public async Task GetTicketsFirstPageAsync_ApiResponseContainsData()
        {
            RestClient client = new RestClient($"https://zcctickets.zendesk.com/api/v2");
            RestRequest request = new RestRequest($"/tickets.json?page[size]=25", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic a2V2aW5yYW1pcmV6Y3MxOTk3QGdtYWlsLmNvbS90b2tlbjpraHJiWkJVYXJ4dWlwZlVRdEZNS09sOVltTUV3RDZoMU8zWjc3UXRZ");

            var response = await client.ExecuteAsync(request);

            Assert.IsNotNull(response.Content);
        }

        [Test]
        public async Task GetTicketsFirstPageAsync_ApiNotAuthenticated()
        {
            RestClient client = new RestClient($"https://zcctickets.zendesk.com/api/v2");
            RestRequest request = new RestRequest($"/tickets.json?page[size]=25", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic ");

            var response = await client.ExecuteAsync(request);

            Assert.True(!response.IsSuccessful);
        }
    }
}