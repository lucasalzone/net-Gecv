using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeCv;

namespace GeCvClass {
	public partial class Archivio: ICurriculum <Curriculum> {
		
		public Curriculum VisualizzaCV(Curriculum c){
			SqlConnection conn = new SqlConnection(GetStringBuilder());
			string sql = "SELECT Matricola FROM Curriculum " +
						   $"WHERE Matricola='{c.Matricola}' ";
			Curriculum result=null;
			string Matricola = null;
			try {
				conn.Open();
				SqlCommand command = new SqlCommand(sql, conn);
				SqlDataReader sdr = command.ExecuteReader();
				while (sdr.Read()) {
					Matricola = sdr.GetString(0);
				}
				sdr.Close();
				command.Dispose();
				result = FindMatri(Matricola);
			} catch (Exception e) {
				throw e;
			} finally {
				conn.Dispose();
			}
			return result;
		}
		

		private int RecuperaIdCv(Curriculum c) {
			SqlConnection conn = new SqlConnection(GetStringBuilder());
			string sql = "SELECT IdCv FROM Curriculum " +
						   $"WHERE Matricola='{c.Matricola}'";
			int IdCv = 0;
			try {
				conn.Open();
				SqlCommand command = new SqlCommand(sql, conn);
				SqlDataReader sdr = command.ExecuteReader();
				while (sdr.Read()) {
					IdCv = sdr.GetInt32(0);
				}
				sdr.Close();
				command.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				conn.Dispose();
			}
			return IdCv;
		}

		public List<Curriculum> CercaParolaChiava(string chiava) {
			SqlConnection connection= new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				StringBuilder sb = new StringBuilder();
				sb.Append("select Matricola From Curriculum c inner join PercorsoStudi ps ");
				sb.Append(" on c.IDcv= ps.IDcv inner join EspLav el on c.IDCV= el.IDcv ");
				sb.Append(" inner join Competenze cs on c.IDCV = cs.Idcv where ");
				sb.Append($" c.nome like '%{chiava}'% or c.Cognome like '%{chiava}%' or  ");
				sb.Append($" c.email like '%{chiava}%' or c.Residenza like '%{chiava}%' or ");
				sb.Append($" ps.Titolo like '%{chiava}%' or ps.Descrizione like '%{chiava}%' or ");
				sb.Append($" el.Qualifica like '%{chiava}%' or el.Descrizione like '%{chiava}%' or ");
				sb.Append($" cs.Tipo like '%{chiava}%' ;");
				string sql = sb.ToString();
				SqlCommand command = new SqlCommand(sql, connection);
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()){
					Curricula.Add(FindMatri(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch(Exception e ){
				throw e ;
			}finally{
				connection.Dispose();
			}

		}

		public List<Curriculum> CercaLingua(string competenza) {
			SqlConnection connection = new SqlConnection(GetStringBuilder());
			List<Curriculum> result = null;
			try{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append($" Select matricola from Curriculum c inner join Competenze cs on c.idcv = cs.Idcv where ");
				sb.Append($" cs.Titolo like '%{competenza}%' ;");
				string sql = sb.ToString();
				SqlCommand command = new SqlCommand(sql, connection);
				SqlDataReader reader = command.ExecuteReader();
				result = new List<Curriculum>();
				while(reader.Read()){
					result.Add(FindMatri(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return result;
			}catch (Exception e ){
				throw e ;
			}finally{
				connection.Dispose();
			}
		}
	}
}
