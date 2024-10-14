public class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string? datosReferenciaDireccion;

    public Cliente(string nombre, string direccion, int telefono, string? datosReferenciaDireccion)
    {
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.DatosReferenciaDireccion = datosReferenciaDireccion;
    }

    public Cliente(){}

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public static Cliente CargarCliente()
    {
        Cliente nuevo = new Cliente();

        Console.Write("Ingrese nombre del cliente: ");
        nuevo.Nombre = Console.ReadLine();

        Console.Write("Ingrese dirección del cliente: ");
        nuevo.Direccion = Console.ReadLine();

        Console.Write("Ingrese telefono del cliente: ");
        nuevo.Telefono = int.Parse(Console.ReadLine());

        Console.Write("Ingrese referencias de la dirección (si es que tiene): ");
        nuevo.DatosReferenciaDireccion = Console.ReadLine();

        return nuevo;
    }
}