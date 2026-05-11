public class Pelicula{
    private string titulo;
    private string director;
    private int anyo;
    private bool disponible;

    public Pelicula(string titulo, string director, int anyo, bool disponible)
    {
        this.titulo = titulo;
        this.director = director;
        this.anyo = anyo;
        this.disponible = disponible;
    }

    public string getTitulo()
    {
        return titulo;
    }

    public string getDirector()
    {
        return director;
    }

    public int getAnyo()
    {
        return anyo;
    }

    public bool isDisponible()
    {
        return disponible;
    }

    public override string ToString()
    {
        return $"{titulo} - {director} ({anyo})";
    }
}
public class main
{
    public static void Main(string[] args)
    {
        Console.WriteLine(DateTime.Now.ToShortDateString());

        List<Pelicula> peliculas = new List<Pelicula>();
        peliculas.Add(new Pelicula("I swear", "Un escocés", 2026, false));
        peliculas.Add(new Pelicula("Cars", "Un inglés", 2003, true));
        peliculas.Add(new Pelicula("Shrek", "Un galés", 2000, true));

        foreach (Pelicula p in peliculas)
        {
            Console.WriteLine(p.ToString());
        }
        foreach (Pelicula p in peliculas)
        {
            if (p.ToString().Contains("Nolan"))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }

    public static void GuardarPeliculas(List<Pelicula> lista, string ruta)
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            foreach (Pelicula p in lista)
            {
                writer.WriteLine($"{p.getTitulo()};{p.getDirector()};{p.getAnyo()};{p.isDisponible()}");
            }
        }
    }
}