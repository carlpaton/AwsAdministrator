# AWS Administrator
AWS infrastructure administration tool uses the [AWS SDK for .NET Version 3](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html)

These services are a proof of concept facade. This means they simply wrap the massive AWS SDK and group the responsibilities in a cohesive manner. The methods return ASW SDK types where your production code would be returning your own entities for your application.

- [Auto Scaling](https://github.com/carlpaton/AwsAdministrator/tree/master/Business/AmazonWebServices/Autoscaling)
- [EC2 (Elastic Compute Cloud)](https://github.com/carlpaton/AwsAdministrator/tree/master/Business/AmazonWebServices/Ec2)
- [ECS (Elastic Container Service)](https://github.com/carlpaton/AwsAdministrator/tree/master/Business/AmazonWebServices/Ecs)
- [ECR (Elastic Container Registry)](https://github.com/carlpaton/AwsAdministrator/tree/master/Business/AmazonWebServices/Ecr)
- [S3 (Simple Storage Service)](https://github.com/carlpaton/AwsAdministrator/tree/master/Business/AmazonWebServices/S3)

## Account

- https://carlpaton.github.io/2019/09/aws-install-and-configure-cli/

### Root user

Account owner that performs tasks requiring unrestricted access, this mu

### IAM user

User within an account that performs daily tasks.

- https://aws.amazon.com/iam/

#### Groups

Groups are the preferred way to apply policies to IAM Users. The following policies were applied to my IAM User to run this application:

- AmazonEC2FullAccess
- AmazonS3FullAccess

For production code more granular access would be used.

### IAM Roles

IAM roles are a secure way to grant permissions to entities that you trust.