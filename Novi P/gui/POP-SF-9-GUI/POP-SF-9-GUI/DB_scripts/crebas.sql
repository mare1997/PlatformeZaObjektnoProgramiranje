
Create table TipNamestaja (
	Id int primary key IDENTITY (1, 1) ,
	Naziv varchar(80),
	Obrisan bit 
)

Create table Akcija(
	Id int primary key IDENTITY (1, 1),
	Dp datetime not null,
	Dk datetime not null,
	Popust int,
	Obrisan bit,
	

)
Create table Namestaj(
	Id int primary key IDENTITY (1, 1),
	TipNamestajaId int, 
	AkcijaId int,
	Naziv varchar(80),
	Obrisan bit ,
	Cena numeric(9,2),
	Kolicina int,
	
	
)

create table DodatnaUsluga(
	Id int primary key IDENTITY (1, 1),
	Naziv varchar(80),
	Obrisan bit ,
	Cena numeric(9,2),

)
create table Korisnik(
	Id int primary key IDENTITY (1, 1),
	Ime varchar(20),
	Prezime varchar(40),
	KorisnickoIme varchar(50),
	Lozinka varchar(50),
	Obrisan bit,
	TipKorisnika bit,
)
create table Racun(
	Id int primary key IDENTITY (1, 1),
	Dp datetime ,
	Kupac varchar(100),
	UkupnaCena numeric(9,2),
)

create table StavkaNamestaja(
	Id int primary key IDENTITY (1, 1),
	RacunId int ,
	NamestajID int,
	Kolicina int,
	 

)
create table StavkaDUsluge(
	Id int primary key IDENTITY (1, 1),
	RacunId int,
	DUId int,

)



