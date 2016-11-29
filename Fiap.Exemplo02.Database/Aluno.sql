CREATE TABLE [dbo].[Aluno]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(150) NOT NULL, 
    [DataNascimento] DATETIME2 NOT NULL, 
    [Bolsa] BIT NOT NULL, 
    [Desconto] FLOAT NULL, 
    [GrupoId] INT NOT NULL, 
    [Cep] NVARCHAR(50) NOT NULL, 
    [Logradouro] NVARCHAR(250) NOT NULL, 
    [Cidade] NVARCHAR(250) NOT NULL, 
    CONSTRAINT [FK_Aluno_Grupo] FOREIGN KEY ([GrupoId]) REFERENCES [Grupo]([id])
)
