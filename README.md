# PokemonApi

## Levantar ambiente

Para levantar la aplicación:

``` cmd
docker-compose up -d
```

ir al navegador e ingresar a la url http://localhost:5000/api/pokemon

## Nomenclaturas de prueas unitarias

El nombre de la prueba consta de tres partes:

- Nombre del método que se va a probar.
- Escenario en el que se está probando.
- Comportamiento esperado al invocar al escenario.

Ejecutar pruebas:

``` cmd
dotnet test
```
