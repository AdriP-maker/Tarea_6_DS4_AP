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
                this.ColeccionLibros = System.Text.Json.JsonSerializer.Deserialize<List<Books>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            }
            
        }
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
            return ColeccionLibros.Where(n=> n.PageCount >450).OrderByDescending(k => k.PageCount);
        }

        //Take-Skip
        public IEnumerable<Books> PrimerosLibrosporFechaparaJava()
        {
            return ColeccionLibros.Where(g => g.Categories.Contains("Java")).OrderByDescending(g => g.PublishedDate).
                Take(3);
        }

        public IEnumerable<Books> Seleciondelibrosespc()
        {
            return ColeccionLibros.Where(f=> f.PageCount >400)
                .Take(4)
                .Skip(2);
        }

        //Seleción de Datos Dinámicos
        public IEnumerable<Books> Librodelacoleecionseleccion()
        {
            return ColeccionLibros.Take(3)
                .Select(y => new Books() { Title = y.Title, PageCount = y.PageCount });
        }
    }
}
