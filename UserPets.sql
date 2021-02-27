CREATE TABLE UserPets(
   Id INT NOT NULL,
   PetName NVARCHAR(20) NOT NULL,
   UserId INT NOT NULL
)

INSERT INTO UserPets(Id, PetName, UserId)
VALUES (1, 'Cat', 2)

SELECT * from UserPets
SELECT * FROM Users

SELECT * FROM UserPets p, Users u
WHERE p.UserId = u.Id

SELECT p.PetName, u.LastName, u.FirstName FROM UserPets p, Users u
WHERE p.UserId = u.Id