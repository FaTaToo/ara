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
	---
	--Foreign key
	AccountId	int unique not null,
	---
	RowVersion	RowVersion
)

create table ARA_AccountType
(
	AccountTypeId	int not null primary key identity(1,1),
	Name			nvarchar(100) unique not null,
	GroupType		int not null,
	---
	--Check whether the account is business type or customer type.
	constraint check_GroupType check (GroupType in (1,2)),
	---
	RowVersion		RowVersion
)

create table ARA_Account
(
	AccountId		int not null primary key identity(1,1),
	UserName		varchar(100) unique not null,
	Password		varchar(100) not null,
	---
	--Foreign key
	AccountTypeId	int not null,
	---
	RowVersion	RowVersion
)

create table ARA_CompanyAccount
(
	AccountId	int not null,
	CompanyId	int not null,
	UserName	nvarchar(100) not null,
	Password	varchar(100) not null,
	---
	--primary key
	Primary key (AccountId, CompanyId),
	---
	RowVersion	RowVersion
)

create table ARA_Company
(
	CompanyId	int not null primary key identity(1,1),
	Name		nvarchar(100) unique not null,
	Address		nvarchar(500) not null,
	Email		varchar(100) unique not null,
	Phone		varchar(20) unique not null,
	---
	RowVersion	RowVersion
)

create table ARA_Campaign
(
	CampaignId	int not null primary key identity(1,1),
	Name		nvarchar(100) unique not null,
	StartTime	datetime not null,
	EndTime		datetime,
	Descriptor	nvarchar(500) not null,
	Banner		varchar(500) not null,
	Avatar		varchar(500) not null,
	Gift		nvarchar(500) not null,
	NumMission	int	not null,
	---
	--Foreign key
	CompanyId	int not null,
	---
	RowVersion	RowVersion
)

create table ARA_Mission
(
	MissionId	int not null primary key identity(1,1),
	Name		nvarchar(100) unique not null,		
	Descriptor	nvarchar(500) not null,
	Avatar		varchar(500) not null,	
	IsComplete  bit not null,	
	NumTarget	int not null,
	---
	--Foreign key
	CampaignId	int not null,
	PreMission	int unique,
	---
	RowVersion	RowVersion
)

create table ARA_Target
(
	TargetId	int not null primary key identity(1,1),
	Url			varchar(500) not null,
	Name		nvarchar(100) unique not null,
	Latitude	int,
	Longitude	int,
	Descriptor	nvarchar(500) not null,
	IsComplete  bit not null,	
	--
	--Foreign key
	MissionId	int not null,
	PreTarget	int unique,
	---
	RowVersion	RowVersion
)

create table ARA_ArData
(
	ArDataId	int not null primary key identity(1,1),
	VideoUrl	nvarchar(500),
	FacebookUrl	nvarchar(500),
	YoutubeUrl	nvarchar(500),
	---
	--Foreign key
	TargetId	int unique not null,
	---
	RowVersion	RowVersion
)

create table ARA_Subscription
(
	CustomerId	int not null,
	CampaignId	int not null,
	IsComplete	bit not null,
	GiftCode	char(20),
	Comment		nvarchar(500) not null,
	Rating		int not null,
	---
	--Check whether the account is business type or customer type.
	constraint check_Rating check (Rating in (1,2,3,4,5)),
	--primary key
	Primary key (CustomerId,CampaignId),
	---
	RowVersion	RowVersion
)
------------------------------------------------------------------------------------------------------------

--ADD FOREIGN KEY-------------------------------------------------------------------------------------------
Alter table ARA_Customer
Add constraint FK_ARA_Customer
	foreign key (AccountId) references ARA_Account(AccountId)

Alter table ARA_Account
Add constraint FK_ARA_Account
	foreign key (AccountTypeId) references ARA_AccountType(AccountTypeId)

Alter table ARA_Campaign
Add constraint FK_ARA_Campaign
	foreign key (CompanyId) references ARA_Company(CompanyId)

Alter table ARA_Mission
Add constraint FK_ARA_Mission
	foreign key (CampaignId) references ARA_Campaign(CampaignId),
	foreign key (PreMission) references ARA_Mission(MissionId) 

Alter table ARA_Target
Add constraint FK_ARA_Target 
	foreign key (MissionId) references ARA_Mission(MissionId),
	foreign key (PreTarget) references ARA_Target(TargetId)

Alter table ARA_ArData
Add constraint FK_ARA_ArData
	foreign key (TargetId) references ARA_Target(TargetId)

Alter table ARA_CompanyAccount
Add constraint FK_ARA_CompanyAccount
	foreign key (AccountId) references ARA_Account(AccountId),
	foreign key (CompanyId) references ARA_Company(CompanyId)

Alter table ARA_Subscription
Add constraint FK_ARA_Subscription
	foreign key (CustomerId) references ARA_Customer(CustomerId),
	foreign key (CampaignId) references ARA_Campaign(CampaignId)
------------------------------------------------------------------------------------------------------------

--INSERT DATA-----------------------------------------------------------------------------------------------
insert into ARA_AccountType (Name,GroupType) values ('Limited company',1)
insert into ARA_AccountType (Name,GroupType) values ('Movie theater',1)
insert into ARA_AccountType (Name,GroupType) values ('Stock company',1)
insert into ARA_AccountType (Name,GroupType) values ('Shop',1)
insert into ARA_AccountType (Name,GroupType) values ('Customer',2)
------------------------------------------------------------------------------------------------------------