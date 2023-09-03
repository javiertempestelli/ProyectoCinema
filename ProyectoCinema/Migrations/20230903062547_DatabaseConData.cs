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
                values: new object[] {  "   	El secreto de sus ojos 	",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "1"});

            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "1"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "2"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "2"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "3"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "3"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "4"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "4"});

            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "5"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "5"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "7"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "7"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "8"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "8"});

            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "9"});
            migrationBuilder.InsertData(
    table: "Peliculas",
    columns: new[] { "Titulo", "Sonopsis", "Poster", "Trailer", "GeneroId" },
    values: new object[] {  "El secreto de sus ojos",
                                        "	    Un asesor legal retirado escribe una novela con la " +
                                        "       esperanza de encontrar un cierre para uno de sus" +
                                        "       casos de homicidio no resueltos en el pasado y para" +
                                        "       su amor no correspondido con su superior, los cuales " +
                                        "       aún lo persiguen décadas después.	",
                                        "	    https://es.web.img3.acsta.net/r_1920_1080/medias/nmedia/18/72/09/92/19153236.jpg",
                                        "   	https://youtu.be/viV-OC4bpOw?si=guzx2kgRN9YcgXn6	" ,
                                        "9"});

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Eliminar tabla al salid o vaciarla
        }
    }
}
