public class Cadeteria{
    private string nombre = @"Pedidos YA";
    private string telefono = @"38128903";
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(){
       cargarDatos.ArchivoCadetes(listadoCadetes);
    }
}