using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeCv;

namespace GeCvClass {
	public partial class Archivio : ICurriculum<Curriculum> {
		List<Curriculum> Curricula;
		public Archivio(){
			Curricula= new List<Curriculum>();
		}
		private string GetStringBuilder() {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\MSSQLLocalDB";
            builder.InitialCatalog = "GECV";
            return builder.ToString();
        }
		
		
		public Curriculum FindMatri(string matricola) {
			SqlConnection connection = new SqlConnection (GetStringBuilder());
			Curriculum result = null;
			foreach(Curriculum c in Curricula ){
				if(c.Matricola == matricola ){
					result = c ;
					break;
				}
			}
			return result;
		}
		public void Del(Curriculum c) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try{
				connection.Open();

				string sql = $"Delete Curriculum where Matricola='{c.Matricola}' ; ";
				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();
				Curricula.Remove(c);

			}catch(Exception e ){
				throw e ;
			}finally{
				connection.Dispose();
			}
		}
		public List<Curriculum> CercaEta(int min,int max) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				string sql  = $" Select Matricola from Curriculum where Eta between {min} and {max} ;";
				SqlCommand command = new SqlCommand(sql , connection);
				SqlDataReader reader = command.ExecuteReader();
				result= new List<Curriculum>();
				while(reader.Read()){
					result.Add(FindMatri(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}

		public Curriculum Modifica(Curriculum daModificare,Curriculum Modificato) {
			throw new NotImplementedException();
		}
		

		public List<Curriculum> VisualizzaCV(List<Curriculum> c) {
			throw new NotImplementedException();
		}
		

		public List<Curriculum> CercaPerMatricola(string Matricola) {
			throw new NotImplementedException();
		}
		

		public List<Curriculum> CercaEta(int eta) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				string sql = $"Select Matricola from Curriculum Where Eta={eta} ;";
				SqlCommand command = new SqlCommand(sql , connection);
				SqlDataReader reader = command.ExecuteReader();
				result = new List<Curriculum>();
				while(reader.Read()){
					result.Add(FindMatri(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}

		

		public List<Curriculum> CercaResidenza(string citta) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				string sql = $"Select Matricola from Curriculum Where Residenza like '%{citta}%' ;";
				SqlCommand command = new SqlCommand(sql , connection);
				SqlDataReader reader = command.ExecuteReader();
				result = new List<Curriculum>();
				while(reader.Read()){
					result.Add(FindMatri(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}

		


		public List<Curriculum> CercaPiuParam(string parola,int e_min,int e_max,string residenza,string lingue) {
			throw new NotImplementedException();
		}

		public List<Curriculum> CercaPiuParam(string parola,string residenza,string lingue) {
			throw new NotImplementedException();
		}
	}
}
