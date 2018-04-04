using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibGeCvTest;
using GeCvClass;
using GeCv;
using LibGeCv;

namespace LibGeCvTest {
	[TestClass]
	public class UnitTest1 {
		[TestMethod()]
		public void AddTest() {
			Archivio arch = new Archivio();
			Curriculum Tester = new Curriculum("Fezio","Marras",21,"AD554","justoxion@gmail.com","392234","Torino");
			arch.Add(Tester);
			int id = Tester.IDCV;
			//List<Curriculum> Albo = new List<Curriculum>();
   			//Assert.IsNotNull(Albo);
		
		}

		[TestMethod()]
		public void AddPerStudiTest() {
			Archivio arch = new Archivio();
			PercorsoStudi Studiato = new PercorsoStudi(2010,2017,"Diploma Informatico","Tutto molto bello");
			Curriculum Tester2 = new Curriculum("Florin","Gheliuc",53,"AD5634","lello@gmail.com","33234","Romania");
			arch.Add(Tester2);
			arch.AddPerStudi(Tester2,Studiato);

			Assert.IsTrue(Studiato.IDCV== Tester2.IDCV);
			
		}

		[TestMethod()]
		public void AddEspLavTest() {
			Archivio arch = new Archivio();
			EspLav Lavorato = new EspLav(2010,2017,"Medico","Tutto blallo");
			Curriculum Tester2 = new Curriculum("Florin","Gheliuc",53,"AD5634","lello@gmail.com","33234","Romania");
			arch.Add(Tester2);
			arch.AddEspLav(Tester2,Lavorato);

			Assert.IsTrue(Lavorato.IDCV== Tester2.IDCV);
		}

		[TestMethod()]
		public void AddCompetenzeTest() {
			Archivio arch = new Archivio();
			Competenze Competente = new Competenze("ORO","2");
			Curriculum Tester2 = new Curriculum("Florin","Gheliuc",53,"AD5634","lello@gmail.com","33234","Romania");
			arch.Add(Tester2);
			arch.AddCompetenze(Tester2,Competente);

			Assert.IsTrue(Competente.IDCV== Tester2.IDCV);
		}
		[TestMethod]
		public void CercaCittà(){
			Archivio test = new Archivio();
			List<Curriculum> res =  test.CercaResidenza("Torino");
			Assert.IsTrue(res.Count==16);
		}
		[TestMethod]
		public void DelTest(){
			Archivio test = new Archivio();
			Curriculum c = new Curriculum("Florin", "Gheliuc",22,"Aaha11","ddd","Torino","ddd" );
			c.IDCV = 9;
			test.Del(c);
		}
		[TestMethod]
		public void ModificaTest(){
			Archivio test = new Archivio();
			Curriculum c = new Curriculum("Florin", "Gheliuc",22,"Aaha11","ddd","Torino","ddd" );
			Curriculum s = new Curriculum("Fede", "Marracash",22,"Aaha11","ddd","Torino","ddd" );
			s.IDCV = 5;
			test.Modifica(s,c);
		}
		[TestMethod]
		public void CercaEtaTest(){
			Archivio test = new Archivio();
			Curriculum c = new Curriculum("Florin", "Gheliuc",22,"Aaha11","ddd","Torino","ddd" );
			test.Add(c);
			List<Curriculum> res = test.CercaEta(22);
			Assert.IsTrue(res.Count ==1);
		}
        [TestMethod]
        public void CercaParolaChiavaTest(){
            Archivio CercaP = new Archivio();
            List<Curriculum> ElencoCv = new List<Curriculum>();
            ElencoCv = CercaP.CercaParolaChiava("C#");
            Assert.IsTrue(ElencoCv!=null);
        }
         [TestMethod]
        public void CercaLinguaTest(){
            Archivio CercaP = new Archivio();
            List<Curriculum> ElencoCv = new List<Curriculum>();
            ElencoCv = CercaP.CercaLingua("Inglese");
            Assert.IsTrue(ElencoCv!=null);
        }        
	}
}
