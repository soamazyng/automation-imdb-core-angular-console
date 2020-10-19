/*
   domingo, 18 de outubro de 202021:04:18
   User: 
   Server: DESKTOP-VKFH9QA
   Database: imdbAutomation
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.researches
	(
	id int NOT NULL IDENTITY (1, 1),
	movieName varchar(300) NOT NULL,
	newSearch tinyint NOT NULL,
	hasResponse tinyint NOT NULL,
	created_at datetime NOT NULL,
	updated_at datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.researches ADD CONSTRAINT
	DF_researches_newSearch DEFAULT 1 FOR newSearch
GO
ALTER TABLE dbo.researches ADD CONSTRAINT
	DF_researches_hasResponse DEFAULT 0 FOR hasResponse
GO
ALTER TABLE dbo.researches ADD CONSTRAINT
	DF_researches_created_at DEFAULT getDate() FOR created_at
GO
ALTER TABLE dbo.researches ADD CONSTRAINT
	PK_researches PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.researches SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.researches', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.researches', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.researches', 'Object', 'CONTROL') as Contr_Per 