namespace TP05.Models
{
    public static class Escape
{
    private static string[] IncognitasSala { get; set; } = new string[] { "COMPLOT", "G99H72", "GDIPBEB", "8" };
    public static int EstadoJuego { get; set; } = 1;
    private static int Apoyo { get; set; } = 0;
    private static DateTime InicioJuego { get; set; }
    private static bool JuegoIniciado { get; set; } = false;

    public static string[] Pistas { get; private set; } = new string[]
    {
        "Atención por favor, eso está prohibido.", 
        "La primera letra es la ‘C’", 
        "Prestar atención en la puntuación.", 
        "- = ,", 
        "“Todo tiene un comienzo no un final”", 
        "El orden es fijo.", 
        "Abrí bien los ojos", 
        "“Nunca dejes de sumar”"
    };

    public static int GetEstadoJuego()
    {
        return EstadoJuego;
    }

    public static int GetApoyo()
    {
        return Apoyo;
    }

    public static int GetTiempoTotal()
    {
        TimeSpan tiempoJugado = DateTime.Now - InicioJuego;
        return (int)tiempoJugado.TotalSeconds;
    }

    public static void IniciarJuego()
    {
        EstadoJuego = 1;
        Apoyo = 0;
        InicioJuego = DateTime.Now;
        JuegoIniciado = true;
    }

    public static bool ResolverSala(int sala, string incognita)
    {
        if (sala == EstadoJuego && incognita == IncognitasSala[sala - 1])
        {
            TimeSpan tiempo = DateTime.Now - InicioJuego;
            EstadoJuego++;
            ActualizarApoyo(tiempo);
            return true;
        }
        return false;
    }

    private static void ActualizarApoyo(TimeSpan tiempo)
    {
        if (tiempo.TotalSeconds <= 120)
        {
            Apoyo += 50;
        }
        else if (tiempo.TotalSeconds <= 210)
        {
            Apoyo += 35;
        }
        else if (tiempo.TotalSeconds <= 330)
        {
            Apoyo += 15;
        }
        else
        {
            Apoyo = 0;
            EstadoJuego = 1;
            JuegoIniciado = false;
        }
    }

    public static void UsarPista()
    {
        Apoyo -= 5;
    }

    public static string GetDescripcion(int sala)
    {
        switch (sala)
        {
            case 1:
                return "Entras último a la casa y no conoces a nadie, al principio te fulminan y quedas en placa, pero te llaman al confe para demostrar porque tenes que quedarte, y salis primero de placa. Hay 5 jugadores.";
            case 2:
                return "A la siguiente semana, jugas la prueba del líder para ganar la inmunidad. Elige un jugador para salvar. Hay 4 jugadores.";
            case 3:
                return "Suena el teléfono y atendes, tienes la oportunidad de cenar con un familiar y que te de información sobre a quién sacar si completas un desafío.";
            case 4:
                return "Gracias a esto pudiste salir último de placa y llegar a la final. Hay 3 jugadores. Tienes que conseguir la mayor cantidad de votos posibles. El jugador con mayor índice de apoyo va a ganar.";
            default:
                return "Habitación desconocida";
        }
    }
}
}