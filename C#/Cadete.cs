public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listadoPedidos;

    public Cadete(int id, string nombre, string direccion, int telefono, List<Pedido> listadoPedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }
}