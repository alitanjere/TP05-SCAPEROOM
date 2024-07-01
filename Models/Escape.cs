namespace TP05.Models
{
    public static class Escape
    {
        private static string[] IncognitasSala { get; set; } = new string[] { "COMPLOT", "G99H72", "GDIPBEB", "8" };
        private static int EstadoJuego { get; set; } = 1;
        private static int Apoyo { get; set; } = 0;
        private static int TiempoTotal { get; set; } = 0;

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

        public static string GetPista(int pista)
        {
            switch (pista)
            {
                case 1:
                    return "Esta es la primera pista.";
                case 2:
                    return "Esta es la segunda pista.";
                default:
                    return string.Empty;
            }
        }
    }
}
