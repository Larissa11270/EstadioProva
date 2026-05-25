-- TABELA SELECAO
-- =========================
CREATE TABLE TB_SELECOES (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Pais VARCHAR(100) NOT NULL
);

-- =========================================
-- INSERT DAS SELEÇÕES DA COPA
-- =========================================

INSERT INTO TB_SELECOES (Nome, Pais)
VALUES
('África do Sul', 'África do Sul'),
('Alemanha', 'Alemanha'),
('Argélia', 'Argélia'),
('Argentina', 'Argentina'),
('Arábia Saudita', 'Arábia Saudita'),
('Austrália', 'Austrália'),
('Áustria', 'Áustria'),
('Bélgica', 'Bélgica'),
('Bósnia e Herzegovina', 'Bósnia e Herzegovina'),
('Brasil', 'Brasil'),
('Cabo Verde', 'Cabo Verde'),
('Canadá', 'Canadá'),
('Catar', 'Catar'),
('Colômbia', 'Colômbia'),
('Coreia do Sul', 'Coreia do Sul'),
('Costa do Marfim', 'Costa do Marfim'),
('Croácia', 'Croácia'),
('Curaçao', 'Curaçao'),
('Egito', 'Egito'),
('Equador', 'Equador'),
('Escócia', 'Escócia'),
('Espanha', 'Espanha'),
('Estados Unidos', 'Estados Unidos'),
('França', 'França'),
('Gana', 'Gana'),
('Holanda', 'Holanda'),
('Haiti', 'Haiti'),
('Inglaterra', 'Inglaterra'),
('Irã', 'Irã'),
('Iraque', 'Iraque'),
('Japão', 'Japão'),
('Jordânia', 'Jordânia'),
('Marrocos', 'Marrocos'),
('México', 'México'),
('Noruega', 'Noruega'),
('Nova Zelândia', 'Nova Zelândia'),
('Panamá', 'Panamá'),
('Paraguai', 'Paraguai'),
('Portugal', 'Portugal'),
('República Democrática do Congo', 'República Democrática do Congo'),
('Senegal', 'Senegal'),
('Suécia', 'Suécia'),
('Suíça', 'Suíça'),
('República Tcheca', 'República Tcheca'),
('Tunísia', 'Tunísia'),
('Turquia', 'Turquia'),
('Uruguai', 'Uruguai'),
('Uzbequistão', 'Uzbequistão');

GO
-- =========================================
-- ATUALIZAR JOGADORES JÁ EXISTENTES
-- PARA A SELEÇÃO BRASILEIRA
-- =========================================
UPDATE TB_JOGADORES
SET SelecaoId = (
    SELECT Id
    FROM TB_SELECOES
    WHERE Nome = 'Brasil'
);


go
-- =========================
-- TABELA TECNICO (1:1)
-- =========================
CREATE TABLE TB_TECNICOS (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    SelecaoId INT UNIQUE, 
    CONSTRAINT FK_TB_TECNICOS_TB_SELECOES 
        FOREIGN KEY (SelecaoId) REFERENCES TB_SELECOES(Id)
);

-- =========================
-- UPDATE TABELA JOGADOR (1:N)
-- =========================
ALTER TABLE TB_JOGADORES 
    ADD CONSTRAINT FK_TB_JOGADORES_TB_SELECOES 
        FOREIGN KEY (SelecaoId) REFERENCES TB_SELECOES(Id)


-- =========================
-- TABELA JOGO
-- =========================
CREATE TABLE TB_JOGOS (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DataHora DATETIME NOT NULL,
    EstadioId INT NOT NULL,
    CONSTRAINT FK_TB_JOGOS_TB_ESTADIO
        FOREIGN KEY (Id) REFERENCES TB_ESTADIO(Id)
);

-- =========================
-- TABELA N:N JOGO-SELECAO
-- =========================
CREATE TABLE TB_JOGOS_SELECOES (
    JogoId INT NOT NULL,
    SelecaoId INT NOT NULL,
    Gols INT DEFAULT 0,
    GolsDecisaoPenaltis INT DEFAULT 0,
    PRIMARY KEY (JogoId, SelecaoId),
    CONSTRAINT FK_TB_JOGOS_SELECOES_TB_JOGOS 
        FOREIGN KEY (JogoId) REFERENCES TB_JOGOS(Id),
    CONSTRAINT FK_TB_JOGOS_SELECOES_TB_SELECOES 
        FOREIGN KEY (SelecaoId) REFERENCES TB_SELECOES(Id)
);


