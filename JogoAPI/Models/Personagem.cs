using System;
using System.ComponentModel.DataAnnotations;

namespace JogoAPI.Models
{
    public class Personagem
    {
        public Personagem()
        {
            Id = Guid.NewGuid().ToString();
            CriadoEm = DateTime.Now;
        }

        public Personagem(string nome, int vida, int ataque, int defesa, int ouro, int usuarioId, Usuario usuario)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Vida = vida;
            Ataque = ataque;
            Defesa = defesa;
            Ouro = ouro;
            UsuarioID = usuarioId;
            Usuario = usuario;
            CriadoEm = DateTime.Now;
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MinLength(3, ErrorMessage = "Este campo tem o tamanho mínimo de 3 caracteres.")]
        [MaxLength(10, ErrorMessage = "Este campo tem o tamanho máximo de 10 caracteres.")]
        public string? Nome { get; set; }

        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public int Ouro { get; set; }
        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
