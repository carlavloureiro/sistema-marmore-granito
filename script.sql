 CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Login TEXT NOT NULL,
                Senha TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Blocos (
                CodigoBloco TEXT PRIMARY KEY NOT NULL, -- Alterado de Codigo para CodigoBloco
                PedreiraOrigem TEXT NOT NULL,
                Metragem REAL NOT NULL,
                TipoMaterial TEXT NOT NULL,
                ValorCompra REAL NOT NULL,
                NotaFiscalEntrada TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Chapas (
                CodigoChapa TEXT PRIMARY KEY NOT NULL, -- Alterado de Id INTEGER PRIMARY KEY AUTOINCREMENT
                BlocoCodigo TEXT NOT NULL,
                TipoMaterial TEXT NOT NULL,
                Comprimento REAL NOT NULL,
                Largura REAL NOT NULL,
                Espessura REAL NOT NULL, -- Nova coluna
                Valor REAL NOT NULL,
                FOREIGN KEY (BlocoCodigo) REFERENCES Blocos(CodigoBloco) -- Referência atualizada
            );