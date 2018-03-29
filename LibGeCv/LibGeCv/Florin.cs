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
				SqlCommand command = new SqlCommand("DeleteCurriculum", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@idcurr" , System.Data.SqlDbType.Int).Value=c.IDCV;
				command.ExecuteNonQuery();
				command.Dispose();

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
				SqlCommand command = new SqlCommand("CercaEtaMinMax", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@e_min" , System.Data.SqlDbType.Int).Value=min;
				command.Parameters.Add("@e_max" , System.Data.SqlDbType.Int).Value=max;
				SqlDataReader reader = command.ExecuteReader();
				
				while(reader.Read()){
					result.Add(FindIdCv(reader.GetInt32(0)));
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

		private Curriculum FindIdCv(int v) {
			Curriculum result = null;
			foreach(Curriculum c in Curricula){
				if(c.IDCV == v){
					result=c;
					break;
				}
			}
			if(result==null){
				throw new  Exception("ID NON TROVATO");
			}else{
				return result;
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
