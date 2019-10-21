using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;

namespace IntegrationTest.Plumbing
{
    public class EnvironmentVariables
    {
        private readonly string awsAccessKeyId = "";
        private readonly string awsSecretAccessKey = "";

        public EnvironmentVariables() 
        {
            //System.Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", "hoe");
            //System.Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", "bar");
        }

        public AmazonEC2Client CloudComputeClient() 
        {
            // Assume dev machine, return `C:\Users\[USERNAME]\.aws\credentials` which is what AWS CLI is using.
            if (awsAccessKeyId == "" || awsSecretAccessKey == "")
                return new AmazonEC2Client();

            return new AmazonEC2Client(awsAccessKeyId, awsSecretAccessKey);
        }

        public AmazonECSClient ContainerServiceClient()
        {
            if (awsAccessKeyId == "" || awsSecretAccessKey == "")
                return new AmazonECSClient();

            return new AmazonECSClient(awsAccessKeyId, awsSecretAccessKey);
        }

        public AmazonECRClient ContainerRegistryClient()
        {
            if (awsAccessKeyId == "" || awsSecretAccessKey == "")
                return new AmazonECRClient();

            return new AmazonECRClient(awsAccessKeyId, awsSecretAccessKey);
        }
    }
}
