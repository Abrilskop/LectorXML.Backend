CREATE OR ALTER PROCEDURE sp_RegistrarComprobante
(
    @Id INT = NULL,
    @DocumentoPago_Id INT = NULL,
    @Nro NVARCHAR(510) = NULL,
    @FechaEmision DATETIME = NULL,
    @Moneda_Id NVARCHAR(510) = NULL,
    @Proveedor_NroIdentificacion NVARCHAR(510) = NULL,
    @Proveedor_RazonSocial NVARCHAR(510) = NULL,
    @Cliente_NroIdentificacion NVARCHAR(510) = NULL,
    @Cliente_RazonSocial NVARCHAR(510) = NULL,
    @SubTotal DECIMAL(9,2) = NULL,
    @Anticipo DECIMAL(9,2) = NULL,
    @Descuento DECIMAL(9,2) = NULL,
    @OperacionGravada DECIMAL(9,2) = NULL,
    @OperacionExonerada DECIMAL(9,2) = NULL,
    @ISC DECIMAL(9,2) = NULL,
    @IVA DECIMAL(9,2) = NULL,
    @OtroCargo DECIMAL(9,2) = NULL,
    @OtroTributo DECIMAL(9,2) = NULL,
    @Total DECIMAL(9,2) = NULL,
    @OperacionGratuita DECIMAL(9,2) = NULL,
    @TotalTexto NVARCHAR(510) = NULL,
    @TipoDocumento NVARCHAR(510) = NULL,
    @OrdenCompra_Nro NVARCHAR(510) = NULL,
    @NotaRecepcion_Codigo NVARCHAR(510) = NULL,
    @Codigo_Detraccion NVARCHAR(510) = NULL,
    @FechaConsulta DATETIME = NULL,
    @DiaPago INT = NULL,
    @FechaVencimientoPago DATETIME = NULL,
    @PorcentajeDetraccion DECIMAL(9,2) = NULL,
    @MontoDetraccion DECIMAL(9,2) = NULL,
    @DescripcionDetraccion NVARCHAR(510) = NULL,
    @EstadoSunat NVARCHAR(510) = NULL,
    @TipoDocumentoNeoGrid NVARCHAR(510) = NULL,
    @MontoOtrosCargos DECIMAL(9,2) = NULL,
    @CorrelativoPortal INT = NULL,
    @OtroCargoAplicable DECIMAL(9,2) = NULL,
    @Creado DATETIME = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Comprobante 
			   WHERE Nro = @Nro)
		BEGIN
			UPDATE Comprobante
			SET 
				Creado = GETDATE()
			WHERE Nro = @Nro;
		END

    ELSE
    BEGIN
        SET @Id = ISNULL(
			(SELECT 
					MAX(Id) 
				FROM 
					Comprobante
			),
		0) + 1;

        INSERT INTO Comprobante (
            Id,
            DocumentoPago_Id,
            Nro,
            FechaEmision,
            Moneda_Id,
            Proveedor_NroIdentificacion,
            Proveedor_RazonSocial,
            Cliente_NroIdentificacion,
            Cliente_RazonSocial,
            SubTotal,
            Anticipo,
            Descuento,
            OperacionGravada,
            OperacionExonerada,
            ISC,
            IVA,
            OtroCargo,
            OtroTributo,
            Total,
            OperacionGratuita,
            TotalTexto,
            TipoDocumento,
            OrdenCompra_Nro,
            NotaRecepcion_Codigo,
            Codigo_Detraccion,
            FechaConsulta,
            DiaPago,
            FechaVencimientoPago,
            PorcentajeDetraccion,
            MontoDetraccion,
            DescripcionDetraccion,
            EstadoSunat,
            TipoDocumentoNeoGrid,
            MontoOtrosCargos,
            CorrelativoPortal,
            OtroCargoAplicable,
            Creado	
        )
        VALUES (
            @Id,
            @DocumentoPago_Id,
            @Nro,
            @FechaEmision,
            @Moneda_Id,
            @Proveedor_NroIdentificacion,
            @Proveedor_RazonSocial,
            @Cliente_NroIdentificacion,
            @Cliente_RazonSocial,
            @SubTotal,
            @Anticipo,
            @Descuento,
            @OperacionGravada,
            @OperacionExonerada,
            @ISC,
            @IVA,
            @OtroCargo,
            @OtroTributo,
            @Total,
            @OperacionGratuita,
            @TotalTexto,
            @TipoDocumento,
            @OrdenCompra_Nro,
            @NotaRecepcion_Codigo,
            @Codigo_Detraccion,
            @FechaConsulta,
            @DiaPago,
            @FechaVencimientoPago,
            @PorcentajeDetraccion,
            @MontoDetraccion,
            @DescripcionDetraccion,
            @EstadoSunat,
            @TipoDocumentoNeoGrid,
            @MontoOtrosCargos,
            @CorrelativoPortal,
            @OtroCargoAplicable,
            @Creado	
        );
    END
END
GO
