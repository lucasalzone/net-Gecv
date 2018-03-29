create procedure DeleteCurriculum
	@idcurr int
as
	begin transaction 
	declare @test int;
	set @test = (select IdCv from Curriculum c where c.IdCv=@idcurr);
	if @test is null
		begin 
			rollback transaction ;
			throw 66666 , 'id errato riprovare!' ,2;
		end
	else
		begin
			delete Competenze from Competenze cs where cs.IdCv = @idcurr;
			delete EspLav from EspLav es where es.IdCv=@idcurr;
			delete PercorsoStudi from PercorsoStudi ps where ps.IdCv=@idcurr;
			delete Curriculum from Curriculum c where c.IdCv=@idcurr;
			commit transaction;
		end
go