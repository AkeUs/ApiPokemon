# PokemonApi

## Levantar proyecto en Docker

Para levantar la aplicación:

``` cmd
docker-compose up -d
```

ir al navegador e ingresar a la url http://localhost:5000/api/pokemon

## Levantar proyecto en Kubernetes

Posicionarse en la carpeta _Kuberntes_ y ejecutar el siguiete comando

``` cmd
kubectl apply -f .
```

Para ver la IP del nodo ejecutar

``` cmd
kubectl get nodes -o wide
```

tomar la IP que se muestra en **INTERNAL-IP** e ingresarla en el navegador apuntando al puerto 30000

Ejemplo:
http://localhost:30000/api/pokemon

## Nomenclaturas de prueas unitarias

El nombre de la prueba consta de tres partes:

- Nombre del método que se va a probar.
- Escenario en el que se está probando.
- Comportamiento esperado al invocar al escenario.

Ejecutar pruebas:

``` cmd
dotnet test
```



