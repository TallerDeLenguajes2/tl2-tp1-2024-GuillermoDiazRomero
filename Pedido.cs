
public class Pedido {
    private int nro = 0;
    private string? observacion;
    private Cliente cliente;
    private Estado estadoPedido;

    public int Nro { get => nro; set => nro = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }

    public Pedido(int nro, string? observacion, Cliente cliente, Estado estadoPedido)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.cliente = cliente;
        this.estadoPedido = estadoPedido;
    }

    public Pedido(){}

    public void VerDireccionCliente(Cliente clienteDatos)
    {
        Console.WriteLine("Dirección :"+ clienteDatos.Direccion);
        if (clienteDatos.DatosReferenciaDireccion != null)
        {
            Console.WriteLine("Referencias: "+ clienteDatos.DatosReferenciaDireccion);
        }
        else{
            Console.WriteLine("No agregó referencias...");
        }
    }

    public void VerDatosCliente(Cliente datos){
        Console.WriteLine("      Datos del Cliente");
        Console.WriteLine("Nombre: "+ datos.Nombre);
        Console.WriteLine("Teléfono: "+ datos.Telefono);
        VerDireccionCliente(datos);
    }

    public Pedido IngresarPedido(Cliente cliente){
        Console.WriteLine("Ingrese Observaciones de su Pedido:");
        string obs = Console.ReadLine() ?? string.Empty;
        Pedido nuevoPedido = new Pedido(nro,obs,cliente,Estado.EnEspera);
        nro++;
        return nuevoPedido;
    }
}
