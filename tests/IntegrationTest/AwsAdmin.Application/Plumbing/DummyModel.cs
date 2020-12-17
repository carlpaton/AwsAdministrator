using System;

namespace IntegrationTest.AwsAdmin.Application.Plumbing
{
    public class DummyModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
