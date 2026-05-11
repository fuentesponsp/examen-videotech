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
