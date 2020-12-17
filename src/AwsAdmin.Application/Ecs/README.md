# ECS (Elastic Container Service)

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

* https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ECS_AWSCLI_EC2.html
* https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_container_instance.html