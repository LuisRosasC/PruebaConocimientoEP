CREATE TABLE IdentificationTypes
(
	IdentificationTypeId TINYINT PRIMARY KEY,
	Name VARCHAR(3)
)

CREATE TABLE ContactUs
(
	ContactUsId UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
	CustomerFullName VARCHAR(100),
	IdentificationTypeId TINYINT,
	CreationDate DATETIME DEFAULT SYSDATETIME(),
	Comments VARCHAR(500),
	FOREIGN KEY (IdentificationTypeId) REFERENCES IdentificationTypes(IdentificationTypeId)
)

INSERT INTO IdentificationTypes
(
	IdentificationTypeId,
	Name
) VALUES
(1, 'CC'),
(2, 'TI'),
(3, 'CE'),
(4, 'PA'),
(5, 'CD')