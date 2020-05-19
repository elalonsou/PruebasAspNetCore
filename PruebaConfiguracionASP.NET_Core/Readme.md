# Prueba configuración ASP.NET Core
Este proyecto se trata de varias pruebas sobre diferentes aspectos de la configuración:

- **Orden de los proveedores**

    Para esta prueba se obtienen valores de configuracion de ++appsettings.json++ y de ++appsettings.Development.json++ para poder comprobar como se comporta
    estando la propiedad en uno u otro fichero.
    http://localhost:3864/api/PruebasConfiguracion/PruebaOrden
- **Proveedor Json personalizado**

    Se configura un fichero Json personalizado y se muestran sus propiedades configPersonalizada.json 
    http://localhost:3864/api/PruebasConfiguracion/PruebaJsonPersonalizado
- **Proveedor de línea de comandos**
 
    Para poder acceder a los argumentos hay que definirlos como clave-valor. Se pueden definir también secciones con el carácter
    ":".
    
    Aunque en este ejemplo no se realiza se puede difinir un diccionario de reemplazos cuando se da de alta la configuracion de linea de comandos
    para que al guardar una clave en su lugar se guarde su reemplazo. Por ejemplo, si en los argumentos se defina la clave "o" esta se pueda guardar con otro nombre por ejemplo "options"

    Para este ejemplo se ha definido los argumentos en las opciones de depuración del proyecto en visual studio.
    
    http://localhost:3864/api/PruebasConfiguracion/PruebaArgumento

- **Uso de secretos**

    Se tienen que iniciar los secretos para el proyecto con el comando:
    >dotnet user-secrets init

    Los secretos se guardan en el equipo de desarrollo *"%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json"* con lo cual se tendrán que crear manualmente los secretos para esta prueba
    >dotnet user-secrets set "SeccionSecretos:ClaveSecreto" "Valor Secreto"

    Esto es muy útil para guardar datos privados (Contraseñas, tokens, etc) y que no se guarden con el control de código.
    
    En esta prueba simplemente agregaremos el proveedor de secretos y obtendremos la clave que hemos guardado.

    http://localhost:3864/api/PruebasConfiguracion/PruebaSecretos
- **Patrón de Opciones**
    Se han configurado dos secciones en appsettings.json para probar el patrón de opciones mediante la inyección de 
    dependencias configurando el servicio e inyectándolo en el controlador y realizando un binding 
    (Mapeando la clase con la sección de opciones) en el propio controlador.
    http://localhost:3864/api/PruebasConfiguracion/PruebaOpciones

- **Proveedor personalizado**

    https://docs.microsoft.com/es-es/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#custom-configuration-provider
