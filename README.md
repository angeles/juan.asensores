Este repositorio contiene Los assessments de Front end y Back End para Altran.
==============================================================================

Antes de iniciar los proyectos, debe ejecutarse el archivo prepareLinks.bat que ajustará los enlaces internos de dependencias.
Esto es necesario porque originalmente este proyecto lo resguarde en un repositorio SVN privado y use externals.
Git no posee un manejo de externos como posee SVN, y no recupera correctamente enlaces simbolicos de directorio de windows,
por lo que resolvi generar este bat para solucionar el problema.

## Update: ##

Se hicieron cambios mayores en cuanto a la arquitectura de la construcción de los servicios. Entre estos cambios se aplico uso de:

* **Diseño n-Layers**: Se cambio la arquitectura de ApiServer para que respete un modelo de n-Layers con inyección de dependencias.
                   El mismo principio no se aplico directamente en AuthServer, debido a que el control de las dependencias hay que
		   manejarlo dentro de IdentityServer directamente, y me parecio que quizas no se veia completamente el manejo completo
		   de las mismas.
* **Entity Framework**: Se agrego uso de EntityFramework y un repositorio para el proyecto de AuthServer, el cual ahora posee un servicio para
                    registrar nuevos usuarios. Los usuarios solo se les permite el registro si existen en el mock de clientes.
* **Flujo de Autorización**: Se modifico el modelo de autenticación para que sea de flujo completo de cliente-usuario (ResourceOwner).
                         De esta manera ApiServer actua como un cliente teniendo sus claves de api propias, las cuales se adjuntan
			 a las del usuario con una autorización completa de acceso.
* **Servicios**: Se modifico la url de respuesta de IdentityServer, y este ahora responde a <AuthServerBaseURL>/identity y se agrego un
             nuevo metodo de registro en la url <AuthServerBaseURL>/register.
* **Front-End**: Se hicieron algunos cambios esteticos y de navegabilidad, para que sea un poco mas amistoso/natural para el usuario.

## Back-End: ##

En el directorio Back-End\trunk se podra encontrar la solución completa del Back End Assessment

La solución se planteo en 3 partes:

1. **AuthServer**: Implementado con IdentityServer, AspNet Identity y EntityFramework. Maneja la autorización mediante clients y users
               Posee un metodo para registro de usuarios, el cual valida contra los datos de clientes del servicio de mock y crea nuevos
	       usuarios si y solo si corresponde a un cliente existente (verifica por email). Este proyecto esta armado como Standalone
	       para correr desde consola. Como repositorio de datos, se hace uso de MySQL, y se implementaron migraciones explicitas de
	       base de datos, por lo que el proyecto, al iniciar, conecta y genera la base de datos necesaria para operar.
	       Este proyecto incluye en sus dependencias, los proyectos que se pueden encontrar en la carpeta de solucion "Auth".
2. **ApiServer**: Implementado en n-layers, este proyecto contiene el api que devuelve con métodos la información solicitada por el ejercicio,
              para su utilización primero se debe obtener un token del server de autorizaciones y luego, se podra llamar a los metodos,
	      luego dependiendo del rol del cliente llamador, cada método devolverá la información o un error 401. Este proyecto se armo
	      como proyecto web, para correr desde IIS o IIS Express. Este proyecto incluye en sus dependencias, los proyectos que se
	      pueden encontrar en la carpeta de solucion "Api".
3. **AuthApiTester**: Es un proyecto, implementado con mstest, que hace las verificaciones y uso de los metodos del apiServer, el mismo
                  ejecuta 2 pasos, uno con rol admin y otro con rol user.

Como adicional, tambien he agregado un proyecto ApiServerStandalone el cual es solamente un wrapper para el proyecto ApiServer, que permite
correrlo de forma standalone desde linea de comandos.
			
Para compilarlo, es necesario abrir el proyecto en Visual Studio (lo he desarrollado con Visual Studio 2015 Enterprise), restaurar los
paquetes de nuget (todos los paquetes utilizados son de licencia de uso libre), y luego compilarlo.

La ejecución se puede realizar, luego de la compilación, usando el archivo RunServer.bat. El mismo ejecutará los 2 servidores como
standalone (AuthServer y ApiServer), Ejecutará los tests de AuthApiTester y luego apagará a los servers iniciados.

Previo a la ejecutar este archivo bat, se debe hacer desde una ventana de "Developer Command Prompt for VS2015" y estando parado en
el directorio donde se descomprimió el zip enviado (directorio donde se encuentra el bat.)


## Front-End: ##

En el directorio Front-End\trunk se podra encontrar la solución completa del Front End Assessment

El proyecto esta armado sobre Visual Studio, por lo que es una solucion y el site web basico, esta hecho con .Net.

Fue necesario que hacer una capa minima de api para utilizar los servicios de los mocks, debido a que el site donde estan levantados
no tiene configurado CORS, por lo que no me permitia hacer las llamadas directas desde la aplicacion Angular.

Este proyecto se hizo con Visual Studio Enterprise 2015 y tiene ademas los siguientes requisitos para funcionar
(informo las versiones utilizadas de cada requisito, no necesariamente son las minimas requeridas.):

    * Typescript for Visual Studio 2.5.2.0
    * Node.Js 8.5: Se debe instalar afuera de visual studio y luego asociarla al visual S1tudio para que la use, ya
                   que la que instala por defecto el Visual es una versión vieja, se puede realizar siguiendo esta
	               guia: http://www.ryadel.com/en/visual-studio-2015-update-nodejs-andor-npm-latest-version/

Sin muchas mas aclaraciones, el proyecto corre directamente al presionar f5 dentro del Visual Studio con IIS Express...


## Helper Libs: ##

Como adicional, he agregado 2 proyectos mas como "ayudantes" que paso a detallar:

1. MockClient: Es un cliente proxy que he creado para hacer las llamadas al api mock donde esta la información de clientes y policies.
2. MockClientTest: Proyecto de UnitTests para evaluar el correcto funcionamiento de MockClient.


Cualquier consulta o duda, estoy a su disposición.

Juan Bautista Cavallo
