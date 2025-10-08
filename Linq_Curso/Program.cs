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
//ImprimirValores(peticiones.Librodelacoleecionseleccion());

// Agregado de los videos 17 al 26 

//Libros que contienen en entre 200 y 500 paginas.
//Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 paginas es: {peticiones.Librosentre200_500pag()}");

//Fecha de la menor publicación de un libro
//Console.WriteLine($"Fecha de la publicacion antiguo: { peticiones.FechaMenor()}");

//Paginas del libro con la mayor cantidad
//Console.WriteLine($"La cantidad de paginas del libro con mas de estas es: {peticiones.Libromasgrande()} paginas");

//Paginas del libro con menos paginas
//Books LibMin = peticiones.Libroconpocaspaginas();
//Console.WriteLine($"El libro con el menor numero de paginas es : {LibMin.Title}  y tiene {LibMin.PageCount} paginas");

//Libro con la publicacion mas reciente.
//Books Libnew = peticiones.Libromasreciente();
//Console.WriteLine($"El libro con la más reciente publicacion es : {Libnew.Title}  y fue publicado en:  {Libnew.PublishedDate} ");

//Suma de los libros que tienen entre 0 y 500 paginas
//Console.WriteLine($"La suma de los libros entre 0 y 500 paginas es : { peticiones.Sumalibros()} paginas");

//Libros que fueron publicados despues del 2015
//Console.WriteLine(peticiones.Libros2015publi());

//Promedio del los caracteres que tiene los libros 
//Console.WriteLine($"El promedio de caracteres en los titulos de los libros es de: {peticiones.PromCaracLib()}");

//Libros publicados a partir del año 2000 presentados de forma agrupada
//ImprimirGrupo(peticiones.Librosdp200Agrupados());

//Diccionario de libros por letras del abecedario
//var dicionario = peticiones.LibrosporLetra();
//ImprimirDiccionario(dicionario,'A');

//Libros con Join Filtrado
ImprimirValores(peticiones.JoinLibros());

void ImprimirValores (IEnumerable<Books> listadeLibros)
{
    Console.WriteLine("{0, -70}, {1,7}, {2,11} ", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var book in listadeLibros)
    {
        Console.WriteLine("{0, -70}, {1,7}, {2,11} ",book.Title,book.PageCount,book.PublishedDate);
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Books>> listadeLibros)
{

    foreach (var grupo in listadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0, -60}, {1,15}, {2,15} ", "Titulo", "N. Paginas", "Fecha de Publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0, -60}, {1,15}, {2,15} ", item.Title, item.PageCount, item.PublishedDate);
        }

        
    }
}

void ImprimirDiccionario(ILookup<char, Books> listadeLibros, char letra)
{
    Console.WriteLine("{0, -60}, {1,7}, {2,11} \n ", "Titulo", "N. Paginas", "Fecha de Publicacion");
    foreach (var item in listadeLibros[letra])
    {
        Console.WriteLine("{0, -60}, {1,7}, {2,11} ", item.Title, item.PageCount, item.PublishedDate);
    }
}