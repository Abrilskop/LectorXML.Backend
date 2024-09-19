CREATE OR ALTER PROCEDURE sp_ObtenerComprobante
AS
BEGIN
    SELECT [Id], [Codigo], [Monto], [CodigoDetraccion], [Creado], [CreadoPor]
    FROM [Comprobante]
    ORDER BY Id;
END
GO

CREATE OR ALTER PROCEDURE sp_RegistrarComprobante
    @Codigo VARCHAR(50),
    @Monto DECIMAL(18, 2),
    @CodigoDetraccion VARCHAR(4),
    @Creado VARCHAR(50),
    @CreadoPor VARCHAR(50)
AS
BEGIN
    INSERT INTO Comprobante (Codigo, Monto, CodigoDetraccion, Creado, CreadoPor)
    VALUES (@Codigo, @Monto, @CodigoDetraccion, @Creado, @CreadoPor);
END
GO


