# DigitalWareFacturaAPI
Prueba Técnica DigitalWare
1. La aplicación WebAPI se puede ejecutar y realizar pruebas con POSTMAN (Abrir el archivo respectivo postman)
2. La documentación se puede encontrar al ejecutar la aplicación con Swagger.
3. Ej: Registrar Factura

    * Datos de entrada desde el Cliente:
      {
  
          "facturaFecha": "2022-05-09T18:41:23.700Z",
          "clienteId": 103018745,
          "facturaIvaporcentaje": 19.0,
          "productosFacturar": [
            {
              "productoId": "48D7B75F-6E40-4C5B-A817-3C0FD5930A0C",
              "cantidadFacturar": 1
            },
            {
              "productoId": "4AD0825B-9BE8-4836-9EBD-D125EE5B1B5C",
              "cantidadFacturar": 3
            }    
           ]
        },
        
    * Respuesta al Cliente:
     ```
      { 
          "facturaId": "83d2148c-1bfb-4f72-ed16-08d9135dbca8",
          "facturaFecha": "2022-05-09T18:41:23.7Z",
          "clienteId": 103018745,
          "clienteNombre": "JOHAN ANDREY CHALA",
          "facturaIvaporcentaje": 19.0,
          "facturaSubtotal": 8550000.00,
          "facturaTotal": 10174500.0000,
          "facturaIvatotal": 1624500.0000,
          "listaDescripcionFactura": [
            {
            "descripcionFacturaCantidad": 1,
            "descripcionFacturaPrecio": 5700000.00,
            "productoId": "48d7b75f-6e40-4c5b-a817-3c0fd5930a0c",
            "productoNombre": "Computador Gamer Start"
          },
          {
            "descripcionFacturaCantidad": 3,
            "descripcionFacturaPrecio": 2850000.00,
            "productoId": "4ad0825b-9be8-4836-9ebd-d125ee5b1b5c",
            "productoNombre": "Nevera LG"
          }
          ]
        }
       
