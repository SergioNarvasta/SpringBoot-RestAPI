using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace WebAplicacion.Models.ViewModels
{
    public class Correo
    {
        public string EnviarCorreo3()
        {
            // Montamos la estructura básica del mensaje...
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("helpdesksac2021@gmail.com");
            mail.To.Add("@helpdesk.com.pe");
            mail.Subject = "Graficos Estadisticos";

            // Creamos la vista para clientes que
            // sólo pueden acceder a texto plano...

            string text = "Hola, ayer estuve disfrutando de " +
                          "un paisaje estupendo.";

            AlternateView plainView =
                AlternateView.CreateAlternateViewFromString(text,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Plain);

            // Ahora creamos la vista para clientes que 
            // pueden mostrar contenido HTML...
            StringBuilder html = new StringBuilder();
            html.Append("<html><head>");
            html.Append("<style>table {width:100%;}table, th, td {border: 1px solid black; border-collapse: collapse; font: 11px arial;} ");
            html.Append("table th { background-color: #154da0; color: white;height:28px; } .ctnd {border: 2px solid #c1b8b8;border-left: 6px solid #154da0;background-color: white; padding-left: 6px;padding-right: 6px;font-size: 16px;margin-top: 10px;}.imag{width:100%;margin-top: 10px;}.titcont{text-align: center;}</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h2><center><u style='color: darkblue;'>GRAFICOS ESTADISTICOS - HDSOFT</u>		</center></h1>");
            html.Append("<div class='ctnd'>");
            html.Append("<p><b style='color: darkblue;'>Estimado Sr(a): </b> Pepito</p>");
            html.Append("<p style='font-style: italic;'>Mediante este correo le enviamos las graficas estadisticas.</p>");
            html.Append("<p style='color: red;'><b>NOTA:</b> Deberán generar una nueva.</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd' >");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico de Linea - </b>Productos<br>");
            html.Append("<img src='cid:GraficoLinea' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico de Columna - </b>Productos<br>");
            html.Append("<img src='cid:GraficoColumna' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico Circular - </b>Productos<br>");
            html.Append("<img src='cid:GraficoCircular' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico Histograma - </b>Productos<br>");
            html.Append("<img src='cid:Histograma' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico de Barra - </b>Productos<br>");
            html.Append("<img src='cid:GraficoBarra' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico de Dispersion - </b>Productos<br>");
            html.Append("<img src='cid:GraficoDispersion' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("</body>");
            html.Append("</html>");

            //html.Append("<h2>Grafico de barra:</h2><img alt='' src='cid:imagen' />");

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) está
            // referenciado desde el código HTML como origen
            // de la imagen (resaltado en amarillo)...

            LinkedResource GraficoLinea = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\GraficoLinea.png", MediaTypeNames.Image.Jpeg);
            GraficoLinea.ContentId = "GraficoLinea";
            htmlView.LinkedResources.Add(GraficoLinea);

            LinkedResource GraficoColumna = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\GraficoColumna.png", MediaTypeNames.Image.Jpeg);
            GraficoColumna.ContentId = "GraficoColumna";
            htmlView.LinkedResources.Add(GraficoColumna);

            LinkedResource GraficoCircular = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\GraficoCircular.png", MediaTypeNames.Image.Jpeg);
            GraficoCircular.ContentId = "GraficoCircular";
            htmlView.LinkedResources.Add(GraficoCircular);

            LinkedResource Histograma = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\Histograma.png", MediaTypeNames.Image.Jpeg);
            Histograma.ContentId = "Histograma";
            htmlView.LinkedResources.Add(Histograma);

            LinkedResource GraficoBarra = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\GraficoBarra.png", MediaTypeNames.Image.Jpeg);
            GraficoBarra.ContentId = "GraficoBarra";
            htmlView.LinkedResources.Add(GraficoBarra);

            LinkedResource GraficoDispersion = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderGraficos\GraficoDispersion.png", MediaTypeNames.Image.Jpeg);
            GraficoDispersion.ContentId = "GraficoDispersion";
            htmlView.LinkedResources.Add(GraficoDispersion);

            // Por último, vinculamos ambas vistas al mensaje...

            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);

            // Y lo enviamos a través del servidor SMTP...
            string rpta = "";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                rpta = "OK";
            }
            catch (Exception ex)
            {
                rpta = "Error";
                throw;

            }
            return rpta;

        }
        public string EnviarCorreoTrauma()
        {
            // Montamos la estructura básica del mensaje...
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("helpdesksac2021@gmail.com");
            mail.To.Add("abram.usca@helpdesk.com.pe");
            mail.Subject = "Graficos Estadisticos";

            // Creamos la vista para clientes que
            // sólo pueden acceder a texto plano...
            string text = "Hola, ayer estuve disfrutando de " +
                          "un paisaje estupendo.";
            AlternateView plainView =
                AlternateView.CreateAlternateViewFromString(text,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Plain);

            // Ahora creamos la vista para clientes que 
            // pueden mostrar contenido HTML...
            StringBuilder html = new StringBuilder();
            html.Append("<html><head>");
            html.Append("<style>table {width:100%;}table, th, td {border: 1px solid black; border-collapse: collapse; font: 11px arial;} ");
            html.Append("table th { background-color: #154da0; color: white;height:28px; } .ctnd {border: 2px solid #c1b8b8;border-left: 6px solid #154da0;background-color: white; padding-left: 6px;padding-right: 6px;font-size: 16px;margin-top: 10px;}.imag{width:100%;margin-top: 10px;}.titcont{text-align: center;}</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h2><center><u style='color: darkblue;'>GRAFICOS ESTADISTICOS -  VENTAS - TRAUMA</u>		</center></h1>");
            //html.Append("<div class='ctnd'>");
            //html.Append("<p><b style='color: darkblue;'>Estimado Sr(a): </b> Pepito</p>");
            //html.Append("<p style='font-style: italic;'>Reporte de ventas - graficas estadisticas.</p>");
            //html.Append("<p style='color: red;'><b>NOTA:</b> </p>");
            //html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico de Columna - </b>Ventas Por Mes<br>");
            html.Append("<img src='cid:GraficoColumna' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Grafico Circular - </b>Ventas Por Vendedores<br>");
            html.Append("<img src='cid:GraficoCircular' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("</body>");
            html.Append("</html>");

            //html.Append("<h2>Grafico de barra:</h2><img alt='' src='cid:imagen' />");

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) está
            // referenciado desde el código HTML como origen
            // de la imagen (resaltado en amarillo)...

            LinkedResource GraficoColumna = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderTrauma\GraficoColumna.png", MediaTypeNames.Image.Jpeg);
            GraficoColumna.ContentId = "GraficoColumna";
            htmlView.LinkedResources.Add(GraficoColumna);

            LinkedResource GraficoCircular = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderTrauma\GraficoCircular.png", MediaTypeNames.Image.Jpeg);
            GraficoCircular.ContentId = "GraficoCircular";
            htmlView.LinkedResources.Add(GraficoCircular);


            // Por último, vinculamos ambas vistas al mensaje...

            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);

            // Y lo enviamos a través del servidor SMTP...
            string rpta = "";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                rpta = "OK";
            }
            catch (Exception ex)
            {
                rpta = "Error";
                throw;

            }
            return rpta;

        }
        public string EnviarCorreoMineraCopper(string ruta)
        {
            string nombre = Path.Combine(ruta, "grafico" + ".png");
            // Montamos la estructura básica del mensaje...
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("helpdesksac2021@gmail.com");
            //mail.To.Add(new MailAddress("abram.usca@helpdesk.com.pe"));

            mail.To.Add(new MailAddress("acontabilidad@mineracoppercave.pe"));
            mail.To.Add(new MailAddress("arcejohnj @hotmail.com"));
            mail.To.Add(new MailAddress("arcejag@hotmail.com"));
            mail.To.Add(new MailAddress("tesoreia@mineracoppercave.pe"));
            mail.To.Add(new MailAddress("asistentegerencia.coppercave@gmail.com"));

            mail.CC.Add(new MailAddress("gerardo.cherre@helpdesk.com.pe")); 
            mail.CC.Add(new MailAddress("erika.mallque@mineracoppercave.pe"));
            mail.Bcc.Add(new MailAddress("abram.usca@helpdesk.com.pe"));

            mail.Subject = "Reporte - Graficos Estadisticos Minera Copper Cave SAC";

            // Ahora creamos la vista para clientes que 
            // pueden mostrar contenido HTML...
            StringBuilder html = new StringBuilder();
            html.Append("<html><head>");
            html.Append("<style>table {width:100%;}table, th, td {border: 1px solid black; border-collapse: collapse; font: 11px arial;} ");
            html.Append("table th { background-color: #154da0; color: white;height:28px; } .ctnd {border: 2px solid #c1b8b8;border-left: 6px solid #154da0;background-color: white; padding-left: 6px;padding-right: 6px;font-size: 16px;margin-top: 10px;}.imag{width:100%;margin-top: 10px;}.titcont{text-align: center;}</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h2><center><u style='color: darkblue;'>GRAFICOS ESTADISTICOS - MINERA COPPER CAVE SAC- " + DateTime.Now.ToShortDateString() + "</u></center></h1>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>YEAR TO DATE</b><br>");
            html.Append("<img src='cid:GraficoYearToDate' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>MONTH TO DATE</b><br>");
            html.Append("<img src='cid:GraficoMonthToDate' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>TOTAL GASTOS </b><br>");
            html.Append("<img src='cid:GraficoGastos' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>020 Costos </b><br>");
            html.Append("<img src='cid:GraficoCostos' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Detalle Costos - 601 Mercaderias </b><br><br>");
            html.Append("<img src='cid:GraficoCostos601' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>Detalle Costos - 632 Asesoria y Consultoria</b><br><br>");
            html.Append("<img src='cid:GraficoCostos632' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>10 Bancos</b><br>");
            html.Append("<img src='cid:GraficoBancos' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("</body>");
            html.Append("</html>");

            //html.Append("<h2>Grafico de barra:</h2><img alt='' src='cid:imagen' />");

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) 

            //LinkedResource GraficoYearToDate = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoYearToDate.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoYearToDate = new LinkedResource(Path.Combine(ruta, "GraficoYearToDate.png"), MediaTypeNames.Image.Jpeg);
            GraficoYearToDate.ContentId = "GraficoYearToDate";
            htmlView.LinkedResources.Add(GraficoYearToDate);

            //LinkedResource GraficoMonthToDate = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoMonthToDate.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoMonthToDate = new LinkedResource(Path.Combine(ruta, "GraficoMonthToDate.png"), MediaTypeNames.Image.Jpeg);

            GraficoMonthToDate.ContentId = "GraficoMonthToDate";
            htmlView.LinkedResources.Add(GraficoMonthToDate);

            //LinkedResource GraficoGastos = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoGastos.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoGastos = new LinkedResource(Path.Combine(ruta, "GraficoGastos.png"), MediaTypeNames.Image.Jpeg);
            GraficoGastos.ContentId = "GraficoGastos";
            htmlView.LinkedResources.Add(GraficoGastos);

            //LinkedResource GraficoCostos = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoCostos.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoCostos = new LinkedResource(Path.Combine(ruta, "GraficoCostos.png"), MediaTypeNames.Image.Jpeg);
            GraficoCostos.ContentId = "GraficoCostos";
            htmlView.LinkedResources.Add(GraficoCostos);

            //LinkedResource GraficoCostos601 = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoCostos601.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoCostos601 = new LinkedResource(Path.Combine(ruta, "GraficoCostos601.png"), MediaTypeNames.Image.Jpeg);
            GraficoCostos601.ContentId = "GraficoCostos601";
            htmlView.LinkedResources.Add(GraficoCostos601);

            //LinkedResource GraficoCostos632 = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoCostos632.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoCostos632 = new LinkedResource(Path.Combine(ruta, "GraficoCostos632.png"), MediaTypeNames.Image.Jpeg);
            GraficoCostos632.ContentId = "GraficoCostos632";
            htmlView.LinkedResources.Add(GraficoCostos632);

            //LinkedResource GraficoBancos = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoBancos.png", MediaTypeNames.Image.Jpeg);
            //LinkedResource GraficoBancos = new LinkedResource(Path.Combine(WebConfigurationManager.AppSettings["RutaGrafico"].ToString(), "GraficoBancos.png"), MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoBancos = new LinkedResource(Path.Combine(ruta, "GraficoBancos.png"), MediaTypeNames.Image.Jpeg);
            GraficoBancos.ContentId = "GraficoBancos";
            htmlView.LinkedResources.Add(GraficoBancos);
            var sd = Path.GetFullPath("GraficoBancos.png");

            // Por último, vinculamos ambas vistas al mensaje...
            mail.AlternateViews.Add(htmlView);

            // Y lo enviamos a través del servidor SMTP...
            string rpta = "";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                rpta = "OK: El correo ha sido enviado correctamente.";
            }
            catch (Exception ex)
            {
                rpta = "Error" + ex.Message;
                throw;

            }
            return rpta;

        }
        public string EnviarCorreoCorpCopper(string ruta)
        {
            string nombre = Path.Combine(ruta, "grafico" + ".png");
            // Montamos la estructura básica del mensaje...
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("helpdesksac2021@gmail.com");
            //mail.To.Add(new MailAddress("uzuajcvd@gmail.com"));
            //mail.To.Add(new MailAddress("abram.usca@helpdesk.com.pe"));

            mail.To.Add(new MailAddress("acontabilidad@mineracoppercave.pe"));
            mail.To.Add(new MailAddress("arcejohnj @hotmail.com"));
            mail.To.Add(new MailAddress("arcejag@hotmail.com"));
            mail.To.Add(new MailAddress("tesoreia@mineracoppercave.pe"));
            mail.To.Add(new MailAddress("asistentegerencia.coppercave@gmail.com"));

            mail.CC.Add(new MailAddress("gerardo.cherre@helpdesk.com.pe"));
            mail.CC.Add(new MailAddress("erika.mallque@mineracoppercave.pe"));
            mail.Bcc.Add(new MailAddress("abram.usca@helpdesk.com.pe"));

            mail.Subject = "Reporte - Graficos Estadisticos - CC LAB Corporacion Copper Cave SAC";

            // Ahora creamos la vista para clientes que 
            // pueden mostrar contenido HTML...
            StringBuilder html = new StringBuilder();
            html.Append("<html><head>");
            html.Append("<style>table {width:100%;}table, th, td {border: 1px solid black; border-collapse: collapse; font: 11px arial;} ");
            html.Append("table th { background-color: #154da0; color: white;height:28px; } .ctnd {border: 2px solid #c1b8b8;border-left: 6px solid #154da0;background-color: white; padding-left: 6px;padding-right: 6px;font-size: 16px;margin-top: 10px;}.imag{width:100%;margin-top: 10px;}.titcont{text-align: center;}</style>");
            html.Append("</head>");
            html.Append("<body>");
            html.Append("<h2><center><u style='color: darkblue;'>GRAFICOS ESTADISTICOS - CC LAB. CORPORACION COPPER CAVE SAC - " + DateTime.Now.ToShortDateString() + "</u></center></h1>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>YEAR TO DATE</b><br>");
            html.Append("<img src='cid:GraficoYearToDate' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>MONTH TO DAY</b><br>");
            html.Append("<img src='cid:GraficoMonthToDate' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>TOTAL GASTOS </b><br>");
            html.Append("<img src='cid:GraficoGastos' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("<div class='ctnd'>");
            html.Append("<p class='titcont'><b style='color: darkblue;'>10 Bancos</b><br>");
            html.Append("<img src='cid:GraficoBancos' class='imag' />");
            html.Append("</p>");
            html.Append("</div>");
            html.Append("</body>");
            html.Append("</html>");

            //html.Append("<h2>Grafico de barra:</h2><img alt='' src='cid:imagen' />");

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) 

            //LinkedResource GraficoYearToDate = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoYearToDate.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoYearToDate = new LinkedResource(Path.Combine(ruta, "GraficoYearToDate.png"), MediaTypeNames.Image.Jpeg);
            GraficoYearToDate.ContentId = "GraficoYearToDate";
            htmlView.LinkedResources.Add(GraficoYearToDate);

            //LinkedResource GraficoMonthToDate = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoMonthToDate.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoMonthToDate = new LinkedResource(Path.Combine(ruta, "GraficoMonthToDate.png"), MediaTypeNames.Image.Jpeg);

            GraficoMonthToDate.ContentId = "GraficoMonthToDate";
            htmlView.LinkedResources.Add(GraficoMonthToDate);

            //LinkedResource GraficoGastos = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoGastos.png", MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoGastos = new LinkedResource(Path.Combine(ruta, "GraficoGastos.png"), MediaTypeNames.Image.Jpeg);
            GraficoGastos.ContentId = "GraficoGastos";
            htmlView.LinkedResources.Add(GraficoGastos);

            //LinkedResource GraficoBancos = new LinkedResource(@"G:\Documentos\WebAplicacion\WebAplicacion\FolderCopper\GraficoBancos.png", MediaTypeNames.Image.Jpeg);
            //LinkedResource GraficoBancos = new LinkedResource(Path.Combine(WebConfigurationManager.AppSettings["RutaGrafico"].ToString(), "GraficoBancos.png"), MediaTypeNames.Image.Jpeg);
            LinkedResource GraficoBancos = new LinkedResource(Path.Combine(ruta, "GraficoBancos.png"), MediaTypeNames.Image.Jpeg);
            GraficoBancos.ContentId = "GraficoBancos";
            htmlView.LinkedResources.Add(GraficoBancos);
            var sd = Path.GetFullPath("GraficoBancos.png");

            // Por último, vinculamos ambas vistas al mensaje...
            mail.AlternateViews.Add(htmlView);

            // Y lo enviamos a través del servidor SMTP...
            string rpta = "";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                rpta = "OK: El correo ha sido enviado correctamente.";
            }
            catch (Exception ex)
            {
                rpta = "Error" + ex.Message;
                throw;

            }
            return rpta;

        }
        public string EnviarCorreo2()
        {

            string resp;
            MailMessage mensaje = new MailMessage("@gmail.com", "@gmail.com");
            mensaje.Subject = "Prueba imágenes embedidas";

            // Crear la vista HTML del mail, notar lo que se pone en el tag "img"
            AlternateView html = AlternateView.CreateAlternateViewFromString(@"<h1>Buayacorp</h1>
        <img src=""cid:buayacorp_logo"" /><br /><p>Esto es una prueba de una imagen incrustada</p>", Encoding.UTF8, "text/html");

            // Crear la vista de texto plano, siempre es bueno para aquellos que no les gusta el HTML
            AlternateView texto = AlternateView.CreateAlternateViewFromString("BuayaCorp\n\nTexto plano", Encoding.UTF8, "text/html");

            // Adjuntar el recurso logo.jpg, con id "buayacorp_logo" a la vista HTML
            LinkedResource logo = new LinkedResource(@"C:\logo.jpg");
            logo.ContentId = "buayacorp_logo";
            html.LinkedResources.Add(logo);

            // Añadir las 2 vistas del correo
            mensaje.AlternateViews.Add(texto);
            mensaje.AlternateViews.Add(html);

            // Definir el servidor SMTP, GMail usa SSL para la autenticación
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;

            // Ingresar nuestra cuenta de gmail
            //smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            resp = "OK";
            try
            {
                smtp.Send(mensaje);
                resp = "OK: El correo ha sido enviado correctamente.";
            }
            catch (Exception)
            {

                throw;
                resp = "Error";
            }
            


            return resp;
        }
        public string   EnviarCorreo(string _correoDestino, string _asunto, string _mensaje)
        {
            MailMessage correo = new MailMessage();
            SmtpClient protocolo = new SmtpClient();
            string resp = "";
            correo.To.Add(_correoDestino);
            correo.From = new MailAddress("abram.usca@helpdesk.com.pe", "Sistema de Gestion de Tramite Documentario", System.Text.Encoding.UTF8);
            correo.Subject = _asunto;
            correo.SubjectEncoding = System.Text.Encoding.UTF8;
            correo.Body = _mensaje;
            correo.BodyEncoding = System.Text.Encoding.UTF8;
            correo.IsBodyHtml = true;

            //smtp-mail.outlook.com
            //smtp.gmail.com
            protocolo.Credentials = new NetworkCredential("helpdesksac2021@gmail.com", "Helpdesksac2021@");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;
            resp = "OK";
            try
            {
                protocolo.Send(correo);
            }
            catch (SmtpException error)
            {
                //string error = ex.Message;
                //estado = false;
                resp = error.Message.ToString();
            }
            correo.Dispose();

            return resp;

        }

    }
}