

USE MARANATHA_V21

SELECT  DISTINCT a.grc_numero, b.ccr_codccr, b.ccr_nomaux,  
                 b.ccr_numruc, a.grc_origen, p.pla_dirpla, dpe1.dpe_direcc
FROM dbo.guia_remision_grc a 
INNER JOIN dbo.cuen_corr_ccr b ON (b.cia_codcia = a.cia_codcia AND b.ccr_codepk = a.ccr_codepk) 
INNER JOIN dbo.motivos_almacen_moa c ON (c.cia_codcia = a.cia_codcia AND c.moa_codepk = a.moa_codepk) 
INNER JOIN dbo.kardex_productos_kac d ON (d .cia_codcia = a.cia_codcia AND d .suc_codsuc = a.suc_codsuc AND d .kac_codepk = a.kac_codepk) 
LEFT JOIN dbo.cuen_corr_ccr f ON (f.cia_codcia = a.cia_codcia AND f.ccr_codepk = a.tra_codepk) 
LEFT JOIN dbo.unidad_transporte_utr g ON (g.cia_codcia = a.cia_codcia AND g.utr_codepk = a.utr_codepk) 
LEFT JOIN dbo.choferes_cho h ON (h.cia_codcia = a.cia_codcia AND h.cho_codepk = a.cho_codepk) 
LEFT JOIN dbo.plantas_cia_pla p ON (p.cia_codcia = a.cia_codcia AND p.pla_codepk = a.pla_codepk) 
LEFT JOIN dbo.lugar_despacho_ldp q ON (q.cia_codcia = a.cia_codcia AND q.ccr_codepk = a.ccr_codepk AND q.ldp_codldp = a.ldp_codldp) 
INNER JOIN dbo.kardex_productos_kad r ON (r.cia_codcia = a.cia_codcia AND r.suc_codsuc = a.suc_codsuc AND r.kac_codepk = a.kac_codepk) 
INNER JOIN dbo.productos_prd s ON (s.cia_codcia = r.cia_codcia AND s.prd_codepk = r.prd_codepk) 
LEFT JOIN MARCA_PRODUCTOS_MAP map ON (s.cia_codcia = map.cia_codcia AND s.map_codepk = map.map_codepk)
LEFT JOIN dbo.tipoinventario_tin t ON (t .cia_codcia = s.cia_codcia AND t .tin_codtin = s.tin_codtin) 
LEFT JOIN dbo.umedida_ume u ON (u.cia_codcia = s.cia_codcia AND u.ume_codepk = s.ume_codepk) 
INNER JOIN (SELECT kad.cia_codcia, kad.suc_codsuc, kad.kac_codepk, kad.kad_seckad, kad.prd_codepk, 
                   STUFF(( SELECT '/' + Rtrim(Ltrim(t2.lot_codlot)) + ' (FV ' + t2.lot_fecven + ') ' --'(' + CONVERT(varchar(10), cast(t2.kpl_canund AS int)) + ') '
                           FROM (SELECT  kp.cia_codcia, kp.suc_codsuc, lt.lot_codlot, kp.kad_seckad, kp.kac_codepk, kp.kpl_canund,
						                (case when Lt.lot_fecven is null then '  /  /    ' else convert(varchar,Lt.lot_fecven,103) end) as lot_fecven
                                 FROM KARDEX_PRODUCTOS_LOTE_KPL kp 
				                 LEFT JOIN LOTES_LOT lt ON kp.cia_codcia = lt.cia_codcia AND kp.lot_codepk = lt.lot_codepk AND kp.prd_codepk = lt.prd_codepk
                                 WHERE kp.kpl_canund > 0 ) t2
	                       WHERE t2.cia_codcia = kad.cia_codcia AND t2.suc_codsuc = kad.suc_codsuc AND t2.kad_seckad = kad.kad_seckad AND 
                                t2.kac_codepk = kad.kac_codepk FOR XML PATH('')), 1, 1, '') AS lot_codlot
            FROM  kardex_productos_kad kad
            GROUP BY kad.cia_codcia, kad.suc_codsuc, kad.kac_codepk, kad.kad_seckad, kad.prd_codepk) tabla 
ON a.kac_codepk = tabla.kac_codepk AND r.kad_seckad = tabla.kad_seckad AND r.prd_codepk = tabla.prd_codepk
LEFT JOIN PRODUCTOS_CORR_PCO N ON r.cia_codcia=n.cia_codcia and r.prd_codepk=n.prd_codepk and a.ccr_codepk=n.ccr_codepk
Left Join DATO_PERS_DPE DPE1 On DPE1.cia_codcia = a.cia_codcia And DPE1.ccr_codepk = a.ccr_codepk 
Left Join dato_pers_dpe DPE2 On DPE2.cia_codcia = a.cia_codcia And DPE2.ccr_codepk = a.tra_codepk 
left join COTIZACIONES_COT D1 on d.cia_codcia=d1.cia_codcia and d.cot_numepk=d1.cot_numepk
WHERE dpe1.dpe_direcc = '-'
GROUP BY a.grc_numero, b.ccr_codccr, b.ccr_nomaux, a.grc_origen,p.pla_dirpla,dpe1.dpe_direcc,b.ccr_numruc