using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibGeCv;
using GeCvClass;
using GeCv;
namespace LibGeCvTest {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void DeleteTest(){
			Archivio test = new Archivio();
			test.Del()
		}
	}
}
