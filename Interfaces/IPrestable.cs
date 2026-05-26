// Una interfaz es un contrato.
// Toda clase que implemente IPrestable está obligada a tener:
// - EstaDisponible
// - Prestar()
// - Devolver()
// - ObtenerEstado()
//Material define qué es una clase.
//IPrestable define qué puede hacer una clase.

public interface IPrestable
{
    bool EstaDisponible { get; }

    void Prestar();

    void Devolver();

    string ObtenerEstado();
}