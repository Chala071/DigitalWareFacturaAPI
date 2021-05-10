USE SistemaFacturacionDigitalDB
SELECT
  Cliente.ClienteId
 ,Cliente.ClienteNombre
 ,Factura.FacturaId
 ,Factura.FacturaFecha
FROM dbo.Cliente
     INNER JOIN dbo.Factura
       ON Cliente.ClienteId = Factura.ClienteId
WHERE Cliente.ClienteEdad < 35
AND Factura.FacturaFecha >= '20000201'
AND Factura.FacturaFecha <= '20000525'