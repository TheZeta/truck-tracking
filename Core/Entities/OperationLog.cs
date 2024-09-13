namespace Core.Entities
{
    public class OperationLog
    {
        public int Id { get; set; }
        public string OperationType { get; set; }
        public string AffectedEntity { get; set; }
        public int AffectedEntityId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
    }
}
