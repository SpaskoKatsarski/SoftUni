--******************************************************************
--\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
--******************************************************************

CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

--Attaching trigger to Accounts table so that when an account is updated, the logs table will save the changes about
--the difference in the Balance
GO

CREATE TRIGGER tr_AddToLogsOnSumChange
ON Accounts
AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs
		 VALUES
		 (
			(SELECT Id
			  FROM inserted),
			(SELECT Balance
			   FROM deleted),
			(SELECT Balance
			   FROM inserted)
		 )
END

GO

--******************************************************************
--\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
--******************************************************************

CREATE TABLE NotificationEmails (
	Recipent INT,
	[Subject] VARCHAR(100),
	Body VARCHAR(150)
)
GO

--Whenever there is a new record in the Logs table, there will be also a new record into the NotificationEmails 
--table with information about the time it happened and the balance change
CREATE TRIGGER tr_CreateNewEmailOnNewRecord
ON Logs
AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipent, [Subject], Body)
		 SELECT i.AccountId,
		 CONCAT('Balance change for account: ', i.AccountId),
		 CONCAT('On', GETDATE(), 'your balance was changed from', i.OldSum, 'to', i.NewSum)
		 FROM inserted AS i
END

GO

--******************************************************************
--\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
--******************************************************************

--Procedure which deposits money into account with the given ID as an argument
--Using transaction to make sure that no money gets lost during the whole process
GO

CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN
	BEGIN TRANSACTION

		IF @MoneyAmount < 0
		BEGIN
			ROLLBACK
		END

		ELSE
		BEGIN
			UPDATE Accounts
			   SET Balance += @MoneyAmount
			 WHERE Id = @AccountId
		END

		COMMIT
END

GO

--Procedure which withdraws money from account with the given ID as an argument
--Using transaction to make sure that no money gets lost during the whole process
GO

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN
	BEGIN TRANSACTION
	IF @MoneyAmount < 0
	BEGIN
		ROLLBACK
	END
	ELSE
	BEGIN
		UPDATE Accounts
		   SET Balance -= @MoneyAmount
		 WHERE Id = @AccountId
	END

	COMMIT
END

GO

--Procedure which transfers money from one account to another
--The previous two procedures are used and thus we make sure that no money gets lost
GO

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN
	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
END

GO