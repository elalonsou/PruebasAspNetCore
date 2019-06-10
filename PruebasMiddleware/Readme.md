# Pruebas MiddleWare
#### Configuración de log
Se ha configurado un log utilizando el paquete Microsoft.Extensions.Logging
y Serilog.Extensions.Logging.File para agregar la opción de volcar el resultado
del log a un fichero.

También se aplica la configuración del fichero de configuración en vez de configurarlo por código.
#### Configuración global de Excepciones
Se añade una extensión de IApplicationBuilder para configurar el Middleware para capturar las excepciones.

En este ejemplo se utiliza el logger para guardar información de la excepción
y se devuelve un error genérico como respuesta.
#### Obtención datos de configuración
Registramos una instancia de configuración para que se sirva un IOptions de tipo de una clase
que definamos. Los datos de nuestra clase serán macheados automáticamente con los nombres de las propiedades a partir de los datos de la configuración.   
