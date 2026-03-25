using System;

namespace LigaBetPlay.utils;

public class Equipos
{
    public string Nombre { get; set;}
    public int PJ { get; set;}
    public int PG { get; set;}
    public int PE { get; set;}
    public int PP { get; set;}
    public int GF { get; set;}
    public int GC { get; set;}
    public int TP { get; set;}

// Constructor
    public Equipos(string nombre)
        {
            Nombre = nombre;
            PJ = 0;
            PG = 0;
            PE = 0;
            PP = 0;
            GF = 0;
            GC = 0;
            TP = 0;
        }
    
// Metodo para registrar resultados
    public void RegistrarResultado(int golesAFavor, int golesEnContra)
    {
        PJ++;
        GF += golesAFavor;
        GC += golesEnContra;

        if (golesAFavor > golesEnContra)
        {
            PG++;
            TP += 3;
        }
        else if (golesAFavor == golesEnContra)
        {
            PE++;
            TP += 1;
        }
        else
        {
            PP++;
        }
    }

    public override string ToString()
        {
            return $"{Nombre,-22} | PJ:{PJ,2} | PG:{PG,2} | PE:{PE,2} | PP:{PP,2} | GF:{GF,3} | GC:{GC,3} | Pts:{TP,3}";
        }



}
