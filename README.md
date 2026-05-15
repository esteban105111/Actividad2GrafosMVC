# CampusNet - Grafo Dirigido MVC en C#

---

# Integrantes

| Nombre | Responsabilidad |
|---|---|
| Juan Esteban Montaño Benites | Lógica del grafo y estructura MVC |
| Juan Esteban Montaño Benites | Implementación de recorridos BFS y DFS |
| Juan Esteban Montaño Benites | Vista en consola, pruebas y documentación |

---

# Descripción del Proyecto

CampusNet es una simulación de una red social académica basada en grafos dirigidos.

Cada usuario representa un vértice del grafo y cada relación de seguimiento representa una arista dirigida.

El sistema permite:

- Registrar usuarios académicos.
- Crear relaciones dirigidas de seguimiento.
- Ejecutar recorridos BFS y DFS.
- Detectar ciclos.
- Consultar usuarios influyentes y activos.
- Realizar operaciones CRUD sobre usuarios y relaciones.
- Al ejecutar el proyecto se simulan automáticamente todas las interacciones del sistema.

---

# Tecnologías Utilizadas

- C#
- Arquitectura MVC
- GitHub

---

# Características Implementadas

## Construcción del Grafo

- Grafo dirigido.
- 12 usuarios registrados.
- 18 relaciones dirigidas.
- Control de duplicados.
- Lista de adyacencia.

---

## Recorridos

### BFS

- BFS desde 3 nodos diferentes.
- Orden de visita.
- Cantidad de vértices alcanzados.

### DFS

- DFS completo.
- Orden de descubrimiento.
- Detección de ciclos.

---

## Consultas Sociales

- Usuarios sin seguidores.
- Usuarios más influyentes.
- Usuarios más activos.
- Verificación de alcanzabilidad entre nodos.

---

## Operaciones CRUD

- Agregar usuarios.
- Eliminar usuarios.
- Actualizar usuarios.
- Agregar relaciones.
- Eliminar relaciones.

---

# Requisitos

- Visual Studio 2022 o superior
- .NET 6 o superior
- Git instalado

---

# Instrucciones de Ejecución

## 1. Clonar el repositorio

```bash
git clone https://github.com/esteban105111/Actividad2GrafosMVC
```

---

## 2. Abrir el proyecto

Abrir la solución en Visual Studio.

---

## 3. Ejecutar

Ejecutar el proyecto desde Visual Studio usando:

```plaintext
Ctrl + F5
```

El sistema ejecutará automáticamente:

- Construcción del grafo.
- Recorridos BFS.
- Recorrido DFS.
- Consultas sociales.
- Operaciones CRUD.

---

# Evidencia de Ejecución

## Ejemplo de construcción del grafo

```plaintext
====================================
ESTRUCTURA DEL GRAFO
LISTA DE ADYACENCIA
====================================

U1 (Ana) -> U2 (Luis) U3 (Carlos) U4 (Maria) U5 (Laura)
U2 (Luis) -> U3 (Carlos) U6 (Pedro) U7 (Camila) U8 (Sofia)
U3 (Carlos) -> U1 (Ana)
```

---

## Ejemplo recorrido BFS

```plaintext
====================================
RECORRIDO BFS DESDE U1
====================================

Orden de visita:
1. U1
2. U2
3. U3
4. U4

Cantidad de vertices alcanzados: 10
```

---

## Ejemplo recorrido DFS

```plaintext
====================================
RECORRIDO DFS COMPLETO
====================================

Orden de descubrimiento:
1. U1
2. U2
3. U3

Resultado: Se detectaron ciclos dirigidos.
```

---

## Ejemplo consultas sociales

```plaintext
====================================
CONSULTAS SOCIALES
====================================

Usuarios sin seguidores:
ID: U11 | Nombre: Andres | Rol: Profesor

Usuarios mas activos:
ID: U1 | Nombre: Ana | Rol: Estudiante
```

---

## Ejemplo operaciones CRUD

```plaintext
====================================
OPERACIONES CRUD
====================================

1. Agregando nuevo usuario...
Usuario agregado correctamente.

2. Eliminando usuario U13...
Usuario eliminado correctamente.
```

---

# Repositorio Público

https://github.com/esteban105111/Actividad2GrafosMVC

---

# Universidad de Manizales

Facultad de Ciencias e Ingeniería  
Programación III  
2026
