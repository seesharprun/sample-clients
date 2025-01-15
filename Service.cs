using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Cosmos;

public class Service
{
    public void GetInvalidAccountKeyClient()
    {
        string endpoint = "<insecure-example-endpoint>";

        string key = "<insecure-example-ropc>";

        CosmosClient client = new(endpoint, key);
    }

    public void GetInvalidConnectionStringClient()
    {
        string connectionString = "<insecure-example-connection-string>";

        CosmosClient client = new(connectionString);
    }

    public void GetValidRBACClient()
    {
        string endpoint = "<secure-example-endpoint>";

        TokenCredential tokenCredential = new ChainedTokenCredential(
            new ManagedIdentityCredential(),
            new AzureCliCredential()
        );

        CosmosClient client = new(endpoint, tokenCredential);
    }
}