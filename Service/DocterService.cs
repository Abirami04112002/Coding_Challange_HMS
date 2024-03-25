using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal class DocterService
    {
        public DocterService() { }
        DoctorsRepository DoctorsRepository=new DoctorsRepository();

        public void DoctorDirectory()

        {
            int choice = 0;
            do
            {
                Console.WriteLine("****Doctor Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: AddDoctor\n2: GetAllDoctor\n3: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        DoctorsRepository.AddDoctor();
                        break;

                    case 2:
                        DoctorsRepository.getDoctors();
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
