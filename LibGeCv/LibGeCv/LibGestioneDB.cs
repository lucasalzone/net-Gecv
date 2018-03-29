using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeCv;
using GeCvClass;

namespace GeCv {
    public class LibGestioneDB {
    
        public string getConnectionString() {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"(localdb)\MSSQLLocalDB";
            return scsb.ToString();
        }

        public void CreateDB() {
            SqlConnection connection = new SqlConnection(getConnectionString());
            string sql = "CREATE DATABASE GECV;";
            try {
                connection.Open();
                //creo DB
                SqlCommand command = new SqlCommand(sql, connection);
                command.Dispose();
                //uso il DB
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("USE GECV;");
                SqlCommand command1 = new SqlCommand(sb1.ToString(), connection);
                command1.Dispose();
                //creo Tabella Curriculum
                StringBuilder sb2 = new StringBuilder();
                sb2.Append("CREATE TABLE Curriculum(");
                sb2.Append("IdCv int IDENTITY(1, 1) NOT NULL PRIMARY KEY,");
                sb2.Append("Nome nvarchar(50),");
                sb2.Append("Cognome nvarchar(50),");
                sb2.Append("Eta int,");
                sb2.Append("Matricola nvarchar(10),");
                sb2.Append("Email nvarchar(30),");
                sb2.Append("Residenza nvarchar(100),");
                sb2.Append("Telefono nvarchar(10)");
                sb2.Append(");");
                SqlCommand command2 = new SqlCommand(sb2.ToString(), connection);
                command2.Dispose();
                //creo Tabella PercorsoStudi
                StringBuilder sb3 = new StringBuilder();
                sb3.Append("CREATE TABLE PercorsoStudi (");
                sb3.Append("IdPs int IDENTITY(1,1) NOT NULL PRIMARY KEY,");
                sb3.Append("AnnoI int,");
                sb3.Append("AnnoF int,");
                sb3.Append("Titolo nvarchar(50),");
                sb3.Append("Descrizione nvarchar(200),");
                sb3.Append("IdCv int FOREIGN KEY REFERENCES Curriculum");
                sb3.Append(");");
                SqlCommand command3 = new SqlCommand(sb3.ToString(), connection);
                command3.Dispose();
                //creo Tabella EspLav
                StringBuilder sb4 = new StringBuilder();
                sb4.Append("CREATE TABLE EspLav (");
                sb4.Append("IdEl int IDENTITY(1,1) NOT NULL PRIMARY KEY,");
                sb4.Append("AnnoI int,");
                sb4.Append("AnnoF int,");
                sb4.Append("Qualifica nvarchar(50),");
                sb4.Append("Descrizione nvarchar(200),");
                sb4.Append("IdCv int FOREIGN KEY REFERENCES Curriculum");
                sb4.Append(");");
                SqlCommand command4 = new SqlCommand(sb4.ToString(), connection);
                command4.Dispose();
                //creo Tabella Competenze
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("CREATE TABLE Competenze(");
                sb5.Append("IdCs int IDENTITY(1,1) NOT NULL PRIMARY KEY,");
                sb5.Append("Tipo nvarchar(50),");
                sb5.Append("Livello int,");
                sb5.Append("IdCv int FOREIGN KEY REFERENCES Curriculum");
                sb5.Append(");");
                SqlCommand command5 = new SqlCommand(sb5.ToString(), connection);
                command5.Dispose();
            } catch (Exception e) {
                throw e;
            } finally {
                connection.Dispose();
            }
        }

        public void DropDB () {
            SqlConnection connection = new SqlConnection(getConnectionString());
            string sql = "DROP IF EXISTS GECV;";
            try {
                connection.Open();
                //droppo DB
                SqlCommand command = new SqlCommand(sql, connection);
                command.Dispose();
            } catch (Exception e) {
                throw e;
            } finally {
                connection.Close();
            }
        }
    }
}
