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
    internal class DoctorsRepository
    {
        List<Docters> docters = new List<Docters>();
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public DoctorsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AddDoctor()
        {
            Console.WriteLine("Enter the firstName::");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter the lastName");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter the specialization");
            string specil = Console.ReadLine();
            Console.WriteLine("Enter the contactNumber");
            string ContactNumber = Console.ReadLine();
            Console.WriteLine("Enter the DateOFBirth");
            string Dob = Console.ReadLine();
            cmd.CommandText = "insert into Docter values(@firstName,@lastName,@Dob,@spcil,@Contact)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@firstName", firstname);
            cmd.Parameters.AddWithValue("@lastName", lastname);
            cmd.Parameters.AddWithValue("@Dob", Dob);
            cmd.Parameters.AddWithValue("@spcil", specil);
            cmd.Parameters.AddWithValue("Contact", ContactNumber);
            cmd.Connection = connect;
            connect.Open();
            int appointmentstatus = cmd.ExecuteNonQuery();
            Console.WriteLine($"Doctor Inserted!!!! {appointmentstatus}row affected");
            connect.Close();
          

        }
        public List<Docters> getDoctors()
        {
            cmd.CommandText = "Select * from Docter";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Docters docters1 = new Docters();
                docters1.doctorId = (int)reader["doctorId"];
                docters1.firstName = (string)reader["firstName"];
                docters1.lastName = (string)reader["lastName"];
                docters1.dateOfBirth = (DateTime)reader["dateOfBirth"];
                docters1.specialization = (string)reader["specialization"];
                docters1.contactNumber = (string)reader["contactNumber"];
                docters.Add(docters1);

            }

            connect.Close();
            return docters;
        }
    }
}
