// Material es una clase abstracta;
// No vamos a crear objetos "Material" directamente.
// Material sirve como clase PADRE para Libro y Revista.


public abstract class Material
{
    public string IdMaterial { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public int Anio { get; set; }

    public Material(string idMaterial, string nombre, string categoria, int anio)
    {
        IdMaterial = idMaterial;
        Nombre = nombre;
        Categoria = categoria;
        Anio = anio;
    }

    public abstract decimal CalcularCostoBase();

    public virtual string ObtenerFicha()
    {
        return $"ID: {IdMaterial} | Nombre: {Nombre} | Categoría: {Categoria} | Año: {Anio}";
    }
}