USE SistemaFacturacionDigitalDB
SELECT
  P.ProductoNombre
 ,SUM(D.DescripcionFacturaPrecio) AS [Ventas Totales]
FROM Producto AS P
     INNER JOIN dbo.DescripcionFactura AS D
       ON P.ProductoId = D.ProductoId
     INNER JOIN dbo.Factura AS F
       ON F.FacturaId = D.FacturaId
WHERE F.FacturaFecha >= '20000101'
AND   F.FacturaFecha <=	'20001201'
GROUP BY P.ProductoNombre