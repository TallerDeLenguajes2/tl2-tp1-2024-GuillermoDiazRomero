public class Cadeteria{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> pedidosAsignados;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
        pedidosAsignados = new List<Pedido>();

    }
    public Cadeteria(){}

    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> PedidosAsignados { get => pedidosAsignados; set => pedidosAsignados = value; }

    public void AgregarCadete(){
        foreach(var elemento in cargarDatos.obtenerDatosCadetes()){
            listadoCadetes.Add(elemento);
        }
    }
}