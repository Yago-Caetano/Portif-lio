use Portifolio;
-- ---------------------------------------------------------------------------------------------------
DELIMITER $$
create PROCEDURE spInsert_tbProjeto(_id  varchar(50),_Nome varchar(50),_Descricao text(16382))
BEGIN
	insert into tbProjeto (id,Nome,Descricao) values (_id,_Nome,_Descricao);
END$$
DELIMITER ;


DELIMITER $$
create PROCEDURE spListagem_tbProjeto()
BEGIN
	select * from tbProjeto;
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spUpdate_tbProjeto(_id  varchar(50),_Nome varchar(50),_Descricao varchar(16382))
BEGIN
	update tbProjeto set 
	Nome=_Nome,
	Descricao=_Descricao
	where id=_id;
    
END$$
DELIMITER ;
-- -------------------------------------------------------------------------------------------------------
-- ---------------------------------------------------------------------------------------------------------- Tags
DELIMITER $$
create PROCEDURE spInsert_tbTags
(_id  varchar(50),_Nome varchar(255))
BEGIN
	insert into tbTags (id,Nome) 
    values (_id,_Nome);
END$$
DELIMITER ;



DELIMITER $$
create PROCEDURE spUpdate_tbTags(_id  varchar(50),_Nome varchar(255))
BEGIN
	update tbTags set 
	Nome=_Nome
	where id=_id;
    
END$$
DELIMITER ;


-- --------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------

DELIMITER $$
create PROCEDURE spInsert_tbFoto
(_id  varchar(50),_Foto MEDIUMBLOB,_idProjeto varchar(50))
BEGIN
	insert into tbFoto (id,arquivo_img) values (_id,_Foto);
    insert into tbFotoProjeto (idProjeto,idFoto) values (_idProjeto,_id);
END$$


DELIMITER $$
create PROCEDURE spUpdate_tbFoto(_id  varchar(50),_Foto MEDIUMBLOB)
BEGIN
	update tbFoto set 
	arquivo_img=_Foto
	where id=_id;
    
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spConsulta_tbFotoProjeto(_idProjeto  varchar(50))
BEGIN
	select f.id, f.arquivo_img from tbfoto as f inner join tbfotoprojeto as fp on f.id = fp.idFoto where fp.idProjeto = _idProjeto;
END$$
DELIMITER ;

-- --------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------

DELIMITER $$
create PROCEDURE spInsert_tbVideos
(_id  varchar(50),_Link varchar(255),_idProjeto varchar(50))
BEGIN
	insert into tbVideos (id,link) values (_id,_Link);
    insert into tbVideoProjeto (idProjeto,idVideo) values (_idProjeto,_id);
END$$
DELIMITER ;


DELIMITER $$
create PROCEDURE spUpdate_tbVideos(_id  varchar(50),_Link varchar(255))
BEGIN
	update tbVideos set 
	link=_Link
	where id=_id;
    
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spConsulta_tbVideoProjeto(_idProjeto  varchar(50))
BEGIN
	select v.id, v.link from tbVideos as v inner join tbVideoProjeto as vp on v.id = vp.idVideo where vp.idProjeto = _idProjeto;
END$$
DELIMITER ;

-- ------------------------------------------------------------------ SP TAGS/PROJETOS ------------------------------------------------------------------ 

DELIMITER $$
create PROCEDURE spInsert_tbTagsProjeto
(_idProjeto varchar(50),_idTag varchar(50))
BEGIN
	insert into tbTagsProjeto (idProjeto,idTag) values (_idProjeto,_idTag);
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spConsulta_tbTagsProjeto(_idProjeto  varchar(50))
BEGIN
	select * from tbTagsProjeto where idProjeto = _idProjeto;
END$$
DELIMITER ;

-- ------------------------------------------------------------------ SP GENERICAS ------------------------------------------------------------------ 
DELIMITER $$
create PROCEDURE spConsultaID(tabela varchar(100),idserial varchar(50))
BEGIN
	DECLARE  SQL_Query varchar(600);
    Set @SQL_Query =(Select Concat('select id from ',tabela,' where id = ',"'",idserial,"'"));
	PREPARE stmt FROM @SQL_Query;
	EXECUTE stmt;
	DEALLOCATE PREPARE stmt; 
    
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spListagem(tabela varchar(100),ordem varchar(50))
BEGIN
	DECLARE  SQL_Query varchar(600);
    Set @SQL_Query =(Select Concat('select* from ',tabela,' order by ',ordem));
	PREPARE stmt FROM @SQL_Query;
	EXECUTE stmt;
	DEALLOCATE PREPARE stmt; 
    
END$$
DELIMITER ;

DELIMITER $$
create PROCEDURE spConsulta(id varchar(50),tabela varchar(100))
BEGIN
	DECLARE  SQL_Query varchar(600);
	if id is not null then
		Set @SQL_Query =(Select Concat('select* from ',tabela,' where id = ',"'",id,"'",';'));
        PREPARE stmt FROM @SQL_Query;
        EXECUTE stmt;
		DEALLOCATE PREPARE stmt; 
    end if;
    
END$$
DELIMITER ;