
public class cargarDatos
{
    private static string archivoCadetes = @"csv/cadetes.csv";
    private static string archivoCadeteria = @"csv/cadeteria.csv";

    public static string ArchivoCadetes { get => archivoCadetes; } //Static permite el uso del atributo adentro de la función
    public static string ArchivoCadeteria { get => archivoCadeteria; set => archivoCadeteria = value; }

    public List<Cadete> obtenerDatosCadetes()
    {
        string lineas;

        List<Cadete> listCadete = new List<Cadete>();
        //Primero leo el archivo
        using (StreamReader leer = new StreamReader(ArchivoCadetes))
        {
            while ((lineas = leer.ReadLine()) != null)
            {

                string[] datos = lineas.Split(',');

                var cadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], int.Parse(datos[3]));
                listCadete.Add(cadete);
            }

        }
        return listCadete;

    }

    public static Cadeteria obtenerDatosCadeteria()
    {
        string? lineas;

        using (StreamReader leer = new StreamReader(ArchivoCadetes))
        {

            lineas = leer.ReadLine();

            string[] datos = lineas.Split(',');

            var cadeteria = new Cadeteria(datos[0], datos[1]);



            return cadeteria;

        }

    }

}