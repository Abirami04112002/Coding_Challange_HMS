using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal interface IHospitalManagement
    {
        public Appointments getAppointmentById(int Appoint_id);
        public List<Appointments> getAppointmentsForPatient(int PatientID);

        public List<Appointments> getAppointmentsForDoctor(int doctorID);

        public bool scheduleAppointment();

        public bool updateAppointment(Appointments appointments);

        public bool cancelAppointment(int AppointmentID);

    }
}
