using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplicacion.Models.ViewModels
{
    public class GraficosCopper
    {
        public string GraficoYearToDate { get; set; }
        public string GraficoMonthToDate { get; set; }
        public string GraficoGastos { get; set; }
        public string GraficoCostos { get; set; }
        public string GraficoCostos632 { get; set; }
        public string GraficoCostos601 { get; set; }
        public string GraficoBancos { get; set; }
    }

    public class GraficosInversionActivo
    {
        public string GraficoInventarios { get; set; }
        public string GraficoBancos { get; set; }
        public string GraficoPrestamos { get; set; }
        public string GraficoActivos { get; set; }
        public string GraficoAdelantos { get; set; }
    }
}