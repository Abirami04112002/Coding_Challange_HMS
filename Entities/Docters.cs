using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    internal class Docters
    {
        public Docters() { }
        public int doctorId { get; set; }
        public string firstName { get; set;}
        public string lastName { get; set;}
        public DateTime dateOfBirth { get; set;}
       
        public string specialization { get; set;}
        public string contactNumber { get; set; }

        public Docters(int doctorId, string firstName, string lastName, DateTime dateOfBirth, string specialization, string contactNumber)
        {
            this.doctorId = doctorId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.specialization = specialization;
            this.contactNumber = contactNumber;
        }
        public override string? ToString()
        {
            return $"DoctorID::{doctorId}\tFirstName::{firstName}\tLastNAme::{lastName}\tdataOfBirth::{dateOfBirth}\tContactNumber::{contactNumber}\tSpecialization::{specialization}";
        }
    }
}
