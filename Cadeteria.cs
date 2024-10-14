using System.Text.Json.Serialization;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private List<Pedido> pedidosAsignados;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
        pedidosAsignados = new List<Pedido>();
        listadoPedidos = new List<Pedido>();
    }
    public Cadeteria() { }

    //Datos que se leen desde .json
    [JsonPropertyName("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [JsonPropertyName("telefono")]
    public string Telefono { get => telefono; set => telefono = value; }

    public List<Pedido> PedidosAsignados { get => pedidosAsignados; set => pedidosAsignados = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public (int, float) JornalACobrar(int idCadete)
    {
        float montoXpedido = 250;
        int cantidadEnvios = pedidosAsignados.Where(p => p.CadeteACargo.Id == idCadete).Count();
        float montoTotal = montoXpedido * cantidadEnvios;
        return (cantidadEnvios, montoTotal);
    }


    //COMPLETADO ASIGNAR CADETE A PEDIDO
    public void AsignarCadeteAPedido(int idCadete, int idPedido)    //idCadete e idPedido ya vienen con su respectivo control
    {
        Pedido pedidoE = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        Cadete cadeteE = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        pedidoE.CadeteACargo = cadeteE;
        pedidosAsignados.Add(pedidoE);
        listadoPedidos.Remove(pedidoE);
    }
}