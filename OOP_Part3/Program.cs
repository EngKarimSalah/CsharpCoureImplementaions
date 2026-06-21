using OOP_Part3;
using OOP_Part3.Models;

namespace OOP_Part3
{
    public class Program
    {
        public static HospitalContext context = new HospitalContext()
        {
            Patients = new List<Patient>(),
            Doctors = new List<Doctor>(),
            Appointments = new List<Appointment>(),
            MedicalRecords = new List<MedicalRecord>(),
            AvailableSlots = new List<AvailableSlot>()
        };

        // ─────────────────────────────────────────────────────────────────────
        // EASY 01 — Patient Registration
        // ─────────────────────────────────────────────────────────────────────
        public static void RegisterPatient()
        {
            Console.WriteLine("\n=== Register New Patient ===");

            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            Console.Write("Enter patient age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter patient gender (Male/Female): ");
            string gender = Console.ReadLine();

            Console.Write("Enter patient phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter patient email: ");
            string email = Console.ReadLine();

            Console.Write("Enter patient blood type (e.g. A+, O-): ");
            string bloodType = Console.ReadLine();

            int patientId = context.Patients.Count + 1;

            context.Patients.Add(

                new Patient
                {
                    patientId = patientId,
                    patientName = name,
                    patientAge = age,
                    patientGender = gender,
                    patientEmail = email,
                    patientPhone = phone,
                    patientBloodType = bloodType

                }

                );

            Console.WriteLine($"Patient registered successfully. Assigned ID: {patientId}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // EASY 02 — Add a New Doctor
        // ─────────────────────────────────────────────────────────────────────
        public static void AddDoctor()
        {
            Console.WriteLine("\n=== Add New Doctor ===");

            Console.Write("Enter doctor name: ");
            string name = Console.ReadLine();

            Console.Write("Enter specialization: ");
            string specialization = Console.ReadLine();

            Console.Write("Enter doctor phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter doctor email: ");
            string email = Console.ReadLine();

            Console.Write("Enter consultation fee: ");
            decimal fee = decimal.Parse(Console.ReadLine());

            int doctorId = context.Doctors.Count + 1;

            context.Doctors.Add(new Doctor
            {
                doctorId = doctorId,
                doctorName = name,
                doctorSpecialization = specialization,
                doctorPhone = phone,
                doctorEmail = email,
                consultationFee = fee
            });

            Console.WriteLine($"Doctor added successfully. Assigned ID: {doctorId}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // EASY 03 — View All Patients
        // ─────────────────────────────────────────────────────────────────────
        public static void ViewAllPatients()
        {
            Console.WriteLine("\n=== All Registered Patients ===");

            foreach (Patient p in context.Patients)
            {
                Console.WriteLine($"ID: {p.patientId}  |  Name: {p.patientName}  |  Age: {p.patientAge}" +
                                  $"  |  Gender: {p.patientGender}  |  Blood Type: {p.patientBloodType}" +
                                  $"  |  Phone: {p.patientPhone}  |  Email: {p.patientEmail}");
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // EASY 04 — View Doctors by Specialization
        // ─────────────────────────────────────────────────────────────────────
        public static void ViewDoctorsBySpecialization()
        {
            Console.WriteLine("\n=== Search Doctors by Specialization ===");

            Console.Write("Enter specialization to search: ");
            string input = Console.ReadLine().ToLower();

            List<Doctor> matched = context.Doctors
                                   .Where(d => d.doctorSpecialization.ToLower() == input)
                                   .ToList();

            foreach (Doctor d in matched)
            {
                Console.WriteLine($"ID: {d.doctorId}  |  Name: {d.doctorName}" +
                                  $"  |  Phone: {d.doctorPhone}  |  Fee: {d.consultationFee:C}");
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // MEDIUM 05 — Add an Available Time Slot for a Doctor
        // ─────────────────────────────────────────────────────────────────────
        public static void AddAvailableSlot()
        {
            Console.WriteLine("\n=== Add Available Slot for Doctor ===");

            foreach (Doctor d in context.Doctors)
            {
                Console.WriteLine($"  ID: {d.doctorId}  |  {d.doctorName}  ({d.doctorSpecialization})");
            }

            Console.Write("Enter doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter slot date (e.g. 2026-07-10): ");
            string date = Console.ReadLine();

            Console.Write("Enter slot time (e.g. 10:00 AM): ");
            string time = Console.ReadLine();

            int slotId = context.AvailableSlots.Count + 1;

            context.AvailableSlots.Add(new AvailableSlot
            {
                slotId = slotId,
                doctorId = doctorId,
                slotDate = date,
                slotTime = time,
                isBooked = false
            });

            Console.WriteLine($"Slot added successfully.");
        }

        // ─────────────────────────────────────────────────────────────────────
        // MEDIUM 06 — Book an Appointment
        // ─────────────────────────────────────────────────────────────────────
        public static void BookAppointment()
        {
            Console.WriteLine("\n=== Book an Appointment ===");

            Console.Write("Enter your patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            ViewDoctorsBySpecialization();

            Console.Write("Enter doctor ID to book with: ");
            int doctorId = int.Parse(Console.ReadLine());

            List<AvailableSlot> openSlots = context.AvailableSlots
                .Where(s => s.doctorId == doctorId && s.isBooked == false)
                .ToList();

            Console.WriteLine($"\nAvailable slots :");
            foreach (AvailableSlot s in openSlots)
            {
                Console.WriteLine($"  Slot ID: {s.slotId}  |  Date: {s.slotDate}  |  Time: {s.slotTime}");
            }

            Console.Write("Enter slot ID to book: ");
            int slotId = int.Parse(Console.ReadLine());

            AvailableSlot selectedSlot = openSlots.FirstOrDefault(s => s.slotId == slotId);

            int appointmentId = context.Appointments.Count + 1;

            context.Appointments.Add(new Appointment
            {
                appointmentId = appointmentId,
                patientId = patientId,
                doctorId = doctorId,
                slotId = slotId,
                appointmentDate = selectedSlot.slotDate,
                appointmentTime = selectedSlot.slotTime,
                status = "Scheduled"
            });

            selectedSlot.isBooked = true;

            Console.WriteLine($"Appointment booked successfully! Appointment ID: {appointmentId}" +
                              $" | Date: {selectedSlot.slotDate} | Time: {selectedSlot.slotTime}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // MEDIUM 07 — Cancel an Appointment
        // ─────────────────────────────────────────────────────────────────────
        public static void CancelAppointment()
        {
            Console.WriteLine("\n=== Cancel an Appointment ===");

            Console.Write("Enter appointment ID to cancel: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Appointment appointment = context.Appointments.FirstOrDefault(a => a.appointmentId == appointmentId);

            AvailableSlot slot = context.AvailableSlots
                                .FirstOrDefault(s => s.slotId == appointment.slotId);

            slot.isBooked = false;

            appointment.status = "Cancelled";

            Console.WriteLine($"Appointment {appointmentId} has been cancelled and the time slot is now available again.");
        }

        // ─────────────────────────────────────────────────────────────────────
        // MEDIUM 08 — Create a Medical Record After a Visit
        // ─────────────────────────────────────────────────────────────────────
        public static void CreateMedicalRecord()
        {
            Console.WriteLine("\n=== Create Medical Record ===");

            Console.Write("Enter appointment ID for this visit: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Console.Write("Enter diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter prescription / medication: ");
            string prescription = Console.ReadLine();


            Appointment appointment = context.Appointments
                          .FirstOrDefault(a => a.appointmentId == appointmentId);

            decimal fee = context.Doctors
                          .Where(d => d.doctorId == appointment.doctorId)
                          .Select(d => d.consultationFee)
                          .FirstOrDefault();

            int recordId = context.MedicalRecords.Count + 1;

            context.MedicalRecords.Add(new MedicalRecord
            {
                recordId = recordId,
                appointmentId = appointmentId,
                patientId = appointment.patientId,
                doctorId = appointment.doctorId,
                visitDate = appointment.appointmentDate,
                diagnosis = diagnosis,
                prescription = prescription,
                visitFee = fee
            });

            appointment.status = "Completed";

            Console.WriteLine($"Medical record created successfully. Record ID: {recordId}" +
                              $" | Fee charged: {fee:C}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // HARD 09 — Patient Medical History Report
        // ─────────────────────────────────────────────────────────────────────
        public static void PatientMedicalHistory()
        {
            Console.WriteLine("\n=== Patient Medical History Report ===");

            Console.Write("Enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            List<MedicalRecord> records = context.MedicalRecords
                .Where(r => r.patientId == patientId)
                .ToList();

            Console.WriteLine($"\n--- Medical History for (ID: {patientId}) ---");

            foreach (MedicalRecord r in records)
            {
                Console.WriteLine($"\n  Record ID   : {r.recordId}");
                Console.WriteLine($"  Visit Date  : {r.visitDate}");
                Console.WriteLine($"  Doctor      : {r.doctorId}");
                Console.WriteLine($"  Diagnosis   : {r.diagnosis}");
                Console.WriteLine($"  Prescription: {r.prescription}");
                Console.WriteLine($"  Fee Charged : {r.visitFee:C}");
            }

            decimal totalCharged = records.Sum(r => r.visitFee);
            Console.WriteLine($"\n  TOTAL AMOUNT CHARGED: {totalCharged:C}");
        }

        // ─────────────────────────────────────────────────────────────────────
        // HARD 10 — Doctor Workload and Revenue Summary
        // ─────────────────────────────────────────────────────────────────────
        public static void DoctorRevenueSummary()
        {
            Console.WriteLine("\n=== Doctor Workload & Revenue Summary ===");

            var summary = context.Doctors
                .Select(d => new
                {
                    d.doctorName,
                    d.doctorSpecialization,
                    completed = context.Appointments.Count(a => a.doctorId == d.doctorId && a.status == "Completed"),
                    cancelled = context.Appointments.Count(a => a.doctorId == d.doctorId && a.status == "Cancelled"),
                    totalRevenue = context.MedicalRecords
                                       .Where(r => r.doctorId == d.doctorId)
                                       .Sum(r => r.visitFee)
                })
                .OrderByDescending(x => x.totalRevenue)
                .ToList();

            Console.WriteLine("\n  Rank  | Doctor Name               | Specialization       | Completed | Cancelled | Total Revenue");

            for (int i = 0; i < summary.Count; i++)
            {
                var x = summary[i];
                Console.WriteLine($"  #{i + 1,-5} | {x.doctorName,-25} | {x.doctorSpecialization,-20} |" +
                                  $" {x.completed,-9} | {x.cancelled,-9} | {x.totalRevenue:C}");
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // MAIN — Menu Loop
        // ─────────────────────────────────────────────────────────────────────
        static void Main(string[] args)
        {
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   Hospital Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - Register Patient");
                Console.WriteLine(" 2  - Add Doctor");
                Console.WriteLine(" 3  - View All Patients");
                Console.WriteLine(" 4  - View Doctors by Specialization");
                Console.WriteLine(" 5  - Add Available Slot for Doctor");
                Console.WriteLine(" 6  - Book an Appointment");
                Console.WriteLine(" 7  - Cancel an Appointment");
                Console.WriteLine(" 8  - Create Medical Record");
                Console.WriteLine(" 9  - Patient Medical History Report");
                Console.WriteLine(" 10 - Doctor Workload & Revenue Summary");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterPatient(); break;
                    case 2: AddDoctor(); break;
                    case 3: ViewAllPatients(); break;
                    case 4: ViewDoctorsBySpecialization(); break;
                    case 5: AddAvailableSlot(); break;
                    case 6: BookAppointment(); break;
                    case 7: CancelAppointment(); break;
                    case 8: CreateMedicalRecord(); break;
                    case 9: PatientMedicalHistory(); break;
                    case 10: DoctorRevenueSummary(); break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}