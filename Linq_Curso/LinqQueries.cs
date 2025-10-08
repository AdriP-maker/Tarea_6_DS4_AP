using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Curso
{
    public class LinqQueries
    {
        private List<Books> ColeccionLibros = new List<Books>();
        public LinqQueries()
        {
            using (StreamReader lector = new StreamReader("books.json"))
            {
                string json = lector.ReadToEnd();
                this.ColeccionLibros = System.Text.Json.JsonSerializer.Deserialize<List<Books>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

        }

        //Peticiones
        public IEnumerable<Books> ExportarColeccion()
        {
            return ColeccionLibros;
        }
        //Where
        public IEnumerable<Books> Publi2000()
        {
            //Metodo de extensión ?
            //return ColeccionLibros.Where(p  => p.PublishedDate.Year != 2000);  

            //Query expresion
            return from l in ColeccionLibros where l.PublishedDate.Year > 2000 select l;
        }
        public IEnumerable<Books> LibrosAccionmas200pag()
        {
            //Metodo de extension
            //return ColeccionLibros.Where(p => p.PageCount > 250 && p.Title.Contains("In Action"));

            //Query Expresion
            return from h in ColeccionLibros where h.PageCount > 250 && h.Title.Contains("In Action") select h;
        }
        //Any All
        public bool librosconEstatus()
        {
            return ColeccionLibros.All(m => m.Status != string.Empty);
        }

        public bool Publicaciones2005()
        {
            return ColeccionLibros.Any(r => r.PublishedDate.Year == 2005);
        }

        public IEnumerable<Books> TituloPython()
        {
            return ColeccionLibros.Where(t => t.Categories.Contains("Python"));
        }

        //OrderBy
        public IEnumerable<Books> JavaLibrosAsc()
        {
            return ColeccionLibros.Where(k => k.Categories.Contains("Java")).OrderBy(k => k.Title);
        }

        public IEnumerable<Books> Libros450OrdenadosDesc()
        {
            return ColeccionLibros.Where(n => n.PageCount > 450).OrderByDescending(k => k.PageCount);
        }

        //Take-Skip
        public IEnumerable<Books> PrimerosLibrosporFechaparaJava()
        {
            return ColeccionLibros.Where(g => g.Categories.Contains("Java")).OrderByDescending(g => g.PublishedDate).
                Take(3);
        }

        public IEnumerable<Books> Seleciondelibrosespc()
        {
            return ColeccionLibros.Where(f => f.PageCount > 400)
                .Take(4)
                .Skip(2);
        }

        //Seleción de Datos Dinámicos
        public IEnumerable<Books> Librodelacoleecionseleccion()
        {
            return ColeccionLibros.Take(3)
                .Select(y => new Books() { Title = y.Title, PageCount = y.PageCount });
        }

        // Agregado de los videos 17 al 26 
        public int Librosentre200_500pag()
        {
            //return ColeccionLibros.Count(v => v.PageCount > 200 && v.PageCount < 500); //Modificación aplicada con el filtro Count que seria similar a lo aplicado en el video con LongCount

            return (int)ColeccionLibros.LongCount(v => v.PageCount > 200 && v.PageCount < 500);
            //Aplico la función de Long Count en la misma linea para hacer la diferencia, aunque el resutlado de la misma va a ser el mismo que la función anterior, pero es mas por su forma de alojar los datos

            //A como es un long se hace cast explicito para que la función pueda usarse con el int
        }

        public DateTime FechaMenor()
        {
            return ColeccionLibros.Min(d => d.PublishedDate);
        }

        public int Libromasgrande()
        {
            return ColeccionLibros.Max(e => e.PageCount);
        }

        public Books Libroconpocaspaginas()
        {
            return ColeccionLibros.Where(y => y.PageCount > 0).MinBy(y => y.PageCount);
        }

        public Books Libromasreciente()
        {
            return ColeccionLibros.MaxBy(u => u.PublishedDate);
        }

        public int Sumalibros()
        {
            return ColeccionLibros.Where(r => r.PageCount >= 0 && r.PageCount < 500).Sum(r => r.PageCount);
        }

        public string Libros2015publi()
        {
            return ColeccionLibros
                .Where(t => t.PublishedDate.Year > 2015).
                Aggregate("", (TituloLibros, next) =>
                {
                    if (TituloLibros != string.Empty)
                        TituloLibros += "  -  " + next.Title;
                    else
                        TituloLibros += next.Title;
                    return TituloLibros;
                });
        }

        public double PromCaracLib()
        {
            return ColeccionLibros.Average(i=> i.Title.Length);
        }

        public IEnumerable<IGrouping<int,Books>> Librosdp200Agrupados()
        {
            return ColeccionLibros.Where(g => g.PublishedDate.Year >= 2000).GroupBy(g => g.PublishedDate.Year);
        }

        public ILookup<char, Books> LibrosporLetra()
        {
            return ColeccionLibros.ToLookup(x => x.Title[0], x => x);
        }

        public IEnumerable<Books> JoinLibros()
        {
            var Librosdp2005 = ColeccionLibros.Where(q => q.PublishedDate.Year >= 2005);

            var Libros500pag = ColeccionLibros.Where(q => q.PageCount > 500);

            return Librosdp2005.Join(Libros500pag, q => q.Title, l => l.Title, (q, l) => l);

        }
    }
}
