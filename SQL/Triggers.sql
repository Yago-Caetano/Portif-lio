use Portifolio;
DELIMITER $$
Create TRIGGER TriggerDeleteProjetos BEFORE delete on tbProjeto for each row
BEGIN

    call spDelete_tbTagsProjeto(Old.id);
    
    call spDelete_tbVideoProjeto(Old.id);

    call spDelete_tbFotoProjeto(Old.id);

    call spDelete_tbFotoProjeto(Old.id);
     
END$$
DELIMITER ;

DELIMITER $$
Create TRIGGER TriggerDeleteTags BEFORE delete on tbTags for each row
BEGIN

    delete from tbTagsProjeto where idTag = Old.id;
     
END$$
