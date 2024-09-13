public class cargarDatos{
    private static string archivoCadetes = @"csv/cadetes.csv";

    public static string ArchivoCadetes { get => archivoCadetes;} //Static permite el uso del atributo adentro de la función

    public static void obtenerDatos(Cadeteria sucursal){
        string lineas;        

        //Primero leo el archivo
        using (StreamReader leer = new StreamReader(ArchivoCadetes)){

            while((lineas = leer.ReadLine()) != null){

                string[] datos = lineas.Split(',');

                var cadete = new Cadete(datos[0],datos[1],datos[2]);

                sucursal.AgregarCadete(cadete);

            }

        }
    }
} 