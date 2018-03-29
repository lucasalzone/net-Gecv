﻿CREATE PROCEDURE AddCv
    @Nome VARCHAR(50), 
  	@Cognome VARCHAR(50),
	@Eta Int, 
  	@Matricola VARCHAR(50), 
  	@Email VARCHAR(50),
	@Residenza VARCHAR(50), 
  	@Telefono VARCHAR(50)
	as
    SET IMPLICIT_TRANSACTIONS ON;
	INSERT INTO Curriculum(Nome,Cognome ,Eta ,Matricola,Email,Residenza ,Telefono)
				VALUES(@Nome,@Cognome,@Eta,@Matricola,@Email,@Residenza,@Telefono)
    COMMIT TRANSACTION 
	go

CREATE PROCEDURE AddCvStudi
    @AnnoI Int, 
  	@AnnoF Int,
	@Titolo VARCHAR(50), 
  	@Descrizione VARCHAR(50), 
  	@IdCv Int
	
	as
    SET IMPLICIT_TRANSACTIONS ON;
	INSERT INTO PercorsoStudi (AnnoI, AnnoF, Titolo, Descrizione, IdCv)
				VALUES(@AnnoI,@AnnoF,@Titolo,@Descrizione,@IdCv)

	if @IdCv is null
		begin
			print 'Warning! ID non trovato';
			ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdCv;
		end
	 else 	
		begin
			print 'Warning! ID trovato';			 
		end
		COMMIT TRANSACTION 
	go

CREATE PROCEDURE AddEspLav
    @AnnoI Int, 
  	@AnnoF Int,
	@Qualifica NVARCHAR(50), 
  	@Descrizione NVARCHAR(50), 
  	@IdCv Int
as
SET IMPLICIT_TRANSACTIONS ON;			
INSERT INTO EspLav (AnnoI, AnnoF, Qualifica, Descrizione, IdCv) 
			VALUES (@AnnoInizio, @AnnoFine, @Qualifica,@Descrizione,@IdCv)
if @IdCv is null
		begin
			print 'Warning! ID non trovato';
            ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdCv;
			
		end
	 else 	
		begin
			print 'Warning! ID trovato';			 
		end
		COMMIT TRANSACTION 
	go

CREATE PROCEDURE AddCompetenze
	@Tipo NVARCHAR(50),
    @Livello Int,
    @IdCv Int
as
INSERT INTO Competenze (Tipo, Livello, IdCv)
				VALUES (@Tipo,@Livello,@IdCv)
if @IdCv is null
		begin
			print 'Warning! ID non trovato';
            ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdCv;
			
		end
	 else 	
		begin
			print 'Warning! ID trovato';			 
		end
		COMMIT TRANSACTION 
	go

				
				
				