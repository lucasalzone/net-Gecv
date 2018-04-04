using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGeCv;


namespace GeCv{
  public interface ICurriculum<Curriculum>{
		void Add(Curriculum c );
		// Permette di aggiungere il proprio curriculum alla lista di quelli esistenti;
		// in caso lo user sia admin, permette di aggiungere anche i curriculum degli sconosciuti 
		void AddPerStudi(Curriculum c, PercorsoStudi p);
		// Permette di aggiungere al proprio curriculum 1 o più percorsi di studio
		void AddEspLav(Curriculum c, EspLav e);
		// Permette di aggiungere al proprio curriculum 1 o più esperienze lavorative
		void AddCompetenze(Curriculum c, Competenze t);
		// Permette di aggiungere al proprio curriculum 1 o più competenze
		List<Curriculum> CercaPerMatricola(string Matricola);
		void Del(Curriculum c );
		//Funzione visibile solo se loggati come Admin, Permette di eliminare un curriculum;
		void Modifica(Curriculum daModificare, Curriculum Modificato );
		// Funzionalità che permette di modificare solo il proprio curriculum ;
		// in caso lo user sia loggato come admin, permette di modificare anche curriculum esterni;
		// in caso lo user sia loggato come professore, permette di modificare anche curriculum dei suoi corsisti.
		// Funzionalità che permette di visualizzare una Lista di curriculum, un curriculum in particolare
		List<Curriculum> CercaEta(int min, int max);
		// Funzionalità che permette di cercare curriculum in un range di eta, compreso tra il min e il max
		List<Curriculum> CercaEta(int eta);
		// Funzionalità che permette di cercare curriculum per un età specifica
		List<Curriculum> CercaLingua(string competenza);
		// Funzionalità che permette di cercare curriculum per le competenze Linguistiche
		List<Curriculum> CercaResidenza(string citta);
		// Funzionalità che permette di cercare curriculum per residenza specifica
		List<Curriculum> CercaParolaChiava(string chiava);
		// Funzionalità che permette la ricerca per una o piu parole chiave  all'interno di tutti i curriculum
		List<Curriculum> CercaPiuParam(string parola, int e_min, int e_max, string residenza , string lingue );
		// Funzionalità che permette la ricerca per tutti i parametri presenti sull'interfaccia grafica
		List<Curriculum> CercaPiuParam(string parola, string residenza, string lingue );
		// Funzionalità che permette la ricerca per tutti i parametri, esclusa l'età
		void ModEspLav(Curriculum c, EspLav daMod, EspLav Modificata);
		void ModPerStud(Curriculum c , PercorsoStudi daMod , PercorsoStudi Modificata);
		void ModComp(Curriculum c , Competenze daMod , Competenze Modificata);
	}



}



