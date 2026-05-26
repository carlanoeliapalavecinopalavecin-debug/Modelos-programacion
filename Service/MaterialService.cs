using System;
using System.Collections.Generic;
using System.Linq;


// MaterialService contiene reglas o acciones del sistema.
// No guarda directamente los datos.
// Para guardar o buscar, usa el Repository.

// Repository maneja datos.
// Service maneja reglas.
// Program.cs ejecuta.


public class MaterialService
{
    private MaterialRepository _repository;

    public MaterialService(MaterialRepository repository)
    {
        _repository = repository;
    }

    public void AgregarMaterial(Material material)
    {
        if (string.IsNullOrWhiteSpace(material.Nombre))
        {
            Console.WriteLine("No se puede agregar un material sin nombre.");
            return;
        }

        _repository.Agregar(material);
        Console.WriteLine($"Material agregado: {material.Nombre}");
    }

    public List<Material> ListarMateriales()
    {
        return _repository.ObtenerTodos();
    }

    public List<Material> BuscarMaterialesDesdeAnio(int anio)
    {
        return _repository
            .ObtenerTodos()
            .Where(m => m.Anio >= anio)
            .ToList();
    }

    public List<Material> OrdenarPorAnioDescendente()
    {
        return _repository
            .ObtenerTodos()
            .OrderByDescending(m => m.Anio)
            .ToList();
    }

    public void MostrarCantidadPorCategoria()
    {
        var grupos = _repository
            .ObtenerTodos()
            .GroupBy(m => m.Categoria);

        foreach (var grupo in grupos)
        {
            Console.WriteLine($"Categoría: {grupo.Key} | Cantidad: {grupo.Count()}");
        }
    }
}