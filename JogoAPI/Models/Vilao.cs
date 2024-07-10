using System;

namespace JogoAPI.Models
{
    public class Vilao
    {
        public Vilao()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Vilao(string nome, int vida, int ataque, int defesa, int ouro)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Vida = vida;
            Ataque = ataque;
            Defesa = defesa;
            Ouro = ouro;
        }

        public string Id { get; set; }
        public string? Nome { get; set; }

        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public int Ouro { get; set; }

    }
}
