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


            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Documental" });



            // Crea nuevas filas en la tabla 'Salas'
            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 1", 5 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 2", 15 });

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

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
