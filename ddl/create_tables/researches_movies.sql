/*
   domingo, 18 de outubro de 202021:08:51
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
CREATE TABLE dbo.researches_movies
	(
	id int NOT NULL IDENTITY (1, 1),
	research_id int NOT NULL,
	movie_id int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.researches_movies ADD CONSTRAINT
	PK_researches_movies PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.researches_movies SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.researches_movies', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.researches_movies', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.researches_movies', 'Object', 'CONTROL') as Contr_Per 