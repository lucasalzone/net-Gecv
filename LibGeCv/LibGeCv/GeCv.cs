using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
		Curriculum Modifica(Curriculum daModificare, Curriculum Modificato );
		// Funzionalità che permette di modificare solo il proprio curriculum ;
		// in caso lo user sia loggato come admin, permette di modificare anche curriculum esterni;
		// in caso lo user sia loggato come professore, permette di modificare anche curriculum dei suoi corsisti.
		Curriculum VisualizzaCV(Curriculum c);
		List<Curriculum> VisualizzaCV(List<Curriculum> c);
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
	}

	[Serializable]
	public class Curriculum{
		private int idCv;
		private string nome;
		private string cognome;
		private int eta;
		private string matricola;
		private string residenza;
		private string email;
		private string telefono;
		private string corrisponde;
		private List<PercorsoStudi> studi;
		private List<EspLav> lavori;
		private List<Competenze> _Competenze;
		private List<string> competenze;

		public Curriculum (string nome, string cognome, int eta, string matricola, string email, string telefono, string residenza){
			this.nome = nome;
			this.cognome = cognome;
			this.eta = eta;
			this.matricola=matricola;
			this.email = email;
			this.residenza=residenza;
			this.telefono = telefono;
			this.studi = new List<PercorsoStudi>();
			this.lavori = new List<EspLav>();
			this._Competenze= new List<Competenze>();
			this.competenze = new List<string>();
		}
		public Curriculum (string Matricola){
			this.matricola=Matricola;
			this.studi = new List<PercorsoStudi>();
			this.lavori = new List<EspLav>();
			this._Competenze= new List<Competenze>();
			this.competenze = new List<string>();
		}
		public string Matricola{
			get {return this.matricola;}
		}

		/*
		public Curriculum(){
			this.studi = new List<PercorsoStudi>();
			this.lavori = new List<EspLav>();
			this._Competenze= new List<Competenze>();
			this.competenze = new List<string>();
		}
		*/
		 public string Corrisponde{
                  get { return corrisponde; }
                  set { this.corrisponde = value; }
            }

		public int IDCV{
			get {return this.idCv;}
			set {this.idCv= value;}
		}
		public string Nome{
			get{return nome;}
		}
		public string Residenza{
			get{ return this.residenza;} set{ this.residenza=value;}
		}
		public string Cognome{
			get{return cognome;}
		}
		public int Eta{
			get{return eta;}
			set{this.eta = value;}
		}
		
		public string Email{
			get{return email;}
			set{this.email=value;}
		}
		public string Telefono{
			get{return telefono;}
			set{this.telefono = value;}
		}
			
		public List<PercorsoStudi> Studi{
			get{return studi;}
			set{this.studi=value;}
		}
		public List<EspLav> Lavori{
			get{return lavori;}
			set{this.lavori=value;}
		}

		public List<Competenze> CompSpec{
			get{return _Competenze;}
			set{this._Competenze=value;}
		}

		public List<string> Competenze{
			get{return competenze;}
			set{this.competenze=value;}
		}
		public bool ListComp(string var1){
			foreach(string s1 in Competenze){
				if (s1.Contains(var1)){
					return true;
				}
			}
			return false;
		}
		public void AddPS(PercorsoStudi c){
			studi.Add(c);
		}
		public void AddLav(EspLav c){
			lavori.Add(c);
		}
		public void AddCompSpec(Competenze c){
			_Competenze.Add(c);
		}
		public void AddComp(string c){
			competenze.Add(c);
		}
		public void StampaCV(){
			Console.WriteLine("\n\n------CURRICULUM DI {0} {1}------",this.Nome,this.Cognome);
			Console.WriteLine("Nome: {0} | Cognome: {1}", this.Nome,this.Cognome);
			Console.WriteLine("Età: "+this.eta);
			
			Console.WriteLine("E-mail: "+this.email+" | Telefono: "+this.telefono);
			Console.WriteLine("------ESPERIENZE LAVORATIVE------");
			for(int i = 0; i < lavori.Count; i++){
				Console.WriteLine("____________________ ",i);
				Console.WriteLine(lavori[i]);

			}
			Console.WriteLine("------PERCORSO STUDI------");
			for(int i = 0; i < studi.Count; i++){
				//olConse.WriteLine("____________________ ",i);
				Console.WriteLine(studi[i]);

			}
			Console.WriteLine("------COMPETENZE SPECIFICHE------");
			for(int i = 0; i < _Competenze.Count; i++){
				Console.WriteLine("____________________ ",i);
				Console.WriteLine(_Competenze[i]);

			}
			Console.WriteLine("------COMPETENZE GENERALI------");
			foreach(string b in competenze){
				Console.WriteLine(b);
			}
		}
		public bool Equals(Curriculum c){
			if (this.Cognome== c.Cognome){
				return true;
			}else
				return false;
		}
		public bool ListEspLav(string var1){
			EspLav b = new EspLav(var1);
			bool ritorno= false;
			foreach(EspLav c in lavori){
				if(c.Equals(b)){
					ritorno= true;
				}
			}
			return ritorno;
		}
		public bool ListPerStudi(string var1){
			PercorsoStudi b = new PercorsoStudi(var1);
			bool ritorno= false;
			foreach(PercorsoStudi c in studi){
				if(c.Equals(b)){
					ritorno= true;
				}
			}
			return ritorno;
		}
		public bool ListPerComp(string var1){
			bool ret = false;
			foreach(Competenze c in _Competenze){
				if(c.Tipo.Contains(var1)){
					ret=true;
				}
			}
			return ret;
		}
		public bool Contiene(string s1){
			bool result= false;
			try{
				int c = int.Parse(s1);
				if(this.eta.Equals(c))
					result = true;
			}catch(Exception){
				if(this.nome.Equals(s1) || this.cognome.Equals(s1) || this.email.Contains(s1) || this.telefono.Equals(s1) ){
					result= true;
				}else
					result = false;
			}
			return result;

		}
		public void DelEspLav(EspLav c ){
			lavori.Remove(c);
		}
		public void DelPS(PercorsoStudi c ){
			studi.Remove(c);
		}
		public void DelCompSpec(Competenze c){
			_Competenze.Remove(c);
		}
		public void modPercStud(int id, Curriculum cv){
			Console.WriteLine("Menu : \n 1.....inizio \n 2.....fine \n 3.....Titolo \n 4.....Descrizione");
			int k = 0;
			k = int.Parse(LeggiInputString("Cosa vuoi modificare ?"));
			switch (k){
				case 1:
					Console.WriteLine("Inserisci L'anno D'inizio ");
					studi[id].AnnoInizio = int.Parse(Console.ReadLine());
					break;
				case 2:
					Console.WriteLine("Inserisci L'anno Di fine ");
					studi[id].AnnoFine = int.Parse(Console.ReadLine());
					break;
				case 3:
					Console.WriteLine("Inserisci il Titolo ");
					studi[id].Titolo = Console.ReadLine();
					break;
				case 4:
					Console.WriteLine("Inserisci la Descrizione ");
					studi[id].Descrizione = Console.ReadLine();  
					break;
			}
			StampaCV();
		}

		public void modEspLav(int id, Curriculum cv){
			Console.WriteLine("Menu : \n 1.....inizio \n 2.....fine \n 3.....Titolo \n 4.....Descrizione");
			int k = 0;
			k = int.Parse(LeggiInputString("Cosa vuoi modificare ?"));
			switch (k){
				case 1:
					Console.WriteLine("Inserisci L'anno D'inizio ");
					studi[id].AnnoInizio = int.Parse(Console.ReadLine());
					break;
				case 2:
					Console.WriteLine("Inserisci L'anno Di fine ");
					studi[id].AnnoFine = int.Parse(Console.ReadLine());
					break;
				case 3:
					Console.WriteLine("Inserisci la qualifica ");
					studi[id].Titolo = Console.ReadLine();
					break;
				case 4:
					Console.WriteLine("Inserisci la Descrizione ");
					studi[id].Descrizione = Console.ReadLine();  
					break;
			}
			StampaCV();
		}

		//implementare il modifica competenze modifiche e modifiche competenze generali


		private static string LeggiInputString(string v){
			Console.WriteLine(v);
			return Console.ReadLine();
		}
		public bool ListPerComp(int var1){
			bool ret = false;
			Competenze t = new Competenze(var1);
			foreach(Competenze c in _Competenze){
				if(c.Livello.Equals(t.Livello)){
					ret=true;
				}
			}
			return ret;
		}
		public void modCompSpec(int id, Curriculum cv){
			Console.WriteLine("Menu : \n 1.....Tipo \n 2.....Livello ");
			int k = 0;
			Console.WriteLine("bimbo");
			k = int.Parse(LeggiInputString("Cosa vuoi modificare ?"));
			switch (k){
				case 1:
					Console.WriteLine("Inserisci Il tipo");
					_Competenze[id].Tipo = Console.ReadLine();
					break;
				case 2:
					Console.WriteLine("Inserisci Il livello ");
					_Competenze[id] = new Competenze(_Competenze[id].Tipo , int.Parse(Console.ReadLine()));
					break;
					
			}
			StampaCV();
		}
		public bool ListCompGeneral(string var1){
			foreach (string s1 in competenze){
				if (s1.Contains(var1))
				{
					return true;
				}
			}
			return false;
		}
		public override string ToString(){
			return $"{this.nome} , {this.cognome} , {this.eta} ,{this.email}, {this.telefono}, {this.residenza} :";
		}
	}

	[Serializable]
	public class Competenze: IEquatable<Competenze>{
		private int idCs;
		private string _tipo;
		private string _livello;
		private int idCv;
		public int IDCV{
			get{return this.idCv;}
			set{this.idCv= value;}
		}
		public int IDCS{
			get{return this.idCs;}
			set{this.idCs= value;}
		}
		public Competenze( string type , string level){
			this._tipo=type;
			this._livello=level;
		}
		
		public Competenze(string type , int lvl){
			this._tipo=type;
			if(lvl>10){
				lvl=lvl%10;
			}
			if(lvl>=0 && lvl <=5){
				this._livello="SUFFICIENTE";
			}else if(lvl>=6 && lvl <=8){
				this._livello="BUONO";
			}else if(lvl==9 || lvl==10){
				this._livello="OTTIMO";
			}
		}
		public Competenze(string type){
			this._tipo=type;
			this._livello="SUFFICIENTE";
		}
		public Competenze(int lvl){
			this._tipo="";
			if(lvl>10){
				lvl=lvl%10;
			}
			if(lvl ==0 && lvl <=5){
				this._livello="SUFFICIENTE";
			}else if(lvl>=6 && lvl <=8){
				this._livello="BUONO";
			}else if(lvl==9 || lvl==10){
				this._livello="OTTIMO";
			}
		}
		public string Tipo{
			get{return this._tipo;}
			set{this._tipo=value;}
		}
		public string Livello{
			get{return this._livello;}
			set{this._livello = value;}
		}
		public override string ToString(){
			return $"{this._tipo} , {this._livello}";
		}
		public bool Equals(Competenze c ){
			if(this._tipo.Contains(c._tipo))
				return true;
			else
				return false;
		}

	}
	[Serializable]

	public class PercorsoStudi: IEquatable<PercorsoStudi> {
		private int idPs;
		private int _AnnoInizio;
		private int _AnnoFine;
		private string _Titolo;
		private string _Descrizione;
		private int idCv;
		public int IDCV{
			get{return this.idCv;}
			set{this.idCv= value;}
		}
		public int IDPS{
			get{return this.idPs;}
			set{this.idPs=value;}
		}
		
		//costruttore
		public PercorsoStudi(int annoinizio, int annofine, string titolo, string descrizione) {
			this._AnnoInizio = annoinizio;
			this._AnnoFine = annofine;
			if (titolo==null || titolo=="") {
				this._Titolo = "Nessun titolo ottenuto";
		} else {
				this._Titolo = titolo;
			}
			if (descrizione=="") {
				this._Descrizione = "Nessuna descrizione disponibile";
			} else {
				this._Descrizione = descrizione;
			}
		}

		public PercorsoStudi(string Esperienza){
			this._Titolo = Esperienza;
			this._Descrizione = Esperienza;
		}

		
		public int AnnoInizio {
			get {return _AnnoInizio;}
			set { this._AnnoInizio = value; }
		}
		public int AnnoFine {
			get {return _AnnoFine;}
			set { this._AnnoFine = value; }
		}
		public string Titolo {
			get {return _Titolo;}
			set { this._Titolo = value; }
		}
		public string Descrizione {
			get {return _Descrizione;}
			set { this._Descrizione = value; }
		}
		public override string ToString() {
			return $"Anno inizio studi: {this._AnnoInizio}\nAnno fine studi: {this._AnnoFine}\nTitolo di studio: {this._Titolo}\nDescrizione degli studi: {this._Descrizione}\n";
		}

		public bool Equals(PercorsoStudi c){
			if((this.Titolo.Contains(c._Titolo)) || (this.Descrizione.Contains(c._Descrizione))){
				return true;
			}
			else { return false; }
			}

	}
	[Serializable]
	public class EspLav:IEquatable<EspLav>{
		//variabili
		private int idEl;
		private int _AnnoInizio;
		private int _AnnoFine;
		private string _Qualifica;
		private string _Descrizione;
		private int idCv;

		//proprietà
		public int IDCV{
			get{return this.idCv;}
			set{this.idCv= value;}
		}
		public int IDEL{
			get{return this.idEl;}
			set{this.idEl= value;}
		}
		public int AnnoInizio{
			get {return _AnnoInizio;}
			set {this._AnnoInizio=value;}
			}
		public int AnnoFine{
			get {return _AnnoFine;}
			set {this._AnnoFine=value;}
			}
		public string Qualifica{
			get {return _Qualifica;}
			set {this._Qualifica=value;}
			}
		public string Descrizione{
			get {return _Descrizione;}
			set {this._Descrizione=value;}
			}
		//costruttore qualifica-descrizione
		public EspLav(string Esperienza){
			this._Qualifica = Esperienza;
			this._Descrizione = Esperienza;
			}
		//costruttore full
		public EspLav(int AnnoInizio, int AnnoFine, string Qualifica, string Descrizione){
			this._AnnoInizio = AnnoInizio;
			this._AnnoFine = AnnoFine;
			this._Qualifica = Qualifica;
			if(Descrizione == ""){
				this._Descrizione = "Nessuna descrizione disponibile";
				}
			else{this._Descrizione = Descrizione;}
			}
		//override to string
		public override string ToString(){
			return $"Anno Inizio: {this._AnnoInizio}\nAnno Fine: {this._AnnoFine}\nQualifica: {this._Qualifica}\nDescrizione: {this._Descrizione}\n";
		}
		public bool Equals(EspLav c){
			if((this.Qualifica.Contains(c._Qualifica))||(this.Descrizione.Contains(c._Descrizione))){
				return true;
			} else { return false; }
		}
	}
}



