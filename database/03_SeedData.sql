INSERT INTO ROLES VALUES("Admin") , ("Manager") , ("User");USE TaskFlowDB;
GO



IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Admin')
    INSERT INTO Roles (RoleName) VALUES ('Admin');

IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Manager')
    INSERT INTO Roles (RoleName) VALUES ('Manager');

IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'User')
    INSERT INTO Roles (RoleName) VALUES ('User');




IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'admin@taskflow.local')
BEGIN
    INSERT INTO Users (FullName, Email, PasswordHash, IsActive)
    VALUES
    (
        'Mohamed Admin',
        'admin@taskflow.local',
        'DEV_HASH_ADMIN',
        1
    );
END;


IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'sara@taskflow.local')
BEGIN
    INSERT INTO Users (FullName, Email, PasswordHash, IsActive)
    VALUES
    (
        'Sara Manager',
        'sara@taskflow.local',
        'DEV_HASH_SARA',
        1
    );
END;


IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'youssef@taskflow.local')
BEGIN
    INSERT INTO Users (FullName, Email, PasswordHash, IsActive)
    VALUES
    (
        'Youssef Developer',
        'youssef@taskflow.local',
        'DEV_HASH_YOUSSEF',
        1
    );
END;


IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'amina@taskflow.local')
BEGIN
    INSERT INTO Users (FullName, Email, PasswordHash, IsActive)
    VALUES
    (
        'Amina Tester',
        'amina@taskflow.local',
        'DEV_HASH_AMINA',
        0
    );
END;


/* =========================================================
   USER ROLES
   ========================================================= */

DECLARE @AdminUserId INT =
(
    SELECT UserId
    FROM Users
    WHERE Email = 'admin@taskflow.local'
);

DECLARE @SaraUserId INT =
(
    SELECT UserId
    FROM Users
    WHERE Email = 'sara@taskflow.local'
);

DECLARE @YoussefUserId INT =
(
    SELECT UserId
    FROM Users
    WHERE Email = 'youssef@taskflow.local'
);

DECLARE @AminaUserId INT =
(
    SELECT UserId
    FROM Users
    WHERE Email = 'amina@taskflow.local'
);


DECLARE @AdminRoleId INT =
(
    SELECT RoleId
    FROM Roles
    WHERE RoleName = 'Admin'
);

DECLARE @ManagerRoleId INT =
(
    SELECT RoleId
    FROM Roles
    WHERE RoleName = 'Manager'
);

DECLARE @UserRoleId INT =
(
    SELECT RoleId
    FROM Roles
    WHERE RoleName = 'User'
);


IF NOT EXISTS
(
    SELECT 1 FROM UserRoles
    WHERE UserId = @AdminUserId
      AND RoleId = @AdminRoleId
)
    INSERT INTO UserRoles (UserId, RoleId)
    VALUES (@AdminUserId, @AdminRoleId);


IF NOT EXISTS
(
    SELECT 1 FROM UserRoles
    WHERE UserId = @SaraUserId
      AND RoleId = @ManagerRoleId
)
    INSERT INTO UserRoles (UserId, RoleId)
    VALUES (@SaraUserId, @ManagerRoleId);


IF NOT EXISTS
(
    SELECT 1 FROM UserRoles
    WHERE UserId = @YoussefUserId
      AND RoleId = @UserRoleId
)
    INSERT INTO UserRoles (UserId, RoleId)
    VALUES (@YoussefUserId, @UserRoleId);


IF NOT EXISTS
(
    SELECT 1 FROM UserRoles
    WHERE UserId = @AminaUserId
      AND RoleId = @UserRoleId
)
    INSERT INTO UserRoles (UserId, RoleId)
    VALUES (@AminaUserId, @UserRoleId);


/* =========================================================
   PROJECTS
   ========================================================= */

IF NOT EXISTS (SELECT 1 FROM Projects WHERE Name = 'TaskFlow API')
BEGIN
    INSERT INTO Projects
        (Name, Description, OwnerUserId, IsArchived)
    VALUES
        (
            'TaskFlow API',
            'Backend REST API development project.',
            @AdminUserId,
            0
        );
END;


IF NOT EXISTS (SELECT 1 FROM Projects WHERE Name = 'Mobile Application')
BEGIN
    INSERT INTO Projects
        (Name, Description, OwnerUserId, IsArchived)
    VALUES
        (
            'Mobile Application',
            'Future mobile client for TaskFlow.',
            @SaraUserId,
            0
        );
END;


/* =========================================================
   PROJECT TASKS
   ========================================================= */

DECLARE @TaskFlowProjectId INT =
(
    SELECT TOP 1 ProjectId
    FROM Projects
    WHERE Name = 'TaskFlow API'
);

IF NOT EXISTS
(
    SELECT 1
    FROM ProjectTasks
    WHERE ProjectId = @TaskFlowProjectId
      AND Title = 'Implement Users API'
)
BEGIN
    INSERT INTO ProjectTasks
    (
        ProjectId,
        Title,
        Description,
        Status,
        Priority,
        CreatedByUserId,
        AssignedToUserId,
        DueDate
    )
    VALUES
    (
        @TaskFlowProjectId,
        'Implement Users API',
        'Create endpoints for retrieving TaskFlow users.',
        'InProgress',
        'High',
        @AdminUserId,
        @YoussefUserId,
        DATEADD(DAY, 7, SYSUTCDATETIME())
    );
END;


IF NOT EXISTS
(
    SELECT 1
    FROM ProjectTasks
    WHERE ProjectId = @TaskFlowProjectId
      AND Title = 'Configure Authentication'
)
BEGIN
    INSERT INTO ProjectTasks
    (
        ProjectId,
        Title,
        Description,
        Status,
        Priority,
        CreatedByUserId,
        AssignedToUserId
    )
    VALUES
    (
        @TaskFlowProjectId,
        'Configure Authentication',
        'Implement authentication and JWT security.',
        'TODO',
        'High',
        @AdminUserId,
        @YoussefUserId
    );
END;


IF NOT EXISTS
(
    SELECT 1
    FROM ProjectTasks
    WHERE ProjectId = @TaskFlowProjectId
      AND Title = 'Prepare API Documentation'
)
BEGIN
    INSERT INTO ProjectTasks
    (
        ProjectId,
        Title,
        Description,
        Status,
        Priority,
        CreatedByUserId,
        AssignedToUserId
    )
    VALUES
    (
        @TaskFlowProjectId,
        'Prepare API Documentation',
        'Document available API endpoints.',
        'TODO',
        'Medium',
        @SaraUserId,
        NULL
    );
END;




DECLARE @UsersApiTaskId INT =
(
    SELECT TOP 1 TaskId
    FROM ProjectTasks
    WHERE ProjectId = @TaskFlowProjectId
      AND Title = 'Implement Users API'
);

IF NOT EXISTS
(
    SELECT 1
    FROM Comments
    WHERE TaskId = @UsersApiTaskId
      AND Content = 'Please implement the first users endpoint.'
)
BEGIN
    INSERT INTO Comments
        (TaskId, UserId, Content)
    VALUES
        (
            @UsersApiTaskId,
            @AdminUserId,
            'Please implement the first users endpoint.'
        );
END;


IF NOT EXISTS
(
    SELECT 1
    FROM Comments
    WHERE TaskId = @UsersApiTaskId
      AND Content = 'GET all users endpoint is currently in progress.'
)
BEGIN
    INSERT INTO Comments
        (TaskId, UserId, Content)
    VALUES
        (
            @UsersApiTaskId,
            @YoussefUserId,
            'GET all users endpoint is currently in progress.'
        );
END;
GO