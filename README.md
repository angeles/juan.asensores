Este repositorio contiene Los assessments de Front end y Back End para Altran.

Antes de iniciar los proyectos, debe ejecutarse el archivo prepareLinks.bat que ajustará los enlaces internos de dependencias.
Esto es necesario porque originalmente este proyecto lo resguarde en un repositorio SVN privado y use externals. Git no posee un manejo de externos como posee SVN,
y no recupera correctamente enlaces simbolicos de directorio de windows, por lo que resolvi generar este bat para solucionar el problema.

Back-End:
En el directorio Back-End\trunk se podra encontrar la solución completa del Back End Assessment

La solución se planteo en 3 partes:

1. AuthServer: Implementado con IdentityServer y maneja la autorización mediante clients (como no habian contraseñas de usuarios,
               me parecio demasiado hacer un api para registro, aunque si consideran lo podría hacer.). Este proyecto esta armado
			   como Standalone para correr desde consola.
2. ApiServer: Este contiene el api que devuelve con métodos la información solicitada por el ejercicio, para su utilización primero
              se debe obtener un token del server de autorizaciones y luego, se podra llamar a los metodos, luego dependiendo del rol
			  del cliente llamador, cada método devolverá la información o un error 401. Este proyecto se armo como proyecto web, para
			  correr desde IIS o IIS Express.
3. AuthApiTester: Es un proyecto, implementado con mstest, que hace las verificaciones y uso de los metodos del apiServer, el mismo
                  ejecuta 2 pasos, uno con rol admin y otro con rol user.

Como adicional, he agregado 3 proyectos mas como "ayudantes" que paso a detallar:

1. ApiServerStandalone: Es solamente un wrapper para el proyecto ApiServer, que permite correrlo de forma standalone desde linea de comandos.
2. MockClient: Es un cliente proxy que he creado para hacer las llamadas al api mock donde esta la información de clientes y policies.
3. MockClientTest: Proyecto de UnitTests para evaluar el correcto funcionamiento de MockClient.

Para compilarlo, es necesario abrir el proyecto en Visual Studio (lo he desarrollado con Visual Studio 2015 Enterprise), restaurar los paquetes
de nuget (todos los paquetes utilizados son de licencia de uso libre), y luego compilarlo.

La ejecución se puede realizar, luego de la compilación, usando el archivo RunServer.bat. El mismo ejecutará los 2 servidores como standalone
(AuthServer y ApiServer), Ejecutará los tests de AuthApiTester y luego apagará a los servers iniciados.

Previo a la ejecutar este archivo bat, se debe hacer desde una ventana de "Developer Command Prompt for VS2015" y estando parado en el directorio
donde se descomprimió el zip enviado (directorio donde se encuentra el bat.)



Front-End:
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


Cualquier consulta o duda, estoy a su disposición.

Juan Bautista Cavallo