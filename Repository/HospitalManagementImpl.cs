using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal class HospitalManagementImpl : IHospitalManagement
    {
        List<Patients> patients = new List<Patients>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public HospitalManagementImpl()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public Appointments getAppointmentById(int Appoint_id)
        {
            Appointments appointments = new Appointments();

            cmd.CommandText = "select * from Appointment where AppointmentID=@appointID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appointID",Appoint_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                appointments.appointmentId = (int)reader["appointmentId"];
                appointments.patientId = (int)reader["patientId"];
                appointments.doctorId = (int)reader["doctorId"];
                appointments.appointmentDate = (DateTime)reader["appointmentDate"];
                appointments.description = (string)reader["AppointmentDescription"];


            }
            connect.Close();
            return appointments;

        }
      
        public List<Appointments> getAppointmentsForPatient(int patientID)
        {
             List<Appointments> appointmentList = new List<Appointments>();

            cmd.CommandText = "select * from Appointment where patientId=@patientId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@patientId", patientID);
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
                appointmentList.Add(appointments);

            }
            connect.Close();
            return appointmentList;
        }

        public List<Appointments> getAppointmentsForDoctor(int doctorid)
        {
            List<Appointments> appointmentList = new List<Appointments>();

            cmd.CommandText = "select * from Appointment where patientId=@doctorid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@doctorid", doctorid);
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
                appointmentList.Add(appointments);

            }
            connect.Close();
            return appointmentList;
        }

        public bool scheduleAppointment()
        {
            PatientsRepository patientsRepository = new PatientsRepository();
            Console.WriteLine("1. Existing Patient\n2. NewPatient::");
            Console.WriteLine("Enter your choice::");
            int choice = 0;
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the PatientID::");
                    int Patientid = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the DoctorID::");
                    int DoctorId= int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the AppointmentDate");
                    string appoitDate= Console.ReadLine();
                    Console.WriteLine("Enter the Problem");
                    string description= Console.ReadLine();
                    cmd.CommandText = "insert into Appointment values(@patientid,@doctorid,@appointdate,@description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@patientid", Patientid);
                    cmd.Parameters.AddWithValue("@doctorid", DoctorId);
                    cmd.Parameters.AddWithValue("@appointdate", appoitDate);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Connection = connect;
                    connect.Open();
                    int appointmentstatus= cmd.ExecuteNonQuery();
                    Console.WriteLine($"Appointment Confirmed!!!! {appointmentstatus}row affected");
                    connect.Close();
                    return true;
                    break;

                case 2:
                    patientsRepository.insertPatients();
                    Console.WriteLine("Enter the PatientID::");
                    int Patient_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the DoctorID::");
                    int Doctor_Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the AppointmentDate");
                    string appoit_Date = Console.ReadLine();
                    Console.WriteLine("Enter the Problem");
                    string description_ = Console.ReadLine();
                    cmd.CommandText = "insert into Appointment values(@patientid,@doctorid,@appointdate,@description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@patientid", Patient_id);
                    cmd.Parameters.AddWithValue("@doctorid", Doctor_Id);
                    cmd.Parameters.AddWithValue("@appointdate", appoit_Date);
                    cmd.Parameters.AddWithValue("@description", description_);
                    cmd.Connection = connect;
                    connect.Open();
                    int appointment_status = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Appointment Confirmed!!!! {appointment_status}row affected");
                    connect.Close();
                    return true;
                    break;

                default:
                    Console.WriteLine("Invalid Option!!1");
                    return true;
                    break;

            }
        }

        public bool updateAppointment(Appointments appointments)
        {
            cmd.CommandText = "update Appointment set patientId=@patientsid,doctorId=@doctorid,appointmentDate=@appointmentdate,AppointmentDescription=@appointmentDes where appointmentId=@appoint_id\r\n)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appoint_id", appointments.appointmentId);
            cmd.Parameters.AddWithValue("@patientsid", appointments.patientId);
            cmd.Parameters.AddWithValue("@doctorid", appointments.doctorId);
            cmd.Parameters.AddWithValue("@appointdate", appointments.appointmentDate);
            cmd.Parameters.AddWithValue("@description", appointments.description);
            cmd.Connection = connect;
            connect.Open();
            int appointmentstatus = cmd.ExecuteNonQuery();
            Console.WriteLine($"Appointment Updated!!!! {appointmentstatus}row affected");
            connect.Close();
            return true;
        }

        public bool cancelAppointment(int AppointmentID)
        {
            
            cmd.CommandText = "delete from Appointments where appointmentId=@Appointmentid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@patientid", AppointmentID);
            cmd.Connection = connect;
            connect.Open();
            int appointmentstatus = cmd.ExecuteNonQuery();
            Console.WriteLine($"Appointment Canceled!!!! {appointmentstatus}row affected");
            connect.Close();
            return true;
        }

    }
}
