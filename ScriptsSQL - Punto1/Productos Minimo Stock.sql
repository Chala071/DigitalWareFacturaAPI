USE SistemaFacturacionDigitalDB
SELECT
	P.ProductoNombre,
	P.ProductoPrecioUnitario,
	P.ProductoCantidad
FROM Producto AS P
WHERE P.ProductoCantidad <= 5
ORDER BY P.ProductoNombre DESC