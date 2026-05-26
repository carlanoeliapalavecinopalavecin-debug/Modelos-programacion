using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistema de Biblioteca");
        Console.WriteLine("----------------------");

        // 1. Crear repository
        MaterialRepository repository = new MaterialRepository();

        // 2. Crear service
        MaterialService service = new MaterialService(repository);

        // 3. Crear materiales

        Libro libro1 = new Libro(
            "L001",
            "El Principito",
            1943,
            "Antoine de Saint-Exupéry",
            120
        );

        Libro libro2 = new Libro(
            "L002",
            "Clean Code",
            2008,
            "Robert C. Martin",
            450
        );

        Revista revista1 = new Revista(
            "R001",
            "National Geographic",
            2025,
            "NatGeo",
            15
        );

        // 4. Agregar materiales al sistema
        service.AgregarMaterial(libro1);
        service.AgregarMaterial(libro2);
        service.AgregarMaterial(revista1);

        Console.WriteLine();
        Console.WriteLine("LISTA DE MATERIALES");
        Console.WriteLine("----------------------");

        // 5. Mostrar todos
        List<Material> materiales = service.ListarMateriales();

        foreach (Material m in materiales)
        {
            Console.WriteLine(m.ObtenerFicha());
        }

        Console.WriteLine();
        Console.WriteLine("FILTRO: DESDE AÑO 2000");
        Console.WriteLine("----------------------");

        // 6. Filtrar por año
        List<Material> recientes = service.BuscarMaterialesDesdeAnio(2000);

        foreach (Material m in recientes)
        {
            Console.WriteLine(m.ObtenerFicha());
        }

        Console.WriteLine();
        Console.WriteLine("CANTIDAD POR CATEGORIA");
        Console.WriteLine("----------------------");

        // 7. Agrupar por categoría
        service.MostrarCantidadPorCategoria();

        Console.WriteLine();
        Console.WriteLine("PRÉSTAMO DE LIBRO");
        Console.WriteLine("----------------------");

        // 8. Probar interfaz (préstamo)
        libro1.Prestar();

        Console.WriteLine("Estado: " + libro1.ObtenerEstado());

        Console.WriteLine();
        Console.WriteLine("FIN DEL PROGRAMA");
    }
}