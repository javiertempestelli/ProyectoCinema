using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoCinema.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseConData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                },
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

            // Crea nuevas filas en la tabla 'Salas'
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

            // Crea una nueva fila en la tabla 'Peliculas'
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "El Aura",
                                        "Un hombre con epilepsia comienza a vivir una doble vida, involucrándose en un peligroso robo en la Patagonia argentina.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "1"});

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Carancho",
                                        "Un abogado sin escrúpulos se involucra en un oscuro mundo de accidentes de tráfico y corrupción en busca de dinero fácil.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "1"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "El secreto de sus ojos",
                                        "Un exagente judicial busca la verdad en un antiguo caso de asesinato mientras enfrenta su propio pasado.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "2"});
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] {  "Relatos Salvajes",
                                        "Diversas historias exploran los límites de la sociedad y el comportamiento humano en situaciones extremas.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
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
               values: new object[] {  "Tango",
                                        "Una película que celebra el tango argentino y su impacto en la cultura del país a lo largo de las décadas.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "8"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Esperando la Carroza",
                                        "Una comedia musical que sigue las desventuras de una familia disfuncional durante el funeral de la abuela.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "8"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Método",
                                        "Un grupo de aspirantes a ejecutivos compite brutalmente por un codiciado puesto de trabajo en una entrevista de selección.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "9"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Relaciones Peligrosas",
                                        "Un psicólogo se ve involucrado en un peligroso juego de seducción con una enigmática paciente.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "9"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "Terrified",
                                        "Una serie de eventos aterradores afecta a una comunidad, y un equipo de investigadores busca respuestas sobrenaturales.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "10"});
            migrationBuilder.InsertData(
               table: "Peliculas",
               columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
               values: new object[] {  "El Espinazo del Diablo",
                                        "En un orfanato durante la Guerra Civil Española, un niño se enfrenta a sucesos paranormales y oscuros secretos.",
                                        "https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "10"});
 
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Eliminar tabla al salid o vaciarla
        }
    }
}
