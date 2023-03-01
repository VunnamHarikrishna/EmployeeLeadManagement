create database KalingaData

use KalingaData

--------------------------create CatageryData


CREATE TABLE CatageryData (
    CatageryID int IDENTITY(100,1) PRIMARY KEY,
    CatageryName varchar(255)
);

--------------------------create LeadData


CREATE TABLE LeadData (
    LeadID int IDENTITY(100,1) PRIMARY KEY,
    Name varchar(255),
    CatogeryID int,
    ContactNumber varchar(255),
	FOREIGN KEY (CatogeryID) REFERENCES CatageryData(CatageryID)
);

drop table LeadData
---alterning table 
ALTER TABLE LeadData
DROP COLUMN CatogeryId;

ALTER TABLE LeadData
ADD FOREIGN KEY (CatogeryId) REFERENCES CatageryData(CatogeryId);

FOREIGN KEY (CatogeryId) REFERENCES CatageryData(CatogeryId)

--------------------------create StudentData

CREATE TABLE StudentData (
    StudentID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    DOJ varchar(255),
    ContactNumber varchar(255),
    Address varchar(255),
	LeadID int,
	FOREIGN KEY (LeadID) REFERENCES LeadData(LeadID)
);


--------------------store procedures------------------------------------------------------


--------------------store AddStudentData

CREATE PROCEDURE AddStudentData(@Name varchar(255),
@DOJ varchar(255),
@ContactNumber varchar(255),
@Address varchar(255),
@LeadId int) 
AS
begin
INSERT INTO StudentData VALUES (@Name,@DOJ,@ContactNumber,@Address,@LeadId);
end;


--------------------store AddLeadData


CREATE PROCEDURE AddLeadData(@Name varchar(255),
@CatogeryId int,
@ContactNumber varchar(255))
AS
begin
INSERT INTO LeadData VALUES (@Name,@CatogeryId,@ContactNumber);
end;


--------------------store GetCatageryData

CREATE PROCEDURE GetCatageryData
AS
begin
select * from CatageryData
end;

--------------------store GetStudentData


CREATE PROCEDURE GetStudentData
AS
begin
select * from StudentData
end;

--------------------store GetLeadData


CREATE PROCEDURE GetLeadData
AS
begin
select * from LeadData
end;

---------------store procedure update lead in student 

CREATE PROCEDURE UpdateLead(@LeadId int,
@Id int)
AS
begin
UPDATE StudentData set LeadId=@LeadId where StudentId=@Id
end;
 
---------------store procedure update  student data

CREATE PROCEDURE UpdateStudentData(@Name varchar(255),
@DOJ varchar(255),
@ContactNumber varchar(255),
@Address varchar(255),
@LeadId int,
@Id int)
AS
begin
UPDATE StudentData set name=@Name,DOJ=@DOJ,ContactNumber= @ContactNumber,Address= @Address,LeadId= @LeadId where StudentId=@Id
end;

---------------store procedure update  GetStudentDataByLeadId

CREATE PROCEDURE GetStudentDataByLeadId(@LeadId int)
AS
begin
select * from StudentData where LeadId=@LeadId
end;

---------------store procedure update  GetStudentDataByLeadId

CREATE PROCEDURE RemoveStudent(@Id int)
AS
begin
DELETE FROM StudentData WHERE StudentId=@Id;
end;

DELETE FROM StudentData WHERE StudentId=@Id;