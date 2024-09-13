
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
}
