# Prueba de desarrollo de Intelutions

Consta de dos proyectos, **Intelutions.Permissions.API** que define el API del servicio desarrollado en .NET Core, y **Intelutions.Permissions.WebApp** que contiene el front-end desarrollado en Vue.js.

## Intelutions.Permissions.API

Define dos recursos **permission** y **permissiontype**.

### **permission** 

Define CRUD para la gestión de los permisos.

URL: http://localhost:7000/api/v1/permission

### **permissionType**.

Define CRUD para la gestión de tipos de permisos.

URL: http://localhost:7000/api/v1/permissiontype

### Configuración 

+ **URL del API en Intelutions.Permissions.API:** En el perfil Intelutions.Permissions.API se define la URL para consumir el API.
```
https://localhost:7001;http://localhost:7000
```
+ **ConnectionStrings:ApplicationConnection**: Cadena de conexión del API. Por defecto usa MSSQLLocalDB.
```
"ConnectionStrings": {
	"ApplicationConnection": "Server=(localdb)\\MSSQLLocalDB;Database=intelutions.permission;Trusted_Connection=True;MultipleActiveResultSets=True"
}
```
+ **Origins:WebApp:Url**: URL para configurar CORS y permitir el consumo del API a través de la URL de la aplicación web.
```
"Origins": {
	"WebApp": {
		"Url": "http://localhost:8080"
	}
}
```

### Dependencias

+ AutoMapper
+ FluentValidation
+ EF Core

## Intelutions.Permissions.WebApp

Define la aplicación Web que consume el API.

### Dependencias

+ vuelidate
+ vue-router
+ sass-loader
+ date-fns
+ axios