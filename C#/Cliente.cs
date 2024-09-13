public class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string? datosReferenciaDireccion;

    public Cliente(string nombre, string direccion, int telefono, string? datosReferenciaDireccion, List<Pedido> pedidosCliente)
    {
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.DatosReferenciaDireccion = datosReferenciaDireccion;

    }

    public string Nombre { get => nombre;}
    public string Direccion { get => direccion;}
    public int Telefono { get => telefono;}
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion;}
}