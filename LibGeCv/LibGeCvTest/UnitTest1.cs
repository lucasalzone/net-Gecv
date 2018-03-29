﻿using System;
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
			List<Curriculum> Albo = new List<Curriculum>();
   			Assert.IsNotNull(Albo);
		
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
	}
}
