﻿CREATE TABLE [ExpenseManager].[Tier]
(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR (50)	NOT NULL
	CONSTRAINT [PK_Tier] PRIMARY KEY CLUSTERED ([Id])
)