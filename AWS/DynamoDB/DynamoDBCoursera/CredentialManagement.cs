using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace DynamoDBCoursera
{
    public static class CredentialManagement
    {
        public static AWSCredentials GetCredentials()
        {
            var chain = new CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials("maoneng-sandbox", out AWSCredentials result))
            {
                return result;
            }
            else
            {
                return new EnvironmentVariablesAWSCredentials();
            }
        }
    }
}