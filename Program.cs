using System;
using System.Collections.Generic;

// Program.cs es el punto de entrada del programa.
// En una aplicación de consola, este es el archivo que se ejecuta primero.
// Su responsabilidad principal es coordinar el flujo general del sistema:
// crear los objetos necesarios, llamar a los métodos correspondientes
// y mostrar los resultados por consola.

// Program.cs no debería contener toda la lógica del sistema.
// No debería encargarse de guardar datos, validar reglas complejas
// ni resolver operaciones internas del sistema.
// Para eso existen otras clases, como Repository y Service.

Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");

// Creamos el repositorio.
// El repositorio se encargará de manejar el acceso a los datos.
// En este ejemplo, los datos se guardan en una lista en memoria.
// Más adelante, esta misma idea podría reemplazarse por una base de datos
// usando Entity Framework.

MaterialRepository repository = new MaterialRepository();

// Creamos el servicio.
// El servicio contiene las reglas y acciones principales del sistema.
// El servicio no guarda directamente los datos.
// Para guardar, listar o buscar materiales, utiliza el repositorio.

// En esta línea le pasamos el repository al service.
// Esto significa que MaterialService va a trabajar con materiales,
// pero cuando necesite acceder a los datos, va a usar MaterialRepository.

MaterialService service = new MaterialService(repository);

// Creamos los materiales del sistema.
// Aunque los objetos reales son Libro o Revista,
// los guardamos en variables de tipo Material.

// Esto es posible porque Libro y Revista heredan de Material.
// Este es un ejemplo de polimorfismo:
// todos son materiales, pero cada uno puede tener su propia forma
// de calcular el costo o mostrar su ficha.

Material libro1 = new Libro("M001", "El Aleph", 2000, "Borges", 274);
Material libro2 = new Libro("M002", "Rayuela", 1963, "Cortázar", 600);
Material revista1 = new Revista("M003", "National Geo", 2023, "Nat Geo", 45);
Material revista2 = new Revista("M004", "Time Magazine", 2024, "Time Inc.", 12);

// Agregamos materiales usando el Service.
// Program.cs no agrega directamente los materiales al repository.
// Primero llama al service, porque el service es el encargado
// de aplicar las reglas del sistema antes de guardar.

// Por ejemplo, MaterialService valida que un material no tenga
// el nombre vacío antes de enviarlo al repository.

service.AgregarMaterial(libro1);
service.AgregarMaterial(libro2);
service.AgregarMaterial(revista1);
service.AgregarMaterial(revista2);

Console.WriteLine("\n===== LISTADO GENERAL =====");

// Pedimos al service la lista completa de materiales.
// Program.cs no accede directamente a la lista interna del repository.
// El flujo correcto es:
// Program.cs llama al Service.
// El Service llama al Repository.
// El Repository devuelve los datos.

List<Material> materiales = service.ListarMateriales();

// Recorremos todos los materiales.
// Como la lista es de tipo Material, puede contener libros y revistas.
// Cada objeto ejecuta su propia versión de ObtenerFicha().
// Si el objeto es un Libro, se muestra la ficha del libro.
// Si el objeto es una Revista, se muestra la ficha de la revista.

foreach (Material material in materiales)
{
    Console.WriteLine(material.ObtenerFicha());
}

Console.WriteLine("\n===== MATERIALES DESDE EL AÑO 2000 =====");

// En este caso le pedimos al service que busque materiales
// cuyo año sea mayor o igual a 2000.

// Esta operación no se resuelve directamente en Program.cs.
// Program.cs solamente solicita la acción.
// La lógica de filtrado está dentro de MaterialService.

List<Material> materialesModernos = service.BuscarMaterialesDesdeAnio(2000);

// Mostramos los materiales encontrados.
// Nuevamente se aplica polimorfismo al llamar a ObtenerFicha().

foreach (Material material in materialesModernos)
{
    Console.WriteLine(material.ObtenerFicha());
}

Console.WriteLine("\n===== MATERIALES ORDENADOS POR AÑO DESCENDENTE =====");

// Pedimos al service que devuelva los materiales ordenados
// desde el más nuevo al más antiguo.

// La lógica de ordenamiento está dentro del service,
// no dentro de Program.cs.

List<Material> materialesOrdenados = service.OrdenarPorAnioDescendente();

// Recorremos la lista ordenada y mostramos cada ficha.

foreach (Material material in materialesOrdenados)
{
    Console.WriteLine(material.ObtenerFicha());
}

Console.WriteLine("\n===== CANTIDAD POR CATEGORÍA =====");

// En este punto se muestra una agrupación por categoría.
// Por ejemplo, cuántos materiales son libros y cuántos son revistas.

// Program.cs no realiza el GroupBy directamente.
// Solamente llama al método correspondiente del service.

service.MostrarCantidadPorCategoria();

Console.WriteLine("\n===== PRUEBA DE INTERFAZ IPRESTABLE =====");

// Creamos una variable de tipo IPrestable.
// Esto significa que no nos interesa trabajar con el objeto como Libro,
// sino como algo que se puede prestar.

// IPrestable es un contrato.
// Cualquier clase que implemente IPrestable está obligada a tener:
// EstaDisponible, Prestar(), Devolver() y ObtenerEstado().

IPrestable prestable = new Libro("M005", "Ficciones", 1944, "Borges", 186);

// Mostramos el estado inicial del material prestable.
// En este caso, el libro comienza disponible.

Console.WriteLine(prestable.ObtenerEstado());

// Prestamos el libro.
// Al ejecutar Prestar(), cambia su estado interno.

prestable.Prestar();

// Volvemos a mostrar el estado.
// Ahora debería figurar como prestado.

Console.WriteLine(prestable.ObtenerEstado());

// Devolvemos el libro.
// Al ejecutar Devolver(), vuelve a estar disponible.

prestable.Devolver();

// Mostramos nuevamente el estado final.

Console.WriteLine(prestable.ObtenerEstado());

// Fin del programa.
// Program.cs ejecutó el flujo principal,
// pero no concentró toda la lógica del sistema.
// La lógica de datos quedó en Repository.
// Las reglas del sistema quedaron en Service.
// Las entidades quedaron representadas por Material, Libro y Revista.

Console.WriteLine("\n===== FIN DEL PROGRAMA =====");