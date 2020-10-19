/*
   domingo, 18 de outubro de 202021:21:49
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
ALTER TABLE dbo.movies
	DROP CONSTRAINT DF_movies_created_at
GO
CREATE TABLE dbo.Tmp_movies
	(
	id int NOT NULL IDENTITY (1, 1),
	name varchar(500) NOT NULL,
	description varchar(500) NULL,
	uri varchar(500) NULL,
	cover varchar(500) NULL,
	grade decimal(5, 2) NULL,
	created_at datetime NOT NULL,
	updated_at datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_movies SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_movies ADD CONSTRAINT
	DF_movies_created_at DEFAULT (getdate()) FOR created_at
GO
SET IDENTITY_INSERT dbo.Tmp_movies ON
GO
IF EXISTS(SELECT * FROM dbo.movies)
	 EXEC('INSERT INTO dbo.Tmp_movies (id, name, description, uri, cover, grade, created_at, updated_at)
		SELECT id, name, description, uri, cover, CONVERT(decimal(5, 2), grade), created_at, updated_at FROM dbo.movies WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_movies OFF
GO
DROP TABLE dbo.movies
GO
EXECUTE sp_rename N'dbo.Tmp_movies', N'movies', 'OBJECT' 
GO
ALTER TABLE dbo.movies ADD CONSTRAINT
	PK_movies PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.movies', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.movies', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.movies', 'Object', 'CONTROL') as Contr_Per 