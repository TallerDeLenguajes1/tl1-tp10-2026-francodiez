using usuario;
using System.Net.Http;
using System.Text.Json;
using System;
using System.IO;
using System.Linq; // Necesario para usar .Take() para limitar el recorrido en la lista

HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
respuesta.EnsureSuccessStatusCode();

string contenidoresp= await respuesta.Content.ReadAsStringAsync();

List<Usuario> listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(contenidoresp);

foreach (var Usu in listaUsuarios.Take(5))
{
    Console.WriteLine($"Nombre:{Usu.name}\nCorreo:{Usu.email}\nDomicilio:");
    Console.WriteLine($" Calle:{Usu.address.street}\n Suite:{Usu.address.suite}\n Ciudad:{Usu.address.city}\n Codigo postal:{Usu.address.zipcode}");
    Console.WriteLine($" Ubicacion geografica:\n  Latitud:{Usu.address.geo.lat}\n  Longitud:{Usu.address.geo.lng}\n\n");
}


string jsonString = JsonSerializer.Serialize(listaUsuarios);

File.WriteAllText("usuarios.json", jsonString); 
