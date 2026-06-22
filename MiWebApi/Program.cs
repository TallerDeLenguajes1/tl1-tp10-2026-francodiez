using gato;
using System.Net.Http;
using System.Text.Json;
using System;
using System.IO;

HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync("https://catfact.ninja/facts");
respuesta.EnsureSuccessStatusCode();
string contenidoresp = await respuesta.Content.ReadAsStringAsync();

RespuestaGatosContenedor contenedor = JsonSerializer.Deserialize<RespuestaGatosContenedor>(contenidoresp);

//extraigo la lista de datos del contenedor
List<Dato> listaDatos = contenedor.data;

Console.WriteLine("Datos curiosos de gatos");
foreach (var dato in listaDatos)
{
    Console.WriteLine($"Curiosidad:{dato.fact}\nCantidad de caracteres:{dato.length}\n");
}

string jsonString = JsonSerializer.Serialize(listaDatos);
File.WriteAllText("datos.json", jsonString);