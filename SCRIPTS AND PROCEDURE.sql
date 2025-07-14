CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    BirthDate DATE,
    Gender CHAR(1)
);



--PROCEDURE

DELIMITER $$

CREATE PROCEDURE sp_User_CRUD(
    IN in_Action VARCHAR(20),
    IN in_Id INT,
    IN in_Name VARCHAR(100),
    IN in_BirthDate DATE,
    IN in_Gender CHAR(1)
)
BEGIN
    IF in_Action = 'INSERT' THEN
        INSERT INTO Users (Name, BirthDate, Gender)
        VALUES (in_Name, in_BirthDate, in_Gender);

    ELSEIF in_Action = 'UPDATE' THEN
        UPDATE Users
        SET Name = in_Name,
            BirthDate = in_BirthDate,
            Gender = in_Gender
        WHERE Id = in_Id;

    ELSEIF in_Action = 'DELETE' THEN
        DELETE FROM Users WHERE Id = in_Id;

    ELSEIF in_Action = 'SELECT' THEN
        SELECT * FROM Users;

    ELSEIF in_Action = 'SELECT_BY_ID' THEN
        SELECT * FROM Users WHERE Id = in_Id;
    END IF;
END$$

DELIMITER ;
