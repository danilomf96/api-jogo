using JogoAPI.Models;

namespace JogoAPI;

public class Batalha
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public Usuario? Usuario { get; set; }
    public Personagem? Personagem { get; set; }
    public Vilao? Vilao { get; set; }
    public bool Inicio { get; set; }

    public DateTime HoraBatalha { get; set; } = DateTime.Now;

}
