--DATOS DE PRUEBA--
INSERT INTO dbo.Categoria (CategoriaId,CategoriaNombre) VALUES('CE384BF0-A326-454F-B936-86FD94EF8CDE','Hogar')
INSERT INTO dbo.Producto (
							ProductoId,
							ProductoNombre,
							ProductoPrecioUnitario,
							ProductoCantidad,
							ProductoDescripcion,
							CategoriaId)
					VALUES( 'A7325178-2200-47D7-A7BA-5DCA1540F108',
							'TelevisorHD',
							1500000,
							10,
							'Televisor Smart Full HD',
							'CE384BF0-A326-454F-B936-86FD94EF8CDE'),

							( '5e9c5e6a-0254-48d3-89bc-b4abaa633a08',
							'Xbox One',
							1250000,
							5,
							'Video Consola',
							'CE384BF0-A326-454F-B936-86FD94EF8CDE'),

							( '48D7B75F-6E40-4C5B-A817-3C0FD5930A0C',
							'Computador Gamer Start',
							5700000,
							7,
							'Computador para Gamers',
							'CE384BF0-A326-454F-B936-86FD94EF8CDE')

INSERT INTO dbo.Cliente (
							ClienteId,
							ClienteTipoIdentificacion,
							ClienteNombre,
							ClienteDireccion,
							ClienteTelefono,
							ClienteEdad)
					VALUES('103018745',
							0,
							'JOHAN ANDREY CHALA',
							'CRA 87 # 52 -55',
							'3502081891',
							33)


							


					

							
