using System;


// Libro hereda de Material.
// Libro implementa IPrestable.
// Libro está obligado a implementar CalcularCostoBase porque viene abstracto desde Material.
// Libro puede sobrescribir ObtenerFicha porque en Material era virtual.





public class Libro : Material, IPrestable
{
    public string Autor { get; set; }
    public int NroPaginas { get; set; }

    private bool _estaDisponible = true;

    public bool EstaDisponible
    {
        get { return _estaDisponible; }
    }

    public Libro(string idMaterial, string nombre, int anio, string autor, int nroPaginas)
        : base(idMaterial, nombre, "Libro", anio)
    {
        Autor = autor;
        NroPaginas = nroPaginas;
    }

    public override decimal CalcularCostoBase()
    {
        return 1500 + (NroPaginas * 0.5m);
    }

    public override string ObtenerFicha()
    {
        return $"{base.ObtenerFicha()} | Autor: {Autor} | Páginas: {NroPaginas} | Costo: ${CalcularCostoBase()}";
    }

    public void Prestar()
    {
        _estaDisponible = false;
        Console.WriteLine($"El libro '{Nombre}' fue prestado.");
    }

    public void Devolver()
    {
        _estaDisponible = true;
        Console.WriteLine($"El libro '{Nombre}' fue devuelto.");
    }

    public string ObtenerEstado()
    {
        if (EstaDisponible)
        {
            return "Disponible";
        }

        return "Prestado";
    }
}