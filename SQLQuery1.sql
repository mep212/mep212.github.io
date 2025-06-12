CREATE TABLE [dbo].[Denik]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Jmeno] NVARCHAR(50) NOT NULL, 
    [Prijmeni] NVARCHAR(50) NOT NULL, 
    [Nazev] NVARCHAR(50) NOT NULL, 
    [Popis] NTEXT NULL, 
    [Nakladatelstvi] NVARCHAR(50) NULL, 
    [PocetStran] INT NULL, 
    [RokVydani] INT NULL
)