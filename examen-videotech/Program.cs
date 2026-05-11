using MySql.Data.MySqlClient;

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

public class GestorBD
{
    private MySqlConnection conexion;

    public GestorBD()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            UserID = "root",
            Password = "12345678",
            Database = "videotech"
        };

        conexion = new MySqlConnection(builder.ConnectionString);
    }

    public void Insertar(Pelicula p)
    {
        try
        {
            conexion.Open();

            string query = "INSERT INTO peliculas (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";
            MySqlCommand comando = new MySqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@titulo", p.getTitulo());
            comando.Parameters.AddWithValue("@director", p.getDirector());
            comando.Parameters.AddWithValue("@anyo", p.getAnyo());
            comando.Parameters.AddWithValue("@disponible", p.isDisponible());

            comando.ExecuteNonQuery();
        }
        finally
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }

    public List<Pelicula> ObtenerTodos()
    {
        List<Pelicula> peliculas = new List<Pelicula>();

        try
        {
            conexion.Open();

            string query = "SELECT * FROM peliculas";
            MySqlCommand comando = new MySqlCommand(query, conexion);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                string titulo = reader.GetString("titulo");
                string director = reader.GetString("director");
                int anyo = reader.GetInt32("anyo");
                bool disponible = reader.GetBoolean("disponible");

                Pelicula p = new Pelicula(titulo, director, anyo, disponible);
                peliculas.Add(p);
            }

            reader.Close();
        }
        finally
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        return peliculas;
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