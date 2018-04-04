using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeCv;
using LibGeCv;



namespace GeCvClass {

	public partial class Archivio : ICurriculum<Curriculum> {
		public void Add(LibGeCv.Curriculum c) {
			
			try{
				using (var db = new GECVEntities()) {
				db.AddCv(c.Nome,c.Cognome,c.Eta,c.Matricola,c.Email,c.Residenza,c.Telefono);
				db.SaveChanges();
				}
				/* connection.Open();
                 SqlCommand command = new SqlCommand("AddCv",connection);
                 command.CommandType = System.Data.CommandType.StoredProcedure;
                 command.Parameters.Add("@Nome",System.Data.SqlDbType.NVarChar).Value= c.Nome;
                 command.Parameters.Add("@Cognome",System.Data.SqlDbType.NVarChar).Value= c.Cognome;
                 command.Parameters.Add("@Eta",System.Data.SqlDbType.Int).Value= c.Eta;
			     command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value= c.Matricola;
                 command.Parameters.Add("@Email",System.Data.SqlDbType.NVarChar).Value= c.Email;
                 command.Parameters.Add("@Residenza",System.Data.SqlDbType.NVarChar).Value= c.Residenza;
                 command.Parameters.Add("@Telefono",System.Data.SqlDbType.NVarChar).Value= c.Telefono;
              	 c.IDCV = RecuperaIdCv(c);				 
                 command.ExecuteNonQuery();
                 command.Dispose();*/
		    }catch(Exception e ){
				throw e ;
			}
		}
		public void AddPerStudi(LibGeCv.Curriculum c, LibGeCv.PercorsoStudi p){			
			try {
				using (var db = new GECVEntities()) {
				db.AddCvStudi(p.AnnoI,p.AnnoF,p.Titolo,p.Descrizione,c.IdCv);
				db.SaveChanges();
				}
				/*connection.Open();
				int Idps = 0;
				SqlCommand command = new SqlCommand("AddCvStudi", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@AnnoI", System.Data.SqlDbType.Int).Value = p.AnnoInizio;
				command.Parameters.Add("@AnnoF", System.Data.SqlDbType.Int).Value = p.AnnoFine;
				command.Parameters.Add("@Titolo", System.Data.SqlDbType.NVarChar).Value = p.Titolo;
				command.Parameters.Add("@Descrizione", System.Data.SqlDbType.NVarChar).Value = p.Descrizione;
				command.Parameters.Add("@IdCv", System.Data.SqlDbType.Int).Value = c.IDCV;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
				Idps = (int)reader.GetDecimal(0);
				}
				p.IDCV = c.IDCV;
				p.IDPS = Idps;
				reader.Close();		
				c.AddPS(p);
				command.Dispose();*/			
			} catch (Exception e){
				throw e;
			} finally {
				//connection.Dispose();
			}
		}
		public void AddEspLav(Curriculum c, EspLav el){
			
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try {
			/*
				int Idel = 0;
				connection.Open();
				SqlCommand command = new SqlCommand("AddEspLav", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@AnnoI", System.Data.SqlDbType.Int).Value = el.AnnoInizio;
				command.Parameters.Add("@AnnoF", System.Data.SqlDbType.Int).Value = el.AnnoFine;
				command.Parameters.Add("@Qualifica", System.Data.SqlDbType.NVarChar).Value = el.Qualifica;
				command.Parameters.Add("@Descrizione", System.Data.SqlDbType.NVarChar).Value = el.Descrizione;
				command.Parameters.Add("@IdCv", System.Data.SqlDbType.Int).Value = c.IDCV;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
				Idel = (int)reader.GetDecimal(0);
				}
				el.IdCv = c.IdCv;
				el.IdCv = Idel;
				reader.Close();
				//c.AddLav(el);
				command.Dispose();
			*/

			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}
		public void AddCompetenze(Curriculum c, Competenze t){
			
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			try {
			/*
				connection.Open();
				int Idcomp = 0;
				SqlCommand command = new SqlCommand("AddCompetenze", connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@Tipo", System.Data.SqlDbType.NVarChar).Value = t.Tipo;
				command.Parameters.Add("@Livello", System.Data.SqlDbType.Int).Value = t.Livello;
				command.Parameters.Add("@IdCv", System.Data.SqlDbType.Int).Value = c.IDCV;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
				Idcomp = (int)reader.GetDecimal(0);
				}
			    t.IDCV = c.IDCV;
				t.IDCS = Idcomp;
				reader.Close();
				c.AddCompSpec(t);
				command.Dispose();

			*/
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}
		
		
	}

}
