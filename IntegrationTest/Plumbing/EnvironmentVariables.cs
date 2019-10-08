namespace IntegrationTest.Plumbing
{
    public class EnvironmentVariables
    {
        public EnvironmentVariables() 
        {
            //this didnt work. lol
            //if this code does auth to aws, its probably reading `C:\Users\[USERNAME]\.aws\credentials` which is what your AWS CLI is using

            //System.Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", "hoe");
            //System.Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", "bar");
        }
    }
}
