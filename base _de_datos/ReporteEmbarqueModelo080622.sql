
use EQUILIBRA_V17
--select*from CEX_ImportacionING
Select 
      ISNULL(YEAR(a.FechaETA),'')AS A�o,               d.Seguimiento AS Estatus,                   ISNULL(a.CodAnt,' ')AS MF ,                           ISNULL(B.ProductoCEX,' ')AS Producto, 
	  ISNULL(C.ProveedorCEX,' ')AS Proveedor    ,      ISNULL(z.TipoCarga,' ')AS TipoCarga,        ISNULL(ab.PresentacionCEX,' ')AS Presentacion,        ISNULL(a.PesoBBTM,0)AS PesoBBTM,
	  ISNULL(t.Marca,' ')AS Marca,                     ISNULL(CantidadTM,0)AS CantidadTM,          ISNULL(J.Incoterm,' ')AS Incoterm ,                   ISNULL(a.PrecioUSDTM,0)AS PrecioUSDTM	 ,  
	  ISNULL(x.AlmacenDestino,' ')AS AlmacenDestino,   ISNULL(f.PuertoOrigen,' ') as PuertoOrigen, ISNULL(v.PAI_NOMCOR,'')AS PaisOrigen,                 ISNULL(g.PuertoDestino,'')AS PuertoLlegada,
	  ISNULL(a.NaveDestino ,'')AS NaveDestino,         ISNULL(a.BL,' ')AS BL,                      ISNULL(l.Naviera,'')AS Naviera,                       ISNULL(a.IdClasificacionCEX,' ')AS Clase,
	  ISNULL(a.MesEmbProg,'')AS MesEmbProg,            ISNULL(a.FechaContrato,' ')AS FechaContrato,ISNULL(DATEPART(WEEK,a.FechaContrato),0)AS SemContrato,ISNULL(a.FechaETDIni,0)AS ETDInicial,
	  ISNULL(DATEPART(WEEK,a.FechaETDIni),'')AS SemETDIni,ISNULL(ad.FechaETD,'') AS FechaETD1,''as FechaEDT2,''as FechaEDT3,''as FechaEDT4,              '' as UltimoETD,
	  
	 
	 
	
	  ISNULL(a.BLFecha,' ')AS BLFecha,                ISNULL(a.FechaETAIni,0)AS ETAInicial,        ISNULL(y.ConfirmaFecha,' ')AS TipoConfirmacion,
	  ISNULL(a.FechaIngAlmIni,'')AS FechaIngAlmEstIni,ISNULL(e.TipoCarga,'')AS TipoCarga,         ISNULL(g.PuertoDestino +z.TipoCarga ,'')AS Concantenar,a.FechaETD,a.FechaETDIni,ac.fechaING

	From CEX_Importacion A
	Left Join Cex_ProductoCEX B on A.IdProductoCEX=B.IdProductoCEX
	Left Join Cex_ProveedorCEX C on A.IdProveedorCEX=C.IdProveedorCEX
	Left Join Cex_Seguimiento D on a.IdSeguimiento=d.IdSeguimiento
	Left Join Cex_TipoCarga E on a.IdTipoCarga=e.IdTipoCarga
	Left Join Cex_PuertoOrigen F on a.IdPuertoOrigen=f.IdPuertoOrigen
	Left Join Cex_PuertoDestino G on a.IdPuertoDestino=G.IdPuertoDestino
	Left Join CEX_Direccionamiento H on a.IdDireccionamiento = h.IdDireccionamiento
	left join CEX_CanalCEX I on a.IdCanalCEX=i.IdCanalCex
	left join CEX_Incoterm J on a.IdIncoterm=j.IdIncoterm
	left join CEX_EmisionBL K on a.IdEmisionBL=k.IdEmisionBL
	left join CEX_Naviera L on a.IdNaviera=l.IdNaviera
	left join CEX_Regimen M on a.IdRegimen=m.IdRegimen
	left join CEX_PresentacionCEX N on a.IdPresentacion=N.IdPresentacionCEX
	left join CEX_PlazoPago O on a.IdPlazoPago=o.IdPlazoPago
	left join CEX_DiasPlazo P on a.IdDiasPlazo=p.IdDiasPlazo
	left join CEX_EstadoPago Q on a.IdEstadoPago=q.IdEstadoPago
	Left Join CEX_TipoCarga02 R on a.IdTipoCarga02=r.IdTipoCarga02
	left join PRODUCTOS_PRD prd on a.prd_codepk=prd.prd_codepk
    Left Join CEX_ClasificacionMitsui S on b.IDClasificacionMitsui=s.IdClasificacionMitsui
	Left Join CEX_Marca T on a.IdMarca=t.IdMarca
	Left Join CEX_TerminoFletamiento U on a.IdFletamiento=U.IdFletamiento
	Left Join pais_pai V on a.pai_codpai=v.PAI_CODPAI
	Left Join CEX_TerminalMar W on a.IdTerminalMar=w.IdTerminalMar
	Left Join CEX_AlmacenDestino X on a.IdAlmacenDestino=x.IdAlmacenDestino
	left join CEX_ConfirmaFecha Y on a.IdConfirmaAlm = y.IdConfirmaFecha   
	left join CEX_TipoCarga Z on a.IdTipoCarga = z.IdTipoCarga
	left join CEX_PresentacionCEX ab on a.IdPresentacion = ab.IdPresentacionCEX
	left join CEX_ImportacionING ac on a.cia_codcia = ac.cia_codcia
	left join CEX_ImportacionETD ad on (a.cia_codcia = ad.cia_codcia and a.IdImportacion = ad.IdImportacion )
	left join CEX_ImportacionETA ae on a.cia_codcia = ae.cia_codcia
   order by A�o desc


