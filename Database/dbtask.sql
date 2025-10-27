create database BookCatalogDB
go

use BookCatalogDB
GO

create table Authors(
	ID int primary key identity(1,1),
	AuthorName nvarchar(200) not null
);
go

create table Books(
	ID int primary key identity(1,1),
	Title NVARCHAR(255) not null,
	AuthorID int not null,
	PublicationYear int not null,
	constraint FK_BOOK_AUTHOR foreign key (AuthorID) references Authors(ID)

);
go


insert into Authors (AuthorName) values
('Robert C. Martin'),
('Jeffrey Richter');
go

insert into Books(Title, AuthorID, PublicationYear) values 
('Clean Code', 1, 2008),
('CLR via C#', 2, 2012),
('The Clean Coder', 1, 2011);
go

update Books set PublicationYear = 2013 where ID = 2
go

delete from Books where ID=3
go

select b.Title, a.AuthorName from Books b join Authors a on a.ID=b.AuthorID where PublicationYear > 2010
go
