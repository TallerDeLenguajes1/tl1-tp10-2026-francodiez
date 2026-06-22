namespace gato;

public class Dato
{
    public string fact {get;set;}
    public int length{get;set;}
}

public class RespuestaGatosContenedor
{
    //busco la propiedad "data" del JSON y guardo la lista aquí
    public List<Dato> data { get; set; } 
}