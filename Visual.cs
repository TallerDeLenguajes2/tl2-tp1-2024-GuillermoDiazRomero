public class Visual()
{
    public static void Menu(string nom, string tel)
    {
        //Menú interactivo de la empresa
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("       Bienvenido a " + nom);
        Console.WriteLine("     Telefono: " + tel);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("1. Ingresar un Pedido Nuevo");
        Console.WriteLine("2. Asignar Pedido a Cadete");
        Console.WriteLine("3. Cambiar Pedido de Estado");
        Console.WriteLine("4. Reasignar Pedido a otro Cadete");
        Console.WriteLine("5. Mostrar Listado de Pedidos");
        Console.WriteLine("0. Salir de la aplicación");
    }

    public static void MostrarTodosPedidos(List<Pedido> listaPedidos)
    {
        Console.WriteLine("        Mostrando pedidos");
        foreach (var item in listaPedidos)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Numero de pedido ---> " + item.Nro);
            Console.WriteLine("Observaciones ---> " + item.Observacion);
            Console.WriteLine("Estado ---> " + item.EstadoPedido.ToString());
            Pedido.VerDatosCliente(item.Cliente);
            Console.WriteLine("------------------------------------");
        }

    }

    public static void MostarTodosCadetes(List<Cadete> ListadoCadetes)
    {
        Console.Clear();
        Console.WriteLine("             Listado de Cadetes");
        foreach (var item in ListadoCadetes)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ID: " + item.Id);
            Console.WriteLine("Nombre: " + item.Nombre);
            Console.WriteLine("Telefono: " + item.Telefono);
            Console.WriteLine("----------------------------------------------");
        }
        Console.Write("Elija un ID de Cadete: ");
    }

    public static void MenuEstados()
    {
        Console.WriteLine("     Estados Disponibles");
        Console.WriteLine("0.Pendiente");
        Console.WriteLine("1.Preparado");
        Console.WriteLine("2.Completado");
        Console.Write("Elija una opción: ");
    }
}