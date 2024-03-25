using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.HospitalManagementsys
{
    internal class HospitalManageSyscs
    {
        public void run()
        {
            ApointmentService apointmentService = new ApointmentService();
            DocterService docterService = new DocterService();
            PatientService patientService = new PatientService();
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("******Main Menu********");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: Patients\n2: Doctors\n3: Appointments\n4: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("*****Patients*****");
                        patientService.PatientDirectory();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("*****Doctors*****");
                        docterService.DoctorDirectory();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("*****Appointments*****");
                        apointmentService.AppointmetDirectory();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 4);
        }
    }
}
