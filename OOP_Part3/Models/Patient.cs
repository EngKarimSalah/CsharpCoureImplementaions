namespace OOP_Part3.Models
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }

    
        public void printInfo()
        {
            Console.WriteLine($"ID: {patientId}  |  Name: {patientName}  |  Age: {patientAge}" +
                                 $"  |  Gender: {patientGender}  |  Blood Type: {patientBloodType}" +
                                 $"  |  Phone: {patientPhone}  |  Email: {patientEmail}");

        }

    }
}
