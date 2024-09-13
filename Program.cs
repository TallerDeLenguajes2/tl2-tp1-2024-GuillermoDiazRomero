//  Sistema de Cadetería

// Punto 2b
Console.Clear();

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

