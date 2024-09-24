---- ==
--Select * From cc45RegVentasVsSire Where Mes='02' and Estado='SIRESI_VENTASNO'            
----            
----
--Select * from bck_traver_2604.dbo.ccc03astip where ccc03cod='00003' and ccc03emp='01'
--Select * from bck_traver_2604.dbo.ccd03astip where ccd03cod='00003' and ccd03emp='01'

--Insert into ccc03astip 
--Select * from bck_traver_2604.dbo.ccc03astip where ccc03cod='00003' and ccc03emp='01'

--Insert into ccd03astip 
--Select * from bck_traver_2604.dbo.ccd03astip where ccd03cod='00003' and ccd03emp='01'


--Select * from ccd03astip where ccd03cod='00003'

--Update 
----Select * From cc45RegVentasVsSire where Estado='SIRESI_VENTASNO'    

--Select * from ccc where  ccc01emp='01' and ccc01ano='2024' and ccc01mes='02' and ccc01subd='05'	and ccc01numer='PRUEB'
--Select * from ccd where  ccd01emp='01' and ccd01ano='2024' and ccd01mes='02' and ccd01subd='05'	and ccd01numer='PRUEB'

/*        
DECLARE @flag int , @msgretorno varchar(100)        
EXEC Spu_Con_Ins_VoucherSireVentas '01','2024','02','<DataSet><tbl><campo1>204203103830100010000000001</campo1><campo2>VENTA NACIONAL SOL</campo2><campo3>91101</campo3><campo4>00003</campo4><campo5>05</campo5><campo6>PRUEB</campo6></tbl></DataSet>'
,@flag out, @msgretorno out        
SELECT @flag,@msgretorno        
*/        
Alter Procedure Spu_Con_Ins_VoucherSireVentas          
@ccc01emp	Char(2),                                    
@ccc01ano	Char(4),                                    
@ccc01mes	Char(2),                                    
@XMLrango	xml,                        
@flag		int output,                        
@MsgRetorno varchar(100) Output                                    
As                                  
--DECLARE @tmp_rango TABLE                                  
--(                                
--   campo1 varCHAR(250),                                
--   campo2 varchar(250),    -- Libro                            
--   campo3 varchar(250),   -- Voucher numero             
--   campo4 varchar(250),   -- tipdoc                             
--   campo5 varchar(250),    -- Num Doc                        
--   campo6 varchar(250)                        
--)            
            
Create Table #tmp_rango             
(            
            
 campo1 varCHAR(250), --campo1 - CARSIRE          
 campo2 varchar(250),  --campo2 --CONCEPTO          
 campo3 varchar(250),   --campo3 --CENTROCOSTO          
 campo4 varchar(250),   --campo4 --asientotipocod          
 campo5 varchar(250),  --campo5 -- asientotipolibro          
 campo6 varchar(250)    --campo6 -- vouchernumero          
)            
--Insert into  #tmp_rango(campo1,campo2,campo3,campo4,campo5,campo6)            
--SELECT     campo1 as 'CARSIRE'  ,              
--     campo2 ,          
--     campo3 ,          
--     campo4 ,          
--     campo5 ,          
--           campo6             
--           FROM   @tmp_rango          
                     
--           SELECT * FROM #tmp_rango          
                     
If @XMLrango.exist('//tbl')=1 -- Verificar que el XML tenga data                        
 BEGIN                                                      
  DECLARE @HANDLE INT                        
  EXEC SP_XML_PREPAREDOCUMENT  @HANDLE OUTPUT,@XMLrango                              
  INSERT INTO #tmp_rango([campo1], [campo2], [campo3], [campo4], [campo5], [campo6])                        
                        
  SELECT * FROM OPENXML(@HANDLE, '/DataSet/tbl', 2)                        
  WITH (                             
  campo1  varchar(250),                        
  campo2 varchar(250),            
  campo3 varchar(250),            
  campo4 varchar(250),            
  campo5 varchar(250),            
  campo6 varchar(250)            
  )                          
                     
     If @@error <> 0                                                             
  Begin                                              
   set @MsgRetorno  = 'Error al generar xml'                                                            
   Goto ManejaError                                                            
  End                          
                                       
END                     

-- -- Verificar Si existen Voucher Duplicado                                
 If (                        
  Select Count(*) from ccc c Inner Join #tmp_rango ra  On                         
  c.ccc01subd = ra.campo5 And c.ccc01numer = ra.campo6                        
  Where                        
  c.ccc01emp = @ccc01emp And c.ccc01ano = @ccc01ano And c.ccc01mes = @ccc01mes                                    
  ) > 0      
  Begin                           
		Set @MsgRetorno='ERROR :: YA EXISTE NUMERO DE VOUCHER'                                    
		Goto ManejaError                                    
  End                               
--  -- ====2.Inserto Detalle De Voucher                                  
--   --2.1 Creo Tabla temporal de los doc a trabajar     - PARA VENTAS       
   
--      --SACAR TODOS LOS CAMPOS DE SIREVENTAS
      
Create TABLE #DocSireVentas(
[SireEmpresa] char(2) NULL,
[SireAnio] char(4) NULL,
[SireMes] char(2) NULL,
[SireRuc] varchar(11) NULL,
[SireRazon_Social] varchar(255) NULL,
[SirePeriodo] varchar(6) NULL,
[SireCAR_SUNAT] varchar(255) NULL,
[SireFecha_emision] datetime NULL,
[SireFecha_Vcto_Pago] datetime NULL,
[SireTipo_CP_Doc] varchar(2) NULL,
[SireSerie_CDP] varchar(10) NULL,
[SireNro_CP] varchar(20) NULL,
[SireNro_Final] varchar(255) NULL,
[SireTipo_Doc_Identidad] varchar(3) NULL,
[SireNro_Doc_Identidad] varchar(20) NULL,
[SireRazon_Social2] varchar(255) NULL,
[SireValor_Facturado_Exportacion] float NULL,
[SireBI_Gravada] float NULL,
[SireDscto_BI] float NULL,
[SireIGV_IPM] float NULL,
[SireDscto_IGV_IPM] float NULL,
[SireMto_Exonerado] float NULL,
[SireMto_Inafecto] float NULL,
[SireISC] float NULL,
[SireBI_Grav_IVAP] float NULL,
[SireIVAP] float NULL,
[SireICBPER] float NULL,
[SireOtros_Tributos] float NULL,
[SireTotal_CP] float NULL,
[SireMoneda] varchar(4) NULL,
[SireTipo_Cambio] float NULL,
[SireFecha_Emision_Doc_Modificado] datetime NULL,
[SireTipo_CP_Modificado] varchar(2) NULL,
[SireSerie_CP_Modificado] varchar(5) NULL,
[SireNro_CP_Modificado] varchar(20) NULL,
[SireID_Proyecto_Operadores_Atribucion] varchar(255) NULL,
[SireTipo_Nota] varchar(255) NULL,
[SireEst_Comp] varchar(10) NULL,
[SireValor_FOB_Embarcado] float NULL,
[SireValor_OP_Gratuitas] float NULL,
[SireTipo_Operacion] varchar(10) NULL,
[SireDAM_CP] varchar(255) NULL,
[SireCLU] varchar(255) NULL,
[SireFechaImportacion] datetime NULL,
 Concepto			varchar(100),            
 centrocosto		varchar(20),            
 asientotipocod		varchar(20),            
 asientotiplibro	varchar(20),            
 vouchernumero		varchar(5),            
               
)            
             
              
   --2.1 Creo Tabla temporal                                  
   Create Table [#ccd_Ventas] (                                  
   [ccd01emp] [varchar] (2)  NOT NULL ,                                  
   [ccd01ano] [varchar] (4)  NOT NULL ,                                  
   [ccd01mes] [varchar] (2)  NOT NULL ,                     
   [ccd01subd] [varchar] (2)  NOT NULL ,                                  
   [ccd01numer] [varchar] (5)  NOT NULL ,                                  
   [ccd01ord] [float] NOT NULL ,                                  
   [ccd01cta] [varchar] (15)  NULL ,                                
   [ccd01deb] [float] NULL ,                                  
   [ccd01hab] [float] NULL ,                                  
   [ccd01con] [varchar] (80)  NULL ,                                  
   [ccd01tipdoc] [varchar] (2)  NULL ,                                  
   [ccd01ndoc] [varchar] (15)  NULL ,     
   [ccd01fedoc] [varchar] (10) NULL ,                                  
   [ccd01feven] [varchar] (10) NULL ,                                  
   [ccd01ana] [varchar] (2)  NULL ,                                  
   [ccd01cod] [varchar] (11)  NULL ,                                  
   [ccd01dn] [varchar] (1)  NULL ,                                  
   [ccd01tc] [float] NULL ,                                  
   [ccd01afin] [varchar] (1)  NULL ,                                  
   [ccd01cc] [varchar] (12)  NULL ,                                  
   [ccd01cg] [varchar] (6)  NULL ,                                  
   [ccd01fevou] [varchar] (10) NULL ,                                  
   [ccd01ama] [varchar] (1)  NULL ,                                  
   [ccd01astip] [varchar] (5)  NULL ,                                  
   [ccd01val] [varchar] (15)  NULL ,                                  
   [ccd01cd] [varchar] (6)  NULL ,                                  
   [ccd01car] [float] NULL ,                                  
   [ccd01abo] [float] NULL ,                                  
   [ccd01trans] [varchar] (1) NULL ,                                  
   [ccd01AfectoReteccion] [varchar] (1)  NULL ,                                  
   [ccd01FechaRetencion]  [varchar] (10) NULL ,                                  
   [ccd01NroDocRetencion] [varchar] (20)  NULL ,                                  
   [ccd01TipoTransaccion] [varchar] (2)  NULL ,                                  
   [ccd01FechaPagoRetencion] [varchar] (10) NULL ,                                  
   [ccd01TipoDocRetencion] [varchar] (2)  NULL ,                                  
   [ccd01NroPago] [varchar] (15)  NULL ,                                  
   [ccd01FecPago] [varchar] (10) NULL ,                                  
   [ccd01porcentaje] [varchar] (2)  NULL ,                                  
   [ccd01ams] [varchar] (15)  NULL ,                   
   ccd01cqmtipo char(2),            
   ccd01cqmnumero varchar(20),            
   ccd01cqmfecha varchar(10)            
   )                                  
               
--                                 
                        
BEGIN TRANSACTION                                 



--VALIDAR SI EXISTE CONCEPTO  
	IF( SELECT COUNT(*) FROM co08MotivosDocPorPagar_Ventas co08 LEFT JOIN #tmp_rango tmp  
		ON co08.CO08DESCRIPCION = tmp.campo2 and co08.CO08CODEMP = @ccc01emp  
          WHERE CO08CODEMP = @ccc01emp AND CO08DESCRIPCION = tmp.campo2 )<= 0        
   BEGIN        
        INSERT INTO co08MotivosDocPorPagar_Ventas(CO08CODEMP,CO08DESCRIPCION,CO08FECHA,CO08ASIENTOTIPOCOD)  
	     SELECT @ccc01emp,campo2,GETDATE(),campo4 FROM #tmp_rango  
    END     
    --END VALIDACION CONCEPTO -- co07MotivosDocPorPagar  
            
Select '#tmp_rango ',* from #tmp_rango 

Select   [SireEmpresa], [SireAnio], [SireMes], [SireRuc], [SireRazon_Social], [SirePeriodo], [SireCAR_SUNAT], 
    [SireFecha_emision], [SireFecha_Vcto_Pago], [SireTipo_CP_Doc], [SireSerie_CDP], [SireNro_CP], [SireNro_Final], 
    [SireTipo_Doc_Identidad], [SireNro_Doc_Identidad], [SireRazon_Social2], [SireValor_Facturado_Exportacion], 
    [SireBI_Gravada], [SireDscto_BI], [SireIGV_IPM], [SireDscto_IGV_IPM], [SireMto_Exonerado], [SireMto_Inafecto], 
    [SireISC], [SireBI_Grav_IVAP], [SireIVAP], [SireICBPER], [SireOtros_Tributos], [SireTotal_CP], [SireMoneda], 
    [SireTipo_Cambio], [SireFecha_Emision_Doc_Modificado], [SireTipo_CP_Modificado], [SireSerie_CP_Modificado], 
    [SireNro_CP_Modificado], [SireID_Proyecto_Operadores_Atribucion], [SireTipo_Nota], [SireEst_Comp], 
    [SireValor_FOB_Embarcado], [SireValor_OP_Gratuitas], [SireTipo_Operacion], [SireDAM_CP], [SireCLU], 
    [SireFechaImportacion],t.campo2,t.campo3,t.campo4,t.campo5,t.campo6          
            
From cc45RegVentasVsSire sire Inner Join #tmp_rango t on             
 sire.SireCAR_SUNAT = t.campo1            
Where Empresa=@ccc01emp and Anio=@ccc01ano and Mes=@ccc01mes and Estado='SIRESI_VENTASNO'            

            
INSERT INTO #DocSireVentas (
    [SireEmpresa], [SireAnio], [SireMes], [SireRuc], [SireRazon_Social], [SirePeriodo], [SireCAR_SUNAT], 
    [SireFecha_emision], [SireFecha_Vcto_Pago], [SireTipo_CP_Doc], [SireSerie_CDP], [SireNro_CP], [SireNro_Final], 
    [SireTipo_Doc_Identidad], [SireNro_Doc_Identidad], [SireRazon_Social2], [SireValor_Facturado_Exportacion], 
    [SireBI_Gravada], [SireDscto_BI], [SireIGV_IPM], [SireDscto_IGV_IPM], [SireMto_Exonerado], [SireMto_Inafecto], 
    [SireISC], [SireBI_Grav_IVAP], [SireIVAP], [SireICBPER], [SireOtros_Tributos], [SireTotal_CP], [SireMoneda], 
    [SireTipo_Cambio], [SireFecha_Emision_Doc_Modificado], [SireTipo_CP_Modificado], [SireSerie_CP_Modificado], 
    [SireNro_CP_Modificado], [SireID_Proyecto_Operadores_Atribucion], [SireTipo_Nota], [SireEst_Comp], 
    [SireValor_FOB_Embarcado], [SireValor_OP_Gratuitas], [SireTipo_Operacion], [SireDAM_CP], [SireCLU], 
    [SireFechaImportacion],Concepto,centrocosto,asientotipocod,asientotiplibro,vouchernumero)            
            
            
Select   [SireEmpresa], [SireAnio], [SireMes], [SireRuc], [SireRazon_Social], [SirePeriodo], [SireCAR_SUNAT], 
    [SireFecha_emision], [SireFecha_Vcto_Pago], [SireTipo_CP_Doc], [SireSerie_CDP], [SireNro_CP], [SireNro_Final], 
    [SireTipo_Doc_Identidad], [SireNro_Doc_Identidad], [SireRazon_Social2], [SireValor_Facturado_Exportacion], 
    [SireBI_Gravada], [SireDscto_BI], [SireIGV_IPM], [SireDscto_IGV_IPM], [SireMto_Exonerado], [SireMto_Inafecto], 
    [SireISC], [SireBI_Grav_IVAP], [SireIVAP], [SireICBPER], [SireOtros_Tributos], [SireTotal_CP], [SireMoneda], 
    [SireTipo_Cambio], [SireFecha_Emision_Doc_Modificado], [SireTipo_CP_Modificado], [SireSerie_CP_Modificado], 
    [SireNro_CP_Modificado], [SireID_Proyecto_Operadores_Atribucion], [SireTipo_Nota], [SireEst_Comp], 
    [SireValor_FOB_Embarcado], [SireValor_OP_Gratuitas], [SireTipo_Operacion], [SireDAM_CP], [SireCLU], 
    [SireFechaImportacion],t.campo2,t.campo3,t.campo4,t.campo5,t.campo6          
            
From cc45RegVentasVsSire sire Inner Join #tmp_rango t on             
 sire.SireCAR_SUNAT = t.campo1            
Where Empresa=@ccc01emp and Anio=@ccc01ano and Mes=@ccc01mes and Estado='SIRESI_VENTASNO'            
--            


-- Select * from #DocSireVentas 
-- SELECT '#DOCSIREVENTAS',* FROM #DocSireVentas
  INSERT INTO #ccd_Ventas(ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord,ccd01cta,            
  ccd01deb,            
  ccd01hab,            
  ccd01con,ccd01tipdoc,ccd01ndoc,ccd01fedoc,            
  ccd01feven,ccd01ana,ccd01cod,ccd01dn,ccd01tc,ccd01afin,            
  ccd01cc,ccd01cg,ccd01fevou,ccd01ama,ccd01astip,ccd01val,            
  ccd01cd,ccd01car,ccd01abo,ccd01trans,            
  ccd01AfectoReteccion,ccd01FechaRetencion,            
  ccd01NroDocRetencion,ccd01TipoTransaccion,            
  ccd01FechaPagoRetencion,ccd01TipoDocRetencion,ccd01NroPago,ccd01FecPago,ccd01porcentaje,ccd01ams,            
  ccd01cqmtipo,ccd01cqmnumero,ccd01cqmfecha)            
 
Select                                  
  ds.SireEmpresa,ds.SireAnio,ds.SireMes,ds.asientotiplibro,ds.vouchernumero,0 as ccd01ord,atdet.ccd03cta
,(Case when upper(ccd03ca)='C' Then             
 (Case isnull(ccd03afin,'')            
  When '1' then round(SireBI_Gravada*(ccd03porcen/100),2) --  base Gravado 
  When '2' then round(SireMto_Inafecto*(ccd03porcen/100),2) -- Monto inafecto
  When '3' then round(SireISC*(ccd03porcen/100),2) -- ISC          
  When '4' then round(SireDscto_IGV_IPM*(ccd03porcen/100),2) -- IGV IPM        
  When '5' then round(SireOtros_Tributos*(ccd03porcen/100),2) -- Otros tributos
  When '6' then round(SireTotal_CP*(ccd03porcen/100),2) -- Total documento
  When '7' then round(SireMto_Exonerado*(ccd03porcen/100),2) -- Monto exonerado          
  When '8' then round(SireICBPER*(ccd03porcen/100),2) -- ICPBER, impuesto a la bolsa
  When '9' then round(SireOtros_Tributos*(ccd03porcen/100),2)-- Valor facturado exportacion
  else 0 end)            
  else            
  0            
  End) as 'DeberSol',

(Case when upper(ccd03ca)='A' Then             
        (Case isnull(ccd03afin,'')            
  When '1' then round(SireBI_Gravada*(ccd03porcen/100),2) --  base Gravado 
  When '2' then round(SireMto_Inafecto*(ccd03porcen/100),2) -- Monto inafecto
  When '3' then round(SireISC*(ccd03porcen/100),2) -- ISC          
  When '4' then round(SireDscto_IGV_IPM*(ccd03porcen/100),2) -- IGV IPM        
  When '5' then round(SireOtros_Tributos*(ccd03porcen/100),2) -- Otros tributos
  When '6' then round(SireTotal_CP*(ccd03porcen/100),2) -- Total documento
  When '7' then round(SireMto_Exonerado*(ccd03porcen/100),2) -- Monto exonerado          
  When '8' then round(SireICBPER*(ccd03porcen/100),2) -- ICPBER, impuesto a la bolsa
  When '9' then round(SireOtros_Tributos*(ccd03porcen/100),2)-- Valor facturado exportacion
  else 0 end)            
  else            
  0            
  End) as 'HaberSol',            
  
-- ccd01con,ccd01tipdoc,ccd01ndoc,ccd01fedoc,ccd01feven            
 isnull(ds.Concepto,'') as 'Glosa',            
 SireTipo_CP_Doc  as 'DocTip',            
 (Isnull(SireSerie_CDP,'') + '-' + isnull(SireNro_CP,'')) as 'DocNro',            
 dbo.FECHAFORMATEADATEXTO(SireFecha_emision) as 'DocFechaEmision',            
 (Case when isnull(SireFecha_Vcto_Pago,'')='' then Null else dbo.FECHAFORMATEADATEXTO(SireFecha_Vcto_Pago) end) as 'DocFechaVencimiento',            
-- ccd01ana,ccd01cod,ccd01dn,ccd01tc,ccd01afin,                                  
 '01' as 'CtaCteAnalisis', -- por defecto por que es compras y debe ser un cliente
 SireNro_Doc_Identidad as 'CtaCteCod',
 (Case when SireMoneda='PEN' then 'S' else 'D' end) as 'Moneda',            
 SireTipo_Cambio as 'TipoCambio',            
 ccd03afin as 'Columna',            
-- ccd01cc,ccd01cg,ccd01fevou,ccd01ama,ccd01astip,ccd01val,ccd01cd            
 Isnull(centrocosto,'') as 'CentroCosto',
 '' as 'CentroGestion',
 dbo.FECHAFORMATEADATEXTO(SireFecha_emision) as 'Voucherfecha',
 '' as 'Amarre',
 ccd03cod as 'AsientoTipoCod',
 '' as 'ccd01val',
 '' as 'ccd01cd',
  --,ccd01car,ccd01abo,ccd01trans,
 (Case when upper(ccd03ca)='C' Then
        (Case isnull(ccd03afin,'')
  
  When '1' then round(((round(SireBI_Gravada*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) --  base Gravado           
  When '2' then round(((round(SireMto_Inafecto*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Monto inafecto
  When '3' then round(((round(SireISC*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- ISC        
  When '4' then round(((round(SireDscto_IGV_IPM*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- IGV IPM           
  When '5' then round(((round(SireOtros_Tributos*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Otros tributos
  When '6' then round(((round(SireTotal_CP*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- grabada IGV            
  When '7' then round(((round(SireMto_Exonerado*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- IGV Grabada dan derecho            
  When '8' then round(((round(SireICBPER*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- IGV No grabda dan derecho credito fiscal            
  When '9' then round(((round(SireOtros_Tributos*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2)-- Otros tibutos y cargos            
    else 0 end)            
  else            
  0            
  End) as 'CargoDol',            
            
--(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)            
(Case when upper(ccd03ca)='A' Then             
      (Case isnull(ccd03afin,'')            
  When '1' then round(((round(SireBI_Gravada*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) --  base Gravado            
  When '2' then round(((round(SireMto_Inafecto*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Monto inafecto
  When '3' then round(((round(SireISC*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- ISC                    
  When '4' then round(((round(SireDscto_IGV_IPM*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- IGV IPM           
  When '5' then round(((round(SireOtros_Tributos*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Otros tributos
  When '6' then round(((round(SireTotal_CP*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Total documento           
  When '7' then round(((round(SireMto_Exonerado*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- Monto exonerado            
  When '8' then round(((round(SireICBPER*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2) -- ICPBER, impuesto a la bolsa        
  When '9' then round(((round(SireOtros_Tributos*(ccd03porcen/100),2))/(Case when SireTipo_Cambio=1 then tc.VenBan else SireTipo_Cambio end)),2)-- Valor facturado exportacion    
  else 0 end)            
  else            
  0            
  End) as 'AbonoDol',            
  'N' as 'ccdtrans', -- revisar por que se pone N            
             
-- ccd01AfectoReteccion,ccd01FechaRetencion,ccd01NroDocRetencion,            
  '' as 'ccd01AfectoReteccion',            
  '' as 'ccd01FechaRetencion',            
  '' as 'ccd01NroDocRetencion',            
  '' as 'ccd01TipoTransaccion',            
  '' as 'ccd01FechaPagoRetencion',            
  '' as 'ccd01TipoDocRetencion',            
  '' as 'ccd01NroPago',            
  '' as 'ccd01FecPago',            
  '' as 'ccd01porcentaje',            
  '' as 'ccd01ams',            
-- ccd01cqmtipo,ccd01cqmnumero,ccd01cqmfecha)            
 (Case when isnull(SireNro_CP_Modificado,'')='' then Null else  Isnull(SireTipo_CP_Modificado,'') end) as 'DocModTipo',            
 (Case when isnull(SireNro_CP_Modificado,'')='' then Null else  (isnull(SireSerie_CP_Modificado,'') + Isnull(SireNro_CP_Modificado,'')) end)  as 'DocModNumero',            
-- SireCOD_DAM_DSI             
 (Case when isnull(SireNro_CP_Modificado,'')='' then Null else  dbo.FECHAFORMATEADATEXTO(SireFecha_Emision_Doc_Modificado) end) as 'DocModFecha'            
             
  FROM #DocSireVentas ds            
  INNER JOIN ccc03astip atcab            
  ON ds.SireEmpresa=atcab.ccc03emp And ds.SireAnio=atcab.ccc03aa and ds.asientotipocod=atcab.ccc03cod            
  INNER JOIN ccd03astip atdet            
  ON ds.SireEmpresa=atdet.ccd03emp And ds.SireAnio=atdet.ccd03aa and ds.asientotipocod=atdet.ccd03cod            
  Left Join ticambio tc on             
  ds.SireFecha_emision = tc.fecha            
              
  WHERE                                  
  ds.SireEmpresa=@ccc01emp            
  And ds.SireAnio=@ccc01ano            
  And ds.SireMes=@ccc01mes            
  Order by ds.SireCAR_SUNAT            
            
--
--Select * from ccd03astip where ccd03cod='70001'
--Select * from ccd03astip where ccd03cod='70004'
--Select * from FAC08_CABASIENTOTIPO
--Select * from FAC09_DETASIENTOTIPO

            
  If (Select count(*)from #ccd_Ventas)=0          
    Begin                            
   Set @MsgRetorno ='AVISO :: No se genero Voucher, no se encontro coincidencias'                            
   Goto ManejaError                            
  End          
             
---- -- ====Inserto Numero De Voucher                                  
  Insert Into ccc(ccc01emp,ccc01ano,ccc01mes,ccc01subd,ccc01numer,ccc01fecha,ccc01deta,    ccc01flag,ccc01astip,ccc01trans)                                  
  Select distinct ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,Convert(datetime,ccd01fevou,103),Left(ccd01con,60),'0',ccd01astip,'N' from #ccd_Ventas            
              
   If @@ERROR<>0                            
  Begin                            
   Set @MsgRetorno ='ERROR :: Al insertar Cabecera del Voucher'                            
   Goto ManejaError                            
  End                            
                   
                   
  -- Inserto En el Detalle                                    
   -- Declaro Cursor que Arma El Asiento                                  
   DECLARE @ccd01emp  varchar(2)                               
   DECLARE @ccd01ano  varchar(4)                                  
   DECLARE @ccd01mes  varchar(2)                                  
   DECLARE @ccd01subd  varchar(2)                                  
   DECLARE @ccd01numer  varchar(5)                                  
   DECLARE @ccd01ord  float                                  
   DECLARE @ccd01cta  varchar(15)                                  
   DECLARE @ccd01deb  float                                  
   DECLARE @ccd01hab  float                                  
   DECLARE @ccd01con  varchar(80)                                  
   DECLARE @ccd01tipdoc  varchar(2)                                  
   DECLARE @ccd01ndoc  varchar(15)                                  
   DECLARE @ccd01fedoc  varchar(10)                                  
   DECLARE @ccd01feven  varchar(10)                                  
   DECLARE @ccd01ana  varchar(2)                                  
   DECLARE @ccd01cod  varchar(11)                                  
   DECLARE @ccd01dn  varchar(1)                                  
   DECLARE @ccd01tc  float                              
   DECLARE @ccd01afin  varchar(1)                                  
   DECLARE @ccd01cc  varchar(12)                                  
   DECLARE @ccd01cg  varchar(6)                                  
   DECLARE @ccd01fevou  varchar(10)                                  
   DECLARE @ccd01ama  varchar(1)                                  
   DECLARE @ccd01astip  varchar(5)                                  
   DECLARE @ccd01val  varchar(15)                                  
   DECLARE @ccd01cd  varchar(6)                                  
   DECLARE @ccd01car  float                                  
   DECLARE @ccd01abo  float                                  
   DECLARE @ccd01trans  varchar(1)                                    
   DECLARE @ccd01AfectoReteccion  varchar(1)                                  
   DECLARE @ccd01FechaRetencion   varchar(10)                                  
   DECLARE @ccd01NroDocRetencion  varchar(20)                                  
   DECLARE @ccd01TipoTransaccion  varchar(2)                                  
   DECLARE @ccd01FechaPagoRetencion  varchar(10)                                  
   DECLARE @ccd01TipoDocRetencion   varchar(2)                                  
   DECLARE @ccd01NroPago   varchar(15)                                  
   DECLARE @ccd01FecPago   varchar(10)                                  
   DECLARE @ccd01porcentaje  varchar(2)                                  
   DECLARE @ccd01ams   varchar(15)                                  
            
   DECLARE @ccd01cqmtipo   varchar(2)                                  
   DECLARE @ccd01cqmnumero  varchar(20)                                  
   DECLARE @ccd01cqmfecha  varchar(10)                                  
            
   DECLARE @ccd01ord_auto   int              
   --                                  
                 
   DECLARE @nOkDestino int                                  
                                     

    Declare Asiento CURSOR FOR                                  
    Select   ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord,ccd01cta,ccd01deb,                                  
      ccd01hab,ccd01con,ccd01tipdoc,ccd01ndoc,ccd01fedoc,ccd01feven,ccd01ana,                                  
      ccd01cod,ccd01dn,ccd01tc,ccd01afin,ccd01cc,ccd01cg,ccd01fevou,ccd01ama,                                  
      ccd01astip,ccd01val,ccd01cd,ccd01car,ccd01abo,ccd01trans,ccd01AfectoReteccion,                                  
      ccd01FechaRetencion,ccd01NroDocRetencion,ccd01TipoTransaccion,ccd01FechaPagoRetencion,                                  
      ccd01TipoDocRetencion,ccd01NroPago,ccd01FecPago,ccd01porcentaje,ccd01ams,            
    ccd01cqmtipo,ccd01cqmnumero,ccd01cqmfecha            
            
    From #ccd_Ventas              
   Order by ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer                                  
    OPEN Asiento                                  
                                      
     Fetch Next From Asiento                                  
     Into    @ccd01emp,@ccd01ano,@ccd01mes,@ccd01subd,@ccd01numer,@ccd01ord,@ccd01cta,@ccd01deb,                                  
      @ccd01hab,@ccd01con,@ccd01tipdoc,@ccd01ndoc,@ccd01fedoc,@ccd01feven,@ccd01ana,                                  
      @ccd01cod,@ccd01dn,@ccd01tc,@ccd01afin,@ccd01cc,@ccd01cg,@ccd01fevou,@ccd01ama,                                  
      @ccd01astip,@ccd01val,@ccd01cd,@ccd01car,@ccd01abo,@ccd01trans,@ccd01AfectoReteccion,                                  
      @ccd01FechaRetencion,@ccd01NroDocRetencion,@ccd01TipoTransaccion,@ccd01FechaPagoRetencion,                                  
      @ccd01TipoDocRetencion,@ccd01NroPago,@ccd01FecPago,@ccd01porcentaje,@ccd01ams,            
      @ccd01cqmtipo,@ccd01cqmnumero,@ccd01cqmfecha                                  
                                  
     While @@FETCH_STATUS = 0                                  
     Begin                                  
                                  
      EXECUTE @nOkDestino = Sp_Con_Ins_Detalle_Voucher                                   
      @ccd01emp,@ccd01ano,@ccc01mes,@ccd01subd,@ccd01numer,@ccd01cta,                      
      @ccd01deb,@ccd01hab,@ccd01con,@ccd01tipdoc,@ccd01ndoc,@ccd01fedoc,@ccd01feven,                                  
      @ccd01cod,@ccd01dn,@ccd01tc,@ccd01afin,@ccd01cc,@ccd01cg,               
                                       
      @ccd01astip,@ccd01val,@ccd01car,@ccd01abo,@ccd01trans,@ccd01ama,                                  
      @ccd01AfectoReteccion,@ccd01TipoTransaccion,@ccd01NroDocRetencion,@ccd01FechaRetencion,                       
      @ccd01FechaRetencion,                                  
      @ccd01TipoDocRetencion,@ccd01NroPago,@ccd01FecPago,                                  
      @ccd01porcentaje,              
      '', -- as @ccm01ams,              
 Null,-- as @ccd01Comprobante, --36                      
 Null,-- as @ccd01aniodua, --37                           
 Null,-- as @ccd01codtraencurso,  --38                      
 Null,-- as @ccd01codmaquina,  --39                      
 @ccd01cqmtipo,-- as @ccd01cqmtipo,              
 @ccd01cqmnumero,-- as @ccd01cqmnumero,              
 @ccd01cqmfecha,-- as @ccd01cqmfecha,                  
      @ccd01ord_auto   Output,                    
      @MsgRetorno Output                                  
                                  
                                    
             
        If @nOkDestino = -1                                  
             Begin                                  
          Set  @MsgRetorno = 'No se Pudo Insertar Detalle del Voucher'                                  
          GOTO ManejaError                                  
  End                                  
        FETCH NEXT FROM Asiento                                  
        INTO @ccd01emp,@ccd01ano,@ccd01mes,@ccd01subd,@ccd01numer,@ccd01ord,@ccd01cta,@ccd01deb,                          
      @ccd01hab,@ccd01con,@ccd01tipdoc,@ccd01ndoc,@ccd01fedoc,@ccd01feven,@ccd01ana,                                  
      @ccd01cod,@ccd01dn,@ccd01tc,@ccd01afin,@ccd01cc,@ccd01cg,@ccd01fevou,@ccd01ama,                                  
      @ccd01astip,@ccd01val,@ccd01cd,@ccd01car,@ccd01abo,@ccd01trans,@ccd01AfectoReteccion,                                  
      @ccd01FechaRetencion,@ccd01NroDocRetencion,@ccd01TipoTransaccion,@ccd01FechaPagoRetencion,                                  
      @ccd01TipoDocRetencion,@ccd01NroPago,@ccd01FecPago,@ccd01porcentaje,@ccd01ams,            
      @ccd01cqmtipo,@ccd01cqmnumero,@ccd01cqmfecha                                                        
     End                                  
                                      
    CLOSE Asiento                                  
    DEALLOCATE Asiento                                  
                          
Set  @MsgRetorno ='OK:: Se Genero Vouche con Exito'                          
set @flag = 1                        
                        
Commit transaction                
Return 1                          
ManejaError:                          
set @flag = -1                
Rollback transaction                
Return -1 