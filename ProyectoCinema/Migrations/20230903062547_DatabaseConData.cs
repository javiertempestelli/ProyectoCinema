#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCinema.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseConData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Se crea la tabla GENEROS

            migrationBuilder.CreateTable(
            name: "Generos",
            columns: table => new
            {
                GeneroId = table.Column<int>(type: "int", nullable: false)
                 .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
             {
                 table.PrimaryKey("PK_Generos", x => x.GeneroId);
             });


            // Se crea la tabla SALAS

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            // Se crea la tabla PELICULAS

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sonopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                //Se vincula la FK
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });
            // Se crea la tabla FUNCIONES
            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },

                //Se vinculan las FK de FUNCIONES -> SALA; FUNCIONES -> PELICULA
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Se crea la tabla TICKETS
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                },

                //Se vincula la FK de TICKETS -> FUNCION
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Se crean las relaciones entre las tablas

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");

            // Se crean los Generos de las peliculas
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Acción" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Aventuras" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Ciencia Ficcion" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Comedia" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Documental" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Drama" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Fantasía" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Musical" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Suspenso" });


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Terror" });

            // Se crean las 3 Salas en el Cine
            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 1", 5 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 2", 10 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 3", 35 });

            // Se insertan las 20 peliculas 

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Megalodón 2: La fosa",
                                        "Después de detectar un aumento de actividad en una fosa marina de gran profundidad, Jonas Taylor (Jason Statham) y su equipo tendrán que enfrentarse a un depredador ancestral",
                                        "https://es.web.img2.acsta.net/c_310_420/pictures/23/05/09/10/42/0347977.jpg",
                                        "https://youtu.be/7wuK5PhzcNY?si=iH8OrEpFTkDMamrw" ,
                                        "1"});

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Gran Turismo",
                                        "Basada en la historia real de Jann Mardenborough, un chaval aficionado a los videojuegos de carreras que sueña con ser piloto profesional y que empieza a entrenar para aprender a conducir en un circuito real donde competirá para cumplir su sueño.",
                                        "https://es.web.img2.acsta.net/c_310_420/pictures/23/05/03/14/13/0249485.jpg",
                                        "https://youtu.be/f5IRCGKZgJY?si=Q9UWEFByyTuBljqc" ,
                                        "1"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "El secreto de sus ojos",
                                        "Un exagente judicial busca la verdad en un antiguo caso de asesinato mientras enfrenta su propio pasado.",
                                        "https://es.web.img2.acsta.net/c_310_420/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "2"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Relatos Salvajes",
                                        "Diversas historias exploran los límites de la sociedad y el comportamiento humano en situaciones extremas.",
                                        "https://es.web.img3.acsta.net/c_310_420/pictures/14/11/17/11/15/381594.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "2"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Los Simuladores: El Hombre Nuclear",
                                        "Un equipo de especialistas en solucionar problemas a través de engaños se enfrenta a un desafío tecnológico.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "3"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Moebius",
                                        "En un mundo distópico, un científico descubre una forma de viajar en el tiempo, pero desencadena consecuencias imprevisibles.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "3"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Un Novio para mi Mujer",
                                        "Un hombre contrata a un seductor profesional para que seduzca a su esposa y la haga pedirle el divorcio.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "4"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Nueve Reinas",
                                        "Dos estafadores se unen para realizar una serie de engaños, pero nada es lo que parece en este juego de astucia.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "4"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Favio: Crónica de un Director",
                                        "Un retrato íntimo de Leonardo Favio, un legendario director argentino, y su influencia en la cultura cinematográfica.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "5"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Ciudadano Ilustre",
                                        "Un escritor argentino galardonado regresa a su pueblo natal, desencadenando una serie de eventos sorprendentes.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "5"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Hijo de la Novia",
                                        "Un restaurante familiar enfrenta crisis mientras el protagonista lucha por reconciliarse con su madre y su pasado.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "6"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Cautiva",
                                        "Una joven secuestrada durante su infancia trata de reintegrarse en la sociedad después de ser liberada.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "6"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "La Leyenda de Nahuelito",
                                        "Una película animada que narra la misteriosa historia de Nahuelito, el monstruo del lago Nahuel Huapi.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "7"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Juan y Eva",
                                        "Una película que explora la vida de Eva Perón y su influencia en la política argentina, con elementos de fantasía.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "7"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "La La Land",
                                        "Mia, una joven aspirante a actriz que trabaja como camarera mientras acude a castings, y Sebastian, un pianista de jazz que se gana la vida tocando en sórdidos tugurios, se enamoran, pero su gran ambición por llegar a la cima en sus carreras artísticas amenaza con separarlos.",
                                        "https://pics.filmaffinity.com/la_la_land-262021831-mmed.jpg",
                                        "https://youtu.be/0pdqf4P9MB8?si=zic1kY_1HN3zVE28" ,
                                        "8"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Esperando la Carroza",
                                        "Una comedia musical que sigue las desventuras de una familia disfuncional durante el funeral de la abuela.",
                                        "https://pics.filmaffinity.com/esperando_la_carroza-675954190-mmed.jpg",
                                        "https://youtu.be/KIgOuEPQZsU?si=UUb2Wru_MiFzUMeT" ,
                                        "8"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Método",
                                        "Un grupo de aspirantes a ejecutivos compite brutalmente por un codiciado puesto de trabajo en una entrevista de selección.",
                                        "https://pics.filmaffinity.com/el_metodo-411717926-mmed.jpg",
                                        "https://youtu.be/kkqpiImZ5ko?si=uCOWJrypBDUHji2D" ,
                                        "9"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Relaciones Peligrosas",
                                        "Un psicólogo se ve involucrado en un peligroso juego de seducción con una enigmática paciente.",
                                        "https://pics.filmaffinity.com/open_marriage_to_have_and_to_kill-372578448-mmed.jpg",
                                        "https://youtu.be/OQFGYEVsLQU?si=e-lvJDqYuTr7owOY" ,
                                        "9"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Terrified",
                                        "Una serie de eventos aterradores afecta a una comunidad, y un equipo de investigadores busca respuestas sobrenaturales.",
                                        "https://pics.filmaffinity.com/aterrados-800169699-mmed.jpg",
                                        "https://youtu.be/oUmw0tRytDc?si=pUYyYyoXaFmMNTNq" ,
                                        "10"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Espinazo del Diablo",
                                        "En un orfanato durante la Guerra Civil Española, un niño se enfrenta a sucesos paranormales y oscuros secretos.",
                                        "https://es.web.img2.acsta.net/c_310_420/medias/nmedia/18/82/09/38/19598918.jpg",
                                        "https://youtu.be/c3gRqYu5olY?si=21jn-0njwEEt692a" ,
                                        "10"});

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Tickets"); // Elimina la tabla Tickets primero

            // Elimina las relaciones antes de eliminar las tablas principales
            migrationBuilder.DropForeignKey("FK_Funciones_Peliculas_PeliculaId", "Funciones");
            migrationBuilder.DropForeignKey("FK_Funciones_Salas_SalaId", "Funciones");

            // Elimina las tablas principales
            migrationBuilder.DropTable("Funciones");
            migrationBuilder.DropTable("Peliculas");
            migrationBuilder.DropTable("Salas");
            migrationBuilder.DropTable("Generos");
        }
    }
}
