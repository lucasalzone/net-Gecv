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

		public void Modifica(Curriculum daModificare,Curriculum Modificato) {
			try{
				SqlParameter[] parametri = new SqlParameter[]{
					new SqlParameter("@idcurr",daModificare.IDCV),
					new SqlParameter("@nomeM",Modificato.Nome),
					new SqlParameter("@cognomeM",Modificato.Cognome),
					new SqlParameter("@etaM",Modificato.Eta),
					new SqlParameter("@matricolaM",Modificato.Matricola),
					new SqlParameter("@emailM",Modificato.Email),
					new SqlParameter("@residenzaM",Modificato.Residenza),
					new SqlParameter("@telefonoM",Modificato.Telefono)
				};
				ExecNoQuery(parametri,"ModificaCurriculum");

			}catch(Exception e ){
				throw e;
			}
		}
		private void ExecNoQuery(SqlParameter[] parametri,string procedure) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand(procedure,connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.AddRange(parametri);
				command.ExecuteNonQuery();
				command.Dispose();
			} catch(Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}

		}
		public List<Curriculum> CercaPerMatricola(string Matricola) {
			throw new NotImplementedException();
		}
		

		public List<Curriculum> CercaEta(int eta) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("CercaEta" , connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@eta",System.Data.SqlDbType.Int).Value=eta;
				SqlDataReader reader = command.ExecuteReader();
				result = new List<Curriculum>();
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

		

		public List<Curriculum> CercaResidenza(string citta) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("CercaCitta", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@citta",System.Data.SqlDbType.NVarChar).Value=citta;
				SqlDataReader reader = command.ExecuteReader();
				result = new List<Curriculum>();
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

		

		public void ModEspLav(Curriculum c ,EspLav daMod, EspLav Modificata) {
			throw new NotImplementedException();
		}

		public void ModPerStud(Curriculum c,PercorsoStudi daMod,PercorsoStudi Modificata) {
			throw new NotImplementedException();
		}

		public void ModComp(Curriculum c,Competenze daMod,Competenze Modificata) {
			throw new NotImplementedException();
		}
	}
}

