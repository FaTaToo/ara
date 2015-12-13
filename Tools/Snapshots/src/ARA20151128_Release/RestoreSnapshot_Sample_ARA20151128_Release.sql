use master
go
alter database ARA20151128_Release set single_user with rollback immediate 
go
restore database ARA20151128_Release from database_snapshot='ARA20151128_Release_SNAPSHOT2';	
alter database ARA20151128_Release set multi_user
go