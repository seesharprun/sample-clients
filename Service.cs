using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Cosmos;

public class Service
{
    public void GetInvalidClient()
    {
        string endpoint = "<example-endpoint>";

        string key = "<example-key>";

        CosmosClient client = new(endpoint, key);
    }

    public void GetValidClient()
    {
        string endpoint = "<example-endpoint>";

        TokenCredential tokenCredential = new ChainedTokenCredential(
            new ManagedIdentityCredential(),
            new AzureCliCredential()
        );

        CosmosClient client = new(endpoint, tokenCredential);
    }
}