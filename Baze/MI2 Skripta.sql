create database Rwa_WebFromsDB
GO
use Rwa_WebFromsDB
GO

Create Table Cities(
	ID int primary key identity,
	CityName nvarchar(50)
)
GO
INSERT INTO Cities(CityName)
VALUES('Zagreb'),
('Varaždin'),
('Split'),
('Rijeka'),
('Pula'),
('Osijek'),
('Dubrovnik')
GO


Create Table PersonRoles(
	ID int primary key identity,
	RoleName nvarchar(50)
)
GO
INSERT INTO PersonRoles(RoleName)
VALUES('Korisnik')

INSERT INTO PersonRoles(RoleName)
VALUES('Administrator')
GO

Create Table Persons(
	ID int primary key identity,
	PersonName nvarchar(50) NOT NULL,
	PersonSurname nvarchar(50) NOT NULL,
	PersonPassword nvarchar(50) NOT NULL,
	PersonPhone nvarchar(50) NOT NULL,
	PersonEmail nvarchar(100) NOT NULL,
	PersonEmail2 nvarchar(100) NULL,
	PersonEmail3 nvarchar(100) NULL,
	CityId int foreign  key references Cities(ID) NULL,
	PersonRole int foreign key references PersonRoles(ID)
)
GO

CREATE PROCEDURE dbo.InsertPerson
	@PersonName nvarchar(50),
	@PersonSurname nvarchar(50),
	@PersonPassword nvarchar(50),
	@PersonPhone nvarchar(50),
	@PersonEmail nvarchar(100),
	@PersonEmail2 nvarchar(100),
	@PersonEmail3 nvarchar(100),
	@City nvarchar(50),
	@RoleName nvarchar(50)
AS
	DECLARE @cityID int
	SELECT @CityId = Cities.ID FROM Cities WHERE Cities.CityName = @City

	DECLARE @roleID int
	SELECT @roleID = PersonRoles.ID FROM PersonRoles WHERE PersonRoles.RoleName = @RoleName

	INSERT INTO Persons(PersonName, PersonSurname, PersonPassword, PersonPhone, PersonEmail, PersonEmail2, PersonEmail3, CityId, PersonRole)
	VALUES(@PersonName, @PersonSurname, @PersonPassword,@PersonPhone,@PersonEmail,@PersonEmail2,@PersonEmail3,@cityID, @roleID)
RETURN 0 

GO

CREATE PROCEDURE dbo.CheckLogin
	@PersonEmailIn nvarchar(100),
	@PersonPasswordIn nvarchar(50)
AS
	IF @PersonEmailIn IN (
						SELECT p.PersonEmail
						FROM Persons as p) OR
	   @PersonEmailIn IN (
						SELECT p.PersonEmail2
						FROM Persons as p) OR
	   @PersonEmailIn IN (
						SELECT p.PersonEmail3
						FROM Persons as p)
		BEGIN
			DECLARE @ID int
			SELECT @ID = Persons.ID FROM Persons WHERE Persons.PersonEmail = @PersonEmailIn OR Persons.PersonEmail2 = @PersonEmailIn OR Persons.PersonEmail3 = @PersonEmailIn 

			DECLARE @RealPassword nvarchar(50)
			SELECT @RealPassword = Persons.PersonPassword FROM Persons WHERE Persons.ID = @ID

			IF @PersonPasswordIn =  @RealPassword
				BEGIN
					SELECT Persons.ID FROM Persons WHERE Persons.ID = @ID
				END
			ELSE BEGIN
				SELECT -1
			END
		END

		ELSE BEGIN
			SELECT -2
		END
RETURN 0 

GO


CREATE PROCEDURE dbo.GetUserRole
	@PersonID int
AS
	SELECT pr.RoleName
	FROM Persons as p
	INNER JOIN PersonRoles as pr ON pr.ID = p.PersonRole
	WHERE @PersonID = p.ID
RETURN 0 

GO

CREATE PROCEDURE dbo.UpdatePerson
	@PersonID int,
	@PersonName nvarchar(50),
	@PersonSurname nvarchar(50),
	@PersonPassword nvarchar(50),
	@PersonPhone nvarchar(50),
	@PersonEmail nvarchar(100),
	@PersonEmail2 nvarchar(100),
	@PersonEmail3 nvarchar(100),
	@City nvarchar(50),
	@RoleName nvarchar(50)
AS

	DECLARE @cityID int
	SELECT @CityId = Cities.ID FROM Cities WHERE Cities.CityName = @City

	DECLARE @roleID int
	SELECT @roleID = PersonRoles.ID FROM PersonRoles WHERE PersonRoles.RoleName = @RoleName

	UPDATE Persons
	SET PersonName = @PersonName,
		PersonSurname = @PersonSurname,
		PersonPassword = @PersonPassword,
		PersonPhone = @PersonPhone,
		PersonEmail = @PersonEmail,
		PersonEmail2 = @PersonEmail2,
		PersonEmail3 = @PersonEmail3,
		CityId = @cityID,
		PersonRole = @roleID
	WHERE ID = @PersonID
RETURN 0 

GO

CREATE PROCEDURE dbo.DeletePerson
	@PersonID int
AS
	DELETE FROM Persons
	WHERE ID = @PersonID
RETURN 0 

GO

CREATE PROCEDURE dbo.GetCompleteUserByID
	@PersonID int
AS
	SELECT p.ID, p.PersonName, p.PersonSurname, p.PersonPassword, p.PersonPhone, p.PersonEmail, p.PersonEmail2, p.PersonEmail3, c.CityName, pr.RoleName
	FROM Persons as p
	INNER JOIN PersonRoles as pr ON pr.ID = p.PersonRole
	INNER JOIN Cities as c ON c.ID = p.CityId
	WHERE @PersonID = p.ID
RETURN 0 

GO

CREATE PROCEDURE dbo.GetAllPersons
AS
	SELECT p.ID, p.PersonName, p.PersonSurname, p.PersonPassword, p.PersonPhone, p.PersonEmail, p.PersonEmail2, p.PersonEmail3, c.CityName, pr.RoleName
	FROM Persons as p
	INNER JOIN PersonRoles as pr ON pr.ID = p.PersonRole
	INNER JOIN Cities as c ON c.ID = p.CityId
RETURN 0 

GO


--INSERT DATA
GO
EXEC dbo.InsertPerson 'admin2','administratorovic', 'p','099 555 6789','admin@admin.hr', NULL, NULL, 'Osijek', 'Administrator'
EXEC dbo.InsertPerson 'korisnik','Korisnikovic', 'p','093 333 4456','korisnik@korisnik.hr', 'korisnike2@korisnik.hr', 'korisnike3@korisnik.hr', 'Osijek', 'Korisnik'
EXEC dbo.InsertPerson 'admin2','adminPrimjer', 'p','099 546 6548','administrator@admin.hr', NULL, NULL, 'Osijek', 'Administrator'
EXEC dbo.InsertPerson 'korisnik','korisnikPrimjer', 'p','093 514 2367','korisnikko@korisnik.hr', 'korisnike2@korisnik.hr', 'korisnike3@korisnik.hr', 'Osijek', 'Korisnik'

GO


--TESTS
--SELECT * FROM Persons
--SELECT * FROM Cities
--SELECT * FROM PersonRoles

--EXEC dbo.CheckLogin 'admin@admin.hr','p'
--EXEC dbo.CheckLogin 'admin@admin.hr','wrongpass'
--EXEC dbo.CheckLogin 'noSuchUser@admin.hr','p'
--EXEC dbo.CheckLogin 'korisnike2@korisnik.hr','p'

--EXEC dbo.GetUserRole 1
--EXEC dbo.GetUserRole 2

--EXEC dbo.UpdatePerson 3, 'korisnik','Korisnikovic', 'p','093 333 4456','korisnik@korisnik.hr', 'updated@korisnik.hr', 'korisnike3@korisnik.hr', 'Zagreb', 'Korisnik'

--EXEC dbo.DeletePerson 2

--EXEC dbo.GetCompleteUserByID 1

--EXEC dbo.GetAllPersons



--FIX
--DROP PROC dbo.CheckLogin
--DROP PROC dbo.InsertPerson
--drop proc dbo.UpdatePerson