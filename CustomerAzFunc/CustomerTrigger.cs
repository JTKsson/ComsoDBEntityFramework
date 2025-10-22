using CloudDB_Assignment2.Data.Entities;
using Microsoft.Azure.Functions.Worker;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CustomerAzFunc;

public class CustomerTrigger
{
   private readonly ISendGridClient _sendGridClient;

    public CustomerTrigger(ISendGridClient sendGridClient)
    {
        _sendGridClient = sendGridClient;
    }

    [Function("CustomerAddTrigger")]
    public async Task Run([CosmosDBTrigger(
        databaseName: "CustomerDB",
        containerName: "Customers",
        Connection = "DBConnString",
        CreateLeaseContainerIfNotExists = true)] IReadOnlyList<Customer> input)
    {
        if (input != null && input.Count > 0)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("jtksson@outlook.com", "Customer Auto Message"),
                Subject = "Customer added",
                PlainTextContent = $"Customer {input[0].FullName} was added." +
                $" Adress: {input[0].Address} " +
                $"Company Title: {input[0].Title} " +
                $"Phone number: {input[0].Phone}"
            };
            msg.AddTo(new EmailAddress($"{input[0].SalesRep.Email}", $"{input[0].SalesRep.Name}"));

            await _sendGridClient.SendEmailAsync(msg);

        }
    }
}