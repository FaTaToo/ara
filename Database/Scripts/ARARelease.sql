use ARARelease

set dateformat dym

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
	Avatar		nvarchar(500) not null,
	Banner		nvarchar(500) not null,	
	Gift		nvarchar(500) not null,
	NumMission	int	not null,
	--Foreign key
	CompanyId	int not null,
	CampaignTypeId int not null,
	---
	RowVersion	RowVersion
)

create table ARA_CampaignType
(
	CampaignTypeId int not null primary key identity(1,1),
	CampaignTypeName nvarchar(100) unique not null,	
	RowVersion	RowVersion
)

create table ARA_Mission
(
	MissionId	int not null primary key identity(1,1),
	MissionName	nvarchar(100) unique not null,		
	Description	nvarchar(500) not null,
	Avatar		nvarchar(500) not null,	
	--Foreign key
	CampaignId int not null,
	---
	RowVersion	RowVersion
)

create table ARA_Target
(
	TargetId	int not null primary key identity(1,1),
	Url			varchar(500) unique not null,
	TargetName	nvarchar(100) unique not null,
	Address		nvarchar(500) not null,
	Latitude	float,
	Longitude	float,	
	FacebookUrl	nvarchar(500),
	YoutubeUrl	nvarchar(500),
	--Foreign key
	MissionId	int not null,		
	---
	RowVersion	RowVersion
)

create table ARA_Subscription
(
	SubscriptionId	nvarchar(100) primary key,	
	CustomerId				int not null,
	CampaignId				int not null,
	CompletedMission		nvarchar(500),
	NumOfCompletedMission	int not null,
	IsComplete				bit not null,
	Comment					nvarchar(500) not null,
	Rating					int not null,
	--Check whether the rating value is suitable.
	constraint chk_Rating check (Rating in (1,2,3,4,5)),
	---
	RowVersion	RowVersion
)

------------------------------------------------------------------------------------------------------------

--ADD FOREIGN KEY-------------------------------------------------------------------------------------------
Alter table ARA_Campaign
Add constraint FK_ARA_Campaign
	foreign key (CompanyId) references ARA_Company(CompanyId),
	foreign key (CampaignTypeId) references ARA_CampaignType(CampaignTypeId)

Alter table ARA_Mission
Add constraint FK_ARA_Mission
	foreign key (CampaignId) references ARA_Campaign(CampaignId)

Alter table ARA_Target
Add constraint FK_ARA_Target 
	foreign key (MissionId) references ARA_Mission(MissionId)

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
values ('Tung','Pham','Male','30-04-1993','Lu Gia','phamtangtung@gmail.com','0968979034','tungpt','tung')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf1','ul1','Male','01-01-1994','Fake addrress 01','fakeemail01@gmail.com','fakephonenumber01','c01','c01')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf2','ul2','Male','01-01-1995','Fake addrress 02','fakeemail02@gmail.com','fakephonenumber02','c02','c02')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf3','ul3','Female','01-01-1996','Fake addrress 03','fakeemail03@gmail.com','fakephonenumber03','c03','c03')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf4','ul4','Female','01-01-1997','Fake addrress 04','fakeemail04@gmail.com','fakephonenumber04','c04','c04')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf5','ul5','Male','01-01-1998','Fake addrress 05','fakeemail05@gmail.com','fakephonenumber05','c05','c05')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf6','ul6','Male','01-01-1999','Fake addrress 06','fakeemail06@gmail.com','fakephonenumber06','c06','c06')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf7','ul7','Male','01-01-1994','Fake addrress 07','fakeemail07@gmail.com','fakephonenumber07','c07','c07')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf8','ul8','Female','01-01-1995','Fake addrress 08','fakeemail08@gmail.com','fakephonenumber08','c08','c08')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf9','ul9','Female','01-01-1996','Fake addrress 09','fakeemail09@gmail.com','fakephonenumber09','c09','c09')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf10','ul10','Male','01-01-1996','Fake addrress 10','fakeemail10@gmail.com','fakephonenumber10','c10','c10')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf11','ul11','Male','01-01-1997','Fake addrress 11','fakeemail11@gmail.com','fakephonenumber11','c11','c11')
insert into ARA_Customer(FirstName,LastName,Sex,BirthDay,Address,Email,Phone,UserName,Password)
values ('uf12','ul12','Male','01-01-1996','Fake addrress 12','fakeemail12@gmail.com','fakephonenumber12','c12','c12')

--Company
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('ELCA','N1 Dien Bien Phu','elca@elca.ch','12345','elca','elca')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('CGS','Quang Trung','cgs@cgs.com','123451','cgs','cgs')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('TMA','Quang Trung','tma@tma.com','123452','tma','tma')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('LARION','Quang Trung','larion@larion.com','123453','larion','larion')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('GALAXY','Nguyen Du','galaxy@galaxy.com','1231234453','galaxy','galaxy')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('LOTTE','Dimond plaza','lotte@lotte.com','12334561234453','lotte','lotte')
insert into ARA_Company(CompanyName,Address,Email,Phone,UserName,Password) 
values ('CGV','Vincom Thu Duc','cgv@cgv.com','12312343245342123453','cgv','cgv')
------------------------------------------------------------------------------------------------------------

--Campaign type
insert into ARA_CampaignType(CampaignTypeName) 
values ('checkin')
insert into ARA_CampaignType(CampaignTypeName) 
values ('tour')
insert into ARA_CampaignType(CampaignTypeName) 
values ('theater')
------------------------------------------------------------------------------------------------------------