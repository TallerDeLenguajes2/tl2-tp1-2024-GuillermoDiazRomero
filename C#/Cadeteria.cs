public class Cadeteria{
    private string nombre = @"Pedidos YA";
    private int telefono = 38128903;
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }
}