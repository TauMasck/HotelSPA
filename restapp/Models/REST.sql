CREATE DATABASE Hotel
GO
USE Hotel
GO

CREATE TABLE Rooms (
	Id uniqueidentifier NOT NULL DEFAULT newid() primary key,
	Number int not null,
	How_many_persons int not null,
	Size float not null,
	Price float not null,
	Available int not null
)
CREATE TABLE Treatments (
	Id uniqueidentifier NOT NULL DEFAULT newid() primary key,
	Name varchar(50) not null,
	Price float not null,
	Duration int not null, -- w minutach
	Description varchar(200) not null,
	Active int not null
)

/* 
DROP TABLE Clients 
GO
*/
CREATE TABLE Clients (
	Id uniqueidentifier NOT NULL DEFAULT newid() primary key,
	Name_surname varchar(100) not null,
	Id_number varchar(50) not null,
	Company varchar(100) null,
	Room_number uniqueidentifier constraint FK_room references Rooms(Id) not null,
	Is_here int not null,
	Vegetarian int not null,
	Questionnaire int not null,
	Invoice int not null --faktura
)

/* 
DROP TABLE TreatmentsHistory 
GO
*/
CREATE TABLE TreatmentsHistory(
	Id uniqueidentifier NOT NULL DEFAULT newid() primary key,
	Client_id uniqueidentifier constraint FK_client references Clients(Id) ON DELETE CASCADE not null,
	Treatment_id uniqueidentifier constraint FK_treatment references Treatments(Id) not null,
	This_stay int not null,
	Done int not null
)

