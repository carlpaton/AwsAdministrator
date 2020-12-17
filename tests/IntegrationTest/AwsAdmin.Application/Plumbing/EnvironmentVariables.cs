using Amazon;
using Amazon.EC2;
using Amazon.ECR;
using Amazon.ECS;
using Amazon.S3;

namespace IntegrationTest.AwsAdmin.Application.Plumbing
{
    public class EnvironmentVariables
    {
        private readonly string _awsAccessKeyId = "";
        private readonly string _awsSecretAccessKey = "";
        private readonly RegionEndpoint _region;

        public EnvironmentVariables() 
        {
            //System.Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", "hoe");
            //System.Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", "bar");
            //System.Environment.SetEnvironmentVariable("AWS_REGION", "us-west-2"); // ap-southeast-2
        }

        public EnvironmentVariables(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
        {
            _awsAccessKeyId = awsAccessKeyId;
            _awsSecretAccessKey = awsSecretAccessKey;
            _region = region;
        }

        public AmazonEC2Client CloudComputeClient() 
        {
            // Assume dev machine, return `C:\Users\[USERNAME]\.aws\credentials` which is what AWS CLI is using.
            if (_awsAccessKeyId == "" || _awsSecretAccessKey == "")
                return new AmazonEC2Client();

            return new AmazonEC2Client(_awsAccessKeyId, _awsSecretAccessKey);
        }

        public AmazonECSClient ContainerServiceClient()
        {
            if (_awsAccessKeyId == "" || _awsSecretAccessKey == "")
                return new AmazonECSClient();

            return new AmazonECSClient(_awsAccessKeyId, _awsSecretAccessKey);
        }

        public AmazonECRClient ContainerRegistryClient()
        {
            if (_awsAccessKeyId == "" || _awsSecretAccessKey == "")
                return new AmazonECRClient();

            return new AmazonECRClient(_awsAccessKeyId, _awsSecretAccessKey);
        }

        public AmazonS3Client S3BucketClient()
        {
            if (_awsAccessKeyId == "" || _awsSecretAccessKey == "")
                return new AmazonS3Client();

            return new AmazonS3Client(_awsAccessKeyId, _awsSecretAccessKey, _region);
        }
    }
}
