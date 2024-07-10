using API.Models;
using JogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options=>
    options.AddPolicy("Acesso", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();


app.MapGet("/", () => "Hero World");

//cadastrar usuario
app.MapPost("/usuario/cadastrar", ([FromServices] AppDataContext ctx,[FromBody] Usuario usuario) =>{
    ctx.Usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created("", usuario);

});
//listar usuarios
app.MapGet("/usuario/listar", ([FromServices] AppDataContext ctx) =>{
    if (ctx.Usuarios.Any()){
        return Results.Ok(ctx.Usuarios.ToList());
    }
    return Results.NotFound("Nenhum usuário encontrado!");
});
//deletar usuarios
app.MapDelete("/usuario/deletar/{usuario.Id}", ([FromRoute] string id, [FromServices] AppDataContext context) =>
{

    Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
    if (usuario is null){
        return Results.NotFound("Usuário não encontrado!");
    }
    context.Usuarios.Remove(usuario);
    context.SaveChanges();
    return Results.Ok("Usuário deletado com sucesso!");
});

app.MapPost("/personagem/criar", ([FromServices] AppDataContext ctx, [FromBody] Personagem personagem) =>{
    Usuario? usuario = ctx.Usuarios.Find(personagem.UsuarioID);
    if (usuario is null){
        return Results.NotFound("Usuário não encontrado!");
    }
    personagem.Usuario = usuario;
    ctx.Personagens.Add(personagem);
    ctx.SaveChanges();
    return Results.Created("", personagem);
});

//listar usuarios
app.MapGet("/personagem/listar", ([FromServices] AppDataContext ctx) =>{
    if (ctx.Personagens.Any()){
        return Results.Ok(ctx.Personagens.ToList());
    }
    return Results.NotFound("Nenhum personagens encontrado!");
});


app.MapDelete("/personagem/deletar/{personagem.Id}", ([FromRoute] string id, [FromServices] AppDataContext context) =>
{

    Personagem? personagem = context.Personagens.FirstOrDefault(p => p.Id == id);
    if (personagem is null){
        return Results.NotFound("Usuário não encontrado!");
    }
    context.Personagens.Remove(personagem);
    context.SaveChanges();
    return Results.Ok("Personagem deletado com sucesso!");
});

app.MapPut("/personagem/atualizar/{personagem.Id}", ([FromBody] Personagem personagemAtualizado ,[FromRoute] string id, [FromServices] AppDataContext context) =>
{
    Personagem? personagem = context.Personagens.Find(id);
    if (personagem is null){
        return Results.NotFound("Personagem não encontrado!");
    }
    personagem.Ouro = personagemAtualizado.Ouro;
    personagem.Ataque = personagemAtualizado.Ataque;
    personagem.Defesa = personagemAtualizado.Defesa;
    personagem.Vida = personagemAtualizado.Vida;
    context.SaveChanges();
    return Results.Ok("Personagem atualizado com sucesso!");
});
app.UseCors("Acesso Total");
app.Run();
