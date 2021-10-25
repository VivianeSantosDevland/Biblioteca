create database Biblioteca;
use Biblioteca;

create table cliente
( CodigoCliente    int auto_increment,
  Nome             varchar(60),
primary key(CodigoCliente)
);

create table livro
( CodigoLivro      int auto_increment,
  Titulo           varchar(60),
  Autor            varchar(60),
  Edicao           varchar(10),
  Editora          varchar(20),
  primary key(CodigoLivro)
);

create table emprestimo
( CodigoEmprest    int auto_increment,
  DataEmprest      date,
  CodigoCli        int references cliente,
  CodigoLiv        int references livro,
  primary key(CodigoEmprest)
);

