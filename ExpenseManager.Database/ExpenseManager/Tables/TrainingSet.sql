CREATE TABLE [ExpenseManager].[TrainingSet]
(
	[Id]			INT				NOT NULL,
	[Keywords]		NVARCHAR (200)	NOT NULL,
	[CategoryId]	INT				NOT NULL,
	CONSTRAINT [PK_TrainingSet] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_TrainingSet_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [ExpenseManager].[Category]
)