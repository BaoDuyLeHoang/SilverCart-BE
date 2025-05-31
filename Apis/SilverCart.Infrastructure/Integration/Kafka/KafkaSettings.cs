namespace SilverCart.Infrastructure.Integration.Kafka;

public class KafkaSettings
{
    public string BootstrapServers { get; set; } = string.Empty;
    public string GroupId { get; set; } = string.Empty;
    public string OrdersTopic { get; set; } = string.Empty;
    public int MessageTimeoutMs { get; set; } = 30000;
    public bool EnableAutoCommit { get; set; } = false;
    public bool EnablePartitionEof { get; set; } = false;
    public string SecurityProtocol { get; set; } = "PLAINTEXT";
    public string SaslMechanism { get; set; } = "PLAIN";
    public string SaslUsername { get; set; } = string.Empty;
    public string SaslPassword { get; set; } = string.Empty;
}