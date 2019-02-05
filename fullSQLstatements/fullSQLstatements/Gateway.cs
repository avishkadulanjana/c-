using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace fullSQLstatements
{
    class Gateway
    {
        public bool Save(Student student)
        {
            string connectionString = @"Data Source=.;Initial Catalog=University;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query=@"INSERT INTO Student VALUES ("+student.Roll+", "+student.Science+","+student.English+","+student.Maths+")";
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();


            connection.Close();
            return true;
        }

        public Student Get(string roll)
        {
            Student student = new Student();

            string connectionString = @"Data Source=.;Initial Catalog=University;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT * FROM Student WHERE Roll ="+roll.Trim();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                student.Id = Convert.ToInt32(reader["Id"].ToString());
                student.Roll =reader["Roll"].ToString();
                student.Science = Convert.ToDecimal(reader["Science"].ToString());
                student.English = Convert.ToDecimal(reader["English"].ToString());
                student.Maths = Convert.ToDecimal(reader["Maths"].ToString());

            }
            return student;

        }

        public bool Update(Student student)
        {
            string connectionString = @"Data Source=.;Initial Catalog=University;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"UPDATE Student SET Science="+student.Science+", English="+student.English+", Maths="+student.Maths+" WHERE Roll="+student.Roll+" ";
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool Delete(Student student)
        {
            string connectionString = @"Data Source=.;Initial Catalog=University;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"DELETE FROM Student WHERE Roll="+student.Roll+"";
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
          
    }
}
