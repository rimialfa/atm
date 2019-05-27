namespace AutomatedTellerMachine.Models
{
    public class Auth
    {
        public bool Status { get; set; }
        public int Attempts { get; set; }
        public string Message { get; set; }
    }
}