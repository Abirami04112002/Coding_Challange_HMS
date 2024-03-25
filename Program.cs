using HospitalManagementSystem.Entities;
using HospitalManagementSystem.HospitalManagementsys;
using HospitalManagementSystem.Repository;

namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalManageSyscs hospitalManageSyscs = new HospitalManageSyscs();
            hospitalManageSyscs.run();
        }
    }
}
