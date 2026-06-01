using System; // Se usa para poder mostrar mensajes por consola con Console.WriteLine.
using System.Collections.Generic; // Se usa para trabajar con listas, por ejemplo List<Material>.
using System.Linq; // Se usa para aplicar consultas con LINQ: Where, OrderByDescending y GroupBy.

public class MaterialService
{
    // Declaro un atributo privado de tipo MaterialRepository.
    // Este atributo representa al repositorio que va a usar el Service para acceder a los datos.
    // Uso el guion bajo "_" como convención para identificar que es una variable interna de la clase.
    // Es private porque no quiero que se modifique directamente desde Program.cs u otra clase.
    private MaterialRepository _repository;

    // Este es el constructor de MaterialService.
    // Es public porque necesito poder crear un objeto MaterialService desde Program.cs.
    // Recibe por parámetro un MaterialRepository, es decir, el repositorio que se creó afuera.
    public MaterialService(MaterialRepository repository)
    {
        // El parámetro "repository" existe solamente dentro de este constructor.
        // Para poder usar ese repositorio en los demás métodos de la clase,
        // lo guardo dentro del atributo privado "_repository".

        // A partir de esta asignación, cualquier método de MaterialService
        // puede usar _repository para agregar, listar, filtrar u ordenar materiales.
        _repository = repository;
    }

    // Este método permite agregar un material al sistema.
    // Es public porque se va a llamar desde Program.cs.
    // Recibe un objeto de tipo Material, que puede ser un Libro o una Revista.
    public void AgregarMaterial(Material material)
    {
        // Antes de guardar el material, valido que tenga nombre.
        // IsNullOrWhiteSpace controla tres casos:
        // que el nombre sea null, que esté vacío o que solo tenga espacios.
        if (string.IsNullOrWhiteSpace(material.Nombre))
        {
            // Si el material no tiene un nombre válido, muestro un mensaje.
            Console.WriteLine("No se puede agregar un material sin nombre.");

            // return corta la ejecución del método.
            // Esto evita que el material se guarde en el Repository.
            return;
        }

        // Si el material pasó la validación, recién ahí lo envío al Repository.
        // El Service decide si se puede agregar.
        // El Repository se encarga de guardarlo.
        _repository.Agregar(material);

        // Muestro un mensaje para confirmar que el material fue agregado.
        Console.WriteLine($"Material agregado: {material.Nombre}");
    }

    // Este método devuelve todos los materiales cargados.
    // Retorna una lista de Material, por eso puede contener libros y revistas.
    public List<Material> ListarMateriales()
    {
        // El Service no tiene una lista propia.
        // Por eso le pide los materiales al Repository.
        return _repository.ObtenerTodos();
    }

    // Este método busca materiales desde un año determinado.
    // El parámetro "anio" representa el año desde el cual quiero filtrar.
    public List<Material> BuscarMaterialesDesdeAnio(int anio)
    {
        // Primero obtengo todos los materiales desde el Repository.
        return _repository
            .ObtenerTodos()

            // Luego filtro con Where.
            // "m" representa cada material de la lista.
            // Solo quedan los materiales cuyo año sea mayor o igual al año recibido.
            .Where(m => m.Anio >= anio)

            // ToList convierte el resultado del filtro en una lista.
            .ToList();
    }

    // Este método devuelve los materiales ordenados por año descendente.
    // Es decir, primero aparecen los materiales más nuevos.
    public List<Material> OrdenarPorAnioDescendente()
    {
        // Primero obtengo todos los materiales desde el Repository.
        return _repository
            .ObtenerTodos()

            // OrderByDescending ordena desde el valor más alto al más bajo.
            // En este caso, ordena por el año del material.
            .OrderByDescending(m => m.Anio)

            // ToList convierte el resultado ordenado en una lista.
            .ToList();
    }

    // Este método muestra cuántos materiales hay por cada categoría.
    // Por ejemplo, cuántos son Libro y cuántos son Revista.
    public void MostrarCantidadPorCategoria()
    {
        // Obtengo todos los materiales desde el Repository
        // y los agrupo según el valor de la propiedad Categoria.
        var grupos = _repository
            .ObtenerTodos()
            .GroupBy(m => m.Categoria);

        // Recorro cada grupo generado por el GroupBy.
        foreach (var grupo in grupos)
        {
            // grupo.Key contiene el nombre de la categoría.
            // Por ejemplo: "Libro" o "Revista".

            // grupo.Count() cuenta cuántos materiales hay dentro de esa categoría.
            Console.WriteLine($"Categoría: {grupo.Key} | Cantidad: {grupo.Count()}");
        }
    }
    
// Método para buscar un material por ID.
public Material? BuscarMaterialPorId(string id)
{
    // Validar que el ID no esté vacío.
    if (string.IsNullOrWhiteSpace(id))
    {
        Console.WriteLine("Debe ingresar un ID válido.");
        return null;
    }

    // Buscar el material usando el Repository.
    Material? materialEncontrado = _repository.BuscarPorId(id);

    // Si no se encuentra, mostrar mensaje.
    if (materialEncontrado == null)
    {
        Console.WriteLine($"No se encontró ningún material con ID: {id}");
        return null;
    }


    // Devolver el material encontrado.
    return materialEncontrado;
}

}
