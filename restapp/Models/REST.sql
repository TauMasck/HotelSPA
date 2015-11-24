CREATE DATABASE Hotel
GO
USE Hotel
GO

CREATE TABLE Rooms (
	Id int identity primary key,
	Number int not null,
	How_many_persons int not null,
	Size float not null,
	Price float not null,
	Available int not null
)
CREATE TABLE Treatments (
	Id int identity primary key not null,
	Name varchar(50) not null,
	Price float not null,
	Duration int not null, -- w minutach
	Description varchar(200) not null,
	Active int not null
)

CREATE TABLE Clients (
	Id int identity primary key not null,
	Name_surname varchar(100) not null,
	Id_number int not null,
	Company varchar(100) not null,
	Room_number int constraint FK_room references Rooms(Id) not null,
	Is_here int not null,
	Vegetarian int not null,
	Questionnaire int not null,
	Invoice int not null --faktura
)

CREATE TABLE TreatmentsHistory(
	Id int identity primary key not null,
	Client_id int constraint FK_client references Clients(Id) not null,
	Treatment_id int constraint FK_treatment references Treatments(Id) not null,
	This_stay int not null,
	Done int not null
)
