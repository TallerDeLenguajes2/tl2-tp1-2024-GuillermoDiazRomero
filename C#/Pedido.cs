
public class Pedido {
    private int nro;
    private string? observacion;
    private Cliente cliente;
    private Estado estadoPedido;

    public Pedido(int nro, string? observacion, Cliente cliente, Estado estadoPedido)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.cliente = cliente;
        this.estadoPedido = estadoPedido;
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine("Dirección cliente");
    }

    public void VerDatosCliente(){
        Console.WriteLine("Datos cliente");
    }
}
