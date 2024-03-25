using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    internal class Patients
    {
        public Patients() { }
        public int patientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string contactNumber { get; set; }
        public string Patientsaddress { get; set; }

        public Patients(int patientId, string firstName, string lastName, string gender, string contactNumber, string patientsaddress)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.contactNumber = contactNumber;
            Patientsaddress = patientsaddress;
        }

        public override string? ToString()
        {
            return $"PatientID::{patientId}\tFirstName::{firstName}\tLastName::{lastName}\tGender::{gender}\tcontactNumber::{contactNumber}\tAddress::{Patientsaddress}";
        }
    }
}
