using System.Collections.Generic;
using System.Linq;

// MaterialRepository es la clase encargada de manejar el acceso a los datos.

// En este ejemplo, los datos se guardan en una lista en memoria.
// Eso significa que los materiales existen mientras el programa está en ejecución.
// Cuando el programa se cierra, esa información se pierde.

// Antes, esta lista podría estar directamente en Program.cs.
// El problema de hacer eso es que Program.cs terminaría teniendo demasiadas responsabilidades:
// crear objetos, guardar datos, buscar, eliminar, validar y mostrar resultados.

// Para evitar eso, separamos el acceso a datos en una clase específica.
// Esa clase es el Repository.

// El Repository no debería contener reglas de negocio.
// Su tarea principal es guardar, listar, buscar o eliminar datos.

// Más adelante, cuando se use Entity Framework,
// esta clase podría dejar de trabajar con una lista
// y empezar a trabajar con una base de datos.

// La idea principal es que el resto del sistema no dependa
// de cómo se guardan internamente los datos.

public class MaterialRepository
{
    // Lista privada donde se almacenan los materiales.
    // Es privada porque no queremos que cualquier parte del programa
    // modifique directamente la lista.

    // Para trabajar con los materiales, se deben usar los métodos públicos
    // del repositorio: Agregar, ObtenerTodos, BuscarPorId y Eliminar.

    private List<Material> materiales = new List<Material>();

    // Método encargado de agregar un material a la lista.

    // Este método no valida si el material tiene nombre,
    // si el año es correcto o si cumple alguna regla del sistema.

    // Esa validación corresponde al Service.
    // El Repository solamente recibe el material y lo guarda.

    public void Agregar(Material material)
    {
        materiales.Add(material);
    }

    // Método encargado de devolver todos los materiales almacenados.

    // Devuelve una lista de tipo Material.
    // Como Libro y Revista heredan de Material,
    // esta lista puede contener libros y revistas al mismo tiempo.

    // Esto permite trabajar con polimorfismo:
    // todos se tratan como Material,
    // pero cada objeto mantiene su comportamiento propio.

    public List<Material> ObtenerTodos()
    {
        return materiales;
    }

    // Método encargado de buscar un material por su ID.

    // Recibe un string llamado id.
    // Luego recorre la lista y busca el primer material
    // cuyo IdMaterial sea igual al id recibido.

    // FirstOrDefault devuelve el primer elemento que cumple la condición.
    // Si no encuentra ninguno, devuelve null.

    // Por eso el tipo de retorno es Material?
    // El signo ? indica que puede devolver un Material
    // o también puede devolver null.

    public Material? BuscarPorId(string id)
    {
        return materiales.FirstOrDefault(m => m.IdMaterial == id);
    }

    // Método encargado de eliminar un material según su ID.

    // Devuelve un bool para indicar si la eliminación se realizó o no.

    // Si devuelve true, significa que encontró el material y lo eliminó.
    // Si devuelve false, significa que no encontró ningún material con ese ID.

    public bool Eliminar(string id)
    {
        // Primero se busca el material usando el método BuscarPorId.
        // De esta forma reutilizamos código y evitamos repetir la misma lógica.

        Material? materialEncontrado = BuscarPorId(id);

        // Si materialEncontrado es null,
        // significa que no existe ningún material con ese ID.

        if (materialEncontrado == null)
        {
            return false;
        }

        // Si el material existe, se elimina de la lista.

        materiales.Remove(materialEncontrado);

        // Se retorna true para indicar que la eliminación fue correcta.

        return true;
    }
}
