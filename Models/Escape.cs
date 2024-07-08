namespace TP05.Models
{
    public static class Escape
    {
        private static string[] IncognitasSala { get; set; } = new string[] { "COMPLOT", "G99H72", "GDIPBEB", "8" };
        public static int EstadoJuego { get; set; } = 1;
        private static int Apoyo { get; set; } = 0;
        private static int TiempoTotal { get; set; } = 0;

        public static string[] Pistas { get; private set; } = new string[] { "Atención por favor, eso está prohibido.", "La primera letra es la ‘C’", "Prestar atención en la puntuación.", "- = ,", "“Todo tiene un comienzo no un final”", "El orden es fijo.", "Abrí bien los ojos", "“Nunca dejes de sumar”" };

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
            return TiempoTotal;
        }

        public static bool ResolverSala(int sala, string incognita)
        {
            if (sala == EstadoJuego && incognita == IncognitasSala[sala - 1])
            {
                EstadoJuego++;
                return true;
            }
            return false;
        }

    }
}
