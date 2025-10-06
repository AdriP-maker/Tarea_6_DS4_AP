// See https://aka.ms/new-console-template for more information
using Linq_Curso;


LinqQueries peticiones = new LinqQueries();

//Imprimir toda la colección completa
//ImprimirValores(peticiones.ExportarColeccion());

//Libros despues del 2000
//ImprimirValores(peticiones.Publi2000());

//Libro que tienen mas de 250 paginas y tienen por su titulo la palabra in action
//ImprimirValores(peticiones.LibrosAccionmas200pag());

//Todos los libtos tiene un status
//Console.WriteLine($"Todos los libros tienen status? - {peticiones.librosconEstatus()}");

//Verificar si algun libro fue publicado en el 2005
//Console.WriteLine($"Algun libro fue publicado en el 2005? - {peticiones.Publicaciones2005()}");

//Libros con información de python
//ImprimirValores(peticiones.TituloPython());

//Libros de Java ordenados por su Titulo
//ImprimirValores(peticiones.JavaLibrosAsc());

//Orden de libros de forma descendente con el filtro de 450 paginas
//ImprimirValores(peticiones.Libros450OrdenadosDesc());

//Mostrar los 3 primeros libros con Información de Java publicados recientemente
//ImprimirValores(peticiones.PrimerosLibrosporFechaparaJava());

//De los libros de 400 paginas o mas se seleccionan solo el tercero y cuarto
//ImprimirValores(peticiones.Seleciondelibrosespc());

//Primeros libros con filtro del select
ImprimirValores(peticiones.Librodelacoleecionseleccion());

void ImprimirValores (IEnumerable<Books> listadeLibros)
{
    Console.WriteLine("{0, -70}, {1,7}, {2,11} ", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in listadeLibros)
    {
        Console.WriteLine("{0, -70}, {1,7}, {2,11} ",book.Title,book.PageCount,book.PublishedDate);
    }
}