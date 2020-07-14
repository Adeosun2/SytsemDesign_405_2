﻿using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CUESYSv._01
{
    public class dbConn
    {

        ///// DB CONFIG START //////////////////////////////////////////////////////
        public string varConfigServer { get; set; }
        public string varConfigDatabase { get; set; }
        public string varConfigUser { get; set; }
        public string varConfigPass { get; set; }

        private string connString;
        public MySqlConnection conn;
        public MySqlDataAdapter mySQLda;


        ///// DB CONFIG END ////////////////////////////////////////////////////////



        public void connect()
        {//Connect to database (insecure, not using SSL or stored procedures)
            connString = "SERVER=" + varConfigServer + ";" +
                "DATABASE=" + varConfigDatabase + ";" +
                "UID=" + varConfigUser + ";" +
                "PASSWORD=" + varConfigPass + ";" +
                "SslMode=none;";
            conn = new MySqlConnection(connString);
        }
        public bool connOpen()
        {
            try { conn.Open(); return true; }
            catch (MySqlException err)
            {//Connection error handling control statement
                switch (err.Number)
                {
                    case 0:
                        MessageBox.Show("Server connection failure");
                        break;
                    case 1045:
                        MessageBox.Show("User/Password Error");
                        break;
                    default:
                        MessageBox.Show(err.Message);
                        break;
                }
                return false;
            }
        }
        public bool connClose()
        {//Connection close with error handling
            try { conn.Close(); return true; }
            catch (MySqlException err) { MessageBox.Show("Error: " + err.Message); return false; }
        }
        public DataSet qry(string sql)
        {//Run sql qry in argument and return dataset
            mySQLda = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            mySQLda.Fill(ds);
            connClose();
            return ds;
        }
        public void insertCustomer(string custContact, string custEmail, string custTel, string custAddr1, string custAddr2, string custTownCity, string custPostcode)
        {
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO `tblCustomer` (`custContact`, `custEmail`, `custTel`, `custAddr1`, `custAddr2`, `custTownCity`, `custPostcode`) VALUES (@custContact, @clientAge, @custEmail, @custTel, @custAddr1, @custAddr2, @custTownCity, @custPostcode);";
            comm.Parameters.AddWithValue("@custContact", custContact);
        
            comm.Parameters.AddWithValue("@custEmail", custEmail);
            comm.Parameters.AddWithValue("@custTel", custTel);
            comm.Parameters.AddWithValue("@custAddr1", custAddr1);
            comm.Parameters.AddWithValue("@custAddr2", custAddr2);
            comm.Parameters.AddWithValue("@custTownCity", custTownCity);
            comm.Parameters.AddWithValue("@custPostcode", custPostcode);
            comm.ExecuteNonQuery();
            connClose();
        }

        public void insertbooking(string firstName, string lastName, string Airline, string Origin, string Destination, string flightNunmber, string bookingDate, string bookingTime, string bookingCost, string bookingPaid)
        {
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO `tblBookings` (`FirstName`, `LastName`, `Airline`, `Origin`, `Destination`, `flightNumber`, `bookingDate`, `bookingTime`, `bookingCost`, `bookingPaid`) VALUES (@FirstName, @LastName, @Airline, @Origin, @Destination, @flightNumber, @bookingDate, @bookingTime, @bookingCost, @bookingPaid);";
            comm.Parameters.AddWithValue("@firstName", firstName);
            comm.Parameters.AddWithValue("@lastName", lastName);
            comm.Parameters.AddWithValue("@Airline", Airline);
            comm.Parameters.AddWithValue("@Origin", Origin);
            comm.Parameters.AddWithValue("@Destination", Destination);
            comm.Parameters.AddWithValue("@flightNumber", flightNunmber);
            comm.Parameters.AddWithValue("@bookingDate", bookingDate);
            comm.Parameters.AddWithValue("@bookingTime", bookingTime);
            comm.Parameters.AddWithValue("@bookingCost", bookingCost);
            comm.Parameters.AddWithValue("@bookingPaid", bookingPaid);
            comm.ExecuteNonQuery();
            connClose();

        }

        public void insertBooking(string custContact, string bookingBuilding, string seatNumber, string flightNumber, string bookingDateTime, string bookingCost, string bookingPaid, string status)
        {
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO `tblBookings` (`custContact`, `bookingBuilding`, `seatNumber`, `flightNumber`, `bookingDateTime`, `bookingCost`, `bookingPaid`, `Status`) VALUES (@custContact, @bookingBuilding, @seatNumber, @flightNumber, @bookingDateTime, @bookingCost, @bookingPaid,@Status);";
            comm.Parameters.AddWithValue("@custContact", custContact);
            comm.Parameters.AddWithValue("@bookingBuilding", bookingBuilding);
            comm.Parameters.AddWithValue("@seatNumber", seatNumber); //bookingFloor
            comm.Parameters.AddWithValue("@flightNumber", flightNumber); //bookingRoom
            comm.Parameters.AddWithValue("@bookingDateTime", bookingDateTime);
            comm.Parameters.AddWithValue("@bookingCost", bookingCost);
            comm.Parameters.AddWithValue("@bookingPaid", bookingPaid);
            comm.Parameters.AddWithValue("@Status", status);
            comm.ExecuteNonQuery();
            connClose();



        }
        public void deleteBooking(string id)
        {
            connOpen();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM `tblBookings` WHERE `tblBookings`.`bookingID` = @id";
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            connClose();
        }
        public void deleteCustomer(string id)
        {
            connOpen();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM `tblCustomer` WHERE `tblCustomer`.`custID` = @id";
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            connClose();
        }
    }
}