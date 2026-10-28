Create Table Projects (

     ProjectID INT Identity(1,1) ,
     Name NVARCHAR(150) Not NULL,
     Description NVARCHAR(500) NULL,
     OwnerUserID INT NOT NULL , 
     CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Projects_CreatedAt DEFAULT SYSUTCDATETIME(),
     IsArchived BIT Not Null CONSTRAINT DF_Projects_IsArchived DEFAULT 0,
     Constraint Pk_Projects Primary key(ProjectID),
     Constraint FK_Projects_OwnerUserID FOREIGN KEY(OwnerUserID) references Users(UserID)

);