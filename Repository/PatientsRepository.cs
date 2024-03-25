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
    internal class PatientsRepository
    {
        List<Patients> patients = new List<Patients>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public PatientsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Patients> GetPatients()
        {
            cmd.CommandText = "Select * from Patients";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Patients patients1 = new Patients();
                patients1.patientId = (int)reader["patientId"];
                patients1.firstName = (string)reader["firstName"];
                patients1.lastName = (string)reader["lastName"];
                patients1.gender = (string)reader["gender"];
                patients1.contactNumber = (string)reader["contactNumber"];
                patients1.Patientsaddress = (string)reader["Patientsaddress"];
                patients.Add(patients1);

            }

            connect.Close();
            return patients;
        }
        public bool insertPatients()
        {
           
            Console.WriteLine("Enter the firstName::");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter the lastName");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter the gender");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter the contactNumber");
            string ContactNumber = Console.ReadLine();
            Console.WriteLine("Enter the patientAddress");
            string Patientsaddress = Console.ReadLine();
            cmd.CommandText = "insert into Patients values(@firstName,@lastName,@gender,@contactNumber,@Patientsaddress)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@firstName", firstname);
            cmd.Parameters.AddWithValue("@lastName", lastname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@contactNumber", ContactNumber);
            cmd.Parameters.AddWithValue("Patientsaddress", Patientsaddress);
            cmd.Connection = connect;
            connect.Open();
            int appointmentstatus = cmd.ExecuteNonQuery();
            Console.WriteLine($"Patient Inserted!!!! {appointmentstatus}row affected");
            connect.Close();
            return true;
        }

    }
}
