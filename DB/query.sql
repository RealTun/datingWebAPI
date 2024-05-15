use Dating;

select * from user_account
 
select * from [relationship_type]

select * from [interest_type]

DELETE FROM [interest_type]

DBCC CHECKIDENT ('interest_type', RESEED, 1);
