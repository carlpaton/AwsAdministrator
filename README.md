### AWS Administrator
AWS infrastructure administration tool. The code based steps below allow for the orchestration of an AWS ECS (Amazon Elastic Container Service) environment using EC2 (Amazon Elastic Cloud Compute) infrastructure.

##### Create VPC (Amazon Virtual Private Cloud)

* `Business\AmazonWebServices\Ec2\VpcService.CreateVpcAsync`
  * CIDR Block = `10.0.0.0/16` which will allow for 65536 IP addresses in the [VPC)](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html)
  * Additional EC2/ECS and infrastructure automatically created with the VPC includes
    * [Security Group](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html)
    * [Route Table](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Route_Tables.html)
    * [DHCP options sets](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_DHCP_Options.html)
    * [Network ACLs](https://docs.aws.amazon.com/vpc/latest/userguide/vpc-network-acls.html)

##### Create Subnet

* `Business\AmazonWebServices\Ec2\SubnetService.CreateSubnetAsync`