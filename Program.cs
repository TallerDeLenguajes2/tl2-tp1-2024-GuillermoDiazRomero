//  Sistema de Cadetería

// Punto 2b
Console.Clear();

System.Console.WriteLine("Ingrese su nombre");
string nombre = Console.ReadLine();
System.Console.WriteLine("Ingrese su dirección");
string direccion = Console.ReadLine();
System.Console.WriteLine("Ingrese su numero de telefono");
int telefono = int.Parse(Console.ReadLine());
System.Console.WriteLine("Tiene referencias de la diección?");
string datosReferenciaDireccion = Console.ReadLine();

Cliente nuevoCliente = new Cliente (nombre,direccion,telefono,datosReferenciaDireccion);

System.Console.WriteLine("Datos ingresados:");
System.Console.WriteLine(nuevoCliente.Nombre);
System.Console.WriteLine(nuevoCliente.Direccion);
System.Console.WriteLine(nuevoCliente.Telefono);
System.Console.WriteLine(nuevoCliente.DatosReferenciaDireccion);


/*CLIENTE SI ANDA*/



/*
string texto;
int opcion;
bool restultado;

do
{
    Visual.Menu();
    texto = Console.ReadLine();
    restultado = int.TryParse(texto, out opcion);

} while (!restultado || opcion > 4 || opcion < 0);

Console.WriteLine(opcion);

*/