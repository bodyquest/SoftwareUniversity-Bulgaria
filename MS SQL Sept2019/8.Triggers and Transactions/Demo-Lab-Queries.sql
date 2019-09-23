/*************
 Transactions 
*************/
USE Master
GO

CREATE PROCEDURE usp_Withdraw 
     @withdrawAmount DECIMAL(18, 2)
   , @accountId      INT
AS
    BEGIN TRANSACTION;
        UPDATE Accounts
          SET  
              Balance = Balance - @withdrawAmount
        WHERE   
             Id = @accountId;
        IF @@ROWCOUNT <> 1 --Didn't affect only one row
            BEGIN
                ROLLBACK;
                RAISERROR('Invalid account!', 16, 1);
                RETURN;
        END;
        COMMIT;
GO
--------------------------------------------------------
CREATE DATABASE
BankTransactions
GO

USE BankTransactions
GO

CREATE TABLE Accounts
(
      AccountId INT PRIMARY KEY 
	, [NAME] VARCHAR (20)
	, Balance MONEY
)
GO
INSERT INTO Accounts (AccountId, [NAME], Balance) VALUES (1, 'Dari', 100)
INSERT INTO Accounts (AccountId, [NAME], Balance) VALUES (2, 'Radi', 50)

GO
CREATE PROCEDURE usp_SendMoney 
     @senderAccountId   INT
   , @receiverAccountId INT
   , @amount            MONEY
AS
    BEGIN TRANSACTION

        DECLARE @senderAccount INT=
        (
            SELECT AccountId
            FROM Accounts
            WHERE AccountId = @senderAccountId
        )
        DECLARE @receiverAccount INT=
        (
            SELECT AccountId
            FROM Accounts
            WHERE AccountId = @receiverAccountId
        )

        IF(@senderAccount IS NULL
           OR @receiverAccountId IS NULL)
            BEGIN
                ROLLBACK
                RAISERROR('Account doesn''t exist!', 16, 1)
                RETURN
        END

        DECLARE @currentAmount MONEY=
        (
            SELECT Balance
            FROM Accounts
            WHERE AccountId = @senderAccountId
        )

        IF(@currentAmount - @amount < 0)
            BEGIN
                ROLLBACK
                RAISERROR('Insufficient funds!', 16, 2)
                RETURN
        END

        UPDATE Accounts
          SET  
              Balance-=@amount
        WHERE   
             AccountId = @senderAccountId

        UPDATE Accounts
          SET  
              Balance+=@amount
        WHERE   
             AccountId = @receiverAccountId

        COMMIT
GO

SELECT *
FROM Accounts
GO
EXECUTE usp_SendMoney 2, 1, 40
GO

/***********************************************************
 ACID Model Atomicity, Consistency, Isolation and Durability
************************************************************/

/*********
 Triggers 
**********/
CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE 
AS
  IF (EXISTS
        (SELECT * FROM inserted
		 WHERE [Name] IS NULL OR LEN([Name]) = 0)
	 )

  BEGIN
       RAISERROR('Town name cannot be empty.', 16, 1)
	   ROLLBACK
	   RETURN
  END
UPDATE Towns SET [Name] = '' WHERE TownID = 1
GO
---------------------------------------------
/* INSTEAD OF */
CREATE TABLE Accounts
(
   Username VARCHAR(10) NOT NULL PRIMARY KEY
   , [Password] vVARCHAR (20) NOT NULL
   , ACTIVE CHAR (1) NOT NULL DEFAULT 'Y'
)
GO

CREATE TRIGGER tr_AccountsDelete ON Accounts
INSTEAD OF DELETE
AS
UPDATE a SET Active = 'N'
      FROM Accounts AS a JOIN DELETED d
	  ON d.Usernamre = a.Username
      WHERE a.Active = 'Y'
GO

-------------------
CREATE TRIGGER tr_AccountProtect ON Accounts
INSTEAD OF DELETE
AS

UPDATE Accounts SET IsDeleted = 1
FROM Accounts AS s JOIN deleted AS d on a.Id = d.Id
WHERE a.IsDeleted = 0