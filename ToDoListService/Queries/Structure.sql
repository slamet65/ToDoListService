if exists (select 1 from sys.tables where name = 'Users')
	drop table Users
GO

create table Users (
	Id int identity(1,1),
	Username varchar(25),
	Email varchar(250),
	PasswordHash varchar(2500),
	PasswordSalt varchar(2500)
)
GO
if exists (select 1 from sys.tables where name = 'Checklists')
	drop table Checklists
GO

create table Checklists (
	Id int identity(1,1),
	[Name] varchar(250)
)

if exists (select 1 from sys.tables where name = 'ChecklistItem')
	drop table ChecklistItem
GO

create table ChecklistItem (
	Id int identity(1,1),
	[Name] varchar(250),
	ChecklistId int,
	[Status] bit
)
