CREATE TABLE School (
  schoolID VARCHAR(255)  NOT NULL      ,
PRIMARY KEY(schoolID));
GO




CREATE TABLE Admin (
  adminID VARCHAR(255)  NOT NULL    ,
  loginAdmin VARCHAR(255)    ,
  passwordAdmin VARCHAR(255)      ,
PRIMARY KEY(adminID));
GO




CREATE TABLE Major (
  majorID VARCHAR(255)  NOT NULL    ,
  School_schoolID VARCHAR(255)  NOT NULL  ,
  majorName VARCHAR(255)      ,
PRIMARY KEY(majorID)  ,
  FOREIGN KEY(School_schoolID)
    REFERENCES School(schoolID));
GO


CREATE INDEX Major_FKIndex1 ON Major (School_schoolID);
GO


CREATE INDEX IFK_Rel_03 ON Major (School_schoolID);
GO


CREATE TABLE Student (
  stuID VARCHAR(255)  NOT NULL    ,
  Major_majorID VARCHAR(255)  NOT NULL  ,
  loginStu VARCHAR(255)    ,
  passwordStu VARCHAR(255)      ,
PRIMARY KEY(stuID)  ,
  FOREIGN KEY(Major_majorID)
    REFERENCES Major(majorID));
GO


CREATE INDEX Student_FKIndex1 ON Student (Major_majorID);
GO


CREATE INDEX IFK_Rel_04 ON Student (Major_majorID);
GO


CREATE TABLE Courses (
  courseID VARCHAR(255)  NOT NULL    ,
  Major_majorID VARCHAR(255)  NOT NULL  ,
  courseName VARCHAR(255)    ,
  courseInstructor VARCHAR(255)      ,
PRIMARY KEY(courseID)  ,
  FOREIGN KEY(Major_majorID)
    REFERENCES Major(majorID));
GO


CREATE INDEX Courses_FKIndex1 ON Courses (Major_majorID);
GO


CREATE INDEX IFK_Rel_05 ON Courses (Major_majorID);
GO


CREATE TABLE Student_has_Courses (
  Student_stuID VARCHAR(255)  NOT NULL  ,
  Courses_courseID VARCHAR(255)  NOT NULL  ,
  question1 INTEGER    ,
  question2 INTEGER    ,
  question3 INTEGER    ,
  question4 INTEGER    ,
  question5 INTEGER    ,
  question6 INTEGER    ,
  question7 INTEGER    ,
  question8 INTEGER    ,
  question9 INTEGER    ,
  question10 INTEGER      ,
PRIMARY KEY(Student_stuID, Courses_courseID)    ,
  FOREIGN KEY(Student_stuID)
    REFERENCES Student(stuID),
  FOREIGN KEY(Courses_courseID)
    REFERENCES Courses(courseID));
GO


CREATE INDEX Student_has_Courses_FKIndex1 ON Student_has_Courses (Student_stuID);
GO
CREATE INDEX Student_has_Courses_FKIndex2 ON Student_has_Courses (Courses_courseID);
GO


CREATE INDEX IFK_Rel_06 ON Student_has_Courses (Student_stuID);
GO
CREATE INDEX IFK_Rel_07 ON Student_has_Courses (Courses_courseID);
GO



