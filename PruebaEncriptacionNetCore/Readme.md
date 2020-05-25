# Prueba encriptacion Net Core

#### Encriptacion

IDataProtection, IDataProtectionProvider

Esta encriptación usa una clave interna que net core gestiona (Según si esta en azure o en IIS...). Hay forma para controlar donde se guarda esa clave por ejemplo si se usa microservicios y no
se tiene la clave en un almacén común cada microservicio encriptaría de forma distinta.

#### Hash

Una función Hash es una función que se aplica a un texto para obtener un resultado alterado único. No existe una función de 
vuelta para devolver el valor original, pero si se aplica la función sobre el mismo origen volverá a dar el mismo resultado alterado.
Esto es muy útil para guardar Password los cuales no deben ser guardados en la base de datos, pero podemos guardar la función hash.

Existe los **Sal** que es un valor que se aplica a la función hash, de forma que se hace más segura ya que para que un origen
de el mismo hash se tiene que usar la misma sal.

Para la prueba de Hash crearemos un servicio y lo inyectaremos en el controlador para poder usarlo.

