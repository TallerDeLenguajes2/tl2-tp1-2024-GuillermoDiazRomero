public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listadoPedidos;

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listadoPedidos = new List<Pedido>();
    }
    public void JornalACobrar(){
        System.Console.WriteLine("Cobra $");
    }
}