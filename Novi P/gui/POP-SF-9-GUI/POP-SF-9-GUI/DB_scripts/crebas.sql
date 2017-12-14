Create table TipNamestaja (
	Id int primary key identity(1,1),
	Naziv varchar(80),
	Obrisan bit 
)
go

Create table Namestaj(
	Id int primary key identity(1,1),
	TipNamestajaId int, 
	
	Naziv varchar(80),
	Obrisan bit ,
	Cena numeric(9,2),
	Kolicina int,
	KolicinaApp int,
	Foreign key (TipNamestajaId) references TipNamestaja(Id),
	
)