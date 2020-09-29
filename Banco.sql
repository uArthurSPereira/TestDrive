create database mydb;

use mydb;

show tables;

select*from tb_agendamento;

insert into tb_login(ds_email,ds_senha,ds_perfil)
values ('test123@gmail.com','test123','Cliente');

insert into tb_login(ds_email,ds_senha,ds_perfil)
values ('funcionariotest123@gmail.com','funcionariotest123','Funcionario');

insert into tb_login(ds_email,ds_senha,ds_perfil)
values ('cliente2test@gmail.com','cliente2test','Cliente');

insert into tb_cliente(nm_cliente,ds_cnh,ds_cpf,id_login)
values('Arthur test','12345678900','123.456.789-10',1);

insert into tb_cliente(nm_cliente,ds_cnh,ds_cpf,id_login)
values('Bruno test','00000000000','000.000.000-00',3);

insert into tb_funcionario(nm_funcionario,id_login)
value('Diego test', '2');

insert into tb_carro(ds_marca,ds_modelo,ds_placa,dt_ano)
value('Chevrolet','Cruze','tst1234','2018');

insert into tb_carro(ds_marca,ds_modelo,ds_placa,dt_ano)
value('Fiat','Toro','hoj1234','2020');

insert into tb_agendamento(id_cliente,id_funcionario,id_carro,dt_agendamento,ds_situacao)
value(1,1,1,'2020-09-29','Aprovado');

insert into tb_agendamento(id_cliente,id_funcionario,id_carro,dt_agendamento,ds_situacao)
value(2,1,2,'2020-10-30','Em Análise');

create table tb_login(
id_login int primary key auto_increment,
ds_email varchar(150),
ds_senha varchar(50),
ds_perfil varchar(50)
);

create table tb_cliente(
id_cliente int primary key auto_increment,
nm_cliente varchar (100),
ds_cnh varchar (50),
ds_cpf varchar (50),
id_login int,
foreign key (id_login) references tb_login (id_login)
);

create table tb_funcionario(
id_funcionario int primary key auto_increment,
nm_funcionario varchar(100),
id_login int,
foreign key (id_login) references tb_login (id_login)
);

create table tb_carro(
id_carro int primary key auto_increment,
ds_modelo varchar(50),
ds_marca varchar(50),
ds_placa varchar(50),
dt_ano year
);

create table tb_agendamento(
id_agendamento int primary key auto_increment,
id_cliente int,
id_funcionario int,
id_carro int,
dt_agendamento datetime,
ds_situacao varchar(50),
foreign key (id_cliente) references tb_cliente(id_cliente),
foreign key (id_funcionario) references tb_funcionario(id_funcionario),
foreign key (id_carro) references tb_carro(id_carro)
);