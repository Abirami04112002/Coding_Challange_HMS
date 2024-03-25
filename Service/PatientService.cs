using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal class PatientService
    {
        public PatientService() { }
        PatientsRepository patientRepository = new PatientsRepository();

        public void PatientDirectory()

        {
            int choice = 0;
            do
            {
                Console.WriteLine("****Patient Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: AddPatients\n2: GetAllPatients\n3: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        patientRepository.insertPatients();
                        break;

                    case 2:
                        patientRepository.GetPatients();
                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
