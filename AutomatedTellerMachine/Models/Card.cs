namespace AutomatedTellerMachine.Models
{
    public class Card
    {
        public string CardNumber { get; set; }
        public bool IsReported { get; set; }
        public bool IsRetained { get; set; }
    }
}