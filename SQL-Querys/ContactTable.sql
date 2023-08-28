CREATE TABLE CONTACT(
ContactID int primary key identity,
Name VARCHAR(40),
Phone VARCHAR(20),
BirthDate date,
RegisterDate datetime default getdate()

)

set dateformat dmy

INSERT INTO CONTACT(Name,Phone,BirthDate) VALUES('Soel Attala','2604306032', CONVERT(date,'19/03/1996'))

SELECT * FROM CONTACT