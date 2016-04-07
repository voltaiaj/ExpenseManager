CREATE TABLE [ExpenseManager].[Expense]
(
	[Id]			INT				IDENTITY (1, 1) NOT NULL,
	[Date]			DATETIME		NOT NULL,
	[Name]			NVARCHAR (50)	NULL,
	[Value]			DECIMAL (7,2)   NOT NULL,
	[Description]	NVARCHAR (50)	NOT NULL,
	[TierId]		INT				NOT NULL,
	[CategoryId]	INT				NOT NULL,
	CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Expense_TierId] FOREIGN KEY ([TierId]) REFERENCES [ExpenseManager].[Tier] ([Id]),
	CONSTRAINT [FK_Expense_CategoryId] FOREIGN KEY (CategoryId) REFERENCES [ExpenseManager].[Category] ([Id])
)