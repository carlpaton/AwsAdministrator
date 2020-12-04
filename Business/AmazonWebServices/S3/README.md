# S3 (Simple Storage Service)

## Bucket Service

**Interface**: `IBucketService`

### PutBucketAsync

Creates the given bucket, note that buckets are globally unique in name.
Will throw if the bucket already exists:

- `Amazon.S3.AmazonS3Exception : Your previous request to create the named bucket succeeded and you already own it.`
- `Amazon.S3.AmazonS3Exception : The requested bucket name is not available. The bucket namespace is shared by all users of the system. Please select a different name and try again.`

- `bucketName` - Globally unique bucket name

```c#
Task<PutBucketResponse> PutBucketAsync(string bucketName);
```

### ListBucketsAsync

Gets a list of buckets for the authenticated user

```c#
Task<ListBucketsResponse> ListBucketsAsync();
```

CLI

```
aws s3 ls
```

- https://docs.aws.amazon.com/cli/latest/reference/s3/ls.html

### DeleteBucketAsync

Deletes the given bucket, will throw if its not empty.
- `Amazon.S3.AmazonS3Exception : The bucket you tried to delete is not empty`

```c#
Task<DeleteBucketResponse> DeleteBucketAsync(string bucketName);
```

- https://docs.aws.amazon.com/AmazonS3/latest/dev/DeletingOneObjectUsingNetSDK.html

## Bucket Object Service

**Interface**: `IBucketObjectService`

### GetPreSignedURL

Create a signed URL allowing access to a resource that would usually require authentication.

- `expireInHours` hours in the future in which the URL will expire

```c#
string GetPreSignedURL(string bucketName, string key, double expireInHours);
```

- https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/S3/MS3GetPreSignedURLGetPreSignedUrlRequest.html

### PutTextObjectAsync

Put the plaintext object in the S3 bucket. The content type will be set to 'text/plain'.

```c#
Task<PutObjectResponse> PutTextObjectAsync(string bucketName, string key, string contentBody);
```

- [Object Tagging](https://docs.aws.amazon.com/AmazonS3/latest/dev/object-tagging.html)
- [Object Metadata](https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingMetadata.html#object-metadata)

### GetObjectAsync

Get the value of the object on the bucket by reading `response.ResponseStream`

```c#
Task<GetObjectResponse> GetObjectAsync(string bucketName, string key);
```

### GetObjectMetadataAsync

Retrieves metadata from an object without returning the object itself.

I think this is used as HTTP header data.

```c#
Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key);
```

### DeleteObjectAsync

Deletes the given object (key).

```c#
Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName, string key);
```

### GetObjectTaggingAsync

Gets the tags as `response.Tagging`

```c#
Task<GetObjectTaggingResponse> GetObjectTaggingAsync(string bucketName, string key);
```

### ListObjectsAsync

Gets data about the objects as `response.S3Objects` where `.Key` is the filename
```c#
Task<ListObjectsResponse> ListObjectsAsync(string bucketName);
```