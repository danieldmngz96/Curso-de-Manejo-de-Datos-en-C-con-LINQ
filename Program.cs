LinqQueries queries = new LinqQueries();

//ImprimirValores(queries.TodaLaColeccion());
//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

/* //Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());

//Todos los libros tienen Status
Console.WriteLine($" Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Si algun libro fue publicado en 2005
Console.WriteLine($" Algun libro fue publicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}"); */

//Libros de python
//ImprimirValores(queries.LibrosdePython());

//libros de Java ordenados por nombre
//ImprimirValores(queries.LibrosdeJavaPorNombreAscendente());

//libros que tienen  de 450 o menos paginas ordernados por cantidad de paginas
//ImprimirValores(queries.Librosmasde450pagOrdernadorPorNumPagDescendente());

//tercer y caurto libro con mas de 400 paginas
//ImprimirValores(queries.Take());

//tercer y caurto libro con mas de 400 paginas
//ImprimirValores(queries.TerceryCuartoLibroDeMas400Pag());

//tres primeros libros filtrados con Select
//ImprimirValores(queries.TresPrimeroLibrosDeLaCollecion());

//cantidad de libros que tienen entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros que tiene entre 200 y 500 pag. {queries.CantidadDeLibrosEntre200y500Pag()}");

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'J');

// libros filtradaor con la clausula join 
ImprimirValores(queries.LibrosDespuesdel2005conmasde500Pags());


void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}