--CREATE TABLE-------------------------------------------------------------------------------------------
create table ARA_Customer
(
	CustomerId	int not null primary key identity(1,1),
	FirstName	nvarchar(100) not null,
	LastName	nvarchar(100) not null,
	Sex			bit not null,
	BirthDay	Date,
	Address		nvarchar(500),
	Email		varchar(100) unique not null,
	Phone		varchar(20) unique,
	UserName	varchar(100) unique not null,
	Password	varchar(100) not null,
	---
	RowVersion	RowVersion
)

create table ARA_Company
(
	CompanyId	int not null primary key identity(1,1),
	CompanyName	nvarchar(100) unique not null,
	Address		nvarchar(500) not null,
	Email		varchar(100) unique not null,
	Phone		varchar(20) unique not null,
	UserName	varchar(100) unique not null,
	Password	varchar(100) not null,
	RowVersion	RowVersion
)

create table ARA_Campaign
(
	CampaignId	int not null primary key identity(1,1),
	CampaignName nvarchar(100) unique not null,
	StartTime	datetime not null,
	EndTime		datetime,
	Description	nvarchar(500) not null,
	Banner		varchar(500) not null,
	Avatar		varchar(500) not null,
	Gift		nvarchar(500) not null,
	NumMission	int	not null,
	---
	--Foreign key
	CompanyName	nvarchar(100) unique not null,
	---
	RowVersion	RowVersion
)

create table ARA_Mission
(
	MissionId	int not null primary key identity(1,1),
	MissionName	nvarchar(100) unique not null,		
	Description	nvarchar(500) not null,
	Avatar		varchar(500) not null,	
	IsComplete  bit not null,	
	NumTarget	int not null,
	---
	--Foreign key
	CampaignName nvarchar(100) unique not null,
	---
	RowVersion	RowVersion
)

create table ARA_Target
(
	TargetId	int not null primary key identity(1,1),
	Url			varchar(500) not null,
	TargetName	nvarchar(100) unique not null,
	Latitude	int,
	Longitude	int,
	Description	nvarchar(500) not null,
	IsComplete  bit not null,	
	VideoUrl	nvarchar(500),
	FacebookUrl	nvarchar(500),
	YoutubeUrl	nvarchar(500),
	--
	--Foreign key
	MissionName	nvarchar(100) not null,		
	---
	RowVersion	RowVersion
)

create table ARA_Subscription
(
	SubscriptionId	nvarchar(100) primary key,	
	CustomerId	int not null,
	CampaignId	int not null,
	IsComplete	bit not null,
	Comment		nvarchar(500) not null,
	Rating		int not null,
	---
	--Check whether the rating value is suitable.
	constraint chk_Rating check (Rating in (1,2,3,4,5)),
	---
	RowVersion	RowVersion
)
------------------------------------------------------------------------------------------------------------

--ADD FOREIGN KEY-------------------------------------------------------------------------------------------
Alter table ARA_Campaign
Add constraint FK_ARA_Campaign
	foreign key (CompanyName) references ARA_Company(CompanyName)

Alter table ARA_Mission
Add constraint FK_ARA_Mission
	foreign key (CampaignName) references ARA_Campaign(CampaignName)

Alter table ARA_Target
Add constraint FK_ARA_Target 
	foreign key (MissionName) references ARA_Mission(MissionName)

Alter table ARA_Subscription
Add constraint FK_ARA_Subscription
	foreign key (CustomerId) references ARA_Customer(CustomerId),
	foreign key (CampaignId) references ARA_Campaign(CampaignId)
------------------------------------------------------------------------------------------------------------

--INSERT DATA-----------------------------------------------------------------------------------------------
--Customer
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('Phuc','Le','1','1993-02-18','abc','phucls288@gmail.com','0933111875','phucls','phuc')

--Company
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('ELCA','N1 Dien Bien Phu','elca@elca.ch','12345','elca','mpt')
------------------------------------------------------------------------------------------------------------