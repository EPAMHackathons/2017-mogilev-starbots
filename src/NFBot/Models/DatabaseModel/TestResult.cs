namespace NFBot.Models.DatabaseModel
{
    public class TestResult
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
        public string Result { get; set; }
        public bool IsFinished { get; set; }
    }
}
