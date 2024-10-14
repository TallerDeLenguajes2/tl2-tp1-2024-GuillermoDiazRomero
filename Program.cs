//  Sistema de Cadetería

// Punto 2b
using System.Collections.ObjectModel;
using System.ComponentModel;
using persistencia;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        //Variables
        string texto;
        bool bucle = true;
        bool restultado;
        int opcionCarga;
        int cantidadEnvios = 0;
        int CantidadCompletados = 0;
        int total = 0;


        //CARGANDO DATOS
        AccesoADatos? cargar;
        opcionCarga = controlCarga();
        cargar = opcionCarga switch
        {
            1 => new AccesoCSV(),
            2 => new AccesoJSON(),
            _ => null
        };
        Thread.Sleep(500);
        Console.Clear();
        //Creando Cadeteria
        Cadeteria local = cargar.CargarCadeteria();
        //Creando Listado de Cadetes
        local.ListadoCadetes = cargar.CargarCadetes();

        int cantPedidosTomados = 0;
        //Inicio del programa con los datos ya cargados
        while (bucle)
        {
            switch (seleccionMenu())
            {
                case 1:
                    Console.Clear();
                    OpcionIngresarPedido(Cliente.CargarCliente(),cantPedidosTomados);
                    cantPedidosTomados++;
                    break; //COMPLETADO Y FUNCIONANDO
                case 2:
                    OpcionAsignarPedidos();
                    break;  //COMPLETADO Y FUNCIONANDO
                case 3:
                    OpcionCambiarPedidoEstado();
                    break;
                case 4:
                    OpcionReasignarPedido(); //COMPLETADO Y FUNCIONANDO
                    break;
                case 5:
                    OpcionMostrarPedidos();
                    break;  //COMPLETADO Y FUNCIONANDO
                default:
                    bucle = false;
                    Console.WriteLine("Cerrando el programa...");
                    break;  //COMPLETADO Y FUNCIONANDO
            }

        }

        ResumenJornada();


        void OpcionIngresarPedido(Cliente nuevoCliente, int idP)
        {
            local.ListadoPedidos.Add(Pedido.IngresarPedido(nuevoCliente, idP));
        }

        void OpcionAsignarPedidos()
        {
            int idCadete;
            int idPedido;
            //Controles de listas
            if (local.ListadoPedidos.Count() == 0) { throw new Exception("No hay pedidos para asignar"); }
            if (local.ListadoCadetes.Count() == 0) { throw new Exception("No hay cadetes para ser asignados"); }
            //Menu de selección para cadetes
            idCadete = controlCadetes(local.ListadoCadetes); //CONTROL DE ID CADETE REALIZADO
            Thread.Sleep(500);
            //Elegir pedido
            idPedido = controlPedidos(local.ListadoPedidos); //CONTROL DE ID PEDIDO REALIZADO
            Thread.Sleep(500);
            local.AsignarCadeteAPedido(idCadete, idPedido);
        }

        void OpcionCambiarPedidoEstado()
        {
            int estadoElegido;
            int idPedido;
            if (local.PedidosAsignados.Count() == 0) { throw new Exception("No hay pedidos Asignados para cambiar su estado"); }
            idPedido = controlPedidos(local.PedidosAsignados);
            estadoElegido = controlEstados();
            Pedido cambiarEstado = local.PedidosAsignados.FirstOrDefault(p => p.Nro == idPedido);
            cambiarEstado.EstadoPedido = (Estado)estadoElegido;
            Console.WriteLine("El pedido nro. " + cambiarEstado.Nro + " fue modificado su estado a " + cambiarEstado.EstadoPedido);
        }

        void OpcionReasignarPedido()
        {
            int idPedido;
            int idCadeteRA;
            if (local.PedidosAsignados.Count() <= 0) { throw new Exception("No hay pedidos asignados"); }
            if (local.ListadoCadetes.Count() <= 1) { throw new Exception("No hay suficientes cadetes para reasignar pedidos"); }
            idPedido = controlPedidos(local.PedidosAsignados);
            var pedidoRA = local.PedidosAsignados.Where(p => p.Nro == idPedido).FirstOrDefault(); //Obtengo el pedido a cambiar su cadete
            List<Cadete> cadetesDisponibles = local.ListadoCadetes.Where(c => c.Id != pedidoRA.CadeteACargo.Id).ToList(); //Obtengo una lista nueva con los cadetes disponibles
            idCadeteRA = controlCadetes(cadetesDisponibles);
            var cadeteRA = cadetesDisponibles.FirstOrDefault(c => c.Id == idCadeteRA);
            Console.WriteLine("Reasignando el pedido " + pedidoRA.Nro + " de " + pedidoRA.CadeteACargo.Nombre + " a " + cadeteRA.Nombre);
            Thread.Sleep(2000);
            pedidoRA.CadeteACargo = cadeteRA;
        }

        void OpcionMostrarPedidos()
        {
            if (local.ListadoPedidos.Count != 0)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("        Pedidos Tomados por el local");
                Console.WriteLine("--------------------------------------------");
                Visual.MostrarTodosPedidos(local.ListadoPedidos);
            }
            if (local.PedidosAsignados.Count != 0)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("         Pedidos asignados a cadetes");
                Console.WriteLine("--------------------------------------------");
                Visual.MostrarTodosPedidos(local.PedidosAsignados);
            }

        }

        void ResumenJornada()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("      Resumen de la jornada");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            foreach (var cadete in local.ListadoCadetes)
            {
                var Jornal = local.JornalACobrar(cadete.Id);

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Cadete: " + cadete.Nombre);
                Console.WriteLine("Envios = " + Jornal.Item1);
                Console.WriteLine("Ganancia = $" + Jornal.Item2);
                Console.WriteLine("---------------------------------------");
            }
        }



        //Controles de Carga y Menú principal realizados 
        int controlCarga()
        {
            int opcion;
            do
            {
                Visual.MenuCarga();
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out opcion);
            } while (!restultado || opcion > 2 || opcion < 1);
            return opcion;
        }
        int seleccionMenu()
        {
            int opcion;
            do
            {
                Visual.Menu(local.Nombre, local.Telefono);
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out opcion);
            } while (!restultado || opcion > 5 || opcion < 0);
            return opcion;
        }
        int controlEstados()
        {
            int estadoElegido;
            int cantidadEst = Enum.GetValues(typeof(Estado)).Length;
            do
            {
                Console.Clear();
                Visual.MenuEstados();
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out estadoElegido);
            } while (!restultado || estadoElegido > cantidadEst || estadoElegido < 1);
            return estadoElegido;
        }

        //Controles Pedidos y Cadetes realizados
        int controlPedidos(List<Pedido> lista)
        {
            int idPedido;
            bool consulta;
            do
            {
                Console.Clear();
                Visual.MostrarTodosPedidos(lista);
                Console.WriteLine("Seleccione el Numero de pedido:");
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out idPedido);
                consulta = lista.Where(p => p.Nro == idPedido).Any();
            } while (!restultado || !consulta);
            return idPedido;
        }
        int controlCadetes(List<Cadete> lista)
        {
            int idCadete;
            bool consulta;

            do
            {
                Visual.MostarTodosCadetes(lista);
                texto = Console.ReadLine();
                restultado = int.TryParse(texto, out idCadete);
                consulta = lista.Where(c => c.Id == idCadete).Any();

            } while (!restultado || !consulta);
            return idCadete;
        }



    }
}










