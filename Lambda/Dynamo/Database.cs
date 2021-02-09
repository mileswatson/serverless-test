using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace Functions.Dynamo
{
    public class Database
    {
        public string demoTable = Environment.GetEnvironmentVariable("DEMO_TABLE");

        public async Task Add(string pk, string password)
        {
            using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
            {
                Document newItem = new Document();
                newItem["pk"] = pk;
                newItem["password"] = password;

                Table items = Table.LoadTable(ddbClient, demoTable, DynamoDBEntryConversion.V2);
                await items.PutItemAsync(newItem);
            }
        }

        public async Task<string> Get(string pk)
        {
            using (IAmazonDynamoDB ddbClient = new AmazonDynamoDBClient())
            {
                Table items = Table.LoadTable(ddbClient, demoTable, DynamoDBEntryConversion.V2);
                var doc = await items.GetItemAsync(pk);
                return doc["pk"];
            }
        }
    }
}