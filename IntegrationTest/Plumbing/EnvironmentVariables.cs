using Amazon.EC2;

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

        public AmazonEC2Client GetAmazonEC2Client() 
        {
            // Assume dev machine, return `C:\Users\[USERNAME]\.aws\credentials` which is what AWS CLI is using.
            if (awsAccessKeyId == "" || awsSecretAccessKey == "")
                return new AmazonEC2Client();

            return new AmazonEC2Client(awsAccessKeyId, awsSecretAccessKey);
        }
    }
}
