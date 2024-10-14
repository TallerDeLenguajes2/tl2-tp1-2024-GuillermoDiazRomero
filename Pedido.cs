
public class Pedido {
    private int nro = 0;
    private string? observacion;
    private Cliente cliente;
    private Estado estadoPedido;
    private Cadete cadeteACargo;

    public int Nro { get => nro; set => nro = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
    public Cadete CadeteACargo { get => cadeteACargo; set => cadeteACargo = value; }

    public Pedido(int nro, string? observacion, Cliente cliente, Estado estadoPedido, Cadete cadeteACargo)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.cliente = cliente;
        this.estadoPedido = estadoPedido;
        this.cadeteACargo = cadeteACargo;
    }

    public Pedido(){}

    public string VerDireccionCliente()
    {
        return $"\t\tPedido número {Nro}\nDirección ---> {cliente.Direccion}\nReferencia ---> {cliente.DatosReferenciaDireccion ?? "No agregó referencias"}";
    }

    public string VerDatosCliente(){
        return $"Cliente: {cliente.Nombre} ---> Asociado con el pedido de id {Nro}";
    }

    public static Pedido IngresarPedido(Cliente clt,int id){
        Pedido nuevo = new Pedido();
        nuevo.cliente = clt;
        nuevo.Nro = id;
        Console.Write("Ingrese Observaciones de su Pedido: ");
        nuevo.observacion = Console.ReadLine() ?? string.Empty;
        nuevo.estadoPedido = Estado.Pendiente;
        return nuevo;
    }
}
