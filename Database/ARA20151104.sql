use ARA20151104

--CREATE TABLE-------------------------------------------------------------------------------------------
create table ARA_Customer
(
	CustomerId	int not null primary key identity(1,1),
	FirstName	nvarchar(100) not null,
	LastName	nvarchar(100) not null,
	Sex			varchar(6) not null,
	BirthDay	Date not null,
	Address		nvarchar(500),
	Email		varchar(100) unique not null,
	Phone		varchar(20) unique not null,
	UserName	varchar(100) unique not null,
	Password	varchar(100) not null,
	---
	--Check whether the rating value is suitable.
	constraint chk_Sex check (Sex in ('Male','Female')),	
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
	Banner		image not null,
	Avatar		image not null,
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
	Avatar		image not null,	
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
	Latitude	float,
	Longitude	float,
	Description	nvarchar(500) not null,
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
set dateformat dmy	
--Customer
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('Phuc','Le','Male','18-02-1993','91 Vu Tung, Ward 2, BinH Thanh district','phucls288@gmail.com','0933111875','phucls','phuc')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('Phuc','Le','Female','30-04-1993','Lu Gia','phamtangtung@gmail.com','0968979034','tungpt','tung')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf1','ul1','Male','01-01-1993','Fake addrress 01','fakeemail01@gmail.com','fakephonenumber01','c01','c01')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf2','ul2','Male','01-01-1993','Fake addrress 02','fakeemail02@gmail.com','fakephonenumber02','c02','c02')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf3','ul3','Male','01-01-1993','Fake addrress 03','fakeemail03@gmail.com','fakephonenumber03','c03','c03')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf4','ul4','Male','01-01-1993','Fake addrress 04','fakeemail04@gmail.com','fakephonenumber04','c04','c04')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf5','ul5','Male','01-01-1993','Fake addrress 05','fakeemail05@gmail.com','fakephonenumber05','c05','c05')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf6','ul6','Male','01-01-1993','Fake addrress 06','fakeemail06@gmail.com','fakephonenumber06','c06','c06')

insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf7','ul7','Male','01-01-1993','Fake addrress 07','fakeemail07@gmail.com','fakephonenumber07','c07','c07')

--Company
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('ELCA','N1 Dien Bien Phu','elca@elca.ch','12345','elca','mpt')

insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('CGS','Quang Trung','cgs@cgs.com','123451','cgs','cgs')

insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('TMA','Quang Trung','tma@tma.com','123452','tma','tma')

insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('Larion','Quang Trung','larion@larion.com','123453','larion','larion')
------------------------------------------------------------------------------------------------------------