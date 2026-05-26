using System.Collections.Generic;
using System.Linq;


// MaterialRepository es una clase encargada de manejar los datos.
// Antes la lista estaba en Program.cs.
// Ahora la lista está dentro del repositorio.


// Repository SE ENCARGA DE ACCEDER A LOS DATOS. 
// El Repository no tiene lógica de negocio, solo sabe cómo guardar, buscar, eliminar, etc



public class MaterialRepository
{
    private List<Material> materiales = new List<Material>();

    public void Agregar(Material material)
    {
        materiales.Add(material);
    }

    public List<Material> ObtenerTodos()
    {
        return materiales;
    }

    public Material? BuscarPorId(string id)
    {
        return materiales.FirstOrDefault(m => m.IdMaterial == id);
    }

    public bool Eliminar(string id)
    {
        Material? materialEncontrado = BuscarPorId(id);

        if (materialEncontrado == null)
        {
            return false;
        }

        materiales.Remove(materialEncontrado);
        return true;
    }
}