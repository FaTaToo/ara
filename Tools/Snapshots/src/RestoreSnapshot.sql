use master
go
alter database ARA20151119 set single_user with rollback immediate 
go
restore database ARA20151119 from database_snapshot='ARA20151119_SNAPSHOT';	
alter database ARA20151119 set multi_user
go