using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAplicacion.Models.ViewModels;

namespace WebAplicacion.Controllers
{
    public class TraumaController : Controller
    {

        // GET: Trauma
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GraficoEnColumna()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            //string sConnString = "Data Source=(local);Initial Catalog=WebApp;Integrated Security=True";
            string sConnString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            //string query = "SELECT ano_usucre as ShipCity,ano_codano as TotalOrders FROM ANOS_ANO";
            String query = " Select " +
                " Rtrim(ISNULL(m.vde_codvde, 'ND')) + '-' + Rtrim(ISNULL(m.vde_deslar, 'NO IDENTIFICADO')) as Vendedor," +
                " Sum(case when j.mes_codmes=01 and DAY(J.tcc_fecemi)<12 then Isnull(k.tdo_siglib,0)*(Case When j.mon_codepk=1 then 1 Else j.tcc_tcanac End)*(a.tdd_impbru-a.tdd_impdes) else 0 end) as Total" +
                " From TRAN_DOCCOB_TDD A				Left Join PRODUCTOS_PRD B On a.prd_codepk=b.prd_codepk and a.cia_codcia=b.cia_codcia" +
                " Left Join LINEA_PRODUCTO_LIP C On b.cia_codcia=c.cia_codcia and b.lip_codepk=c.lip_codepk " +
                " Left Join TIPOINVENTARIO_TIN D On b.cia_codcia=d.cia_codcia and b.tin_codtin=d.tin_codtin" +
                " Left Join FAMILIAPROD_FPR E On b.cia_codcia=e.cia_codcia and b.fpr_codepk=e.fpr_codepk" +
                " Left Join SUBFAMILIAPROD_SFP F On b.cia_codcia=f.cia_codcia and b.fpr_codepk=f.fpr_codepk and b.sfp_codepk=f.sfp_codepk" +
                " Left Join UMEDIDA_UME G On b.cia_codcia=g.cia_codcia and b.ume_codepk=g.ume_codepk" +
                " Left Join UMEDIDA_UME H On b.cia_codcia=h.cia_codcia and b.ume_codref=h.ume_codepk" +
                " Left Join TRAN_DOCCOB_TDC I On a.cia_codcia=i.cia_codcia and a.suc_codsuc=i.suc_codsuc and a.tcc_codepk=i.tcc_codepk" +
                " Left Join TRAN_CTACTE_TCC J On a.cia_codcia=j.cia_codcia and a.suc_codsuc=j.suc_codsuc and a.tcc_codepk=j.tcc_codepk" +
                " Left Join TIPO_DOCU_TDO K On j.tdo_codtdo=k.tdo_codtdo" +
                " Left Join CUEN_CORR_CCR L On j.cia_codcia=l.cia_codcia and j.ccr_codepk=l.ccr_codepk" +
                " Left Join VENDEDOR_VDE M on i.vde_codepk=m.vde_codvpk and i.cia_codcia=m.cia_codcia" +
                " Left Join VENDEDOR_VDE N on i.vde_codcaj=n.vde_codvpk and i.cia_codcia=n.cia_codcia" +
                " Left Join COND_PAGO_CPG O on j.cpg_codepk=o.cpg_codepk and j.cia_codcia=o.cia_codcia" +
                " Left Join UMEDIDA_UME P On a.cia_codcia=p.cia_codcia and a.ume_codven=p.ume_codepk" +
                " Left JOIN CUEN_CORR_CCR Q On (Q.cia_codcia=I.cia_codcia and Q.ccr_codepk=I.ccr_codav1)" +
                " Left Join Cuen_Cont_CCT R On b.cia_codcia=r.cia_codcia and b.cct_cueinv=r.cct_codcct " +
                " Left Join Cuen_Cont_CCT S On b.cia_codcia=s.cia_codcia and b.cct_cuevta=S.cct_codcct " +
                " Left Join Clie_Cli T1 On L.cia_codcia=T1.cia_codcia And L.ccr_codepk=T1.ccr_codepk" +
                " Left Join Tipo_Cliente_TCL T2 On T1.cia_codcia=T2.cia_codcia and T1.tcl_codtpk=T2.tcl_codtpk" +
                " Left Join Cotizaciones_Cot C1 ON I.cia_codcia=C1.cia_codcia and I.suc_codsuc=C1.suc_codsuc and I.cot_numepk=C1.cot_numepk " +
                " Left Join Almacenes_Alm C2 ON c1.cia_codcia=c2.cia_codcia and c1.alm_codepk=c2.alm_codepk" +
                " Left Join Grupo_Producto_Gpr C3 on c1.cia_codcia=c3.cia_codcia and c1.gpr_codepk=c3.gpr_codepk" +
                " Left Join Grupo_Producto_Plantilla_Comercial_Gpc C4 On c1.cia_codcia=c4.cia_codcia and c1.gpr_codepk=c4.gpr_codepk and c1.gpc_codgpc=c4.gpc_codgpc" +
                " Left Join Marca_Productos_Map U on b.cia_codcia=u.cia_codcia and b.map_codepk=u.map_codepk" +
                " Left Join Punto_Venta_Pvt T on i.cia_codcia=T.cia_codcia and i.pvt_codepk=t.pvt_codepk" +
                " Where a.cia_codcia=1 and j.ano_codano=2021 and j.mes_codmes=1 and DAY(J.tcc_fecemi)<=12 and Left(isnull(b.cct_cuevta,''),2)<>'12'" +
                " group by" +
                " m.vde_codvde, m.vde_deslar";

            List<object> chartData = new List<object>();

            using (SqlConnection con = new SqlConnection(sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                                sdr["Vendedor"], sdr["Total"]
                            });
                        }
                    }

                    con.Close();
                }
            }
            // return Json(new Response {Action=Accion, Message = Mensaje }, JsonRequestBehavior.AllowGet );
            return Json(chartData);
        }

        [HttpPost]

        public JsonResult ReportesPorMes()
        {
            string sConnString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            String query = "Select" +
                           "     j.mes_codmes as Mes," +
                           "     Sum(Isnull(k.tdo_siglib,0)*(Case When j.mon_codepk=1 then 1 Else j.tcc_tcanac End)*(a.tdd_impbru-a.tdd_impdes)) Total" +
                           " From TRAN_DOCCOB_TDD A" +
                           "     Left Join PRODUCTOS_PRD B On a.prd_codepk=b.prd_codepk and a.cia_codcia=b.cia_codcia" +
                           "     Left Join LINEA_PRODUCTO_LIP C On b.cia_codcia=c.cia_codcia and b.lip_codepk=c.lip_codepk " +
                           "     Left Join TIPOINVENTARIO_TIN D On b.cia_codcia=d.cia_codcia and b.tin_codtin=d.tin_codtin" +
                           "     Left Join FAMILIAPROD_FPR E On b.cia_codcia=e.cia_codcia and b.fpr_codepk=e.fpr_codepk" +
                           "     Left Join SUBFAMILIAPROD_SFP F On b.cia_codcia=f.cia_codcia and b.fpr_codepk=f.fpr_codepk and b.sfp_codepk=f.sfp_codepk" +
                           "     Left Join UMEDIDA_UME G On b.cia_codcia=g.cia_codcia and b.ume_codepk=g.ume_codepk" +
                           "     Left Join UMEDIDA_UME H On b.cia_codcia=h.cia_codcia and b.ume_codref=h.ume_codepk" +
                           "     Left Join TRAN_DOCCOB_TDC I On a.cia_codcia=i.cia_codcia and a.suc_codsuc=i.suc_codsuc and a.tcc_codepk=i.tcc_codepk" +
                           "     Left Join TRAN_CTACTE_TCC J On a.cia_codcia=j.cia_codcia and a.suc_codsuc=j.suc_codsuc and a.tcc_codepk=j.tcc_codepk" +
                           "     Left Join TIPO_DOCU_TDO K On j.tdo_codtdo=k.tdo_codtdo" +
                           "     Left Join CUEN_CORR_CCR L On j.cia_codcia=l.cia_codcia and j.ccr_codepk=l.ccr_codepk" +
                           "     Left Join VENDEDOR_VDE M on i.vde_codepk=m.vde_codvpk and i.cia_codcia=m.cia_codcia" +
                           "     Left Join VENDEDOR_VDE N on i.vde_codcaj=n.vde_codvpk and i.cia_codcia=n.cia_codcia" +
                           "     Left Join COND_PAGO_CPG O on j.cpg_codepk=o.cpg_codepk and j.cia_codcia=o.cia_codcia" +
                           "     Left Join UMEDIDA_UME P On a.cia_codcia=p.cia_codcia and a.ume_codven=p.ume_codepk" +
                           "     Left JOIN CUEN_CORR_CCR Q On (Q.cia_codcia=I.cia_codcia and Q.ccr_codepk=I.ccr_codav1)" +
                           "     Left Join Cuen_Cont_CCT R On b.cia_codcia=r.cia_codcia and b.cct_cueinv=r.cct_codcct " +
                           "     Left Join Cuen_Cont_CCT S On b.cia_codcia=s.cia_codcia and b.cct_cuevta=S.cct_codcct " +
                           "     Left Join Clie_Cli T1 On L.cia_codcia=T1.cia_codcia And L.ccr_codepk=T1.ccr_codepk" +
                           "     Left Join Tipo_Cliente_TCL T2 On T1.cia_codcia=T2.cia_codcia and T1.tcl_codtpk=T2.tcl_codtpk" +
                           "     Left Join Cotizaciones_Cot C1 ON I.cia_codcia=C1.cia_codcia and I.suc_codsuc=C1.suc_codsuc and I.cot_numepk=C1.cot_numepk " +
                           "     Left Join Almacenes_Alm C2 ON c1.cia_codcia=c2.cia_codcia and c1.alm_codepk=c2.alm_codepk" +
                           "     Left Join Grupo_Producto_Gpr C3 on c1.cia_codcia=c3.cia_codcia and c1.gpr_codepk=c3.gpr_codepk" +
                           "     Left Join Grupo_Producto_Plantilla_Comercial_Gpc C4 On c1.cia_codcia=c4.cia_codcia and c1.gpr_codepk=c4.gpr_codepk and c1.gpc_codgpc=c4.gpc_codgpc" +
                           "     Left Join Marca_Productos_Map U on b.cia_codcia=u.cia_codcia and b.map_codepk=u.map_codepk" +
                           "     Left Join Punto_Venta_Pvt T on i.cia_codcia=T.cia_codcia and i.pvt_codepk=t.pvt_codepk" +
                           " Where a.cia_codcia=1 and j.ano_codano=2021 and Left(isnull(b.cct_cuevta,''),2)<>'12'" +
                           " group by j.mes_codmes";

            List<object> chartData = new List<object>();

            using (SqlConnection con = new SqlConnection(sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        string mes = "";
                        while (sdr.Read())
                        {
                            if (sdr["Mes"].ToString() == "1")
                            {
                                mes = "Enero";
                            }
                            if (sdr["Mes"].ToString() == "2")
                            {
                                mes = "Febrero";
                            }
                            if (sdr["Mes"].ToString() == "3")
                            {
                                mes = "Marzo";
                            }
                            if (sdr["Mes"].ToString() == "4")
                            {
                                mes = "Abril";
                            }
                            if (sdr["Mes"].ToString() == "5")
                            {
                                mes = "Mayo";
                            }
                            if (sdr["Mes"].ToString() == "6")
                            {
                                mes = "Junio";
                            }
                            if (sdr["Mes"].ToString() == "7")
                            {
                                mes = "Julio";
                            }
                            if (sdr["Mes"].ToString() == "8")
                            {
                                mes = "Agosto";
                            }
                            if (sdr["Mes"].ToString() == "9")
                            {
                                mes = "Setiembre";
                            }
                            if (sdr["Mes"].ToString() == "10")
                            {
                                mes = "Octubre";
                            }
                            if (sdr["Mes"].ToString() == "11")
                            {
                                mes = "Nomviembre";
                            }
                            if (sdr["Mes"].ToString() == "12")
                            {
                                mes = "Diciembre";
                            }

                            chartData.Add(new object[]
                            {
                                mes, sdr["Total"]
                            });
                            mes = "";
                        }
                    }

                    con.Close();
                }
            }
            // return Json(new Response {Action=Accion, Message = Mensaje }, JsonRequestBehavior.AllowGet );
            return Json(chartData);
        }
        [HttpPost]
        public JsonResult AjaxMethodImagen()
        {
            //string sConnString = "Data Source=(local);Initial Catalog=WebApp;Integrated Security=True";
            string sConnString = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            string query = "SELECT ano_usucre as ShipCity,ano_codano as TotalOrders FROM ANOS_ANO";
            //string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            List<object> chartData = new List<object>();

            using (SqlConnection con = new SqlConnection(sConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                                sdr["ShipCity"], sdr["TotalOrders"]
                            });
                        }
                    }

                    con.Close();
                }
            }
            // return Json(new Response {Action=Accion, Message = Mensaje }, JsonRequestBehavior.AllowGet );
            return Json(chartData);
        }

        [HttpPost]
        public ActionResult Create(TipoGrafico objGrafico)
        {
            

            if (objGrafico.GraficoColumna.Trim() != string.Empty)
            {
                SaveImage(objGrafico.GraficoColumna, "GraficoColumna");
            }

            if (objGrafico.GraficoCircular.Trim() != string.Empty)
            {
                SaveImage(objGrafico.GraficoCircular, "GraficoCircular");
            }

            
            //using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            //{
            //    using (BinaryWriter bw = new BinaryWriter(fs))
            //    {
            //        byte[] data = Convert.FromBase64String(objGrafico.GraficoLinea);
            //        bw.Write(data);
            //        bw.Close();
            //    }
            //    fs.Close();
            //}

            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult EnviarCorreo(string objCorreo)
        {
            var CorreoDestino = "uzuauz@gmail.com";
            var Asunto = "Correo de Prueba con Grafica de Google Charts";
            string Mensaje = "Gracias por realizar su Tramite, para consultar su Tramite " +
                            "ingrese al siguente enlace <img src='data:image/png;base64,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' />";

            Correo correo = new Correo();
            //string resp = correo.EnviarCorreo(CorreoDestino, Asunto, Mensaje);
            //string resp2 = correo.EnviarCorreo2();
            string resp3 = correo.EnviarCorreoTrauma();
            ViewBag.Mensaje = "Enviado....";
            return Json(resp3);

        }
        public void SaveImage(string base64, string nombre)
        {
            //string strm = "R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";

            ////this is a simple white background image
            //var myfilename = string.Format(@"{0}", Guid.NewGuid());
            if (base64!="")
            {
                //Generate unique filename
                string filepath = Path.Combine(Server.MapPath("~/FolderTrauma"), nombre + ".png");
                var bytess = Convert.FromBase64String(base64);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                    imageFile.Close();
                }
            }
          
        }

    }
}
