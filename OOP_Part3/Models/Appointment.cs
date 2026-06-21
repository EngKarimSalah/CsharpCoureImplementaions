namespace OOP_Part3.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public int slotId { get; set; }
        public string appointmentDate { get; set; }
        public string appointmentTime { get; set; }
        public string status { get; set; }   // "Scheduled" | "Completed" | "Cancelled"
    }
}
