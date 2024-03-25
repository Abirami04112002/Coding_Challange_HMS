using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal class ApointmentService
    {
        public ApointmentService() { }
        
        AppointmentRepository appointmentRepository= new AppointmentRepository();
        HospitalManagementImpl hospitalManagementImpl= new HospitalManagementImpl();
        public void AppointmetDirectory()

        {
            int choice = 0;
            do
            {
                Console.WriteLine("****Appointment Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: getAppointmentById\n2: getAppointmentsForPatient\n3: getAppointmentsForDoctor\n4.scheduleAppointment\n5. updateAppointment\n6. CancelAppointment\n7. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Enter the Appointmentid details to get::");
                        int appointid=int.Parse(Console.ReadLine());
                        Appointments ap=new Appointments();
                        ap=hospitalManagementImpl.getAppointmentById(appointid);
                        Console.WriteLine(ap.ToString());
                        break;

                    case 2:
                        Console.WriteLine("Enter the patientid details to get::");
                        int patientid = int.Parse(Console.ReadLine());
                        List<Appointments> appointments = new List<Appointments>();
                        appointments= hospitalManagementImpl.getAppointmentsForPatient(patientid);
                        foreach(Appointments op in appointments)
                        {
                            Console.WriteLine(op);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the doctor id details to get::");
                        int doctor = int.Parse(Console.ReadLine());
                        List<Appointments> appointments1 = new List<Appointments>();
                        appointments1 = hospitalManagementImpl.getAppointmentsForPatient(doctor);
                        foreach (Appointments op1 in appointments1)
                        {
                            Console.WriteLine(op1);
                        }
                        break;
                    case 4:
                        hospitalManagementImpl.scheduleAppointment();
                        break;
                    case 5:
                        Appointments appointments2=new Appointments();
                        Console.WriteLine("Enter the UpdatedPatientID::");
                        int Patientid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the UpdatedDoctorID::");
                        int DoctorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the UPdatedAppointmentDate");
                        string appoitDate = Console.ReadLine();
                        Console.WriteLine("Enter the UpdatedProblem");
                        string description = Console.ReadLine();
                        appointments2 = new Appointments(Patientid,DoctorId,Convert.ToDateTime(appoitDate),description);
                        hospitalManagementImpl.updateAppointment(appointments2);
                        break;
                    case 6:
                        Console.WriteLine("Enter the Appointmentid details to Cancel::");
                        int appointmentid = int.Parse(Console.ReadLine());
                        hospitalManagementImpl.cancelAppointment(appointmentid);
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (choice != 7);
        }
    }
}
