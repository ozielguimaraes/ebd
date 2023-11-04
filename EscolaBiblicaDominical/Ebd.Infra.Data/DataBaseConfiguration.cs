namespace Ebd.Infra.Data
{
    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; }
        public int? TimeoutInSeconds { get; set; }
        public RetryOnFailure RetryOnFailure { get; set; } = new();
    }

    public class RetryOnFailure
    {
        public bool Enable { get; set; }
        public int MaxTimeOutInSeconds { get; set; } = 10;
        public int RetryCount { get; set; } = 3;
    }
}
