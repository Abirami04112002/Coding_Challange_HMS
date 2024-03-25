using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exceptions
{
    internal class PatientNotFoundException:Exception
    {
        public PatientNotFoundException(string message) : base(message) { }

        public void PatientNotFound(int PatientID) 
        {
            bool success= false;
            PatientsRepository patientsRepository = new PatientsRepository();
            List<Patients> patients = new List<Patients>();
            patients = patientsRepository.GetPatients();
            foreach(Patients patients1 in patients)
            {
                if(patients1.patientId==PatientID)
                {
                    success = true;
                }
            }
            if(!success)
            {
                throw new PatientNotFoundException("Patient id not found!!!");
            }

        }

    }
}
