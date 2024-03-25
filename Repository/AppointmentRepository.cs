using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal class AppointmentRepository
    {
        List<Appointments> Appointments=new List<Appointments>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public AppointmentRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Appointments> getAppointments()
        {
            cmd.CommandText = "Select * from Appointmets";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Appointments appointments = new Appointments();
                appointments.appointmentId = (int)reader["appointmentId"];
                appointments.patientId = (int)reader["patientId"];
                appointments.doctorId = (int)reader["doctorId"];
                appointments.appointmentDate = (DateTime)reader["appointmentDate"];
                appointments.description = (string)reader["AppointmentDescription"];
                Appointments.Add(appointments);

            }
         
            connect.Close();
            return Appointments;
        }
    }
}
