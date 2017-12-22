﻿Create table TipNamestaja (
	Id int primary key identity(1,1),
	Naziv varchar(80),
	Obrisan bit 
)
go
Create table Akcija(
	Id int primary key identity(1,1),
	Dp datetime not null,
	Dk datetime not null,
	Popust numeric(2,2),
	Obrisan bit,
	

)
Create table Namestaj(
	Id int primary key identity(1,1),
	TipNamestajaId int, 
	Akcija int,
	Naziv varchar(80),
	Obrisan bit ,
	Cena numeric(9,2),
	Kolicina int,
	
	Foreign key (TipNamestajaId) references TipNamestaja(Id),
	Foreign key (Akcija) references Akcija(Id),
	
)

create table DodatnaUsluga(
	Id int primary key,
	Naziv varchar(80),
	Obrisan bit ,
	Cena numeric(9,2),

)
create table Racun(
	Id int primary key,
	Dp datetime ,
	Kupac varchar(100),
	NamestajId int,
	DUId int,
	UkupnaCena numeric(9,2),
)
create table StavkaNametsaja(
	Id int primary key,
	RacunId int,
	NamestajID int,
	Kolicina int,
)
create table StavkaDUsluge(
	Id int primary key,
	RacunId int,
	DUId int,
)
create table Korisnik(
	Id int primary key,
	Ime varchar(20),
	Prezime varchar(40),
	KorisnickoIme varchar(50),
	Lozinka varchar(50),
	Obrisan bit,
	TipKorisnika bit,
)

//uraditi validaciju i transakciju