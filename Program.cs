//  Sistema de Cadetería

// Punto 2b
using System.Collections.ObjectModel;
using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();

        //Variables
        string texto;
        bool bucle = true;
        int opcion;
        bool restultado;
        int idPedido = 0;
        int pedidoElegido;
        int cadeteElegido;

        //Para usar los métodos
        cargarDatos cargar = new cargarDatos();


        //Listas
        List<Pedido> listaPedidos = new List<Pedido>();

        //Creando Cadeteria
        Cadeteria local = cargarDatos.obtenerDatosCadeteria();
        //Cargando cadetes a la cadeteria
        local.ListadoCadetes = cargarDatos.obtenerDatosCadetes();


        while (bucle)
        {
            opcion = seleccionMenu();

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    OpcionIngresarPedido(Cliente.CargarCliente(), idPedido);
                    idPedido++;
                    break; //COMPLETADO Y FUNCIONANDO
                case 2:
                    OpcionAsignarPedidos();
                    break;  //COMPLETADO Y FUNCIONANDO
                case 3:
                    OpcionCambiarPedidoEstado();
                    break;  //COMPLETADO Y FUNCIONANDO
                case 4:
                    OpcionReasignarPedido();
                    break;  //COMPLETADO Y FUNCIONANDO
                case 5:
                    Visual.MostrarTodosPedidos(listaPedidos);
                    break;  //COMPLETADO Y FUNCIONANDO
                default:
                    bucle = false;
                    Console.WriteLine("Cerrando el programa...");
                    break;  //COMPLETADO Y FUNCIONANDO
            }

        }


        System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        System.Console.WriteLine("      Resumen de la jornada");
        System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");



        int cantidadEnvios = 0;
        int CantidadCompletados = 0;
        int total = 0;
        foreach (var cadete in local.ListadoCadetes)
        {
            cantidadEnvios = cadete.ListadoPedidos.Count(p => p.EstadoPedido == Estado.Preparado);
            CantidadCompletados = cadete.ListadoPedidos.Count(p => p.EstadoPedido == Estado.Completado);
            total += cantidadEnvios + CantidadCompletados;
            System.Console.WriteLine("---------------------------------------");
            System.Console.WriteLine("Cadete: " + cadete.Nombre);
            System.Console.WriteLine("Envios = " + cantidadEnvios);
            System.Console.WriteLine("Completados = " + CantidadCompletados);
            System.Console.WriteLine("Total = " + total);
            System.Console.WriteLine("---------------------------------------");
            cantidadEnvios = 0;
            CantidadCompletados = 0;
            total = 0;
        }



        void OpcionIngresarPedido(Cliente nuevoCliente, int nro)
        {
            listaPedidos.Add(Pedido.IngresarPedido(nuevoCliente, nro));
        }

        void OpcionAsignarPedidos()
        {
            int pedidoElegido;
            int cantidadPed = listaPedidos.Count();
            int cantidadCad = local.ListadoCadetes.Count();

            if (cantidadPed == 0)
            {
                Console.WriteLine("No hay pedidos para asignar");
                return;
            }
            else { cantidadPed--; }
            if (cantidadCad == 0)
            {
                Console.WriteLine("No hay Cadetes para elegir");
                return;
            }
            else { cantidadCad--; }


            //Menu de selección para cadetes
            cadeteElegido = controlCadetes(cantidadCad);
            Thread.Sleep(500);


            //Elegir pedido
            pedidoElegido = controlPedidos(cantidadPed, listaPedidos);
            Thread.Sleep(500);


            //Control que el pedido no este asignado a otro cadete
            bool estaAsignado = local.ListadoCadetes.Any(c => c.ListadoPedidos.Any(p => p.Nro == listaPedidos[pedidoElegido].Nro));

            if (!estaAsignado)
            {
                //Guardado en los Cadetes y cambio en la lista de pedidos
                local.ListadoCadetes[cadeteElegido].ListadoPedidos.Add(listaPedidos[pedidoElegido]);
                local.PedidosAsignados.Add(listaPedidos[pedidoElegido]);
            }
            else
            {
                var cadeteConPedido = local.ListadoCadetes.Where(c => c.ListadoPedidos.Any(p => p.Nro == listaPedidos[pedidoElegido].Nro)).FirstOrDefault();
                Console.WriteLine("Este pedido ya esta asignado a " + cadeteConPedido.Nombre);
                Console.WriteLine("Volviento al menú");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }



        void OpcionCambiarPedidoEstado()
        {
            int estadoElegido;
            int cantidadPed = listaPedidos.Count();
            int cantidadEst = Enum.GetValues(typeof(Estado)).Length - 1;

            if (cantidadPed == 0)
            {
                Console.WriteLine("No hay pedidos para cambiar su estado");
                return;
            }
            else { cantidadPed--; }


            pedidoElegido = controlPedidos(cantidadPed, listaPedidos);

            do
            {
                Console.Clear();
                Visual.MenuEstados();
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out estadoElegido);
            } while (!restultado || estadoElegido > cantidadEst || estadoElegido < 0);


            listaPedidos[pedidoElegido].EstadoPedido = (Estado)estadoElegido;

            var cadeteConPedido = local.ListadoCadetes.Where(c => c.ListadoPedidos.Any(p => p.Nro == listaPedidos[pedidoElegido].Nro)).FirstOrDefault();

            if (cadeteConPedido != null)
            {
                var pedidoEnCadete = cadeteConPedido.ListadoPedidos.FirstOrDefault(p => p.Nro == listaPedidos[pedidoElegido].Nro);
                if (pedidoEnCadete != null)
                {
                    pedidoEnCadete.EstadoPedido = (Estado)estadoElegido;
                }
            }

        }
        void OpcionReasignarPedido()
        {
            int cantidadAsig = local.PedidosAsignados.Count();
            int idPedido;
            if (cantidadAsig == 0) return;


            pedidoElegido = controlPedidos(cantidadAsig, local.PedidosAsignados);
            idPedido = local.PedidosAsignados[pedidoElegido].Nro;

            cadeteElegido = controlCadetes(local.ListadoCadetes.Count());

            var cadeteAsignado = local.ListadoCadetes.FirstOrDefault(cadet => cadet.ListadoPedidos.Any(pedido => pedido.Nro == local.PedidosAsignados[pedidoElegido].Nro));
            cadeteAsignado.ListadoPedidos.RemoveAll(datos => datos.Nro == idPedido);

            Console.WriteLine("Reasignando el pedido a " + local.ListadoCadetes[cadeteElegido].Nombre);
            local.ListadoCadetes[cadeteElegido].ListadoPedidos.Add(local.PedidosAsignados[pedidoElegido]);
            Thread.Sleep(1000);
        }


        int seleccionMenu()
        {
            do
            {
                Visual.Menu(local.Nombre, local.Telefono);
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out opcion);
            } while (!restultado || opcion > 5 || opcion < 0);
            return opcion;
        }

        int controlPedidos(int cantidadPed, List<Pedido> lista)
        {
            do
            {
                Console.Clear();
                Visual.MostrarTodosPedidos(lista);
                Console.WriteLine("Seleccione el pedido:");
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out pedidoElegido);
            } while (!restultado || pedidoElegido > cantidadPed || pedidoElegido < 0);
            return pedidoElegido;
        }
        int controlCadetes(int cantidadCad)
        {
            do
            {
                Visual.MostarTodosCadetes(local.ListadoCadetes);
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out cadeteElegido);
            } while (!restultado || cadeteElegido > cantidadCad || cadeteElegido < 0);
            return cadeteElegido;
        }


    }
}










