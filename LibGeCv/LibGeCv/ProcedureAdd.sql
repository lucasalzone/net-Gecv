﻿ALTER PROCEDURE AddCv
    @Nome NVARCHAR(50), 
  	@Cognome NVARCHAR(50),
	@Eta Int, 
  	@Matricola NVARCHAR(50), 
  	@Email NVARCHAR(50),
	@Residenza NVARCHAR(50), 
  	@Telefono NVARCHAR(50)
	as
    SET IMPLICIT_TRANSACTIONS ON;
	INSERT INTO Curriculum(Nome,Cognome ,Eta ,Matricola,Email,Residenza ,Telefono)
				VALUES(@Nome,@Cognome,@Eta,@Matricola,@Email,@Residenza,@Telefono)
    COMMIT TRANSACTION 
	go

exec AddCv 'Flo','bb',12,'333aa','4141ss','milano','11131';

go

CREATE PROCEDURE AddCvStudi
    @AnnoI Int, 
  	@AnnoF Int,
	@Titolo VARCHAR(50), 
  	@Descrizione VARCHAR(50), 
  	@IdCv Int
	
	as
    SET IMPLICIT_TRANSACTIONS ON;
	
	declare @IdControl int;
	set @IdControl = (select IdCv from Curriculum where IdCv = @IdCv )

	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
            ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdControl;
			
		end
	 else 	
		begin
			print 'Warning! ID trovato';	
			INSERT INTO PercorsoStudi (AnnoI, AnnoF, Titolo, Descrizione, IdCv )
				VALUES(@AnnoI,@AnnoF,@Titolo,@Descrizione,@IdCv);	
			
			SELECT IDENT_CURRENT('PercorsoStudi') 	 
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
 	declare @IdControl int;
	set @IdControl = (select IdCv from Curriculum where IdCv = @IdCv )

	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
            ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdControl;
			
		end
	 else 	
		begin
			print 'Warning! ID trovato';	
			INSERT INTO EspLav (AnnoI, AnnoF, Qualifica, Descrizione, IdCv) 
			VALUES (@AnnoI, @AnnoF, @Qualifica,@Descrizione,@IdCv);

			SELECT IDENT_CURRENT('EspLav') 		 
		end
		COMMIT TRANSACTION 
	go

CREATE PROCEDURE AddCompetenze
	@Tipo NVARCHAR(50),
    @Livello Int,
    @IdCv Int
as
   SET IMPLICIT_TRANSACTIONS ON;
					
	declare @IdControl int;
	set @IdControl = (select IdCv from Curriculum where IdCv = @IdCv )

	if @IdControl is null
		begin
			print 'Warning! ID non trovato';
            ROLLBACK TRANSACTION;
			THROW 51000,'Warning! ID non trovato',@IdControl;
			
		end
	 else 	
		begin
			print 'Warning! ID trovato';	
			INSERT INTO Competenze (Tipo, Livello, IdCv)
						VALUES (@Tipo,@Livello,@IdCv)

					SELECT IDENT_CURRENT('Competenze')			 
		end
		COMMIT TRANSACTION 
	
	go


