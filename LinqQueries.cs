public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2020);
    }

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SiAlgunLibroFuePublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> LibrosdePython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }
    public IEnumerable<Book> LibrosdeJavaPorNombreAscendente()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> Librosmasde450pagOrdernadorPorNumPagDescendente()
    {
        return librosCollection.Where(p => p.PageCount <= 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> Take()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
    }
    public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag()
    {
        return librosCollection
        .Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }
    public IEnumerable<Book> TresPrimeroLibrosDeLaCollecion()
    {
        return librosCollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }
    public long CantidadDeLibrosEntre200y500Pag()
    {
        return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }
    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int NumeroDePagLibroMayor()
    {
        return librosCollection.Max(p => p.PageCount);
    }
      public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p=> p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }
      public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDepuesdel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);

        var LibrosConMasde500pag = librosCollection.Where(p=> p.PageCount > 500);

        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p=> p.Title, x=> x.Title, (p, x) => p);

        
    }
}