using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;
using GeCv;

namespace GeCvClass {

	public partial class Archivio : ICurriculum<Curriculum> {
		public void Add(Curriculum c) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try{
     	      	 connection.Open();
                 SqlCommand command = new SqlCommand("AddCv",connection);
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.Parameters.Add("@Nome",System.Data.SqlDbType.NVarChar).Value= c.Nome;
                 command.Parameters.Add("@Cognome",System.Data.SqlDbType.NVarChar).Value= c.Cognome;
                 command.Parameters.Add("@Eta",System.Data.SqlDbType.Int).Value= c.Eta;
			     command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value= c.Matricola;
                 command.Parameters.Add("@Email",System.Data.SqlDbType.NVarChar).Value= c.Email;
                 command.Parameters.Add("@Residenza",System.Data.SqlDbType.NVarChar).Value= c.Residenza;
                 command.Parameters.Add("@Telefono",System.Data.SqlDbType.NVarChar).Value= c.Telefono;
                 command.ExecuteNonQuery();
                 command.Dispose();
              
                }catch(Exception e ){
				throw e ;
			}finally{
				connection.Dispose();
			}
		}
		public void AddPerStudi(Curriculum c, PercorsoStudi p){
			int IdCv = RecuperaIdCv(c);
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("AddCvStudi", connection);
				command.Parameters.Add("@AnnoI", System.Data.SqlDbType.Int).Value = p.AnnoInizio;
				command.Parameters.Add("@AnnoF", System.Data.SqlDbType.Int).Value = p.AnnoFine;
				command.Parameters.Add("@Titolo", System.Data.SqlDbType.NVarChar).Value = p.Titolo;
				command.Parameters.Add("@Descrizione", System.Data.SqlDbType.NVarChar).Value = p.Descrizione;
				command.Parameters.Add("@IdCv", System.Data.SqlDbType.Int).Value = c.IDCV;
				command.ExecuteNonQuery();
				command.Dispose();
				
			} catch (Exception e){
				throw e;
			} finally {
				connection.Dispose();
			}
		}
		public void AddEspLav(Curriculum c, EspLav el){
			int IdCv = RecuperaIdCv(c);
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("AddCv", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@AnnoI", System.Data.SqlDbType.Int).Value = el.AnnoInizio;
				command.Parameters.Add("@AnnoF", System.Data.SqlDbType.Int).Value = el.AnnoFine;
				command.Parameters.Add("@Qualifica", System.Data.SqlDbType.NVarChar).Value = el.Qualifica;
				command.Parameters.Add("@Descrizione", System.Data.SqlDbType.NVarChar).Value = el.Descrizione;
				command.Parameters.Add("@IdCv", System.Data.SqlDbType.Int).Value = c.IDCV;
				command.ExecuteNonQuery();
				command.Dispose();
				connection.Dispose();

			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}
		public void AddCompetenze(Curriculum c, Competenze t){
			int IdCv = RecuperaIdCv(c);
			SqlConnection conn = new SqlConnection(GetStringBuilder());
			try {
				conn.Open();
				string Sql = "INSERT INTO Competenze (Tipo, Livello, IdCv) " +
				$"VALUES ('{t.Livello}',' {t.Livello}', {IdCv})";
				SqlCommand command = new SqlCommand(Sql, conn);
				if (command.ExecuteNonQuery() != 1) {
					throw new Exception("Inserimento Competenze non avvenuto!");
				}
				command.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				conn.Dispose();
			}
		}
		
		
	}

}
