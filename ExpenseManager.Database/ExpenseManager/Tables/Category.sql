CREATE TABLE [ExpenseManager].[Category]
(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR (50)	NOT NULL,
	[TierId]	INT				NOT NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Category_TierId]	FOREIGN KEY ([TierId]) REFERENCES [ExpenseManager].[Tier]
)