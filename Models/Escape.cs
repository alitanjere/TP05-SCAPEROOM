public static class Escape{
    private static string [] IncognitasSala {get; set;}
    private static int EsatdoJuego {get; set;} = 1;

    private static void InicializarJuego(){
        IncognitasSala[0] =  "COMPLOT" ;
        IncognitasSala[1] = "G99H72";
        IncognitasSala[2] = "GDIPBEB";
        IncognitasSala[3] = "8";
    }

    public static int GetEstadoJuego(){
        return EsatdoJuego;
    }

    public static bool ResolverSala(int Sala, string Incognita){
        bool PuedeResolver = false;
        if (Sala == EsatdoJuego){
            if (IncognitasSala == null){
                InicializarJuego();
            }
            else if(Incognita == IncognitasSala[Sala])
            {
                PuedeResolver = true;
                EsatdoJuego++;
            }
        }
        return PuedeResolver;
    }

}

