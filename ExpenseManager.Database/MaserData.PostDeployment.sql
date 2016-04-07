/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF DATABASE_PRINCIPAL_ID('ExpenseManagerApp') IS NULL
BEGIN
	CREATE ROLE [ExpenseManagerApp]
END

GRANT SELECT ON SCHEMA :: [ExpenseManager] TO [ExpenseManagerApp]
GRANT INSERT ON SCHEMA :: [ExpenseManager] TO [ExpenseManagerApp]
GRANT UPDATE ON SCHEMA :: [ExpenseManager] TO [ExpenseManagerApp]
GRANT DELETE ON SCHEMA :: [ExpenseManager] TO [ExpenseManagerApp]
GRANT EXECUTE ON SCHEMA :: [ExpenseManager] TO [ExpenseManagerApp]

DECLARE @ApplicationName NVARCHAR(30) = N'/ExpenseManager'

-----------------------Tier-----------------------
MERGE INTO [ExpenseManager].[Tier] as Target
USING (VALUES
 (1, N'Month-To-Month'),
 (2, N'Food'),
 (3, N'Unique Expenses')
 )
 AS Source (
	Id,
	Name)
ON Target.Id = Source.Id And
	Target.Name = Source.Name
-- update matched rows
 WHEN MATCHED THEN
 UPDATE SET Id = Source.Id,
 Name=Source.Name
 -- insert new rows
 WHEN NOT MATCHED BY TARGET THEN
 INSERT (
			[Id]
			,[Name])
VALUES
		(
		 Source.Id
		 ,Source.Name)
-- delete rows that are in the target but not in the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

-----------------------Category-----------------------
MERGE INTO [ExpenseManager].[Category] as Target
USING (VALUES
 (1, N'Gym', 1),
 (2, N'Mortgage', 1),
 (3, N'Car Insurance', 1),
 (4, N'Satellite TV', 1),
 (5, N'Cellphone', 1),
 (6, N'Internet', 1),
 (7, N'Spotify', 1),
 (8, N'Gas for Home', 1),
 (9, N'Electricity', 1),
 (10, N'Water', 1),
 (11, N'Home Security', 1),
 (12, N'Identity Guard', 1),
 (13, N'Landscaping', 1),
 (14, N'Groceries', 2),
 (15, N'Fast Food', 2),
 (16, N'Entertainment', 3),
 (17, N'Services', 3),
 (18, N'AnnualRenewals', 3),
 (19, N'Gas for Car', 3),
 (20, N'Pool', 3)
 )
 AS Source (
	Id,
	Name,
	TierId)
ON Target.Id = Source.Id And
	Target.Name = Source.Name And
	Target.TierId = Source.TierId
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Id = Source.Id,
Name = Source.Name,
TierId = Source.TierId
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (
		[Id]
		,[Name]
		,[TierId])
VALUES
		(
		 Source.Id
		 ,Source.Name
		 ,Source.TierId)
-- delete rows that are in the target but not in the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

-----------------------TrainingSet-----------------------
MERGE INTO [ExpenseManager].[TrainingSet] AS Target
USING (VALUES
 (1, N'LTF*LIFE TIME', 1),
 (2, N'JPMORGAN CHASE', 2),
 (3, N'PROG COUNTY MUT INS', 3),
 (4, N'DTV*DIRECTV SERVICE', 4),
 (5, N'ATT Payment ', 5),
 (6, N'COMCAST', 6),
 (7, N'PAYPAL INST XFER SPOTIFYUSAI', 7),
 (8, N'CPENERGY ENTEX ENT', 8),
 (9, N'STARTEX POWER', 9),
 (10, N'HarrisCoMUD151', 10),
 (11, N'ADTSECURITY MYADT.COM|ADT Security', 11),
 (12, N'IDENTITY GUARD', 12), 
 (14, N'HEB', 14),
 (15, N'CHIPOTLE|SUBWAY|FREEBIRDS|JIMMY JOHNS|FIVE GUYS|BUFFALO WILD WINGS|', 15),
 (16, N'LITTLE WOODROWS|CLUB TROPICANA|', 16),
 (17, N'SERENITY NAIL DESIGNS|', 17),
 (18, N'FEMA NFIP FLOOD INSUR|AAA TX MEMBER PAYMENT|', 18), 
 (19, N'SHELL Service Station|TIME WISE|', 19),
 (20, N'TX TOMS POOL SUPPLIES', 20)
   )
AS Source (
	Id,
	Keywords,
	CategoryId)
ON Target.Id = Source.Id And
	Target.Keywords = Source.Keywords And
	Target.CategoryId = Source.CategoryId
-- update matched rows
WHEN MATCHED THEN
UPDATE SET Id = Source.Id,
Keywords=Source.Keywords,
CategoryId=Source.CategoryId
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (
		 [Id]
		 ,[Keywords]
		 ,[CategoryId])
VALUES
		(
		 Source.Id
		 ,Source.Keywords
		 ,Source.CategoryId)
-- delete rows that are in target but not in the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;