using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Newtonsoft.Json;

namespace DynamoDBCoursera
{
    public class DynamoOperations
    {
        public DynamoOperations()
        {
        }

        public void UploadExample()
        {
            var cred = CredentialManagement.GetCredentials();
            using var dynamodbClient = new AmazonDynamoDBClient(cred);

            var putItemRequest = new PutItemRequest();
            putItemRequest.TableName = "Lab1Table";
            putItemRequest.Item = new Dictionary<string, AttributeValue>()
            {
                {"DragonName", new AttributeValue("sparky")},
                {"DragonType", new AttributeValue("green")},
                {"Description", new AttributeValue("breathes acid")},
                {"Attack", new AttributeValue("10")},
                {"Defense", new AttributeValue("7")},
            };
            
            var task = dynamodbClient.PutItemAsync(putItemRequest);
            task.Wait();
            
            putItemRequest.Item = new Dictionary<string, AttributeValue>()
            {
                {"DragonName", new AttributeValue("tallie")},
                {"DragonType", new AttributeValue("red")},
                {"Description", new AttributeValue("breathes fire")},
                {"Attack", new AttributeValue("7")},
                {"Defense", new AttributeValue("10")},
            };
            
            task = dynamodbClient.PutItemAsync(putItemRequest);
            task.Wait();




        }

        public void BatchUploadExample()
        {
            
            var cred = CredentialManagement.GetCredentials();
            using var dynamodbClient = new AmazonDynamoDBClient(cred);
            
            var bwir = new BatchWriteItemRequest();
            bwir.RequestItems = new Dictionary<string, List<WriteRequest>>()
            {
                { 
                    "Lab1Table",  
                    new List<WriteRequest>() {
                        new WriteRequest()
                        {
                            PutRequest = new PutRequest() 
                            {
                                Item = new Dictionary<string, AttributeValue>()
                                {
                                    {"DragonName", new AttributeValue("tallie")},
                                    {"DragonType", new AttributeValue("red")},
                                    {"Description", new AttributeValue("breathes fire")},
                                    {"Attack", new AttributeValue("7")},
                                    {"Defense", new AttributeValue("10")},
                                }
                            }
                        },
                        new WriteRequest()
                        {
                            PutRequest = new PutRequest() 
                            {
                                Item = new Dictionary<string, AttributeValue>()
                                {
                                    {"DragonName", new AttributeValue("sparky")},
                                    {"DragonType", new AttributeValue("green")},
                                    {"Description", new AttributeValue("breathes acid")},
                                    {"Attack", new AttributeValue("10")},
                                    {"Defense", new AttributeValue("7")},
                                }
                            }
                        }
                    }
                }
            };

            var task = dynamodbClient.BatchWriteItemAsync(bwir);
            task.Wait();
        }
        
        public void ScanTable()
        {
            var cred = CredentialManagement.GetCredentials();
            using var dynamodbClient = new AmazonDynamoDBClient(cred);

            var scanRequest = new ScanRequest();
            scanRequest.TableName = "Lab1Table";


            var task = dynamodbClient.ScanAsync(scanRequest);
            task.Wait();
            
            Console.WriteLine($"Scan result: ");

            var result = task.Result.Items;

            foreach (var values in result)
            {
                Console.WriteLine($"Item: {values["DragonName"].S}");
                foreach (var pair in values)
                {
                    Console.WriteLine($"\t{pair.Key}: {pair.Value.S}");
                }
            }

            var jsonOutput = JsonConvert.SerializeObject(result);
            
            Console.WriteLine(jsonOutput);
            
            File.WriteAllText("data.json", jsonOutput);

            // task.Result.Items.Select(values => values.Select(pair => Console.WriteLine($"{pair.Key}: {pair.Value}")));
        }


        public void QueryItem(string dragonName)
        {
            var cred = CredentialManagement.GetCredentials();
            using var dynamodbClient = new AmazonDynamoDBClient(cred);

            var queryRequest = new QueryRequest();
            queryRequest.TableName = "Lab1Table";
            queryRequest.KeyConditionExpression = "DragonName = :v_dragonName";
            queryRequest.ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
            {
                {
                    ":v_dragonName",
                    new AttributeValue(){ S = dragonName}
                }
            };

            var task = dynamodbClient.QueryAsync(queryRequest);
            task.Wait();

            var result = task.Result.Items;

            foreach (var values in result)
            {
                Console.WriteLine($"Item: {values["DragonName"].S}");
                foreach (var pair in values)
                {
                    Console.WriteLine($"\t{pair.Key}: {pair.Value.S}");
                }
            }
        }
        
    }
}