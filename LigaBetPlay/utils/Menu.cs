using System;

namespace LigaBetPlay.utils;

public class Menu
{
    private Torneo torneo = new Torneo();
 
        public void Iniciar()
        {
            MostrarBienvenida();
            bool salir = false;
 
            while (!salir)
            {
                MostrarMenuPrincipal();
                string? opcion = Console.ReadLine()?.Trim();
 
                switch (opcion)
                {
                    case "1": OpcionListarEquipos();         break;
                    case "2": OpcionRegistrarEquipos();      break;
                    case "3": OpcionSimularPartidos();       break;
                    case "4": OpcionVerTablaDePosiciones();  break;
                    case "5": OpcionConsultarEstadisticas(); break;
                    case "6": salir = OpcionSalir();         break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n   Opción inválida. Intenta de nuevo.");
                        Console.ResetColor();
                        break;
                }
 
                if (!salir)
                {
                    Console.WriteLine("\n  Presiona ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }


// menu principal
         private void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  ║-------------LIGA BETPLAY-------------║");
        }
 
        private void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   ────────────────────────────────────── ");
            Console.WriteLine("             MENÚ PRINCIPAL               ");
            Console.WriteLine("   ────────────────────────────────────── ");
            Console.WriteLine("     1. Listar equipos                    ");
            Console.WriteLine("     2. Registrar equipos                 ");
            Console.WriteLine("     3. Simular partidos                  ");
            Console.WriteLine("     4. Ver tabla de posiciones           ");
            Console.WriteLine("     5. Consultar estadísticas del torneo ");
            Console.WriteLine("     6. Salir del sistema                 ");
            Console.WriteLine("   ────────────────────────────────────── ");
            Console.Write("  Selecciona una opción: ");
        }

// listar equipos
         private void OpcionListarEquipos()
        {
            Console.Clear();
            Console.WriteLine("\n  ══ EQUIPOS REGISTRADOS ══\n");
            var equipos = torneo.ObtenerEquipos();
 
            if (equipos.Count == 0)
            {
                Console.WriteLine("  No hay equipos registrados aún.");
                return;
            }
 
            for (int i = 0; i < equipos.Count; i++)
                Console.WriteLine($"  {i + 1,2}. {equipos[i].Nombre}");
 
            Console.WriteLine($"\n  Total: {equipos.Count} equipo(s).");
        }

// registrar equipos
         private void OpcionRegistrarEquipos()
        {
            Console.Clear();
            Console.WriteLine("\n  -- REGISTRAR EQUIPO --\n");
            Console.Write("  Nombre del equipo: ");
            string? nombre = Console.ReadLine()?.Trim();
            torneo.RegistrarEquipo(nombre);
        }

// simular partidos
         private void OpcionSimularPartidos()
        {
            Console.Clear();
            Console.WriteLine("\n  -- SIMULAR PARTIDO --\n");
 
            if (!torneo.HayEquiposSuficientes())
            {
                Console.WriteLine("Se necesitan al menos 2 equipos registrados.");
                return;
            }
 
            Console.WriteLine("Equipos disponibles:");
            var equipos = torneo.ObtenerEquipos();
            for (int i = 0; i < equipos.Count; i++)
                Console.WriteLine($"  {i + 1,2}. {equipos[i].Nombre}");
 
            Console.WriteLine();
            Console.Write("  Equipo LOCAL     : ");
            string? local = Console.ReadLine()?.Trim();
            Console.Write("  Equipo VISITANTE : ");
            string? visitante = Console.ReadLine()?.Trim();
 
            Console.Write($"\n  Goles de {local}    : ");
            if (!int.TryParse(Console.ReadLine(), out int golesLocal) || golesLocal < 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }
 
            Console.Write($"  Goles de {visitante}: ");
            if (!int.TryParse(Console.ReadLine(), out int golesVisitante) || golesVisitante < 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }
 
            torneo.SimularPartido(local, visitante, golesLocal, golesVisitante);
        }

// ver tabla de posiciones
         private void OpcionVerTablaDePosiciones()
        {
            Console.Clear();
            torneo.MostrarTablaDePosiciones();
        }

// consultar estadisticas
        
        private void OpcionConsultarEstadisticas()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("  -------- CONSULTAR ESTADÍSTICAS DEL TORNEO -----");
                Console.WriteLine("  ─────────────────────────────────────────────── ");
                Console.WriteLine("    1.  Líder del torneo                          ");
                Console.WriteLine("    2.  Equipos con más goles a favor             ");
                Console.WriteLine("    3.  Equipos con menos goles en contra         ");
                Console.WriteLine("    4.  Equipos con más partidos ganados          ");
                Console.WriteLine("    5.  Equipos con más empates                   ");
                Console.WriteLine("    6.  Equipos con más derrotas                  ");
                Console.WriteLine("    7.  Equipos invictos                          ");
                Console.WriteLine("    8.  Equipos sin victorias                     ");
                Console.WriteLine("    9.  Top 3 de la tabla                         ");
                Console.WriteLine("   10.  Equipos con diferencia de gol positiva    ");
                Console.WriteLine("   11.  Equipos con más de X puntos               ");
                Console.WriteLine("   12.  Buscar equipo por nombre                  ");
                Console.WriteLine("   13.  Promedio de goles a favor                 ");
                Console.WriteLine("   14.  Promedio de goles en contra               ");
                Console.WriteLine("   15.  Total de goles marcados                   ");
                Console.WriteLine("   16.  Total de puntos sumados                   ");
                Console.WriteLine("   17.  Tabla con proyección personalizada        ");
                Console.WriteLine("   18.  Equipos ordenados alfabéticamente         ");
                Console.WriteLine("   19.  Resumen general del torneo                ");
                Console.WriteLine("   20.  Equipos bajo el promedio de puntos        ");
                Console.WriteLine("   21.  Estadísticas destacadas                   ");
                Console.WriteLine("   22.  Ranking simple (agrupado por puntos)      ");
                Console.WriteLine("    0.  Volver al menú principal                  ");
                Console.WriteLine("  ─────────────────────────────────────────────── ");
                Console.Write("  Selecciona una opción: ");
 
                string? op = Console.ReadLine()?.Trim();
 
                switch (op)
                {
                    case "1":  torneo.ObtenerLider();                      break;
                    case "2":  torneo.ObtenerEquiposMasGolesAFavor();      break;
                    case "3":  torneo.ObtenerEquiposMenosGolesEnContra();  break;
                    case "4":  torneo.ObtenerEquiposMasPartidosGanados();  break;
                    case "5":  torneo.ObtenerEquiposMasEmpates();          break;
                    case "6":  torneo.ObtenerEquiposMasDerrotas();         break;
                    case "7":  torneo.ObtenerEquiposInvictos();            break;
                    case "8":  torneo.ObtenerEquiposSinVictorias();        break;
                    case "9":  torneo.ObtenerTop3();                       break;
                    case "10": torneo.ObtenerEquiposDiferenciaGolPositiva(); break;
                    case "11":
                        Console.Write("  ¿Más de cuántos puntos? ");
                        if (int.TryParse(Console.ReadLine(), out int pts))
                            torneo.ObtenerEquiposConMasDePuntos(pts);
                        else
                            Console.WriteLine("  Valor inválido.");
                        break;
                    case "12":
                        Console.Write("  Nombre del equipo: ");
                        string? nombre = Console.ReadLine()?.Trim();
                        torneo.BuscarEquipoPorNombre(nombre);
                        break;
                    case "13": torneo.ObtenerPromedioGolesAFavor();              break;
                    case "14": torneo.ObtenerPromedioGolesEnContra();            break;
                    case "15": torneo.ObtenerTotalGoles();                       break;
                    case "16": torneo.ObtenerTotalPuntos();                      break;
                    case "17": torneo.MostrarTablaProyeccionPersonalizada();     break;
                    case "18": torneo.ObtenerEquiposOrdenadosAlfabeticamente();  break;
                    case "19": torneo.MostrarResumenGeneral();                   break;
                    case "20": torneo.ObtenerEquiposBajoPromedioPuntos();        break;
                    case "21": torneo.MostrarEstadisticasDestacadas();           break;
                    case "22": torneo.MostrarRankingSimple();                    break;
                    case "0":  volver = true;                                    break;
                    default:

                        Console.WriteLine("\n   Opción inválida.");
                        break;
                }
 
                if (!volver)
                {
                    Console.WriteLine("\n  Presiona ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

         private bool OpcionSalir()
        {
            Console.Write("\n  ¿Seguro que deseas salir? (s/n): ");
            string? resp = Console.ReadLine()?.Trim().ToLower();
            if (resp == "s")
            {
                Console.WriteLine("\n  ¡Gracias por usar el simulador de la Liga BetPlay! Hasta luego.");
                return true;
            }
            return false;
        }
 
}
