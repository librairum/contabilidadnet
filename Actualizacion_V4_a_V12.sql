--@V12 Begin
Use MasterCon
Go
-- 1. Cambiar Version de BD
		Update BDAtributos Set  VersionBD=12, 
							VersionBDHora=Convert(datetime,'11:40',108),
							VersionBDFecha=Convert(datetime,'08/02/2022',103)
-- 2 Modificar SP apertura Anio

--1 Agrandar campo de glosa para reporte de analisis de cuenta corriente
--2 Agregar Reporte de archivo plano


Go
-- Insertar Menu para todas las empresa
Insert into menus(empresa,modulo,nivel1,nivel2,nivel3,texto)
Select Codigo,'CONTABILID','03','16','00','Archivo Plano Voucher' from Empresa where Sistema='CONTABILID'

-- Insertar Menu Para todos los usuarios
Insert Into menuxusuario(empresa,modulo,codigomenu,usuario)
Select Codigo,'CONTABILID','031600',usuario.Nombre from Empresa,usuario where Empresa.Sistema='CONTABILID' and usuario.Sistema='CONTABILID'
Go

-- Agrandar campo de glosa para reporte de analisis de cuenta corriente
Go 
Alter Table tmpctacte Alter Column Glosa varchar(100)
Go

Go

Create  View V_CtaCte  
As  
Select ccd01emp,ccd01ano,ccd01ana,ccd01cod,ccd01cta,ccd01tipdoc,ccd01ndoc,  
Min(ccd01fedoc) as 'FechaInicial',Sum(ccd01deb) as ccd01deb,Sum(ccd01hab) as ccd01hab,Sum(ccd01car) as ccd01car,Sum(ccd01abo) as ccd01abo,  
Sum(ccd01deb)-Sum(ccd01hab) as 'SaldoSoles',  
Sum(ccd01car)-Sum(ccd01abo) as 'SaldoDolares'  
From ccd where isnull(ccd01ana, '') <> '' And isnull(ccd01cod, '') <> ''  
Group by ccd01emp,ccd01ano,ccd01ana,ccd01cod,ccd01cta,ccd01tipdoc,ccd01ndoc  

Go
--Exec Spu_Con_Trae_DocXCtaCteyCtaCble '01','2021','42121','02','20489478162'
Create  Procedure Spu_Con_Trae_DocXCtaCteyCtaCble
@ccd01emp	char(2),
@ccd01ano	char(4),
@ccd01cta	varchar(20),
@ccd01ana	char(2),
@ccd01cod	varchar(20)
As
Select 
ctacte.ccd01tipdoc as 'DocTipo',
ctacte.ccd01ndoc as 'DocNro',
'' as 'DocMoneda',
'' as 'DocFecha',
ctacte.ccd01deb as 'Docdebe',
ctacte.ccd01hab as 'DocHaber',
ctacte.ccd01car	as 'DocCargo',
ctacte.ccd01abo as 'DocAbono',
ctacte.SaldoSoles as 'DocSaldoSoles',
ctacte.SaldoDolares as 'DocSaldoDolares'
From V_CtaCte ctacte 
where
ctacte.ccd01emp=@ccd01emp
And ctacte.ccd01ano=@ccd01ano
And ctacte.ccd01cta =@ccd01cta
And ctacte.ccd01ana=@ccd01ana
And ctacte.ccd01cod=@ccd01cod
Order by  ctacte.ccd01emp,ctacte.ccd01ano,ctacte.ccd01cta,ctacte.ccd01ana,ctacte.ccd01cod,ctacte.ccd01tipdoc,ctacte.ccd01ndoc,ctacte.FechaInicial
                 
Go
--Exec Sp_Con_Rep_RegistroVentas '04','2021','12','05','S'                
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
moneda          char(1),                      
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
                                          
                                          
/* Le coloco valor a la columna 3 - ISC */                                          
UPDATE #RegistroVentas                                          
SET Columna03 = ISNULL(             
-- (SELECT ABS(ROUND(SUM(det.ccd01deb - det.ccd01hab), 2))                                          
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                          
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                          
 FROM  ccd det, ccb02ctalib cxl                                          
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
              
/* Impuesto Por Bolsa */                                          
UPDATE #RegistroVentas                         
SET Columna08 = ISNULL(                                          
-- (SELECT ABS(ROUND(SUM(det.ccd01deb - det.ccd01hab), 2))                                          
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                          
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                          
 FROM  ccd det, ccb02ctalib cxl                                          
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
    
/* Le coloco valor a la columna 2 - Importe Exonerado o Inafecto */       
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
                                          
                                            
/* Le coloco valor a la columna 2 - Base Imponible (Inafectos) */                                          
UPDATE #RegistroVentas                                          
SET Columna02 = ISNULL(                                          
 (SELECT Round(Sum(Case @cMoneda When 'S' Then det.ccd01deb - det.ccd01hab                                 
                                        When 'D' THEN det.ccd01car - det.ccd01abo End), 2)                                          
 FROM  ccd det                                   
 WHERE det.ccd01emp = @cEmpresa                                          
 AND det.ccd01ano = @cAno                                          
 AND det.ccd01mes = @cMes                                          
 AND det.ccd01afin = '2'       -- Inafecto                                    
 AND #RegistroVentas.Libro = det.ccd01subd                                          
 AND #RegistroVentas.Voucher = det.ccd01numer                                          
 AND #RegistroVentas.Tipo_Documento = det.ccd01tipdoc                                          
 AND #RegistroVentas.Documento = det.ccd01ndoc                                          
 GROUP BY ccd01subd, ccd01numer, ccd01tipdoc, ccd01ndoc), 0)                                          
WHERE ISNULL(Columna02, 0) = 0                                           
                                          
                                          
                                          
/* Pongo Positivo si el total es positivo*/                                          
UPDATE #RegistroVentas                                          
SET Columna01 = ABS(Columna01),                 
 Columna02 = ABS(Columna02),                 
 Columna03 = ABS(Columna03),                                          
 Columna04 = ABS(Columna04),                 
 Columna05 = ABS(Columna05),          
 Columna06 = ABS(Columna06),         
 Columna07 = ABS(Columna07),                  
 Columna08 = ABS(Columna08)                                 
WHERE Columna06 > 0                                           
                                          
/* Pone Negativo a las Nota de credito*/                                          
UPDATE #RegistroVentas                                          
SET Columna01 = ABS(Columna01)*(-1), Columna02 = ABS(Columna02)*(-1), Columna03 = ABS(Columna03)*(-1),                                          
 Columna04 = ABS(Columna04)*(-1), Columna05 = ABS(Columna05)*(-1), Columna06 = ABS(Columna06)*(-1)                
,Columna07 = ABS(Columna07)*(-1), Columna08 = ABS(Columna08)*(-1)                                           
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


Go

-- ===    
CREATE Function [dbo].[DiaspormmesConParam](@CodigoAnnio char(4),@CodigoMes char(2))  RETURNS Int      
AS          
BEGIN          
      
         
declare @anio  integer        
declare @mes   integer        
declare @dias   integer        
        
        
Set @anio = @CodigoAnnio      
Set @mes  = @CodigoMes      
        
If @mes In (1,3,5,7,8,10,12)           
 Begin        
  Set @Dias=31        
 End        
Else If @mes In (4,6,9,11)        
 Begin        
  Set @Dias=30        
 End        
Else If @mes In (2)        
 Begin        
  If @anio % 4 =0         
   Set @Dias=29        
  Else        
   Set @Dias=28        
  End        
        
 RETURN(@Dias)          
END    

Go

CREATE Function [dbo].[Periodo_Sumar](@Periodo varchar(6),@CantMeses integer) RETURNS varchar(6)      
/*  
  Creado Por    : William Rodriguez        
  Funcion       : Devolver el tiempo de servciio        
  Restricciones : Solo se basa en 30 dias por mes        
  Uso    : Para Las Utilidades        
*/  
As      
BEGIN        
      
Declare @Periodo_Sumar varchar(6)      
Declare @Anno char(4)      
Declare @CodigoMes char(2)      
Declare @NroAnios int    
      
Set @NroAnios=0    
Set @Anno=Substring(@Periodo,1,4)      
Set @CodigoMes=Substring(@Periodo,5,2)      
--Set @CantMeses=@CantMeses+1      
Declare @AnioPos char(4)      
Declare @MesPos char(2)      
    
While (Convert(int,@CodigoMes) + @CantMeses)>12          
      Begin          
        Set @CantMeses = @CantMeses-12          
        Set @NroAnios = @NroAnios+1          
        Continue          
      End        
  While (Convert(int,@CodigoMes) + @CantMeses)<1          
      Begin          
        Set @CantMeses = 12 + @CantMeses          
        Set @NroAnios = @NroAnios-1          
        Continue          
      End       
        
Set @AnioPos = Convert(Char(4),Convert(Int,@Anno)+@NroAnios)         
Set @MesPos  = Convert(Char(2),Convert(int,(@CodigoMes) + @CantMeses))           
      
    
Set @MesPos = Case When Convert(Int,@MesPos) < 10 Then '0' + ltrim(rtrim(Convert(Int,@MesPos))) Else @MesPos End          
      
 Set @Periodo_Sumar = @AnioPos + @MesPos      
        
   RETURN(@Periodo_Sumar)        
END  

Go

--Exec Spu_Con_Trae_ValImpVoucher '01','2021','12','yadira','IV'    
Alter Procedure Spu_Con_Trae_ValImpVoucher                       
@Empresa   VarChar(2),                    
@Anio     VarChar(4),                    
@Mes     VarChar(2),                    
@Usuario   VarChar(20),                  
@flag  varchar(2)                  
as                          
                          
 -- Creo una temporal para los errores                        
                         
CREATE TABLE #Voucher_importarError(                        
 [ccd01contador] [int] NOT NULL,                        
 [ccd01emp] [varchar](2) NULL,                        
 [ccd01ano] [varchar](4) NULL,                        
 [ccd01mes] [varchar](2) NULL,                        
 [ccd01subd] [varchar](2) NULL,                        
 [ccd01numer] [varchar](5) NULL,                        
 [ccd01tipo] [varchar](2) NULL,                        
 [ccd01fecha] [datetime] NULL,                        
 [ccd01glosa] [varchar](80) NULL,                        
 [ccd01tc] [float] NULL,                        
 [ccd01cta] [varchar](15) NULL,                        
 [ccd01moneda] [varchar](1) NULL,                        
 [ccd01deb] [float] NULL,                        
 [ccd01hab] [float] NULL,                        
 [ccd01car] [float] NULL,                        
 [ccd01abo] [float] NULL,                        
 [ccd01ctactetipo] [varchar](2) NULL,                        
 [ccd01ctacteruc] [varchar](11) NULL,                        
 [ccd01tipdoc] [varchar](2) NULL,                        
 [ccd01ndoc] [varchar](15) NULL,                        
 [usuario] [varchar](20) NULL,                        
 [ccd01errorcod] [varchar](5) NULL,                        
 [ccd01errordes] [varchar](250) NULL                        
)                         
                        
 -- ======= Elimino todas las cuentas que no sean C o D                        
CREATE TABLE #Voucher_importarOri(                  
 [ccd01contador] [int] NOT NULL,                  
 [ccd01emp] [varchar](2) NULL,                  
 [ccd01ano] [varchar](4) NULL,                  
 [ccd01mes] [varchar](2) NULL,                  
 [ccd01subd] [varchar](2) NULL,                  
 [ccd01numer] [varchar](5) NULL,                  
 [ccd01tipo] [varchar](2) NULL,                  
 [ccd01fecha] [datetime] NULL,                  
 [ccd01glosa] [varchar](80) NULL,                  
 [ccd01tc] [float] NULL,                  
 [ccd01cta] [varchar](15) NULL,                  
 [ccd01moneda] [varchar](1) NULL,                  
 [ccd01deb] [decimal](18, 2) NULL,                  
 [ccd01hab] [decimal](18, 2) NULL,                  
 [ccd01car] [decimal](18, 2) NULL,                  
 [ccd01abo] [decimal](18, 2) NULL,                  
 [ccd01ctactetipo] [varchar](2) NULL,                  
 [ccd01ctacteruc] [varchar](11) NULL,                  
 [ccd01tipdoc] [varchar](2) NULL,                  
 [ccd01ndoc] [varchar](15) NULL,                  
 [usuario] [varchar](20) NULL,                  
 [ccd01Comprobante] [varchar](20) NULL                  
)                  
                  
-- =============                  
If @flag='IV'                  
 Begin                  
   Insert into #Voucher_importarOri(ccd01contador,ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01tipo,ccd01fecha,                  
  ccd01glosa,ccd01tc,ccd01cta,ccd01moneda,ccd01deb,ccd01hab,ccd01car,ccd01abo,                  
  ccd01ctactetipo,ccd01ctacteruc,ccd01tipdoc,ccd01ndoc,usuario,ccd01Comprobante)                  
   Select ccd01contador,ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01tipo,ccd01fecha,                  
  ccd01glosa,ccd01tc,ccd01cta,ccd01moneda,ccd01deb,ccd01hab,ccd01car,ccd01abo,                  
  ccd01ctactetipo,ccd01ctacteruc,ccd01tipdoc,ccd01ndoc,usuario,ccd01Comprobante                  
   from Voucher_importar Where                         
   ccd01emp = @Empresa And usuario = @Usuario And Isnull(ccd01tipo,'')<>''                        
            
                  
 End                  
Else If @flag='IC'                  
 Begin                  
                     
   Insert into #Voucher_importarOri(ccd01contador,ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01tipo,ccd01fecha,                  
   ccd01glosa,ccd01tc,ccd01cta,ccd01moneda,ccd01deb,ccd01hab,ccd01car,ccd01abo,                  
   ccd01ctactetipo,ccd01ctacteruc,ccd01tipdoc,ccd01ndoc,usuario,ccd01Comprobante)                  
                    
    Select 0,ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,'D',ccd01fedoc,                  
   ccd01con,ccd01tc,ccd01cta,ccd01dn,ccd01deb,ccd01hab,ccd01car,ccd01abo,                  
   ccd01ana,ccd01cod,ccd01tipdoc,ccd01ndoc,'',ccd01Comprobante                  
   from ccd_importar Where                  
    ccd01emp = @Empresa                  
 End                  
                           
 -- ========== Validar Inconsistencias del mismo registro                        
If @flag='IV'                  
 -- Validar solo para la importacion de excel                  
 Begin                  
     -- 1.- Valida tipo de registro                        
    Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,                   
  
    
     ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
     Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc ,ccd01ndoc,'1.1', 'Valida tipo de registro sea C=cabecera, D=Detalle, R=Resultado'                        
     from #Voucher_importarOri  Where                   
     ccd01emp = @Empresa And usuario = @Usuario                  
        And ccd01tipo Not in ( 'C', 'D')                  
                             
      -- Validar Voucher sin cabcera                        
     Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,                  
  
    
     
     ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
     Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc  c ,                   
                      
    ccd01ndoc,'1.2', 'Validar Voucher sin cabcera'                        
      from #Voucher_importarOri  Where                        
      ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'D'                        
      And (rtrim(ltrim(ccd01emp)) + rtrim(ltrim(ccd01ano)) + rtrim(ltrim(ccd01mes)) + rtrim(ltrim(ccd01subd)) + rtrim(ltrim(ccd01numer))) Not in (Select Distinct (rtrim(ltrim(ccd01emp)) + rtrim(ltrim(ccd01ano)) + rtrim(ltrim(ccd01mes)) + rtrim(ltrim(ccd01subd)) + rtrim(ltrim(ccd01numer))) from #Voucher_importarOri  Where                        
           ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'C')                        
                            
    -- Validar Voucher sin Detalle                        
     Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo ,
  
    
      
        
          
            
              
                
 ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)               
                        
     Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc ,                   
                      
    ccd01ndoc,'1.3', 'Validar Voucher sin Detalle'                        
     from #Voucher_importarOri  Where                        
      ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'C'                        
      And (rtrim(ltrim(ccd01emp)) + rtrim(ltrim(ccd01ano)) + rtrim(ltrim(ccd01mes)) + rtrim(ltrim(ccd01subd)) + rtrim(ltrim(ccd01numer))) Not in (Select Distinct (rtrim(ltrim(ccd01emp)) + rtrim(ltrim(ccd01ano)) + rtrim(ltrim(ccd01mes)) + rtrim(ltrim(ccd01subd                  
                      
    )) + rtrim(ltrim(ccd01numer))) from #Voucher_importarOri  Where                        
           ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'D')                        
 End               
                               
--Validar Voucher repetidos                        
 Insert Into #Voucher_importarError (ccd01contador,ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer,ccd01errorcod,ccd01errordes)                        
 Select  0,ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer ,'1.4', 'Validar Voucher Repetido'                        
 from #Voucher_importarOri  Where                        
  ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'C'                        
  Group By ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer                        
  Having COUNT(*)>1                          
                              
-- ========== Validar datos de la llave del voucher                        
   -- 2.1 .- Valida Empresa                          
 Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
 ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
       
           
            
              
                
                  
                  
ccd01ndoc,'2.1', 'Valida Empresa  '                        
 from #Voucher_importarOri                          
    Where usuario = @Usuario And ccd01emp <> @Empresa And  ccd01tipo in ( 'C','D')                          
                              
    -- 2.- Valida Periodo                          
    Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo   
,     
 ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc ,               
      
 ccd01tipdoc , ccd01ndoc,'2.2', 'Valida Periodo'                        
    from #Voucher_importarOri                          
    Where ccd01emp = @Empresa And usuario = @Usuario And                          
       (ccd01ano <> @Anio Or ccd01mes <> @Mes) And  ccd01tipo in ( 'C','D')                          
                                 
   -- 2.2.- Valida Fecha                     
 If   @flag<>'IC'-- Para la imprtacionde caja no se debe validarq ue la fehca pertenesca al periodo                
  Begin                
		-- Estandarizo a mes  12, los periodos 13, 14, etc (para los periodos de cierre 1, cierre 12)
	  Declare @Mesnew char(2)
	  If @Mes>12 begin	Set @Mesnew='12' end else begin Set @Mesnew=@Mes end 
  
		Declare @periodoActual			char(6)
		Declare @periodoActualMenos12	char(6)
		Declare @FechaRangoValidoInitexto	varchar(10)
		Declare @FechaRangoValidoFintexto	varchar(10)

		Set @periodoActual=@Anio + @Mesnew
		Set @periodoActualMenos12=dbo.Periodo_Sumar(@periodoActual,-12)

		Set @FechaRangoValidoInitexto = '01' + '/' +  right(@periodoActualMenos12,2) +'/'+ left(@periodoActualMenos12,4)
		Set @FechaRangoValidoFintexto = Convert(char(2),(dbo.DiaspormmesConParam(Left(@periodoActual,4),right(@periodoActual,2)))) 
										+ '/' +  right(@periodoActual,2) +'/'+ left(@periodoActual,4)


		-- Voucher de diarios que son de compras
		Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,           
		ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
		Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc,                 
		ccd01ndoc,'2.3', 'Valida Fecha, Debe estar en periodo actual o 12 meses anteriores  ' from #Voucher_importarOri                          
		Where ccd01emp = @Empresa And usuario = @Usuario And  ccd01tipo in ( 'C','D')                          
		And  ccd01subd in (Select ccb02cod from ccb02subd where ccb02emp=@Empresa	And ccb02aa=@Anio	and ccb02tip='C')             
	    -- Traer voucher que no esten dentro del rango valido
	    And ccd01fecha not between  Convert(datetime,@FechaRangoValidoInitexto,103) and Convert(datetime,@FechaRangoValidoFintexto,103)
		
		

  	    -- Voucher de diarios que NO son de compras
		Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,           
		ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
		Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc,                 
		ccd01ndoc,'2.3', 'Valida Fecha, debe ser del periodo  ' from #Voucher_importarOri                          
		Where ccd01emp = @Empresa And usuario = @Usuario And  ccd01tipo in ( 'C','D')                          
		And  ccd01subd in (Select ccb02cod from ccb02subd where ccb02emp=@Empresa	And ccb02aa=@Anio	and ccb02tip<>'C')             
		And (Month(Isnull(ccd01fecha,''))<>  @Mesnew Or YEAR(Isnull(ccd01ano,''))<>@Anio)        
		
  End                
                    
                                 
   -- 2.3.- Valida Libro                          
     Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo ,
   ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 --                    
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
 ccd01ndoc,'2.4', 'Valida Libro   '                        
  from #Voucher_importarOri  Left Join ccb02subd                          
       On ccd01emp = ccb02emp And ccd01subd  = ccb02cod                         
     Where ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo in ( 'C','D')               
   And Isnull(ccb02cod,'')=''                        
                              
   -- 2.4.- Valida Glosa                          
    Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , 
  
    
      
        
          
           
               
                
                  
                  
ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
        
          
            
              
                
                  
                  
ccd01ndoc,'2.5', 'Valida Glosa     '                        
 from #Voucher_importarOri                          
    Where ccd01emp = @Empresa And usuario = @Usuario And rtrim(ltrim(ISnull(ccd01glosa,'')))=''               
    And  ccd01tipo in ( 'C','D')                          
                          
-- ========== Validar datos de Detalle                          
  -- 7.- Valida Cuenta Contable                          
                          
  Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer ,                       
  ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc ,                      
   ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
 
     
      
        
          
            
              
               
           
                  
                    
 ccd01ndoc,'3.1', 'Valida Cuenta Contable  '                        
  From #Voucher_importarOri Left Join ccm01cta                          
     On ccd01emp =ccm01emp  And ccd01cta=ccm01cta And ccd01ano=ccm01aa And ccm01mov = 'S'                         
 Where ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'D'                          
  And Isnull(ccm01cta,'') =''  -- Como es Left si no esta esto debe ser nulo                        
                                
    -- 8.- Valida Moneda                          
 Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,                      
 
 ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo ,                       
ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,'3.2', 'Valida Moneda    '                        
 From #Voucher_importarOri                        
 Where ccd01emp = @Empresa And usuario = @Usuario And                          
      ccd01tipo = 'D' And ccd01moneda Not in ( 'S', 'D' )                          
                          
  -- 9.- Valida Que todos los valores sean positico                        
 Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
 ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
                  
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
        
         
             
              
                
                  
  ccd01ndoc,'3.3', 'Valida Que todos los valores sean positico'                        
 From #Voucher_importarOri                        
      Where ccd01emp = @Empresa And usuario = @Usuario And                       
      ccd01tipo = 'D' And (ccd01deb<0 Or ccd01hab<0 Or ccd01car<0 or ccd01abo<0)                        
                              
  -- 9.- Valida Solo uno tenga importe Debe o Haber                          
 Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,                      
 
 ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
        
          
            
              
                
                  
                  
 ccd01ndoc,'3.4', 'Valida Solo uno tenga importe Debe o Haber  '                        
  From #Voucher_importarOri                        
      Where ccd01emp = @Empresa And usuario = @Usuario And                          
      ccd01tipo = 'D' And (ccd01deb<>0 And ccd01hab<>0)                        
                          
  -- 10.- Valida cargo abono                        
 Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo ,                      
 
 ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
        
          
            
              
                
                  
                  
                    
  ccd01ndoc,'3.5', 'Valida Solo uno tenga importe cargo o Abono  '                        
  From #Voucher_importarOri                        
 Where ccd01emp = @Empresa And usuario = @Usuario And                          
      ccd01tipo = 'D' And (ccd01car <> 0 And ccd01abo <> 0)                        
                          
 -- -- 11.- Valida que la cuenta pida tipo de cuenta corriente y si es asi que coincida con la que se ingreso                        
 --  Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
 --  ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
 --  Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc       
 --, ccd01ndoc,'3.6', 'Valida que la cuenta pida tipo de cuenta corriente y si es asi que coincida con la que se ingreso  '                        
 --  From  #Voucher_importarOri                          
 --  Left Join ccm01cta                          
 --  On ccd01emp =  ccm01emp And ccd01ano= ccm01aa And ccd01cta = ccm01cta And ccd01ctactetipo = ccm01ana                        
 --  Where ccd01emp = @Empresa And usuario = @Usuario And                          
 --        ccd01tipo = 'D' And ISnull(ccd01ctactetipo,'')<>'' -- Traer todo los detalle que tengan tipo de cuenta cooriente                        
 --        And ISnull(ccm01ana,'')=''       -- Si no coincide va a sacar nulo en la ccm01cta                        
                             
  -- 12.- Valida Número de RUC                          
   Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
   ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
   Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc 
  
    
      
        
          
            
              
                
                  
     
                    
 , ccd01ndoc,'3.7', 'Valida Número de RUC    '                   
   From  #Voucher_importarOri                          
   Left Join ccm02cta                            
   On ccd01emp =  ccm02emp And ccd01ctactetipo = ccm02tipana And ccd01ctacteruc=ccm02cod                        
   Where ccd01emp = @Empresa And usuario = @Usuario And                          
         ccd01tipo = 'D' And ISnull(ccd01ctacteruc,'')<>'' -- Traer todo los detalle que tengan tipo de cuenta cooriente                        
         And ISnull(ccm02ruc,'')=''       -- Si no coincide va a sacar nulo en la ccm02cta                        
                    
  -- 13.- Valida Tipo de Documento           
   Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
   ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
   Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc 
  
   
       
        
          
           
               
                
                  
                  
                    
                    
 , ccd01ndoc,'3.8', 'Valida Tipo de Documento  '                        
   From  #Voucher_importarOri                          
   Left Join ccb02tipd                            
   On ccd01emp =  ccb02emp And ccd01ctactetipo = ccd01tipdoc                        
   Where ccd01emp = @Empresa And usuario = @Usuario And                          
         ccd01tipo = 'D' And ISnull(ccd01tipdoc,'')<>'' -- Traer todo los detalle que tengan tipo de cuenta cooriente                        
         And ISnull(ccd01tipdoc,'')=''       -- Si no coincide va a sacar nulo en la ccm02cta                        
                          
                         
  -- 14.- Valida que exista numero documento si es que hay cta cte                         
    Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
    ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
    Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc
  
    
      
        
          
            
 , ccd01ndoc,'3.8', 'Valida que exista numero documento si es que hay cta cte '                        
 From  #Voucher_importarOri                        
 Where ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo = 'D' And                           
   ISnull(ccd01ctacteruc,'')<>'' And Isnull(ccd01ndoc,'')=''                        
                           
                    
-- Validar que el voucher este cuadrado                    
    Insert Into #Voucher_importarError (ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car ,                       
    ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , ccd01ndoc,ccd01errorcod,ccd01errordes)                        
                    
 Select  ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo , ccd01ctacteruc , ccd01tipdoc , 
  
    
      
        
          
                    
 ccd01ndoc,'2.4', 'Valida Libro   '                        
 from #Voucher_importarOri  Left Join ccb02subd                          
 On ccd01emp = ccb02emp And ccd01subd  = ccb02cod                         
 Where ccd01emp = @Empresa And usuario = @Usuario And ccd01tipo in ( 'C','D')                          
 And Isnull(ccb02cod,'')=''                    
                    
--                    
    Insert Into #Voucher_importarError (ccd01contador,usuario, ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer,      ccd01deb ,            ccd01hab ,           ccd01car ,     ccd01abo,                    
    ccd01errordes)                        
               
 Select 0,@Usuario, ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer, Round(Sum(ccd01deb),2),Round(Sum(ccd01hab),2),Round(Sum(ccd01car),2),Round(Sum(ccd01abo),2),                    
 '3.9 Voucher No Cuadra'        
  from #Voucher_importarOri Where                         
 ccd01emp = @Empresa And usuario = @Usuario And Isnull(ccd01tipo,'')='D'  and ccd01moneda='S'                  
 Group By ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer                    
 Having ((Round(Sum(ccd01deb),2)-Round(Sum(ccd01hab),2))) > 0.2    
                  
Insert Into #Voucher_importarError (ccd01contador,usuario, ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer,      ccd01deb ,            ccd01hab ,           ccd01car ,     ccd01abo,                    
    ccd01errordes)                        
               
 Select 0,@Usuario, ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer, Round(Sum(ccd01deb),2),Round(Sum(ccd01hab),2),Round(Sum(ccd01car),2),Round(Sum(ccd01abo),2),                    
 '3.9 Voucher No Cuadra'        
  from #Voucher_importarOri Where                         
 ccd01emp = @Empresa And usuario = @Usuario And Isnull(ccd01tipo,'')='D'  and ccd01moneda='D'                  
 Group By ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer                    
 Having ((Round(Sum(ccd01car),2)-Round(Sum(ccd01abo),2))) > 0.2    
                    
-- Retornar valores                    
 Select  ccd01errorcod,ccd01errordes,                        
 ccd01contador,usuario,ccd01tipo , ccd01emp , ccd01ano , ccd01mes , ccd01subd , ccd01numer , ccd01fecha , ccd01glosa , ccd01tc , ccd01cta , ccd01moneda , ccd01deb , ccd01hab , ccd01car , ccd01abo , ccd01ctactetipo ,                       
 ccd01ctacteruc , ccd01tipdoc , ccd01ndoc                        
  from #Voucher_importarError Order by  ccd01errorcod 

Go

--Exec Spu_Con_Ins_EmpresaNuevaCopia '01','2019',''      
Alter Procedure Spu_Con_Ins_EmpresaNuevaCopia      
@EmpresaModelo  varchar(2),      
@EjercicioActual varchar(4),      
@cMsgRetorno  Varchar(100) OUTPUT        
As        
      
  Declare @UltimoCodigoEmpresa varchar(2)       
  Declare @NuevoCodigoEmpresa varchar(2)       
        
        
  Select @UltimoCodigoEmpresa = Max(Codigo) from empresa where Sistema='CONTABILID'       
  If Isnull(@UltimoCodigoEmpresa,'') =''      
  Begin      
  Set @UltimoCodigoEmpresa='01'      
 End        
      
  Set @NuevoCodigoEmpresa = dbo.IncreNumeracion(@UltimoCodigoEmpresa,1)      
        
BEGIN TRANSACTION        
        
-- Crear Empresa        
   Select * Into #New_empresa from empresa where Sistema='CONTABILID' And Codigo=@EmpresaModelo      
        
    Update #New_empresa      
 Set Codigo = @NuevoCodigoEmpresa,      
    Nombre = 'REMPLAZAR',      
    Direccion= 'REMPLAZAR',      
    Representante= 'REMPLAZAR',      
    Cargo= 'REMPLAZAR' ,      
    Matricula='',      
    Ejercicio = @EjercicioActual,      
 Ruc = 'REMPLAZAR'      
       
 Insert into empresa      
 Select * from #New_empresa      
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Empresa'      
  GOTO ManejaError        
     END        
-- Copiar Menu      
    Select * Into #New_Menus from Menus Where empresa=@EmpresaModelo      
    Update #New_Menus Set empresa=@NuevoCodigoEmpresa      
          
    Insert Into Menus      
    Select * from #New_Menus      
    IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Menu'      
  GOTO ManejaError        
     END        
          
         
-- Copiar Usuario x Menu        
   Select * into #New_menuxusuario from menuxusuario  where empresa=@EmpresaModelo      
   Update #New_menuxusuario Set empresa=@NuevoCodigoEmpresa      
         
   Insert into menuxusuario      
   Select * from #New_menuxusuario      
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Usuario X Menu '      
  GOTO ManejaError        
     END        
      
         
-- == Copiar Periodos      
 Select * into #New_ccb03per from ccb03per where ccb03emp=@EmpresaModelo      
 Update #New_ccb03per Set ccb03emp=@NuevoCodigoEmpresa      
      
 Insert Into ccb03per      
 Select * from #New_ccb03per      
      
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Periodos'      
  GOTO ManejaError        
     END        
-- Copiar plan de cuentas      
 Select * Into #New_cc26NivelesPlanCtas  from cc26NivelesPlanCtas  where cc26codempresa=@EmpresaModelo      
 Update #New_cc26NivelesPlanCtas Set cc26codempresa=@NuevoCodigoEmpresa      
       
 Insert Into cc26NivelesPlanCtas      
 Select * from #New_cc26NivelesPlanCtas      
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Estructura Plan de Cuentas'      
  GOTO ManejaError        
     END        
       
 -- Plan de ceuntas       
 Select * into #New_ccm01cta from ccm01cta  Where ccm01emp=@EmpresaModelo      
 Update #New_ccm01cta Set ccm01emp=@NuevoCodigoEmpresa      
       
 Insert into ccm01cta      
 Select * from #New_ccm01cta      
       
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Plan de Cuentas'      
  GOTO ManejaError        
     END        
-- Copiar Asientos Tipos  
 Select * into #ccc03astip FROM ccc03astip where    ccc03emp=@EmpresaModelo  
 Update #ccc03astip Set ccc03emp=@NuevoCodigoEmpresa  
 Insert into ccc03astip  
 Select * from #ccc03astip  
   
  IF @@ERROR <> 0        
  BEGIN        
 SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Asiento Tipo Cabecera'      
 GOTO ManejaError        
  END  
    
-- Copiar detalle Asiento Tipo    
 Select * into #ccd03astip FROM ccd03astip  where ccd03emp=@EmpresaModelo  
 Update #ccd03astip Set ccd03emp=@NuevoCodigoEmpresa  
   
 Insert into ccd03astip  
 Select * from #ccd03astip  
   
IF @@ERROR <> 0        
  BEGIN        
 SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Asiento Tipo Detalle'      
 GOTO ManejaError        
  END  
     
  
-- Copiar tipo de analisis        
   Select * into #New_ccb17ana from ccb17ana where ccb17emp=@EmpresaModelo      
   Update #New_ccb17ana set ccb17emp=@NuevoCodigoEmpresa      
         
   Insert into ccb17ana      
   Select * from #New_ccb17ana      
         
   IF @@ERROR <> 0        
  BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Tipo Analisis'      
  GOTO ManejaError        
  END        
        
 --  Copiar Libros      
  Select * Into #New_ccb02subd from ccb02subd Where ccb02emp=@EmpresaModelo      
  Update #New_ccb02subd Set ccb02emp=@NuevoCodigoEmpresa      
        
  Insert Into ccb02subd          
  Select * from #New_ccb02subd      
  IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Libro'      
  GOTO ManejaError        
     END        
      
-- Tipo Documento      
 Select * Into #New_ccb02tipd from  ccb02tipd  Where ccb02emp=@EmpresaModelo      
 Update #New_ccb02tipd Set ccb02emp=@NuevoCodigoEmpresa      
      
 Insert into ccb02tipd      
 Select * from #New_ccb02tipd      
       
 IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar Tipo Documento'      
  GOTO ManejaError        
     END        
           
      
-- Formato de reportes      
--Balance General        
  Select * Into #New_cc01estructbalgenComp from cc01estructbalgenComp where cc01empresa=@EmpresaModelo      
  Update #New_cc01estructbalgenComp Set cc01empresa=@NuevoCodigoEmpresa      
        
  Insert Into cc01estructbalgenComp        
  Select * from #New_cc01estructbalgenComp      
  IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar estructura Balance'      
  GOTO ManejaError        
     END        
  -- EEGyP        
  Select * Into #New_cc01estructEGyPComp from cc01estructEGyPComp where cc01empresa=@EmpresaModelo      
  Update #New_cc01estructEGyPComp Set cc01empresa=@NuevoCodigoEmpresa      
        
  Insert Into cc01estructEGyPComp      
  Select * from #New_cc01estructEGyPComp      
        
  IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar estructura EGYP'      
  GOTO ManejaError        
     END        
           
  -- EGyP -Formato Legal        
  Select * into #New_cc01estructegp  from cc01estructegp  where cc01empresa=@EmpresaModelo      
  Update #New_cc01estructegp Set cc01empresa=@NuevoCodigoEmpresa      
        
  Insert Into cc01estructegp        
  Select * from #New_cc01estructegp      
        
  IF @@ERROR <> 0        
    BEGIN        
  SELECT @cMsgRetorno = 'ERROR :: No se Pudo copiar estructura Formato Legal'      
  GOTO ManejaError        
     END        
       
        
  /* Grabo las Operaciones si Elimino Bien */        
SELECT @cMsgRetorno = 'OK : Se creo empresa con exito '        
COMMIT TRANSACTION        
RETURN 0        
        
/* Deshago las Operaciones si Ocurrio algun Error */        
ManejaError:        
ROLLBACK TRANSACTION        
RETURN -1

Go

Set quoted_identifier off
--Delete from ccb01rngimp Where ccb01usu='A' and left(ccb01valor,2)<>'10'        
---Select top 2 * from ccd                    
--Exec Sp_Con_Rep_LibroMayorAnalitico '01','2013','06','S','A','1','',''        
Alter Procedure [dbo].[sp_Con_Rep_LibroMayorAnalitico]        
/*--------------------------------------------------------------------------*/                      
/* Objetivo   : Libro Mayor                                                 */                      
/* Actualiza  :                                                             */                      
/* Creado Por : Miguel Angel Valverde Malaga                                */                      
/* Fecha      : 05/08/1999                                                  */                      
/*--------------------------------------------------------------------------*/                      
@cEmpresa     varchar(2), -- Codigo de Empresa                      
@Ano       varchar(4), -- Aoo de Proceso                      
@Mes       varchar(2), -- 01..15                      
@Moneda      varchar(1), -- Moneda (S=Soles, D=Dolares, P=Dolar Promedio)                      
@Usuario     varchar(8),  -- Usuario                      
@Tipo       varchar(1), -- 1=Por Periodo, 2=Por Rango de Fechas,3 Por Rango de Meses                  
@Fecha_Inicio   varchar(10), -- Fecha Inicio                      
@Fecha_Fin      varchar(10) -- Fecha Final del Reporte                      
                      
AS                      
                  
                  
                      
Declare @Saldo_Debe varchar(300)                      
Declare @Saldo_Haber varchar(300)                      
Declare @Saldo_Cargo varchar(300)                      
declare @Saldo_Abono varchar(300)                      
                      
declare @Debe_Actual varchar(300)                      
declare @Haber_Actual varchar(300)                      
declare @Cargo_Actual varchar(300)                      
declare @Abono_Actual varchar(300)                      
                      
                      
                      
declare @nDolar_Promedio float                      
declare @Dolar_Promedio varchar(15)                      
                  
--======= Para Rango por periodo                  
Declare @MesIni char(2)                  
Declare @MesFin char(2)                  
                   
Set @MesIni=left(ltrim(rtrim(@Fecha_Inicio)),2)                  
Set @MesFin=left(ltrim(rtrim(@Fecha_Fin)),2)                  
        
                  
If @Tipo='3'                  
 Begin                  
  Set @Mes=@MesIni                  
 End                  
               
                      
If @Moneda = 'P'                      
    Begin                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'D', 'A', 'Scta.', 'N', @Saldo_Debe OUTPUT                      
                
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'H', 'A', 'Scta.', 'N', @Saldo_Haber OUTPUT                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'D', 'A', 'Scta.', 'P', @Saldo_Cargo OUTPUT                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'H', 'A', 'Scta.', 'P', @Saldo_Abono OUTPUT                      
                         
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'D', 'M', 'Scta.', 'N', @Debe_Actual OUTPUT                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'H', 'M', 'Scta.', 'N', @Haber_Actual OUTPUT                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'D', 'M', 'Scta.', 'P', @Cargo_Actual OUTPUT                      
    Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'H', 'M', 'Scta.', 'P', @Abono_Actual OUTPUT                      
                        
                        
    Execute sp_Con_Dolar_Promedio @cEmpresa, @Ano, @Mes, @nDolar_Promedio OUTPUT                      
   If @nDolar_Promedio In (0.00, null) SELECT @nDolar_Promedio = 1.00                      
   SELECT @Dolar_Promedio = LTRIM(CONVERT(Char(15),@nDolar_Promedio))              
 End                      
Else                      
    Begin                      
  If @Tipo='3'      
   Begin      
          
      Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @MesIni, 'S', 'D', 'A', 'Scta.', 'N', @Saldo_Debe OUTPUT                    
      Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @MesIni, 'S', 'H', 'A', 'Scta.', 'N', @Saldo_Haber OUTPUT          
      Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @MesIni, 'D', 'D', 'A', 'Scta.', 'N', @Saldo_Cargo OUTPUT                    
      Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @MesIni, 'D', 'H', 'A', 'Scta.', 'N', @Saldo_Abono OUTPUT                
    -- No hay importes del mes      
        SELECT @Dolar_Promedio = LTRIM(CONVERT(Char(15),1.00))                    
       
   End      
  Else      
   Begin      
      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'D', 'A', 'Scta.', 'N', @Saldo_Debe OUTPUT                      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'H', 'A', 'Scta.', 'N', @Saldo_Haber OUTPUT            
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'D', 'A', 'Scta.', 'N', @Saldo_Cargo OUTPUT                      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'H', 'A', 'Scta.', 'N', @Saldo_Abono OUTPUT                      
                         
                         
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'D', 'M', 'Scta.', 'N', @Debe_Actual OUTPUT                      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'S', 'H', 'M', 'Scta.', 'N', @Haber_Actual OUTPUT                      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'D', 'M', 'Scta.', 'N', @Cargo_Actual OUTPUT                      
     Execute sp_Con_Dame_Cadena_Saldo @cEmpresa, @Ano, @Mes, 'D', 'H', 'M', 'Scta.', 'N', @Abono_Actual OUTPUT                      
     SELECT @Dolar_Promedio = LTRIM(CONVERT(Char(15),1.00))                      
   End      
   End                      
                      
 Declare @Mayor_Tempo Table           
(          
          
  Saldo_Debe  float,          
  Saldo_Haber float,          
  Saldo_Cargo float,          
  Saldo_Abono float,          
                      
  Debe_Actual float,          
  Haber_Actual float,          
  Cargo_Actual float,          
  Abono_Actual float,          
                      
  Saldo_ImpCargo float,          
  Saldo_ImpAbono float,          
                      
  ImpCargo_Actual float,          
  ImpAbono_Actual float,          
                       
   Ano   char(4),           
 Mes   char(2),           
 Cuenta   varchar(15),          
nroorden int,        
 Nombre_Cuenta  varchar(60),          
 Mov_Cuenta  char(1),          
   Libro   varchar(2),          
 Voucher  varchar(5),          
   Fecha   datetime,          
 Tipo_Documento   varchar(2),          
   Numero_Documento varchar(20),          
 Cuenta_Corriente varchar(11),          
 Glosa   varchar(100),          
   Centro_Costo  varchar(12),          
 Centro_Gestion  varchar(6),          
 Moneda   char(1),           
 Tipo_Cambio  float,          
 Tip_Ana  char(2),          
   Debe   float,          
   Haber   float,          
   Cargo   float,          
   Abono   float,          
   ImpCargo  float,          
   ImpAbono  float,          
   ccd01codmaquina varchar(3),          
 ccd01codtraencurso   varchar(3)          
          
)          
          
          
          
          
          
If @Tipo = '1' -- Por Per­odo                      
Begin                     
 Insert into @Mayor_Tempo (Saldo_Debe,Saldo_Haber,          
Saldo_Cargo,Saldo_Abono,Debe_Actual,Haber_Actual,Cargo_Actual,Abono_Actual,          
Saldo_ImpCargo,Saldo_ImpAbono,ImpCargo_Actual,ImpAbono_Actual,Ano,Mes,Cuenta,nroorden,          
Nombre_Cuenta,Mov_Cuenta,Libro,Voucher,Fecha,Tipo_Documento,     
Numero_Documento,Cuenta_Corriente,Glosa,Centro_Costo,          
Centro_Gestion,Moneda,Tipo_Cambio,Tip_Ana,Debe,Haber,Cargo,          
Abono,ImpCargo,ImpAbono,ccd01codmaquina,ccd01codtraencurso)            
 Execute ("                      
 SELECT              
              
  Saldo_Debe = " + @Saldo_Debe + ",              
  Saldo_Haber = " + @Saldo_Haber + ",                      
  Saldo_Cargo = " + @Saldo_Cargo + ",                       
  Saldo_Abono = " + @Saldo_Abono + ",                       
                      
  Debe_Actual = " + @Debe_Actual + ",                       
  Haber_Actual = " + @Haber_Actual + ",                      
  Cargo_Actual = " + @Cargo_Actual + ",                       
  Abono_Actual = " + @Abono_Actual + ",                       
                      
  Saldo_ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Debe + " ELSE " + @Saldo_Cargo + " END,                       
  Saldo_ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Haber + " ELSE " + @Saldo_Abono + " END,                      
                      
  ImpCargo_Actual = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Debe_Actual + " ELSE " + @Cargo_Actual + " END,                      
  ImpAbono_Actual = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Haber_Actual + " ELSE " + @Abono_Actual + " END,                      
                       
  Ano = ccd01ano, Mes = ccd01mes, Cuenta = Cta.ccm01cta,ccd01ord, Nombre_Cuenta = Cta.ccm01des,Mov_Cuenta = Cta.ccm01Mov,                       
  Libro = ccd01subd, Voucher = ccd01numer,             
  Fecha = ccd01fevou, Tipo_Documento = ccd01tipdoc,                       
  Numero_Documento = ccd01ndoc, Cuenta_Corriente = ccd01cod, Glosa = Isnull(ccd01Comprobante,'') + ' '+  lower(isnull(ccd01con,'')),                       
  Centro_Costo = ccd01cc, Centro_Gestion = ccd01cg, Moneda = ccd01dn, Tipo_Cambio = ccd01tc, Tip_Ana = ccd01ana,              
  Debe = ccd01deb,                       
  Haber = ccd01hab,                       
  Cargo = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) Else ccd01car END,                       
  Abono = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) Else ccd01abo END,                      
  ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01deb WHEN 'D' THEN ccd01car ELSE ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) END,                      
  ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01hab WHEN 'D' THEN ccd01abo ELSE ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) END                
  ,ccd01codmaquina,ccd01codtraencurso            
          
          
-- ===============          
          
 FROM ccm01cta Cta     
 inner Join  v_ccdcta_01 Scta on     
   Cta.ccm01emp = SCta.ccm01emp    
 And Cta.ccm01aa= SCta.ccm01ano    
 And Cta.ccm01cta = Scta.ccm01cta    
 Inner Join ccb01rngimp r  On    
 Cta.ccm01emp = r.ccb01emp     
  And Cta.ccm01cta = r.ccb01valor      
 Left Join ccd On     
  SCta.ccm01emp = ccd01emp    
 And SCta.ccm01ano = ccd01ano    
 And Scta.ccm01cta = ccd01cta    
 AND ccd01mes = '" + @Mes + "'    
WHERE     
     Cta.ccm01emp = '" + @cEmpresa + "'    
 And Cta.ccm01aa = '" + @Ano + "'    
 And r.ccb01usu = '" + @Usuario + "'    
 And r.ccb01pro = 'LIBMAYORAN'        
  Order By ccd01ano, ccd01mes, Scta.ccm01cta,ccd01subd, ccd01numer,ccd01ord                         
 ")                      
End                      
                      
Else If @Tipo = '2' -- Por Rango de Fechas                      
Begin            
 Insert into @Mayor_Tempo (Saldo_Debe,Saldo_Haber,          
Saldo_Cargo,Saldo_Abono,Debe_Actual,Haber_Actual,Cargo_Actual,Abono_Actual,          
Saldo_ImpCargo,Saldo_ImpAbono,ImpCargo_Actual,ImpAbono_Actual,Ano,Mes,Cuenta,nroorden,        
Nombre_Cuenta,Mov_Cuenta,Libro,Voucher,Fecha,Tipo_Documento,          
Numero_Documento,Cuenta_Corriente,Glosa,Centro_Costo,          
Centro_Gestion,Moneda,Tipo_Cambio,Tip_Ana,Debe,Haber,Cargo,          
Abono,ImpCargo,ImpAbono,ccd01codmaquina,ccd01codtraencurso)                     
 Execute ("                      
 SELECT                      
  /*                    
  Saldo_Debe = " + @Saldo_Debe + ",                       
  Saldo_Haber = " + @Saldo_Haber + ",                      
  Saldo_Cargo = " + @Saldo_Cargo + ",                       
  Saldo_Abono = " + @Saldo_Abono + ",                      
                      
  Debe_Actual = " + @Debe_Actual + ",                       
  Haber_Actual = " + @Haber_Actual + ",                      
  Cargo_Actual = " + @Cargo_Actual + ",                       
  Abono_Actual = " + @Abono_Actual + ",                       
                      
  Saldo_ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Debe + " ELSE " + @Saldo_Cargo + " END,                      
  Saldo_ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Haber + " ELSE " + @Saldo_Abono + " END,                      
  */                    
  Saldo_Debe = 0,                       
  Saldo_Haber = 0,                      
  Saldo_Cargo = 0,                       
  Saldo_Abono = 0,                      
                      
  Debe_Actual = 0,                       
  Haber_Actual = 0,                      
  Cargo_Actual = 0,                       
  Abono_Actual = 0,                       
                      
  Saldo_ImpCargo = 0,                      
  Saldo_ImpAbono = 0,                      
  ImpCargo_Actual = 0,                      
  ImpAbono_Actual = 0,                      
                    
                      
  Ano = ccd01ano, Mes = ccd01mes, Cuenta = ccd01cta,ccd01ord, Nombre_Cuenta = Cta.ccm01des,Mov_Cuenta = Cta.ccm01Mov,                        
  Libro = ccd01subd, Voucher = ccd01numer, Fecha = ccd01fevou, Tipo_Documento = ccd01tipdoc,                       
  Numero_Documento = ccd01ndoc, Cuenta_Corriente = ccd01cod, Glosa = Isnull(ccd01Comprobante,'') + ' '+  lower(isnull(ccd01con,'')),                    
  Centro_Costo = ccd01cc, Centro_Gestion = ccd01cg, Moneda = ccd01dn, Tipo_Cambio = ccd01tc, Tip_Ana = ccd01ana,                      
  Debe = ccd01deb,                       
  Haber = ccd01hab,                       
  Cargo = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) Else ccd01car End,                       
  Abono = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) Else ccd01abo End,                      
  ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01deb WHEN 'D' THEN ccd01car ELSE ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) END,                      
  ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01hab WHEN 'D' THEN ccd01abo ELSE ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) END                       
  ,ccd01codmaquina,ccd01codtraencurso            
 FROM ccd, ccm01cta Cta, v_ccdcta_01 Scta ,ccb01rngimp r                     
 WHERE ccd01cta = Cta.ccm01cta                      
   And ccd01emp = '" + @cEmpresa + "'                 
   And ccd01ano = ccm01ano                       
   And ccd01fevou >= CONVERT(datetime,'" + @Fecha_Inicio + "',103)                      
   And ccd01fevou <= CONVERT(datetime,'" + @Fecha_Fin + "',103)                      
   And Cta.ccm01cta = r.ccb01valor  And  ccb01emp = '" + @cEmpresa + "' And ccb01usu = '" + @Usuario + "' And ccb01pro = 'LIBMAYORAN'        
   And Cta.ccm01emp = '" + @cEmpresa + "'                      
   And Cta.ccm01aa = '" + @Ano + "'                      
   And Cta.ccm01cta = ccd01cta                      
   And SCta.ccm01emp = '" + @cEmpresa + "'                  
   And SCta.ccm01ano = '" + @Ano + "'                  
   And Scta.ccm01cta = Cta.ccm01cta                  
 Order By ccd01ano, ccd01mes, Scta.ccm01cta, ccd01subd, ccd01numer, ccd01ord                    
 ")                  
End                  
Else If @Tipo = '3' -- Por rango de Meses                  
Begin                   
  Insert into @Mayor_Tempo (Saldo_Debe,Saldo_Haber,          
 Saldo_Cargo,Saldo_Abono,Debe_Actual,Haber_Actual,Cargo_Actual,Abono_Actual,          
 Saldo_ImpCargo,Saldo_ImpAbono,ImpCargo_Actual,ImpAbono_Actual,Ano,Mes,Cuenta,nroorden,          
 Nombre_Cuenta,Mov_Cuenta,Libro,Voucher,Fecha,Tipo_Documento,          
 Numero_Documento,Cuenta_Corriente,Glosa,Centro_Costo,          
 Centro_Gestion,Moneda,Tipo_Cambio,Tip_Ana,Debe,Haber,Cargo,          
 Abono,ImpCargo,ImpAbono,ccd01codmaquina,ccd01codtraencurso)           
             
 Execute ("                      
 SELECT  Saldo_Debe = " + @Saldo_Debe + ",                       
  Saldo_Haber = " + @Saldo_Haber + ",                      
  Saldo_Cargo = " + @Saldo_Cargo + ",                       
  Saldo_Abono = " + @Saldo_Abono + ",                       
                      
  Debe_Actual = 0,                       
  Haber_Actual = 0,                      
  Cargo_Actual = 0,                    
  Abono_Actual = 0,                       
                      
  Saldo_ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Debe + " ELSE " + @Saldo_Cargo + " END,                       
  Saldo_ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN " + @Saldo_Haber + " ELSE " + @Saldo_Abono + " END,                      
                      
  ImpCargo_Actual = 0,                      
  ImpAbono_Actual = 0,                      
                       
  Ano = ccd01ano, Mes = ccd01mes, Cuenta = Cta.ccm01cta,ccd01ord, Nombre_Cuenta = Cta.ccm01des,Mov_Cuenta = Cta.ccm01Mov,                       
  Libro = ccd01subd, Voucher = ccd01numer, Fecha = ccd01fevou, Tipo_Documento = ccd01tipdoc,                       
  Numero_Documento = ccd01ndoc, Cuenta_Corriente = ccd01cod, Glosa = Isnull(ccd01Comprobante,'') + ' '+  lower(isnull(ccd01con,'')),                       
  Centro_Costo = ccd01cc, Centro_Gestion = ccd01cg, Moneda = ccd01dn, Tipo_Cambio = ccd01tc, Tip_Ana = ccd01ana,                      
  Debe = ccd01deb,                       
  Haber = ccd01hab,                       
  Cargo = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) Else ccd01car END,                       
  Abono = CASE '" + @Moneda + "' WHEN 'P' THEN ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) Else ccd01abo END,                      
  ImpCargo = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01deb WHEN 'D' THEN ccd01car ELSE ROUND( ccd01deb / " + @Dolar_Promedio + ",2 ) END,                      
  ImpAbono = CASE '" + @Moneda + "' WHEN 'S' THEN ccd01hab WHEN 'D' THEN ccd01abo ELSE ROUND( ccd01hab / " + @Dolar_Promedio + ",2 ) END                
  ,ccd01codmaquina,ccd01codtraencurso    
      
 FROM ccm01cta Cta     
 inner Join  v_ccdcta_01 Scta on     
   Cta.ccm01emp = SCta.ccm01emp    
 And Cta.ccm01aa= SCta.ccm01ano    
 And Cta.ccm01cta = Scta.ccm01cta    
 Inner Join ccb01rngimp r  On    
 Cta.ccm01emp = r.ccb01emp     
  And Cta.ccm01cta = r.ccb01valor      
 Left Join ccd On     
  SCta.ccm01emp = ccd01emp    
 And SCta.ccm01ano = ccd01ano    
 And Scta.ccm01cta = ccd01cta    
 AND ccd01mes >= '" + @MesIni + "'    
 And ccd01mes <= '" + @MesFin + "'    
WHERE     
     Cta.ccm01emp = '" + @cEmpresa + "'    
 And Cta.ccm01aa = '" + @Ano + "'    
 And Cta.ccm01Mov='S'    
 And r.ccb01usu = '" + @Usuario + "'    
 And r.ccb01pro = 'LIBMAYORAN'        
  Order By ccd01ano, ccd01mes, Scta.ccm01cta,ccd01subd, ccd01numer,ccd01ord            
  ")          
End          
          
          
--          
Select Saldo_Debe,Saldo_Haber,          
 Saldo_Cargo,Saldo_Abono,Debe_Actual,Haber_Actual,Cargo_Actual,Abono_Actual,          
 Saldo_ImpCargo,Saldo_ImpAbono,ImpCargo_Actual,ImpAbono_Actual,Ano,Mes,Cuenta,          
 Nombre_Cuenta,Mov_Cuenta,Libro,Voucher,Fecha,Tipo_Documento,          
 Numero_Documento,Cuenta_Corriente,Glosa,Centro_Costo,          
 Centro_Gestion,Moneda,Tipo_Cambio,Tip_Ana,Debe,Haber,Cargo,          
 Abono,ImpCargo,ImpAbono,ccd01codmaquina,ccd01codtraencurso          
from @Mayor_Tempo        
Order by Ano,Mes,Cuenta,Libro,Voucher,Fecha    

Go

Go
--Select * from ccb01rngimp  
  
--Select top 2 * From ccd        
--SP_HELP CCM02CTA        
--SP_HELP tmpctacte        
--EXEC sp_Con_Rep_AnalisisCtaCte '01','2021','11','S','C','12111','joseluis','1'        
Alter PROCEDURE [dbo].[sp_Con_Rep_AnalisisCtaCte]        
/*--------------------------------------------------------------------------*/        
/* Objetivo   : Analisis de Cuenta Corriente                                */        
/* Actualiza  :                                                             */        
/* Fecha      : 11/08/1999                                                  */        
/*--------------------------------------------------------------------------*/        
        
@cEmpresa  varchar(2),  -- Codigo de Empresa        
@Ano   varchar(4),  -- Aoo Proceso        
@Mes   varchar(2),  -- Mes Proceso        
@Moneda  varchar(1),  -- Moneda        
@TipoRep  varchar(1),  -- TipoRep : C=Cuenta, T=Tercero        
@Cuenta  varchar(15),  -- Cuenta Contable        
@Usuario  varchar(8),  -- Usuario        
@Tipo   varchar(1)  -- Tipo : 1=Pendiente, 2=Cancelados, 3=Historicos        
AS        
        
declare @nDolar_Promedio float        
        
--Creo Una Tabla Temporal y Lleno Con Los Valores De la detalles de voucher(CCD)          
Create Table #TmpCtaCte1(        
Ano               VarChar(4) ,         
Mes               VarChar(2) ,        
Cuenta            VarChar(15),        
Nombre_Cuenta     VarChar(100),        
Cuenta_Corriente  VarChar(12),         
Nombre_CC         VarChar(100),        
Libro             VarChar(2) ,         
Voucher           VarChar(5) ,         
Fecha             DateTime,         
Fecha_Documento   DateTime,         
Tipo_Documento    VarChar(2) ,         
Numero_Documento  VarChar(15),         
Fecha_Vencimiento DateTime,         
Glosa             VarChar(100) ,         
Debe              Float Default (0),         
Haber             Float Default (0),         
Cargo             Float Default (0),         
Abono             Float Default (0),         
ImpCargo          Float Default (0),         
ImpAbono          Float Default (0)            
 )        
        
--Creo tabala temporal cta cte 2 y se llena apartir de la primera temporal        
Create Table #TmpCtaCte2(        
Ano               VarChar(4) DEFAULT (''),         
Mes               VarChar(2) DEFAULT (''),        
Cuenta            VarChar(15) DEFAULT (''),        
Nombre_Cuenta     VarChar(100) DEFAULT (''),        
Cuenta_Corriente  VarChar(12) DEFAULT (''),         
Nombre_CC         VarChar(100) DEFAULT (''),        
Libro             VarChar(2) DEFAULT (''),         
Voucher           VarChar(5) DEFAULT (''),         
Fecha             DateTime,         
Fecha_Documento   DateTime,         
Tipo_Documento    VarChar(2) DEFAULT (''),         
Numero_Documento  VarChar(15) DEFAULT (''),         
Fecha_Vencimiento DateTime,         
Glosa             VarChar(100) DEFAULT (''),         
Debe              Float Default (0),         
Haber             Float Default (0),         
Cargo             Float Default (0),         
Abono             Float Default (0),         
ImpCargo          Float Default (0),         
ImpAbono          Float Default (0)            
 )        
        
--Deleteo mi tabla de ctas ctes        
delete tmpctacte where usuario = @usuario        
        
--Traigo el dolar promedio        
Execute sp_Con_Dolar_Promedio @cEmpresa, @Ano, @Mes, @nDolar_Promedio OUTPUT        
        
If @nDolar_Promedio In (0.00, null) Select @nDolar_Promedio = 1.00        
        
--========== si son por cuenta=============        
--========================================         
If @TipoRep = "C"        
     Begin        
   If @Tipo = "1" or  @Tipo = "2"        
     begin         
                 Insert into #TmpCtaCte1(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,        
                 Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono)        
                       
    Select ccd01ano,ccd01mes,ccd01cta,cta.ccm01des,ccd01cod,cte.ccm02nom,ccd01subd,ccd01numer,ccd01fevou,ccd01fedoc,         
                        ccd01tipdoc,ccd01ndoc,ccd01feven,isnull(ccd01Comprobante,'') + space(2)+ ccd01con,ccd01deb,ccd01hab,         
                 Case @Moneda When 'P' Then Round(ccd01deb/@nDolar_Promedio,2) Else ccd01car End,         
                        Case @Moneda When 'P' Then Round(ccd01hab/@nDolar_Promedio,2) Else ccd01abo End,         
                 Case @Moneda When 'S' THEN ccd01deb When 'D' THEN ccd01car When 'P' Then Round(ccd01deb/@nDolar_Promedio,2) End,         
            Case @Moneda When 'S' THEN ccd01hab When 'D' THEN ccd01abo When 'P' Then Round(ccd01hab/@nDolar_Promedio,2) End         
         --  From ccd det , ccm01cta cta , ccm02cta cte         
                 From ccd det, ccm01cta cta, ccm02cta cte         
                 Where ccd01emp = @cEmpresa        
                 And ccd01ano = @Ano        
                 And ccd01mes <= @Mes        
                 And isnull(ccd01ana, "") <> ""        
                 And isnull(ccd01cod, "") <> ""        
                 And det.ccd01cta in (select ccb01valor from ccb01rngimp where ccb01emp = @cEmpresa And ccb01usu = @Usuario and ccb01pro = "ANCTACTECU")        
                 And cta.ccm01emp = @cEmpresa        
           And cta.ccm01aa = @Ano         
                 And cta.ccm01cta = det.ccd01cta        
                 And cte.ccm02emp = @cEmpresa        
                 And cte.ccm02tipana = det.ccd01ana        
                 And cte.ccm02cod = det.ccd01cod        
                 Order By det.ccd01ano, det.ccd01mes, det.ccd01cta, det.ccd01ana, det.ccd01cod, det.ccd01tipdoc, det.ccd01ndoc,det.ccd01fedoc        
              
                 update #TmpCtaCte1        
                 set fecha = Fecha,Fecha_Documento = Fecha_Documento,      
     Fecha_Vencimiento = Fecha_Vencimiento,        
                 glosa = isnull(glosa,'')        
              
                 insert into #TmpCtaCte2(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono,Fecha,Fecha_Documento,Fecha_Vencimiento,Glosa,libro,voucher)        
        
                 select @Ano,@Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,        
                 isnull(sum(Debe),0),isnull(sum(Haber),0),isnull(sum(Cargo),0),isnull(sum(Abono),0),isnull(sum(ImpCargo),0),isnull(sum(ImpAbono),0),        
           min(Fecha),min(Fecha_Documento),min(Fecha_Vencimiento),isnull(min(Glosa),''),        
           isnull(min(libro),''),isnull(min(voucher),'')        
                 from #TmpCtaCte1        
                Group By Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento         
     End        
         
 If @Tipo = "3"        
           begin         
                 insert into #TmpCtaCte1(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,        
                 Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono)        
                 Select ccd01ano,ccd01mes,ccd01cta,cta.ccm01des,ccd01cod,cte.ccm02nom,ccd01subd,ccd01numer,ccd01fevou,ccd01fedoc,         
                        ccd01tipdoc,ccd01ndoc,ccd01feven,isnull(ccd01Comprobante,'') + space(2)+ ccd01con,ccd01deb,ccd01hab,         
                 Case @Moneda When "P" Then Round(ccd01deb/@nDolar_Promedio,2) Else ccd01car End,         
                        Case @Moneda When "P" Then Round(ccd01hab/@nDolar_Promedio,2) Else ccd01abo End,         
                 Case @Moneda When 'S' THEN ccd01deb When 'D' THEN ccd01car When 'P' Then Round(ccd01deb/@nDolar_Promedio,2) End,         
                 Case @Moneda When 'S' THEN ccd01hab When 'D' THEN ccd01abo When 'P' Then Round(ccd01hab/@nDolar_Promedio,2) End         
               --  From ccd det , ccm01cta cta , ccm02cta cte       
                 From ccd det, ccm01cta cta, ccm02cta cte         
                 Where ccd01emp = @cEmpresa        
                 And ccd01ano = @Ano        
                 And ccd01mes <= @Mes        
                 And isnull(ccd01ana, "") <> ""        
                 And isnull(ccd01cod, "") <> ""        
                 And det.ccd01cta in (select ccb01valor from ccb01rngimp where ccb01emp = @cEmpresa And ccb01usu = @Usuario and ccb01pro = "ANCTACTECU")        
             And cta.ccm01emp = @cEmpresa        
                 And cta.ccm01cta = det.ccd01cta        
          And cta.ccm01aa = @Ano        
                 And cte.ccm02emp = @cEmpresa        
                 And cte.ccm02tipana = det.ccd01ana        
                 And cte.ccm02cod = det.ccd01cod        
                 Order By det.ccd01ano, det.ccd01mes, det.ccd01cta, det.ccd01ana, det.ccd01cod, det.ccd01tipdoc, det.ccd01ndoc,det.ccd01fedoc        
              
        --update #TmpCtaCte1        
        --set fecha = isnull(Fecha,''),Fecha_Documento = isnull(Fecha_Documento,''),Fecha_Vencimiento = isnull(Fecha_Vencimiento,''),        
        --glosa = isnull(glosa,'')        
              
                 insert into #TmpCtaCte2(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono,Fecha,Fecha_Documento,Fecha_Vencimiento,Glosa,libro,voucher)        
                 select @Ano,@Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,        
                 isnull(Debe,0),isnull(Haber,0),isnull(Cargo,0),isnull(Abono,0),isnull(ImpCargo,0),isnull(ImpAbono,0),Fecha,Fecha_Documento,Fecha_Vencimiento,isnull(Glosa,''),isnull(libro,''),isnull(voucher,'')        
                 from #TmpCtaCte1        
        --Group By Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento         
     End        
          
  -- Eliminar los importes que no se nesecitan      
      
  If @Tipo = "1"  -- Pendientes        
       Begin        
                  IF @Moneda = 'S'        
                     Begin        
                         delete #TmpCtaCte2 where round(Debe-Haber,2) = 0        
                   End        
                   Else        
                     Begin        
                         delete #TmpCtaCte2 where round(Cargo-Abono,2) = 0        
                     End        
       End        
  Else If @Tipo = "2"  -- Cancelados        
      Begin        
                  IF @Moneda = 'S'        
                     Begin        
                         delete #TmpCtaCte2 where round(Debe-Haber,2) <> 0        
                     End        
                  Else        
                     Begin          
         delete #TmpCtaCte2 where round(Cargo-Abono,2) <> 0        
                     End        
      End        
  Else If @Tipo = "3"  -- Historico        
      Begin        
                select @Tipo = "3"        
      End        
        
        
    End        
        
--=============Si Es Tipo De Cuenta Corriente Terceros ========        
--==============================================================        
        
Else If @TipoRep = "T"        
      Begin        
          If @Tipo = "1" or  @Tipo = "2"        
           begin         
                insert into #TmpCtaCte1(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,        
                Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono)        
                Select ccd01ano,ccd01mes,ccd01cta,cta.ccm01des,ccd01cod,cte.ccm02nom,ccd01subd,ccd01numer,ccd01fevou,ccd01fedoc,         
                   ccd01tipdoc,ccd01ndoc,ccd01feven,isnull(ccd01Comprobante,'') + space(2)+ ccd01con,ccd01deb,ccd01hab,         
            Case @Moneda When "P" Then Round(ccd01deb/@nDolar_Promedio,2) Else ccd01car End,         
            Case @Moneda When "P" Then Round(ccd01hab/@nDolar_Promedio,2) Else ccd01abo End,         
            Case @Moneda When 'S' THEN ccd01deb When 'D' THEN ccd01car When 'P' Then Round(ccd01deb/@nDolar_Promedio,2) End,         
            Case @Moneda When 'S' THEN ccd01hab When 'D' THEN ccd01abo When 'P' Then Round(ccd01hab/@nDolar_Promedio,2) End         
               -- From ccd det , ccm01cta cta , ccm02cta cte     
                From ccd det, ccm01cta cta, ccm02cta cte         
                Where ccd01emp = @cEmpresa        
                And ccd01ano = @Ano        
                And ccd01mes <= @Mes        
                And isnull(ccd01ana, "") <> ""        
                And isnull(ccd01cod, "") <> ""        
                And det.ccd01cta = @Cuenta        
                And det.ccd01ana + det.ccd01cod in (select ccb01valor from ccb01rngimp where ccb01emp = @cEmpresa And ccb01usu = @Usuario and ccb01pro = "ANCTACTETE")        
                And cta.ccm01emp = @cEmpresa        
         And cta.ccm01aa = @Ano        
                And cta.ccm01cta = det.ccd01cta        
                And cte.ccm02emp = @cEmpresa        
                And cte.ccm02tipana = det.ccd01ana        
                And cte.ccm02cod = det.ccd01cod        
                Order By det.ccd01ano, det.ccd01mes, det.ccd01cta, det.ccd01ana, det.ccd01cod, det.ccd01tipdoc, det.ccd01ndoc,det.ccd01fedoc        
             
                update #TmpCtaCte1        
                set glosa = isnull(glosa,'')        
             
       insert into #TmpCtaCte2(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono,Fecha,Fecha_Documento,Fecha_Vencimiento,Glosa,libro,voucher)        
                select @Ano,@Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,        
                isnull(sum(Debe),0),isnull(sum(Haber),0),isnull(sum(Cargo),0),isnull(sum(Abono),0),isnull(sum(ImpCargo),0),isnull(sum(ImpAbono),0),min(Fecha),min(Fecha_Documento),min(Fecha_Vencimiento),isnull(min(Glosa),''),        
       isnull(min(libro),''),isnull(min(voucher),'')        
                from #TmpCtaCte1        
                Group By Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento         
           end        
   If @Tipo = "3"        
        
    begin         
      --           SELECT 'INGRESO 3',@Tipo        
                insert into #TmpCtaCte1(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,        
                Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono)        
                Select ccd01ano,ccd01mes,ccd01cta,cta.ccm01des,ccd01cod,cte.ccm02nom,ccd01subd,ccd01numer,ccd01fevou,ccd01fedoc,         
                   ccd01tipdoc,ccd01ndoc,ccd01feven,isnull(ccd01Comprobante,'') + space(2)+ ccd01con,ccd01deb,ccd01hab,         
            Case @Moneda When "P" Then Round(ccd01deb/@nDolar_Promedio,2) Else ccd01car End,         
            Case @Moneda When "P" Then Round(ccd01hab/@nDolar_Promedio,2) Else ccd01abo End,         
            Case @Moneda When 'S' THEN ccd01deb When 'D' THEN ccd01car When 'P' Then Round(ccd01deb/@nDolar_Promedio,2) End,         
            Case @Moneda When 'S' THEN ccd01hab When 'D' THEN ccd01abo When 'P' Then Round(ccd01hab/@nDolar_Promedio,2) End         
              --  From ccd det  , ccm01cta cta , ccm02cta cte    
                From ccd det, ccm01cta cta, ccm02cta cte         
                Where ccd01emp = @cEmpresa        
                And ccd01ano = @Ano        
                And ccd01mes <= @Mes        
                And isnull(ccd01ana, "") <> ""        
                And isnull(ccd01cod, "") <> ""        
                And det.ccd01cta = @Cuenta        
                And det.ccd01ana + det.ccd01cod in (select ccb01valor from ccb01rngimp where ccb01emp = @cEmpresa And ccb01usu = @Usuario and ccb01pro = "ANCTACTETE")        
               And cta.ccm01emp = @cEmpresa        
          And cta.ccm01aa = @Ano         
                And cta.ccm01cta = det.ccd01cta        
                And cte.ccm02emp = @cEmpresa        
                And cte.ccm02tipana = det.ccd01ana        
                And cte.ccm02cod = det.ccd01cod        
                Order By det.ccd01ano, det.ccd01mes, det.ccd01cta, det.ccd01ana, det.ccd01cod, det.ccd01tipdoc, det.ccd01ndoc,det.ccd01fedoc        
             
       --PRINT 'PRUEBA '         
       --SELECT * FROM #TmpCtaCte1        
              
    Insert into #TmpCtaCte2(Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono,Fecha,Fecha_Documento,Fecha_Vencimiento,Glosa,libro,voucher)        
         Select @Ano,@Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento,        
                isnull(Debe,0),isnull(Haber,0),isnull(Cargo,0),isnull(Abono,0),isnull(ImpCargo,0),isnull(ImpAbono,0),Fecha,Fecha_Documento,Fecha_Vencimiento,isnull(Glosa,''),isnull(libro,''),isnull(voucher,'')        
                From #TmpCtaCte1        
       --           Group By Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Tipo_Documento, Numero_Documento         
      --PRINT 'PRUEBA '         
      --select * from #TmpCtaCte2        
        
    end        
        
   If @Tipo = "1"  -- Pendientes        
         Begin        
               IF @Moneda = 'S'        
                       Begin        
                          delete #TmpCtaCte2 where (round(Debe,2)-Round(Haber,2)) = 0        
                       End        
                    Else        
       Begin        
                          delete #TmpCtaCte2 where (round(Cargo,2)-round(Abono,2)) = 0        
          End        
         End        
   Else If @Tipo = "2"  -- Cancelados        
      Begin        
                    IF @Moneda = 'S'        
                       Begin        
                          delete #TmpCtaCte2        
                          where round(Debe-Haber,2) <> 0        
             End        
                    Else        
                       Begin        
                          delete #TmpCtaCte2        
                          where round(Cargo-Abono,2) <> 0        
                       End        
      End        
    Else If @Tipo = "3"  -- Historico        
           Begin        
                    select @Tipo = "3"        
           End        
        
  End -- ===============Fin de tipo cuenta de terceros        
        
-- =============Actualizaciones para ambos tipos las cuentas y los terceros        
        
  If @Tipo = "1" or  @Tipo = "2"        
   begin         
        update #TmpCtaCte2        
        set Libro = (select max(#TmpCtaCte1.Libro) from  #TmpCtaCte1         
                    where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta and #TmpCtaCte1.Cuenta_Corriente=#TmpCtaCte2.Cuenta_Corriente         
                    and #TmpCtaCte1.Tipo_Documento = #TmpCtaCte2.Tipo_Documento and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                    and #TmpCtaCte1.libro <> '15')        
        update #TmpCtaCte2        
        set Voucher = (select max(#TmpCtaCte1.Voucher) from  #TmpCtaCte1         
                    where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta and #TmpCtaCte1.Cuenta_Corriente=#TmpCtaCte2.Cuenta_Corriente         
                    and #TmpCtaCte1.Tipo_Documento = #TmpCtaCte2.Tipo_Documento and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                    and #TmpCtaCte1.libro <> '15')        
             
        update #TmpCtaCte2        
        set glosa = (select isnull(min(#TmpCtaCte1.Glosa),'') from  #TmpCtaCte1         
                    where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta and #TmpCtaCte1.Cuenta_Corriente=#TmpCtaCte2.Cuenta_Corriente         
                    and #TmpCtaCte1.Tipo_Documento = #TmpCtaCte2.Tipo_Documento and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                    and  #TmpCtaCte1.libro = #TmpCtaCte2.libro and  #TmpCtaCte1.voucher = #TmpCtaCte2.voucher)        
             
    -- Esto se modifico el 04/01/2005 por que el reporte no jalaba la fecah del prestamo por que se trabajaban en difrentes libros        
    -- solo se hizo la modificacion para las fechas y para las cuentas tipo cuenat corriente        
    if @TipoRep = "T"        
     Begin        
        update #TmpCtaCte2        
        set Fecha = (select min(#TmpCtaCte1.Fecha) from  #TmpCtaCte1         
                       where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta         
         and #TmpCtaCte1.Cuenta_Corriente = #TmpCtaCte2.Cuenta_Corriente         
                       and #TmpCtaCte1.Tipo_Documento   = #TmpCtaCte2.Tipo_Documento         
         and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                     --  and #TmpCtaCte1.libro    = #TmpCtaCte2.libro         
              -- and #TmpCtaCte1.voucher   = #TmpCtaCte2.voucher      
 )        
        
             
        update #TmpCtaCte2        
        set Fecha_Documento = (select min(#TmpCtaCte1.Fecha_Documento) from  #TmpCtaCte1         
                        where #TmpCtaCte1.Cuenta    = #TmpCtaCte2.Cuenta         
            and  #TmpCtaCte1.Cuenta_Corriente = #TmpCtaCte2.Cuenta_Corriente         
                         and  #TmpCtaCte1.Tipo_Documento   = #TmpCtaCte2.Tipo_Documento         
            and  #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                    -- and  #TmpCtaCte1.libro     = #TmpCtaCte2.libro         
          -- and  #TmpCtaCte1.voucher = #TmpCtaCte2.voucher      
         )        
     End        
    Else        
     Begin        
      update #TmpCtaCte2        
         set Fecha = (select min(#TmpCtaCte1.Fecha) from  #TmpCtaCte1         
                        where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta         
          and #TmpCtaCte1.Cuenta_Corriente = #TmpCtaCte2.Cuenta_Corriente         
                        and #TmpCtaCte1.Tipo_Documento   = #TmpCtaCte2.Tipo_Documento         
          and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
                        and #TmpCtaCte1.libro    = #TmpCtaCte2.libro         
            and #TmpCtaCte1.voucher   = #TmpCtaCte2.voucher)        
         
              
         update #TmpCtaCte2        
         set Fecha_Documento = (select min(#TmpCtaCte1.Fecha_Documento) from  #TmpCtaCte1      
                       where #TmpCtaCte1.Cuenta    = #TmpCtaCte2.Cuenta      
            and  #TmpCtaCte1.Cuenta_Corriente = #TmpCtaCte2.Cuenta_Corriente      
                        and  #TmpCtaCte1.Tipo_Documento   = #TmpCtaCte2.Tipo_Documento      
            and  #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento      
                       --and  #TmpCtaCte1.libro   = #TmpCtaCte2.libro      
            --and  #TmpCtaCte1.voucher = #TmpCtaCte2.voucher      
          )        
     End        
         
    update #TmpCtaCte2        
    set Fecha_Vencimiento  = (select min(#TmpCtaCte1.Fecha_Vencimiento ) from  #TmpCtaCte1         
       Where #TmpCtaCte1.Cuenta=#TmpCtaCte2.Cuenta and       
  #TmpCtaCte1.Cuenta_Corriente=#TmpCtaCte2.Cuenta_Corriente         
         and #TmpCtaCte1.Tipo_Documento = #TmpCtaCte2.Tipo_Documento       
  and #TmpCtaCte1.Numero_Documento = #TmpCtaCte2.Numero_Documento        
         --and #TmpCtaCte1.libro = #TmpCtaCte2.libro       
  --and #TmpCtaCte1.voucher = #TmpCtaCte2.voucher      
  )        
        
        
 end        
        
--SELECT * FROM #TmpCtaCte2        
        
insert into tmpctacte(Usuario,Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono)         
select              @Usuario,Ano,Mes,Cuenta,Nombre_Cuenta,Cuenta_Corriente,Nombre_CC,Libro,Voucher,Fecha,Fecha_Documento,Tipo_Documento,Numero_Documento,Fecha_Vencimiento,Glosa,Debe,Haber,Cargo,Abono,ImpCargo,ImpAbono        
from #TmpCtaCte2        
Order By Cuenta,Cuenta_Corriente,Tipo_Documento,Numero_Documento,Fecha_Documento        
        
/*        
Update tmpctacte        
Set fecha_vencimiento = null        
Where fecha_vencimiento = '01/01/1900'        
*/        
drop table #TmpCtaCte1        
drop table #TmpCtaCte2        
        
Select * From TmpCtaCte Where usuario = @usuario        
Order By Cuenta,Cuenta_Corriente,Tipo_Documento,Numero_Documento,Fecha_Documento        
--SP_HELP tmpctacte 

Go



--Exec Spu_Con_Rep_ccd '01','2021','01','*','*','*','01','01'          
Alter  Procedure Spu_Con_Rep_ccd          
@ccd01emp CHAR(2),          
@ccd01ano char(4),          
@ccd01subd CHAR(2),          
@ccd01cta VARCHAR(50),          
@ccd01ana CHAR(2),          
@ccd01cod VARCHAR(20) ,        
@ccd01mesini CHAR(2),          
@ccd01mesfin CHAR(2)        
As          
          
Declare @cadSql varchar(800)          
          
--Set @cadSql=''          
          
-- Siempre se filtra por empresa y año          
Set @cadSql = "Select ccd.*,isnull(ccm01cta.ccm01des,'') as ccm01des,isnull(ccm02cta.ccm02nom,'') as ccm02nom from ccd"      
Set @cadSql = @cadSql + "  Left join ccm01cta on  ccd01emp = ccm01emp And  ccd01ano = ccm01aa And ccd01cta = ccm01cta"      
Set @cadSql = @cadSql + "  Left join ccm02cta on  ccd01emp = ccm02emp And  ccd01ana = ccm02tipana And ccd01cod = ccm02cod"      
Set @cadSql = @cadSql + "  Where ccd01emp ='" + @ccd01emp + "' And ccd01ano='" + @ccd01ano + "' And ccd01mes>= '" +@ccd01mesini + "' And ccd01mes<= '" +@ccd01mesfin + "'"          
      
          
If @ccd01subd<>'*'          
 Begin          
  Set @cadSql = @cadSql + ' ' + "And ccd01subd ='" + @ccd01subd + "'"          
 End          
if @ccd01cta<>'*'          
 Begin          
  Set @cadSql = @cadSql + ' ' + "And ccd01cta ='" + @ccd01cta + "'"          
 End          
if @ccd01ana<>'*'          
 Begin          
  Set @cadSql = @cadSql + ' ' + "And ccd01ana ='" + @ccd01ana + "'"          
 End          
          
if @ccd01cod<>'*'          
 Begin          
  Set @cadSql = @cadSql + ' ' + "And ccd01cod ='" + @ccd01cod + "'"          
 End          
           
-- Agregar el orden          
Set @cadSql = @cadSql + ' ' + "Order by ccd01emp,ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord"          
--Select     @cadSql      
Exec(@cadSql)          
Go

Set quoted_identifier ON
        		
--@V12 End
