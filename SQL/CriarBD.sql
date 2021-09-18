Create database Portifolio;
use Portifolio;


create table tbProjeto(
	id varchar(50),
    Nome varchar(50) not null,
    Descricao TEXT(16382), 
    Primary key (id)
);


create table tbTags(
	id varchar(50) not null,
    Nome varchar(255) not null,
    primary key (id)
);

create table tbTagsProjeto(
    idProjeto varchar(50) not null,
    idTag varchar(50) not null,
    foreign key (idProjeto) references tbProjeto (id),
    foreign key (idTag) references tbTags (id) 
);


create table tbFoto(
    id varchar(50) not null,
    arquivo_img MEDIUMBLOB not null,
    primary key(id)
);

create table tbFotoProjeto(
    idProjeto varchar(50) not null,
    idFoto varchar(50) not null,
    foreign key(idProjeto) references tbProjeto (id),
    foreign key(idFoto) references tbFoto (id) 
);



create table tbVideosspConsultaID(
	id varchar(50) not null,
    link varchar(255) not null,
    primary key(id)
);

create table tbVideoProjeto(
    idProjeto varchar(50) not null,
    idVideo varchar(50) not null,
    foreign key (idProjeto) references tbProjeto (id),
    foreign key (idVideo) references tbVideos (id) 
);

