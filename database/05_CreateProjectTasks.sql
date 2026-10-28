Create Table ProjectTasks (

    TaskID Int Identity(1,1),
    ProjectID INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL,
    Status NVARCHAR(30) NOT NULL Constraint DF_ProjectTasks_Status DEFAULT 'TODO',
    Priority NVARCHAR(20) NOT NULL Constraint DF_ProjectTasks_Priority DEFAULT 'Medium',
    CreatedByUserID INT NOT NULL , 
    AssignedToUserID INT NULL,
    CreatedAt DATETIME2 NOT NULL Constraint DF_ProjectTasks_CreatedAt DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    DueDate DATETIME2 ,
    Constraint Pk_ProjectTasks Primary key(TaskID),
    Constraint CK_ProjectTasks_Status check(Status IN('TODO' , 'InProgress' , 'Completed' , 'Cancelled')),
    Constraint CK_ProjectTasks_Priority check(Priority IN('Low' , 'Medium' , 'High')),
    Constraint Fk_Projects_ProjectID Foreign key(ProjectID) references Projects(ProjectID),
    Constraint Fk_Users_UserID Foreign key(CreatedByUserID) references Users(UserID),
    Constraint FK_UsersAssigned_UserID Foreign key(AssignedToUserID) references Users(UserID)

);