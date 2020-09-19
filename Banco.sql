create database mydb;

use mydb;

show tables;

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