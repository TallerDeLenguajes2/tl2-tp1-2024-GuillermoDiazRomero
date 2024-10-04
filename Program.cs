//  Sistema de Cadetería

// Punto 2b
Console.Clear();
Console.WriteLine("Ingrese su nombre");
string nombre = Console.ReadLine();
Console.WriteLine("Ingrese su dirección");
string direccion = Console.ReadLine();
Console.WriteLine("Ingrese su numero de telefono");
int telefono = int.Parse(Console.ReadLine());
Console.WriteLine("Tiene referencias de la diección?");
string datosReferenciaDireccion = Console.ReadLine();

Cliente nuevoCliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);

Console.WriteLine("Datos ingresados:");
Console.WriteLine(nuevoCliente.Nombre);
Console.WriteLine(nuevoCliente.Direccion);
Console.WriteLine(nuevoCliente.Telefono);
Console.WriteLine(nuevoCliente.DatosReferenciaDireccion);
/*CLIENTE SI ANDA*/


string texto;
int opcion;
int seleccion;
int cantidad;
int elegido;
int eleped;
bool restultado;
cargarDatos cargar = new cargarDatos();
List<Pedido> listaPedidos = new List<Pedido>();
Pedido controlador = new Pedido();
List<Cadete> listaCadetes = ObtenerListadoCadetes();



do
{
    do
    {
        Visual.Menu();
        texto = Console.ReadLine();
        restultado = int.TryParse(texto, out opcion);
    } while (!restultado || opcion > 4 || opcion < 0);

    Console.WriteLine(opcion);
    switch (opcion)
    {
        case 1:
            listaPedidos = OpcionIngresarPedido();
            break;
        case 2:
            OpcionAsignarPedidos();

            break;
        case 3:
            OpcionCambiarPedidoEstado();
            break;
        case 4:
            OpcionReasignarPedido();
            break;
        default:
            Console.WriteLine("Cerrando el programa...");
            break;
    }

} while (opcion != 0);


List<Cadete> ObtenerListadoCadetes()
{
    listaCadetes = cargar.obtenerDatosCadetes();
    return listaCadetes;
}

List<Pedido> OpcionIngresarPedido()
{
    listaPedidos.Add(controlador.IngresarPedido(nuevoCliente));
    return listaPedidos;
}

void OpcionAsignarPedidos()
{
    System.Console.WriteLine("Listado de Cadetes");
    foreach (var item in listaCadetes)
    {
        System.Console.WriteLine(item.Id);
        System.Console.WriteLine(item.Nombre);
    }
    cantidad = listaCadetes.Count();
    if (cantidad == 0)
    {
        return;
    }

    do
    {
        texto = Console.ReadLine();
        restultado = int.TryParse(texto, out seleccion);
    } while (!restultado || seleccion > cantidad || seleccion < 0);
    //Elegir pedido
    System.Console.WriteLine("Seleccione el pedido a asignar");
    foreach(var item in listaPedidos){
        System.Console.WriteLine(item.Nro);
        System.Console.WriteLine(item.Cliente.Nombre);
    }
    cantidad = listaPedidos.Count();
    do
    {
        texto = Console.ReadLine();
        restultado = int.TryParse(texto, out eleped);
    } while (!restultado || eleped > cantidad || eleped < 0);
    listaPedidos[eleped].EstadoPedido= Estado.Preparado;
    listaCadetes[seleccion].ListadoPedidos.Add(listaPedidos[eleped]);

}
void OpcionCambiarPedidoEstado()
{  
    System.Console.WriteLine("Seleccione el pedido a cambiar su estado");
    foreach(var item in listaPedidos){
        System.Console.WriteLine(item.Nro);
        System.Console.WriteLine(item.Cliente.Nombre);
        System.Console.WriteLine(item.EstadoPedido);
    }
    cantidad = listaPedidos.Count();
    do
    {
        texto = Console.ReadLine();
        restultado = int.TryParse(texto, out seleccion);
    } while (!restultado || seleccion > cantidad || seleccion < 0);

    System.Console.WriteLine("Ingrese el estado que desea cambiar");
    System.Console.WriteLine("1.Pendiente");
    System.Console.WriteLine("2.Preparado");
    System.Console.WriteLine("3.Completado");
    do
    {
        texto = Console.ReadLine();
        restultado = int.TryParse(texto, out eleped);
    } while (!restultado || eleped > cantidad || eleped < 0);

    listaPedidos[seleccion].EstadoPedido = (Estado) eleped;

}
void OpcionReasignarPedido()
{
    
}

