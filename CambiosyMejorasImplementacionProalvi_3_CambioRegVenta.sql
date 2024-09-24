               
--Exec Sp_Con_Rep_RegistroVentas '01','2021','10','05','S'              
Alter Procedure Sp_Con_Rep_RegistroVentas              
/*-----------------------------------------------------------R---------------*/                                        
/* Objetivo   : Reporte del Registro de Ventas            */                                        
/* Actualiza  :            */                                        
/* Creado Por : William Rodriguez                                   */                                        
/* Fecha      : 10/09/1999                                                  */                                        
/*--------------------------------------------------------------------------*/                                        
@cEmpresa  varchar(2),                                        
@cAno      varchar(4),                                        
@cMes      varchar(2),                                        
@cLibro    varchar(2),                                        
@cMoneda   varchar(1)                                        
                                        
AS                                        
Set nocount On                                
Declare @fechainiperiodo   datetime                                  
Declare @fechafinperiodo   datetime                                  
                                  
Set @fechainiperiodo = Convert(datetime,'01' + '/' + @cMes +'/'+ @cAno,103)                                  
Set @fechafinperiodo = Convert(datetime,Convert(varchar(2),dbo.Diaspormmes(@fechainiperiodo)) + '/'+  @cMes +'/'+ @cAno,103)                                  
                          
                          
Create Table #RegistroVentas                                          
(                                          
Anio          char(4),                          
Mes          char(2),                          
Libro         char(2),                          
Voucher         varchar(5),                          
correlativo       int,                          
Fecha_documento    datetime,                          
--                              
Analisis        char(2),                          
Cuenta_Corriente    varchar(11),                          
Ruc_Cuenta_Corriente    varchar(11),                          
Nombre_Cuenta_Corriente varchar(250),                          
TipDocCtaCte  varchar(10),                          
--                              
Tipo_Documento  varchar(10),                          
nombretipdoc  varchar(50),                          
Documento   varchar(20),                          
SerieDocNac   varchar(20),                          
NumeroDocNac  varchar(20),                          
Fecha_Emision  varchar(10),                          
Fecha_VencoPago  varchar(10),                          
--                                       
columna01    decimal(18,2) DEFAULT(0) ,                          
columna02    decimal(18,2) DEFAULT(0),                          
columna03    decimal(18,2) DEFAULT(0),                          
columna04    decimal(18,2) DEFAULT(0),                          
columna05    decimal(18,2) DEFAULT(0),                          
columna06    decimal(18,2) DEFAULT(0),                          
columna07    decimal(18,2) DEFAULT(0),                          
columna08    decimal(18,2) DEFAULT(0),                          
columna09    decimal(18,2) DEFAULT(0),                          
columna10    decimal(18,2) DEFAULT(0),                          
                          
--                              
Referenciafecha      varchar(10),                    
ReferenciaTipo       varchar(20),                    
ReferenciaSerDoc     varchar(20),                    
ReferenciaNumDoc     varchar(20),                    
--                          
tipo             varchar(2),                    
moneda            char(1),                    
TipoDeCambio        decimal(18,3),        
--                              
periodo        varchar(10),                    
CodigoUnicoOperacion    varchar(20),                    
FlagdeAjuste       varchar(1),                    
NumcorrelativoAsicont   varchar(10),                    
ValorFob    decimal(18,2),              
MonedaTipo     varchar(3),                  
TipoCambioInconsistencia varchar(1) default(''),                    
CancelacionMedioPago  varchar(1) default(''),                            
)                          
              
              
-- =========================Crear Tabla para identificar si el documento ha sido cancelado                  
-- =========================                  
                  
 Declare @FacturasCanceladas table                  
 (                  
 ccd01cta varchar(30),                  
 ccd01ana char(2),                  
 ccd01cod varchar(15),                  
 ccd01tipdoc char(2),                  
 ccd01ndoc varchar(30),                  
 ccd01deb float,                  
 ccd01hab float                  
 )                  
                  
 Insert Into @FacturasCanceladas(ccd01cta,ccd01ana,ccd01cod,ccd01tipdoc,ccd01ndoc,ccd01deb,ccd01hab)                  
 Select ccd01cta,ccd01ana,ccd01cod,ccd01tipdoc,ccd01ndoc,                  
 Sum(ccd01deb) as ccd01deb,Sum(ccd01hab) as ccd01hab                  
 From ccd Inner Join ccm01cta On                  
 ccd01emp=ccm01emp                  
 And ccd01ano=ccm01aa                  
 And ccd01cta=ccm01cta                  
 Where                  
  ccd01emp = @cEmpresa                  
 And ccd01ano = @cAno                  
 And ccd01mes <= @cMes                    
 And (isnull(ccd01ana,'')<>'' And isnull(ccd01cod, '') <> '')                  
 And left(ccd01cta,2)<>'40'                  
 Group By ccd01cta,ccd01ana,ccd01tipdoc,ccd01ndoc,ccd01cod                  
 Having (Sum(ccd01deb)-Sum(ccd01hab))=0                  
-- =========================                   
                    
                          
/* 1. === Traer Los Documentos que deben ir en el registro de ventas =====*/                                          
 Insert Into #RegistroVentas(Anio,Mes,Libro,Voucher,Analisis,Cuenta_Corriente,Tipo_Documento,Documento,Fecha_documento,moneda,tipo)                                          
 Select distinct ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ana,ccd01cod,ccd01tipdoc,ccd01ndoc,ccd01fedoc,ccd01dn,'01'                                      
 from ccd                                          
 WHERE ccd01emp = @cEmpresa                     
  AND  ccd01ano = @cAno                                          
  AND  ccd01mes = @cMes                                          
 -- Que este en el libro de compras                                          
 AND  ccd01subd In (SELECT ccb02cod FROM ccb02subd Where                                           
      ccb02emp=@cEmpresa                                      
      And ccb02aa=@cAno                                     
 And Isnull(ccb02tip,'')='V'                          
          )                                          
-- Tienen que tener cuenta corrinte                              
  And Isnull(ccd01cod,'')<>''                              
--Tienen que teber el indicado de columa de registro de ventas                          
  And Isnull(ccd01afin,'')<>''
  
                                
                              
/*========== Actualizo los importes =================================*/                                
/*===================================================================*/                          
/* Le coloco valor a la columna 1 - Base Imponible (Afectos) */                                        
UPDATE #RegistroVentas                                        
SET Columna01 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
 WHERE det.ccd01emp = @cEmpresa                                        
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND ccd01afin = '1'       -- Afecto o Base                                  
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                                        
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna01, 0) = 0                                         

/* Le coloco valor a la columna 2 - Importe Exonerado o Inafecto */                                        
UPDATE #RegistroVentas                                        
SET Columna02 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
WHERE det.ccd01emp = @cEmpresa                                        
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND det.ccd01afin = '2'                                     
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                            
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna02, 0) = 0                                        

                                        
/* Le coloco valor a la columna 3 - ISC */                                        
UPDATE #RegistroVentas                                        
SET Columna03 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
WHERE det.ccd01emp = @cEmpresa                                        
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND det.ccd01afin = '3'                                     
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                            
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna03, 0) = 0      

/* Le coloco valor a la columna 4 - IGV e IPM */                                        
UPDATE #RegistroVentas                                        
SET Columna04 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
 WHERE det.ccd01emp = @cEmpresa                                        
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                 
 AND det.ccd01afin = '4'                              
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                                        
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna04, 0) = 0                                        

/*  Le coloco valor a la columna 5 - Otros Tributos  */                      
UPDATE #RegistroVentas                                        
SET Columna05 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
 WHERE det.ccd01emp = @cEmpresa                                        
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                 
 AND det.ccd01afin = '5'                              
 AND #RegistroVentas.Libro = det.ccd01subd                                 
 AND #RegistroVentas.Voucher = det.ccd01numer                                        
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna05, 0) = 0                                        
              
/* Le coloco Total del Documento para Facturas y Otros */                                        
UPDATE #RegistroVentas                              
SET Columna06 = ISNULL(                            
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det           
 WHERE det.ccd01emp = @cEmpresa                                        
 ANd det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                 
 AND det.ccd01afin = '6'                   
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                                        
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna06, 0) = 0                                        
                                        

/* Le coloco valor a la columna 7 - Importe Exonerado o Inafecto */                                        
UPDATE #RegistroVentas                                        
SET Columna07 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
WHERE det.ccd01emp = @cEmpresa                             
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND det.ccd01afin = '7'                                     
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                            
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna07, 0) = 0                                        

            
/* Impuesto Por Bolsa */                                        
UPDATE #RegistroVentas                                        
SET Columna08 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
WHERE det.ccd01emp = @cEmpresa                             
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND det.ccd01afin = '8'                                     
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                            
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna08, 0) = 0                                        
                                        
                                        
/* Le coloco valor a la columna 7 - Importe Exonerado o Inafecto */                                        
UPDATE #RegistroVentas                                        
SET Columna09 = ISNULL(                                        
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                        
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                        
 FROM  ccd det                              
WHERE det.ccd01emp = @cEmpresa                             
 AND det.ccd01ano = @cAno                                        
 AND det.ccd01mes = @cMes                                        
 AND det.ccd01afin = '9'                                     
 AND #RegistroVentas.Libro = det.ccd01subd                                        
 AND #RegistroVentas.Voucher = det.ccd01numer                            
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                        
 AND #RegistroVentas.Documento = det.ccd01ndoc                                        
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                        
WHERE ISNULL(Columna09, 0) = 0                                        
                                        
                                        
                                        
                                        
/* Pongo Positivo si el total es positivo*/                                        
UPDATE #RegistroVentas                                        
SET Columna01 = ABS(Columna01),               
 Columna02 = ABS(Columna02),               
 Columna03 = ABS(Columna03),                                        
 Columna04 = ABS(Columna04),               
 Columna05 = ABS(Columna05),        
 Columna06 = ABS(Columna06),       
 Columna07 = ABS(Columna07),                
 Columna08 = ABS(Columna08),
 Columna09 = ABS(Columna09)                                
WHERE Isnull(Columna06,0) > 0                                         
                                        
/* Pone Negativo a las Nota de credito*/                                        
UPDATE #RegistroVentas                                        
SET Columna01 = ABS(Columna01)*(-1), Columna02 = ABS(Columna02)*(-1), Columna03 = ABS(Columna03)*(-1),                                        
 Columna04 = ABS(Columna04)*(-1), Columna05 = ABS(Columna05)*(-1), Columna06 = ABS(Columna06)*(-1)              
,Columna07 = ABS(Columna07)*(-1), Columna08 = ABS(Columna08)*(-1), Columna09 = ABS(Columna09)*(-1)                                         
WHERE #RegistroVentas.Tipo_Documento = '07'                                          
                                        
--                           
/* Le coloco Nombre de Cta. Cte. y RUC a los Documentos Seleccionados */                          
 UPDATE #RegistroVentas                          
 SET                          
  Ruc_Cuenta_Corriente    = Isnull(cte.ccm02ruc,''),                          
  Nombre_Cuenta_Corriente = dbo.Fnc_EliminaCar(Isnull(cte.ccm02nom,'')),                        
  TipDocCtaCte            = isnull(cte.ccm02tipdocidentidad,'')                         
 FROM  ccm02cta cte                          
 WHERE                          
 cte.ccm02emp=@cEmpresa                         
 And #RegistroVentas.Analisis = cte.ccm02tipana                          
 And #RegistroVentas.Cuenta_Corriente = cte.ccm02cod                          
                    
                    
  --  Actualiza (Tipo de cambio) y correlativo del asiento                    
UPDATE #RegistroVentas                                             
Set                                         
TipoDeCambio=ccd01tc,                    
NumcorrelativoAsicont = rtrim(Convert(varchar(10),CONVERT(int,ccd01ord)))                      
From ccd c ,#RegistroVentas r Where                                   
c.ccd01emp        = @cEmpresa                          
And c.ccd01ano    = r.Anio                          
And c.ccd01mes    = r.Mes                          
And c.ccd01subd   = r.Libro                          
And c.ccd01numer  = r.Voucher                     
And c.ccd01ana  = r.Analisis                          
And c.ccd01cod    = r.Cuenta_Corriente                          
And c.ccd01tipdoc = r.Tipo_Documento                          
And c.ccd01ndoc   = r.Documento                          
                    
--  Actualiza documentos que modifica  y Detraccions                                      
UPDATE #RegistroVentas                                             
Set                                         
Referenciafecha=Convert(varchar(10),convert(date,ccd01cqmfecha),103),                              
ReferenciaTipo=ccd01cqmtipo,                                        
ReferenciaSerDoc = dbo.ExtraeSerieyNumero(ccd01cqmnumero,'S'),                              
ReferenciaNumDoc = dbo.ExtraeSerieyNumero(ccd01cqmnumero,'N')                              
From ccd c ,#RegistroVentas r Where                                        
c.ccd01emp   = @cEmpresa                                        
And c.ccd01ano    = r.Anio                                        
And c.ccd01mes    = r.Mes                                        
And c.ccd01subd   = r.Libro                                        
And c.ccd01numer  = r.Voucher                                        
And c.ccd01ana   = r.Analisis                                        
And c.ccd01cod    = r.Cuenta_Corriente                                        
And c.ccd01tipdoc = r.Tipo_Documento                                      
And c.ccd01ndoc   = r.Documento                                        
And (Isnull(ccd01cqmtipo,'') + Isnull(ccd01cqmnumero,''))<>''                                   
                          
                    
-- ==============     
Update #RegistroVentas                            
Set  Fecha_Emision=Convert(Varchar(10),Convert(date,Fecha_documento),103),              
     SerieDocNac = dbo.ExtraeSerieyNumero(Documento,'S')                          
                          
-- === Se actualiza flag de ajuste por que primero te piden de fecha y despues.                    
Update #RegistroVentas                            
Set FlagdeAjuste = (Case When Tipo_Documento In (Select ccb02cod from ccb02tipd Where     -- Si los campos 1,6,7 son NO, quiere decir que esos docuemntos no estan afectos al IGV                    
         ccb02emp=@cEmpresa And (Isnull(ccb02libelercregvenestado0,''))='S')                    
          then '0' else                    
    (Case When dbo.PERIODOANIOMES(Convert(datetime,Fecha_Emision,103)) = (@cAno + @cMes)  Then '1' else                                                
    (Case When dbo.PERIODOANIOMES(Convert(datetime,Fecha_Emision,103)) < (@cAno + @cMes)  then '8' end)                                                
    End)                    
    End)                    
                    
              
-- ========              
Update   #RegistroVentas                                
Set CancelacionMedioPago='1'                  
From @FacturasCanceladas Where                  
Analisis   = ccd01ana                  
And Cuenta_Corriente = ccd01cod                  
And Tipo_Documento  = ccd01tipdoc                  
And Documento   = ccd01ndoc                  
              
-- Actualizar seghun lo requrdido por registro de ventas              
Update   #RegistroVentas                                
Set                                
Nombre_Cuenta_Corriente = Left(ltrim(Nombre_Cuenta_Corriente),60),                                
SerieDocNac = (Case When Isnull(SerieDocNac,'')<>'' then ( Case When Tipo_Documento in ('01','03','04','07','08')then dbo.PadR(SerieDocNac,4,'0')                                
               Else (Case When Tipo_Documento in ('00')  then '-' else SerieDocNac End)                                
           End)else '-'end),          
NumeroDocNac=dbo.ExtraeSerieyNumero(Documento,'N'),                              
Fecha_Emision=Convert(Varchar(10),Convert(date,Fecha_documento),103),                              
Fecha_VencoPago=(Case When Tipo_Documento='14' then convert( varchar(10), convert( date, Fecha_documento ) , 103 ) else ' ' end),                              
Referenciafecha =(Case When Tipo_Documento in ('07','08','87','88','97','98') then (Case When UPPER(Nombre_Cuenta_Corriente) = 'ANULADO' then '01/01/0001' else (Case When dbo.IsDate103(Referenciafecha)=1 then Referenciafecha else '' end) end)  Else '01/01/0001' End),                          
ReferenciaTipo  =(Case When Tipo_Documento in ('07','08','87','88','97','98') then (Case When UPPER(Nombre_Cuenta_Corriente) = 'ANULADO' then '00' else ReferenciaTipo end ) Else '00' End),                          
ReferenciaSerDoc=(Case When Tipo_Documento in ('07','08','87','88','97','98') then (Case When UPPER(Nombre_Cuenta_Corriente) = 'ANULADO' then '-' else dbo.PadR(ReferenciaSerDoc,4,'0')end ) Else '-' End),                          
ReferenciaNumDoc=(Case When Tipo_Documento in ('07','08','87','88','97','98') then (Case When UPPER(Nombre_Cuenta_Corriente) = 'ANULADO' then '-' else ReferenciaNumDoc end ) Else '-' End),                          
-- Para el PLE              
periodo = (Anio + Mes + '00'),                          
CodigoUnicoOperacion  = (Anio + Mes  + Libro + Voucher),                          
NumcorrelativoAsicont = 'M' + NumcorrelativoAsicont,                          
--                          
FlagdeAjuste = (Case When UPPER(Nombre_Cuenta_Corriente) = 'ANULADO' Then '2' else FlagdeAjuste end),                  
--                        
ValorFob = 0.00,                  
-- Valores Adiconales para el PLE 5.0                  
MonedaTipo = (Case When Moneda='S' then 'PEN' else 'USD' End)                  
              
                    
/* Query que saca el Registro de Ventas */                          
SELECT * FROM #RegistroVentas   ORDER BY Fecha_Emision,Libro,Voucher,Tipo_Documento,Documento 