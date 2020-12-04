using Amazon.S3.Model;
using System.Collections.Generic;

namespace Business.AmazonWebServices.S3.Builder
{
    public class PutObjectRequestBuilder
    {
        private readonly string _bucketName;
        private readonly string _key;
        private readonly string _contentBody;
        private readonly List<Tag> _tagSet;
        private readonly List<MetaData> _metaData;

        public PutObjectRequestBuilder(string bucketName, string key, string contentBody) 
        {
            _bucketName = bucketName;
            _key = key;
            _contentBody = contentBody;
            _tagSet = new List<Tag>();
            _metaData = new List<MetaData>();
        }

        public PutObjectRequestBuilder WithTag(string key, string value)
        {
            _tagSet.Add(new Tag { Key = key, Value = value });
            return this;
        }

        public PutObjectRequestBuilder WithMetadata(string name, string value)
        {
            _metaData.Add(new MetaData { Name = name, Value = value });
            return this;
        }

        public PutObjectRequest Create()
        {
            var putObjectRequest = new PutObjectRequest()
            {
                BucketName = _bucketName,
                Key = _key,
                ContentBody = _contentBody,
                TagSet = _tagSet,
            };

            foreach (var metadata in _metaData)
            {
                putObjectRequest
                    .Metadata
                    .Add($"x-amz-meta-{metadata.Name}", metadata.Value);
            }

            return putObjectRequest;
        }

        private class MetaData 
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
