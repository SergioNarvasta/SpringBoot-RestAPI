
use EQUILIBRA_V17
  --MODIFICADO 130622
Select
      ISNULL(YEAR(a.FechaETA),'')AS Año,               
	  d.Seguimiento AS Estatus,                   
	  ISNULL(a.CodAnt,' ')AS MF ,                           
	  ISNULL(B.ProductoCEX,' ')AS Producto, 
	  ISNULL(C.ProveedorCEX,' ')AS Proveedor    ,     
	  ISNULL(E.TipoCarga,' ')AS TipoCarga,        
	  ISNULL(ab.PresentacionCEX,' ')AS Presentacion,       
	  ISNULL(a.PesoBBTM,0)AS PesoBBTM,
	  ISNULL(t.Marca,' ')AS Marca,                     
	  ISNULL(CantidadTM,0)AS CantidadTM,         
	  ISNULL(J.Incoterm,' ')AS Incoterm ,                 
	  ISNULL(a.PrecioUSDTM,0)AS PrecioUSDTM	 ,  
	  ISNULL(x.AlmacenDestino,' ')AS AlmacenDestino,  
	  ISNULL(f.PuertoOrigen,' ') as PuertoOrigen, 
	  ISNULL(v.PAI_NOMCOR,'')AS PaisOrigen,                
	  ISNULL(g.PuertoDestino,'')AS PuertoLlegada,
	  ISNULL(a.NaveDestino ,'')AS NaveDestino,        
	  ISNULL(a.BL,' ')AS BL,                      
	  ISNULL(l.Naviera,'')AS Naviera,                      
	  ISNULL(a.IdClasificacionCEX,' ')AS Clase,
	  ISNULL(a.MesEmbProg,'')AS MesEmbProg,            
	  ISNULL(a.FechaContrato,' ')AS FechaContrato,
	  ISNULL(DATEPART(WEEK,a.FechaContrato),0)AS SemContrato,
	  ISNULL(a.FechaETDIni,0)AS ETDInicial,
	  ISNULL(Datepart(Week,a.FechaETDIni),'')AS SemETDIni,  
	  Space(5)as FechaEDT1,Space(5)as FechaEDT2,Space(5)as FechaEDT3,Space(5)as FechaEDT4,    	           
	  ISNULL(ETD.FechaETD,'')AS UltimoETD,             
	  ISNULL(Datepart(Week,ETD.FechaETD),'')AS SemETDReal,  
	  ISNULL( DATEDIFF(WEEK,ETD.FechaETD,a.FechaContrato),'')AS LtETDReal,
	  (Case When ETD.FechaETD <= a.FechaETDIni Then 'VERDADERO' Else 'FALSO'End)AS CumpETD ,      
	  ISNULL(DATEDIFF(DAY,ETD.FechaETD,a.FechaETDIni),'')AS DifDiasETD,
	  ISNULL(a.FechaBL,' ')AS FechaBL , 
	  ISNULL(a.FechaETAIni,0)AS ETAInicial,          
	  Space(5)as ETA1,Space(5)as ETA2,Space(5)as ETA3,Space(5)as ETA4,     
	  ISNULL(A.FechaETA,'')AS UltimoETA  ,
	  ISNULL( DATEDIFF(WEEK,a.FechaETA,A.FechaETAIni),'')AS NVariacion, 
	  ISNULL(DATEPART(WEEK,a.FechaETA),'')AS SemETAReal, 
	  ISNULL(DATEDIFF(DAY,a.FechaETA,a.FechaContrato),'')AS LtETAReal, 
	  (Case When DATEDIFF(DAY,a.FechaETA,a.FechaETAIni)<=3 Then 'VERDADERO' Else 'FALSO'End )AS CumpETASem, 
	  ---HERE
	  ISNULL(DATEDIFF(DAY,a.FechaETA,a.FechaETAIni),0)AS DifDiasETA,
      ISNULL(y.ConfirmaFecha,' ')AS TipoConfirmacion, 
	  ISNULL(a.FechaIngAlmIni,0)AS FechaIngAlmEstIni,
	  ISNULL(e.TipoCarga,'')AS TipoCarga,                 
	  ISNULL(g.PuertoDestino+e.TipoCarga ,'')AS Concantenar,
	  Space(5)AS TIngreso,Space(5)AS FechaIngAlmEstFin,Space(5)AS DifDiasIng,
	  Space(5)AS SemanaIng,  ISNULL(a.FechaIngAlm,0)AS FechaFinIngAlm, 
	  Space(5)AS DiasETDProm, Space(5)AS DiasETAProm,Space(5)AS DiasIngAlmProm,
	  Space(5)AS DiasETDReal,Space(5)AS DiasETAReal,'' AS DiasIngAlmReal,
	  Space(5)AS LeadTimeEst,Space(5)AS LeadTimeReal,Space(5)AS PVariacion ,
	  Space(5)AS CumpIngreso,Space(5)AS CumpLeadTime ,
	  ISNULL(a.CodigoImportacion,'')AS CodigoOC,     
	  ISNULL(a.OCompraSG,'')AS OC,                  
	  ISNULL(a.OCEstatus,'')AS EstatusOC,                  
	  Space(5)AS NCompra,Space(5)AS MDemora,Space(5)AS Coment ,
	  ISNULL(b.Estado,'')AS EstProd

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
	left join CEX_PresentacionCEX ab on a.IdPresentacion = ab.IdPresentacionCEX
	Left Join (Select cia_codcia, idimportacion, max(nrosec) as maxsec from CEX_ImportacionETD group by cia_codcia, idimportacion ) as maxETD on (a.cia_codcia=maxETD.cia_codcia and a.IdImportacion=maxETD.IdImportacion)
	Left Join CEX_ImportacionETD as ETD on a.cia_codcia=ETD.cia_codcia and a.IdImportacion=ETD.IdImportacion and maxETD.maxsec=ETD.NroSec



	order by Año desc
   

  