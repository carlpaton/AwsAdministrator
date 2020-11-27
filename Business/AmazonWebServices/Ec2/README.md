# EC2 (Elastic Compute Cloud)

**Key Pair**

Create a Key Pair under NETWORK & SECURITY, choose Key Pairs.

* https://console.aws.amazon.com/ec2/

**Putty**

To prepare to connect to a Linux instance from Windows using PuTTY. 

* https://www.chiark.greenend.org.uk/~sgtatham/putty/
* https://carlpaton.github.io/2019/09/aws-secure-shell-ssh-to-instance/
* https://carlpaton.github.io/2018/04/putty/

## VPC (Virtual Private Cloud)

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

## Subnet 1 and 2

* `IntegrationTest\Ec2\SubnetServiceTests.cs`
  * `CreateSubnetAsync_should_create_and_return_subnet`
* `Business\AmazonWebServices\Ec2\SubnetService.CreateSubnetAsync`

**Network Interface**

* `IntegrationTest\Ec2\NetworkInterfaceServiceTests.cs`
  * `CreateNetworkInterfaceAsync_should_create_and_return_nic`

**Task Definition**

Can use image from docker hub or ECR

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

* https://docs.aws.amazon.com/en_pv/AmazonECS/latest/developerguide/bootstrap_container_instance.html

**Run Instance**

* `IntegrationTest\Ec2\InstanceServiceTests.cs`
  * `RunInstancesAsync_should_run_the_given_launchTemplateId`

* https://aws.amazon.com/premiumsupport/knowledge-center/ecs-agent-disconnected/