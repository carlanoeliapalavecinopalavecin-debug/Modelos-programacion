 // Revista también hereda de Material.
// Pero Revista no implementa IPrestable.
// Eso significa que en este ejemplo los libros se pueden prestar, pero las revistas no.




public class Revista : Material
{
    public string Editorial { get; set; }
    public int NroEdicion { get; set; }

    public Revista(string idMaterial, string nombre, int anio, string editorial, int nroEdicion)
        : base(idMaterial, nombre, "Revista", anio)
    {
        Editorial = editorial;
        NroEdicion = nroEdicion;
    }

    public override decimal CalcularCostoBase()
    {
        return 800;
    }

    public override string ObtenerFicha()
    {
        return $"{base.ObtenerFicha()} | Editorial: {Editorial} | Edición: {NroEdicion} | Costo: ${CalcularCostoBase()}";
    }
}