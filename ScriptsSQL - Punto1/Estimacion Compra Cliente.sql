USE SistemaFacturacionDigitalDB
SELECT
  Cliente.ClienteId
 ,Cliente.ClienteNombre
 ,MAX(Factura.FacturaFecha) AS UltimaFacturacion
 ,DATEDIFF(d, MIN(Factura.FacturaFecha), MAX(Factura.FacturaFecha)) / COUNT(Factura.FacturaId) AS EstimacionCompraDias
FROM dbo.Factura
     INNER JOIN dbo.Cliente
       ON Factura.ClienteId = Cliente.ClienteId
GROUP BY Cliente.ClienteId,
		 Cliente.ClienteNombre