using clase;
using System.Net.Http;
using System.Text.Json;
using System;
using System.IO;
//string estado;

HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
respuesta.EnsureSuccessStatusCode();

string contenidoresp= await respuesta.Content.ReadAsStringAsync();

List<Tarea> listaTarea = JsonSerializer.Deserialize<List<Tarea>>(contenidoresp);

foreach (var Tar in listaTarea)
{
    if (Tar.completed == false)
    {
        Console.WriteLine($"Titulo tarea:{Tar.title} \nEstado:Pendiente");
    } 
}

foreach (var Tar in listaTarea)
{
    if (Tar.completed == true)
    {
        Console.WriteLine($"Titulo tarea:{Tar.title} \nEstado:Completada");
    } 
}

string jsonString = JsonSerializer.Serialize(listaTarea);

File.WriteAllText("tareas.json", jsonString);