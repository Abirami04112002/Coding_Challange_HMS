using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    internal class Appointments
    {
        public Appointments() { }

        public int appointmentId { get; set; }

        public int patientId {  get; set; }
        public int doctorId {  get; set; }
        public DateTime appointmentDate {  get; set; }

        public string description { get; set; }

        public Appointments(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.appointmentDate = appointmentDate;
            this.description = description;
        }

        public Appointments(int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.appointmentDate = appointmentDate;
            this.description = description;
        }

        public override string? ToString()
        {
            return $"PatientId::{patientId}\tDoctorId::{doctorId}\tAppointmentDate::{appointmentDate}\tAppointmentID{appointmentId}\tDescription::{description}\t";
        }
    }
}
