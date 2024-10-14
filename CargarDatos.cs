using System.Text.Json;
using System.Text.Json.Serialization;


namespace persistencia;
//COMPLETADO
public interface AccesoADatos
{
    List<string> LeerArchivo(string archivo);
    Cadeteria CargarCadeteria();
    List<Cadete> CargarCadetes();

}

public class AccesoCSV : AccesoADatos
{
    public List<string> LeerArchivo(string ruta)
    {
        if (File.Exists(ruta))
        {
            var lineas = new List<string>();
            using (FileStream archivoCSV = new FileStream(ruta, FileMode.Open))
            {
                using (StreamReader readerCsv = new StreamReader(archivoCSV))
                {
                    while (readerCsv.Peek() != -1)
                    {
                        var linea = readerCsv.ReadLine();
                        if (!string.IsNullOrWhiteSpace(linea)) lineas.Add(linea);
                    }
                }
            }
            return lineas;
        }
        else
        {
            throw new Exception("No existe el archivo en " + ruta);
        }
    }
    public Cadeteria CargarCadeteria()
    {
        var datosCSV = LeerArchivo(@"csv/cadeteria.csv");
        var datos = datosCSV[0].Split(",");
        if (datos.Count() < 2) { throw new Exception("Faltan datos"); }
        return new Cadeteria(datos[0], datos[1]);
    }
    public List<Cadete> CargarCadetes()
    {
        var datosCSV = LeerArchivo(@"csv/cadetes.csv");
        List<Cadete> cadetes = new List<Cadete>();

        foreach (var linea in datosCSV)
        {
            var datos = linea.Split(",");
            if (datos.Count() < 4)
            {
                throw new Exception("Faltan datos del cadete");
                continue;
            }
            if (!int.TryParse(datos[0], out int id))
            {
                continue;
            }
            if (!int.TryParse(datos[3], out int telefono))
            {
                continue;
            }

            cadetes.Add(new Cadete(id, datos[1], datos[2], telefono));
        }
        return cadetes;
    }
}




public class AccesoJSON : AccesoADatos
{
    public List<string> LeerArchivo(string nombreArchivo)
    {
        if (!File.Exists(nombreArchivo))
            throw new Exception($"El archivo {nombreArchivo} no existe");

        // Lee todo el contenido del archivo como una sola cadena y agrégalo a la lista
        string contenido = File.ReadAllText(nombreArchivo);
        return new List<string> { contenido };
    }

    public Cadeteria CargarCadeteria()
    {
        var datosJSON = LeerArchivo(@"json/cadeteria.json").FirstOrDefault();
        if (string.IsNullOrWhiteSpace(datosJSON))
        {
            throw new Exception("No se pudieron leer los datos");
        }
        var cadeteria = JsonSerializer.Deserialize<Cadeteria>(datosJSON);
        if (cadeteria == null) { throw new Exception("ERROR"); }

        cadeteria.ListadoPedidos = new List<Pedido>();
        cadeteria.PedidosAsignados = new List<Pedido>();
        return cadeteria;
    }
    public List<Cadete> CargarCadetes()
    {
        var datosCadetesJson = LeerArchivo("json/cadetes.json").FirstOrDefault();

        if (string.IsNullOrWhiteSpace(datosCadetesJson))
        {
            return new List<Cadete>();
        }

        List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(datosCadetesJson);

        if (cadetes == null)
        {
            return new List<Cadete>();
        }

        return cadetes;
    }
}
