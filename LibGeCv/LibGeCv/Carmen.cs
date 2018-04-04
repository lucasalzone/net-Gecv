using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GeCv;
using LibGeCv;

namespace GeCvClass {
	public partial class Archivio: ICurriculum <Curriculum> {
		
		private int RecuperaIdCv(Curriculum c) {
			SqlConnection conn = new SqlConnection(GetStringBuilder());
			int IdCv = 0;
			try {
				conn.Open();
				SqlCommand cmd = new SqlCommand("RecuperaIdCv", conn);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Matricola", System.Data.SqlDbType.NVarChar).Value=c.Matricola;
                SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read()) {
					IdCv = sdr.GetInt32(0);
				}
				sdr.Close();
				cmd.Dispose();
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
				SqlCommand cmd = new SqlCommand("CercaParolaChiava", connection);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@parola", System.Data.SqlDbType.NVarChar).Value=chiava;
                SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()){
					result.Add(FindIdCv(reader.GetInt32(0)));
				}
				reader.Close();
				cmd.Dispose();
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
				SqlCommand cmd = new SqlCommand("CercaLingua", connection);
				cmd.Parameters.Add("@competenza",System.Data.SqlDbType.NVarChar).Value=competenza;
                SqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read()){
					result.Add(FindIdCv(reader.GetInt32(0)));
				}
				reader.Close();
				cmd.Dispose();
				return result;
			}catch (Exception e ){
				throw e ;
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
