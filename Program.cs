using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0824H1DatabaseRamdomTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            InsertData();
            PrintData();
            Console.ReadKey();
        }


        #region View

        #endregion

        #region Controller

        // Data Manipulation:
        // Import data to DB
        private static void InsertData()
        {
            // Establish SQL connection
            string connectionString = @"Data Source=ZBC-S-tian0247\SQLEXPRESS;Initial Catalog=Performance;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            for (int i = 0; i < randomTable.GetLength(0); i++)
            {
                string insertQuery = "INSERT INTO Randoms(randomNumber) Values(" + randomTable[i, 1] + ")";
                SqlCommand insertCommand1 = new SqlCommand(insertQuery, conn);
                insertCommand1.ExecuteNonQuery();
            }
            // ?? ID starts from 2 
            Console.WriteLine($"{randomTable.GetLength(0)} rows of data added.");
        }

        // Generate random numbers with index
        static int[,] randomTable = RandomDataGenerator(1000000);

        private static void PrintData()
        {
            int colNr = randomTable.GetLength(1);
            int rowNr = randomTable.GetLength(0);

            for (int i = 0; i < rowNr; i++)
            {
                for (int j = 0; j < colNr; j++)
                {
                    Console.Write(randomTable[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Modul
        // Generate 1M random number mellem 0 and 9999
        private static int[,] RandomDataGenerator(int rowCount)
        {
            int[,] randomTable = new int[rowCount, 2];
            Random rand = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                //randomTable[i, 0] = i + 1;
                randomTable[i, 0] = i;
                randomTable[i, 1] = rand.Next(0, 10000);
            }
            return randomTable;
        }
        #endregion
    }

}
