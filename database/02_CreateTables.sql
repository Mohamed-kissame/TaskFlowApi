Create Table Users (

    UserId int Identity(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    PasswordHash NVARCHAR(500) NOT NULL,
    IsActive BIT NOT NULL
    CONSTRAINT DF_Users_IsActive DEFAULT 1,

    CreatedAt DATETIME2 NOT NULL
    CONSTRAINT DF_Users_CreatedAt DEFAULT SYSUTCDATETIME(),
    Constraint Pk_User Primary Key(UserID),
    Constraint UQ_Users_Email  UNIQUE(Email)
   
);

Create Table Roles (

    RoleID INT IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL,
    CONSTRAINT Pk_Role Primary Key(RoleID),
    CONSTRAINT UQ_Roles_RoleName UNIQUE(RoleName)


);

Create Table UserRoles(

    UserID INT NOT Null,
    RoleID INT Not Null,

    Constraint PK_UserID_RoleID Primary key (UserID , RoleID),
    Constraint FK_UserRoles_Users FOREIGN KEY(UserID) references Users(UserID),
    Constraint FK_UserRoles_Roles FOREIGN KEY(RoleID) references Roles(RoleID)


);

