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
-- 
CREATE OR ALTER PROCEDURE sp_RegistrarComprobante
    @Id UNIQUEIDENTIFIER NULL,
    @DocumentoPago_Id UNIQUEIDENTIFIER NULL,
    @Nro NVARCHAR(255) NULL,
    @FechaEmision DATETIME NULL,
    @Moneda_Id NVARCHAR(255) NULL,
    @Proveedor_NroIdentificacion NVARCHAR(255) NULL,
    @Proveedor_RazonSocial NVARCHAR(255) NULL,
    @Cliente_NroIdentificacion NVARCHAR(255) NULL,
    @Cliente_RazonSocial NVARCHAR(255) NULL,
    @SubTotal DECIMAL(18, 2) NULL,
    @Anticipo DECIMAL(18, 2) NULL,
    @Descuento DECIMAL(18, 2) NULL,
    @OperacionGravada DECIMAL(18, 2) NULL,
    @OperacionExonerada DECIMAL(18, 2) NULL,
    @ISC DECIMAL(18, 2) NULL,
    @IVA DECIMAL(18, 2) NULL,
    @OtroCargo DECIMAL(18, 2) NULL,
    @OtroTributo DECIMAL(18, 2) NULL,
    @Total DECIMAL(18, 2) NULL,
    @OperacionGratuita DECIMAL(18, 2) NULL,
    @TotalTexto NVARCHAR(255) NULL,
    @TipoDocumento NVARCHAR(255) NULL,
    @OrdenCompra_Nro NVARCHAR(255) NULL,
    @NotaRecepcion_Codigo NVARCHAR(255) NULL,
    @Codigo_Detraccion NVARCHAR(255) NULL,
    @FechaConsulta DATETIME NULL,
    @DiaPago INT NULL,
    @FechaVencimientoPago DATETIME NULL,
    @PorcentajeDetraccion DECIMAL(18, 2)  NULL,
    @MontoDetraccion DECIMAL(18, 2) NULL,
    @DescripcionDetraccion NVARCHAR(255) NULL,
    @EstadoSunat NVARCHAR(255) NULL,
    @TipoDocumentoNeoGrid NVARCHAR(255) NULL,
    @MontoOtrosCargos DECIMAL(18, 2) NULL,
    @CorrelativoPortal INT NULL,
    @OtroCargoAplicable DECIMAL(18, 2) NULL,
    @Creado DATETIME NULL
AS
BEGIN
    INSERT INTO Comprobante(Id, DocumentoPago_Id, Nro, FechaEmision, Moneda_Id, 
        Proveedor_NroIdentificacion, Proveedor_RazonSocial, Cliente_NroIdentificacion, 
        Cliente_RazonSocial, SubTotal, Anticipo, Descuento, OperacionGravada, 
        OperacionExonerada, ISC, IVA, OtroCargo, OtroTributo, Total, 
        OperacionGratuita, TotalTexto, TipoDocumento, OrdenCompra_Nro, 
        NotaRecepcion_Codigo, Codigo_Detraccion, FechaConsulta, DiaPago, 
        FechaVencimientoPago, PorcentajeDetraccion, MontoDetraccion, 
        DescripcionDetraccion, EstadoSunat, TipoDocumentoNeoGrid, 
        MontoOtrosCargos, CorrelativoPortal, OtroCargoAplicable, Creado)
    VALUES (@Id, @DocumentoPago_Id, @Nro, @FechaEmision, @Moneda_Id, 
        @Proveedor_NroIdentificacion, @Proveedor_RazonSocial, @Cliente_NroIdentificacion, 
        @Cliente_RazonSocial, @SubTotal, @Anticipo, @Descuento, @OperacionGravada, 
        @OperacionExonerada, @ISC, @IVA, @OtroCargo, @OtroTributo, @Total, 
        @OperacionGratuita, @TotalTexto, @TipoDocumento, @OrdenCompra_Nro, 
        @NotaRecepcion_Codigo, @Codigo_Detraccion, @FechaConsulta, @DiaPago, 
        @FechaVencimientoPago, @PorcentajeDetraccion, @MontoDetraccion, 
        @DescripcionDetraccion, @EstadoSunat, @TipoDocumentoNeoGrid, 
        @MontoOtrosCargos, @CorrelativoPortal, @OtroCargoAplicable, @Creado);
END
GO
