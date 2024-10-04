public class Cadeteria{
    private string nombre = @"Pedidos YA";
    private string telefono = @"38128903";
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();

    }

    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public void AgregarCadete(){
        var archivo = new cargarDatos();
        foreach(var elemento in archivo.obtenerDatosCadetes()){
            listadoCadetes.Add(elemento);
        }
    }
}