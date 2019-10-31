### AWS Administrator
AWS infrastructure administration tool. The code based steps below allow for the orchestration of an AWS ECS (Amazon Elastic Container Service) environment using EC2 (Amazon Elastic Cloud Compute) infrastructure.

**Account**

* https://portal.aws.amazon.com/billing/signup

**User**

* https://console.aws.amazon.com/iam/

**IAM (Identity and Access Management) role**

For tasks using the EC2 launch type, you can create an IAM role that allows the agent to know which account it should register your container instances with. When you launch a container instance with the Amazon ECS-optimized AMI provided by Amazon using this role, the agent automatically registers the container instance into your default cluster. This role is referred to as the Amazon ECS container instance IAM role.

* https://aws.amazon.com/iam/

**Key Pair**

Create a Key Pair under NETWORK & SECURITY, choose Key Pairs.

* https://console.aws.amazon.com/ec2/

**Putty**

To prepare to connect to a Linux instance from Windows using PuTTY. 

* https://www.chiark.greenend.org.uk/~sgtatham/putty/
* https://carlpaton.github.io/2019/09/aws-secure-shell-ssh-to-instance/
* https://carlpaton.github.io/2018/04/putty/

##### VPC (Virtual Private Cloud)

* `IntegrationTest\Ec2\VpcServiceTests.cs`
  * `CreateVpcAsync_should_create_and_return_vpc`

* `Business\AmazonWebServices\Ec2\VpcService.CreateVpcAsync`
  * CIDR Block = `10.0.0.0/16` which will allow for 65536 IP addresses in the [VPC)](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html)
  * Additional EC2/ECS and infrastructure automatically created with the VPC includes
    * [Route Table](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Route_Tables.html)
    * [DHCP options sets](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_DHCP_Options.html)
    * [Network ACLs](https://docs.aws.amazon.com/vpc/latest/userguide/vpc-network-acls.html)
    * [Security Group](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html)

```
aws ec2 describe-vpcs 
aws ec2 create-vpc --cidr-block 10.0.0.0/16
```

**Internet gateway**

* `IntegrationTest\Ec2\InternetGatewayServiceTests.cs`
  * `CreateInternetGatewayAsync_should_create_and_return_internetGateway`

**Attach to VPC**

`IntegrationTest\Ec2\InternetGatewayServiceTests.cs`

- `AttachInternetGatewayAsync_should_attach_give_internetgateway_to_vpc`

**Security Group**

Create a Security Group Choose `HTTP`, `HTTPS`, `SSH` from the Type list, and make sure that Source is set to Anywhere (0.0.0.0/0).

* `IntegrationTest\Ec2\SecurityGroupServiceTests.cs`
  * `DescribeSecurityGroupAsync_when_any_exist_should_describe_security_groups`

* https://console.aws.amazon.com/ec2/
* https://checkip.amazonaws.com/

##### Subnet 1 and 2

* `IntegrationTest\Ec2\SubnetServiceTests.cs`
  * `CreateSubnetAsync_should_create_and_return_subnet`
* `Business\AmazonWebServices\Ec2\SubnetService.CreateSubnetAsync`

**Network Interface**

* `IntegrationTest\Ec2\NetworkInterfaceServiceTests.cs`
  * `CreateNetworkInterfaceAsync_should_create_and_return_nic`

**ECR (Elastic Container Registry)**

* https://aws.amazon.com/ecr/
* https://carlpaton.github.io/2019/09/aws-elastic-container-registry/

**Task Definition**

hoe

**Launch Template**

AMI: Amazon ECS-Optimized Amazon Linux 2 AMI 

* `IntegrationTest\Ec2\LaunchTemplateServiceTests.cs`
  * `CreateLaunchTemplateAsync_should_create_and_return_launchTemplate`

base64 encode the `View User Data` as property `UserData`

```
#!/bin/bash
echo ECS_CLUSTER=lexicon-cluster >> /etc/ecs/ecs.config;echo ECS_BACKEND_HOST= >> /etc/ecs/ecs.config;

this becomes

IyEvYmluL2Jhc2gKZWNobyBFQ1NfQ0xVU1RFUj1sZXhpY29uLWNsdXN0ZXIgPj4gL2V0Yy9lY3MvZWNzLmNvbmZpZztlY2hvIEVDU19CQUNLRU5EX0hPU1Q9ID4+IC9ldGMvZWNzL2Vjcy5jb25maWc7
```

**Run Instance**

* `IntegrationTest\Ec2\InstanceServiceTests.cs`
  * `RunInstancesAsync_should_run_the_given_launchTemplateId`

**Cluster**

* `IntegrationTest\Ecs\ClusterServiceTests.cs`
  * `CreateClusterAsync_should_create_and_return_cluster`

Create a Cluster 

```
aws ecs create-cluster --cluster-name MyCluster arn:aws:ecs:ap-southeast-2:032668436735:cluster/MyCluster
```

List Container Instances 

```
aws ecs list-container-instances --cluster MyCluster
```

### References

* https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ECS_AWSCLI_EC2.html
* https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_container_instance.html