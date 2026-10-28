Create Table Comments (


    CommentID INT Identity(1 , 1),
    TaskID Int Not NULL , 
    UserID INT Not Null ,
    Content NVARCHAR(1000) NOT NULL ,
    CreatedAt DATETIME2 NOT NULL Constraint DF_Comments_CreatedAt DEFAULT SYSUTCDATETIME(),
    Constraint Pk_Comments primary key(CommentID),
    Constraint FK_Comments_ProjectTasks Foreign key(TaskID) references ProjectTasks(TaskID),
    Constraint FK_Comments_Users Foreign key(UserID) references Users(UserID)

);