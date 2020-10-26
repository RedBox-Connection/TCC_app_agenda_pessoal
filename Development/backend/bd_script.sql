drop database tccdb;
create database tccdb;

use tccdb;

create table tb_login(
	id_login int auto_increment primary key not null,
    ds_email varchar(100) not null,
    ds_senha varchar(100) not null,
    dt_ult_login datetime not null
);

create table tb_esqueci_senha(
	id_esqueci_senha int auto_increment primary key not null,
    ds_email varchar(100),
    nr_codigo long not null,
    tm_inclusao datetime not null,
    tm_expiracao datetime not null,
    id_login int not null,
    foreign key (id_login) references tb_login (id_login) on delete cascade
);

create table tb_usuario(
	id_usuario int auto_increment primary key not null,
    nm_perfil varchar(100) not null,
    nm_usuario varchar(100) not null,
    ds_foto varchar(200) not null,
    bt_receber_email bool not null,
    id_login int not null,
    foreign key (id_login) references tb_login (id_login) on delete cascade
);

create table tb_quadro(
	id_quadro int auto_increment primary key not null,
    nm_quadro varchar(100) not null,
    id_usuario int not null,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade
);

create table tb_time(
	id_time int auto_increment primary key not null,
    nm_time varchar(100) not null,
    ds_time varchar(500),
    ds_link_convite varchar(100),
    id_quadro int not null,
    foreign key (id_quadro) references tb_quadro (id_quadro) on delete cascade
);

create table tb_time_integrante(
	id_integrante int auto_increment primary key not null,
    id_time int not null,
    id_usuario int not null,
    ds_permissao varchar(100) not null,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade,
    foreign key (id_time) references tb_time (id_time) on delete cascade
);

create table tb_cartao(
	id_cartao int auto_increment primary key not null,
    nm_cartao varchar(100) not null,
    ds_cartao varchar(500),
    dt_inclusao datetime not null,
    dt_termino datetime not null,
    ds_cor varchar(100) not null,
    ds_status varchar(100) not null,
    id_quadro int not null,
    foreign key (id_quadro) references tb_quadro (id_quadro) on delete cascade
);

create table tb_cartao_comentario(
	id_comentario int auto_increment primary key not null,
    ds_comentario varchar(300) not null,
    dt_inclusao datetime not null,
    id_cartao int not null,
    id_usuario int not null,
    foreign key (id_cartao) references tb_cartao (id_cartao) on delete cascade,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade
);

create table tb_checklist(
	id_checklist int auto_increment primary key not null,
    nm_checklist varchar(100) not null,
    id_cartao int not null,
    foreign key (id_cartao) references tb_cartao (id_cartao) on delete cascade
);

create table tb_checklist_item(
	id_item int auto_increment primary key not null,
    nm_item varchar(100) not null,
    bt_feito bool not null,
    id_checklist int not null,
    foreign key (id_checklist) references tb_checklist (id_checklist) on delete cascade
);

show tables;

-- Apague o "/*- code here -*/ para criar o banco, as tabelas e inserir registros testes."

/*-
insert into tb_login (ds_email, ds_senha, dt_ult_login) values ("email@gmail.com", "A1234", "2020-09-25-12-13-45");
insert into tb_login (ds_email, ds_senha, dt_ult_login) values ("email2@gmail.com", "A1234", "2020-09-25-12-13-45");

select * from tb_login;

insert into tb_usuario (nm_perfil, nm_usuario, ds_foto, bt_receber_email, id_login) values ("Gustavo", "Gustta", "user.png", true, 1);
insert into tb_usuario (nm_perfil, nm_usuario, ds_foto, bt_receber_email, id_login) values ("Mario", "Mariozin", "user.png", true, 2);

select * from tb_usuario;

insert into tb_esqueci_senha (ds_email, nr_codigo, tm_inclusao, tm_expiracao, id_login) values (null, 452689, "2020-10-13-19-15-00", "2020-10-13-19-45-00", 1);

select * from tb_esqueci_senha;

insert into tb_quadro (nm_quadro, id_usuario) values ("Pessoal", 1);
insert into tb_quadro (nm_quadro, id_usuario) values ("RedBox", 1);

select * from tb_quadro;

insert into tb_time (nm_time, ds_time, ds_link_convite, id_quadro) values ("RedBox", "Melhor grupo de TCC do mundo", null, 2);

select * from tb_time;

insert into tb_time_integrante (id_time, id_usuario, ds_permissao) values (1, 1, "Admin");
insert into tb_time_integrante (id_time, id_usuario, ds_permissao) values (1, 2, "Guest");

select * from tb_time_integrante;

insert into tb_cartao (nm_cartao, ds_cartao, dt_inclusao, dt_termino, ds_cor, ds_status, id_quadro) values ("Aula de Dança", null, "2020-10-01-15-14-31", "2020-11-01-15-14-31", "blue", "Aguardando", 1);
insert into tb_cartao (nm_cartao, ds_cartao, dt_inclusao, dt_termino, ds_cor, ds_status, id_quadro) values ("Aula de Dança Done", null, "2020-10-01-15-14-31", "2020-11-01-15-14-31", "blue", "Concluído", 1);
insert into tb_cartao (nm_cartao, ds_cartao, dt_inclusao, dt_termino, ds_cor, ds_status, id_quadro) values ("Aula de Dança Late", null, "2020-10-01-15-14-31", "2020-11-01-15-14-31", "blue", "Atrasado", 1);
insert into tb_cartao (nm_cartao, ds_cartao, dt_inclusao, dt_termino, ds_cor, ds_status, id_quadro) values ("Aula de Dança Team", null, "2020-10-01-15-14-31", "2020-11-01-15-14-31", "blue", "Aguardando", 2);

select * from tb_cartao;

insert into tb_cartao_comentario (ds_comentario, dt_inclusao, id_cartao, id_usuario) values ("Oiie", "2020-10-02-13-45-00", 1, 2);

select * from tb_cartao_comentario;

insert into tb_checklist (nm_checklist, id_cartao) values ("Comprar Coisas", 1);
insert into tb_checklist (nm_checklist, id_cartao) values ("Comprar Nada", 2);

select * from tb_checklist;

insert into tb_checklist_item (nm_item, bt_feito, id_checklist) values ("Arroz", false, 1);
insert into tb_checklist_item (nm_item, bt_feito, id_checklist) values ("Feijão", true, 1);
insert into tb_checklist_item (nm_item, bt_feito, id_checklist) values ("Carne", false, 1);

select * from tb_checklist_item;
-*/