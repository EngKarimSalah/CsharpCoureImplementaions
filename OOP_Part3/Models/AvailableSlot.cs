namespace OOP_Part3.Models
{
    public class AvailableSlot
    {
        public int slotId { get; set; }
        public int doctorId { get; set; }
        public string slotDate { get; set; }
        public string slotTime { get; set; }
        public bool isBooked { get; set; }
    }
}
