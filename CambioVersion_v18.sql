create table co09MotivosDocPorPagar_Compras(
  CO09CODEMP         varchar(2)   not null,
  CO09ITEM           int          not null identity,
  CO09DESCRIPCION    varchar(100),
  CO09USUARIO        varchar(20),
  CO09FECHA          datetime,
  CO09ASIENTOTIPOCOD varchar(20),
  CO09MONEDACOD      varchar(1),
  CO09NOMENCLATURA   varchar(5),

  constraint PK_co09MotivosDocPorPagar_Compras primary key(CO09CODEMP,CO09ITEM)
);
go

create table co10MotivosDocPorPagar_Ventas(
  CO10CODEMP         varchar(2)   not null,
  CO10ITEM           int          not null identity,
  CO10DESCRIPCION    varchar(100),
  CO10USUARIO        varchar(20),
  CO10FECHA          datetime,
  CO10ASIENTOTIPOCOD varchar(20),
  CO10MONEDACOD      varchar(1),
  CO10NOMENCLATURA   varchar(5),

  constraint PK_co10MotivosDocPorPagar_Ventas primary key(CO10CODEMP,CO10ITEM)
);
go




-- Crear usuarios
Insert into Menus(empresa,modulo,nivel1,nivel2,nivel3,texto)
Values('01','CONTABILID','01','20','00','Motivos Compras')

Insert into Menus(empresa,modulo,nivel1,nivel2,nivel3,texto)
Select Codigo,'CONTABILID','01','21','00','Motivos Ventas' from Empresa

Select * from Usuario

-- ===
Insert  into menuxusuario(empresa,modulo,codigomenu,usuario)
Select Codigo,'CONTABILID','012000','CONTADOR' from Empresa

Insert  into menuxusuario(empresa,modulo,codigomenu,usuario)
Select Codigo,'CONTABILID','012100','CONTADOR' from Empresa

Insert  into menuxusuario(empresa,modulo,codigomenu,usuario)
Select Codigo,'CONTABILID','012000','ADMIN' from Empresa

Insert  into menuxusuario(empresa,modulo,codigomenu,usuario)
Select Codigo,'CONTABILID','012100','ADMIN' from Empresa


Go
CREATE procedure Spu_Con_Trae_CentroCosto           
@cCodEmp char(2)   ,   @anio char(4) as       Begin        SELECT ccb02cod, ccb02des                 FROM ccb02cc                 WHERE ccb02Emp =  @cCodEmp                --and  ccb02ctactble = @anio           
      
  and ccb02aa = @anio End
  
  Go
  CREATE PROCEDURE Spu_Con_Trae_ComAsientosTipo              
/*--------------------------------------------------------------------------*/              
/* Objetivo   : Trae los Datos de los Asientos Tipo       */              
/* Actualiza  :            */              
/* Creado Por : Jose Carlos Vasquez Laines                                  */              
/* Fecha      : 21/07/1999                                                  */              
/*--------------------------------------------------------------------------*/              
              
@cEmpresa varchar(2),             
@cAnio char(4) ,         
@cOrden varchar(30),              
@cFiltro   varchar(50)              
              
AS              
        
              
/* Selecciono los Datos de Todos los Asientos Tipo */              
IF @cFiltro = '*'              
BEGIN             
   SELECT *               
   FROM ccc03astip               
   WHERE ccc03emp =  @cEmpresa  and  ccc03aa =  @cAnio              
   ORDER BY   ccc03cod      
END              
ELSE              
BEGIN              
   SELECT *               
   FROM ccc03astip               
   WHERE ccc03emp =  @cEmpresa  and  ccc03aa =  @cAnio              
   ORDER BY   ccc03cod      
END                
/* Ejecuto el Procedure */ 
 GO
 
 CREATE PROCEDURE Spu_Con_Trae_co07MotivosDocPorPagar              
@co07CODEMP varchar(2),            
@Anio  varchar(4)          
AS              
SELECT Motivo.co07ITEM,Motivo.co07DESCRIPCION,      
 Motivo.co07ASIENTOTIPOCOD,asientoTipo.ccc03des, Motivo.co07NOMENCLATURA      
FROM co07MotivosDocPorPagar Motivo LEFT JOIN ccc03astip asientoTipo            
ON Motivo.co07CODEMP = asientoTipo.ccc03emp             
 AND Motivo.co07ASIENTOTIPOCOD = ccc03cod          
 AND ccc03aa = @Anio            
WHERE           
co07CODEMP = @co07CODEMP   
order by CO07ITEM ASC

Go

   
CREATE PROCEDURE Spu_Con_Del_co07MotivosDocPorPagar              
@co07CODEMP varchar(2),              
@co07descripcion varchar(100),          
@co07ITEM int,                         
@Msg varchar(100) output              
AS              
IF(SELECT COUNT(*) FROM co07MotivosDocPorPagar WHERE               
co07CODEMP = @co07CODEMP AND co07ITEM = @co07ITEM) <= 0              
  BEGIN               
    Set @Msg='VALIDAR :: NO EXISTE MOTIVO A  ELIMINAR'                  
 GOTO Manejaerror                 
  END              
            
IF(SELECT COUNT(*) FROM co05docu co05 LEFT JOIN co07MotivosDocPorPagar co07          
ON co05.CO05CON = co07.co07DESCRIPCION          
where co07.co07DESCRIPCION = @co07descripcion) > 0          
BEGIN          
      Set @Msg='ERROR:: HAY UN DOCUMENTO QUE ESTA UTILIZANDO EL CONCEPTO A ELIMINAR'                  
 GOTO Manejaerror                
END              
          
 DELETE FROM co07MotivosDocPorPagar              
 WHERE co07CODEMP = @co07CODEMP               
 and co07ITEM = @co07ITEM            
           
 IF @@ERROR <>0                
  BEGIN               
    Set @Msg='ERROR:: INESPERADO'                  
 GOTO Manejaerror                 
  END              
                
   Set @Msg='OK :: SE ELIMINO CON EXITO'                             
  return 1              
            
Manejaerror:                      
return -1 

Go
        
CREATE PROCEDURE Spu_Con_Ins_co07MotivosDocPorPagar                  
@CO07CODEMP  varchar(2),                   
@co07descripcion varchar(100),                 
@AsientoTipoCod varchar(20),                  
@NOMENCLATURA varchar(5),                           
@Msg   varchar(100) output                  
AS                  
                
    IF(SELECT COUNT(*) FROM co07MotivosDocPorPagar where co07CODEMP = @co07CODEMP                  
   AND co07DESCRIPCION = @co07descripcion )> 0                   
 Begin                
  Set @Msg='ERROR:: YA HAY UN CONCEPTO CREADO'                      
  GOTO Manejaerror                     
 End                
              
-- ====================                
 -- UPDATE co07MotivosDocPorPagar_Compras                   
 --SET   co07ASIENTOTIPOCOD = @AsientoTipoCod, co07NOMENCLATURA = @NOMENCLATURA                  
 --WHERE co07CODEMP = @co07CODEMP                  
 --AND co07ITEM = @co07ITEM              
               
   INSERT INTO co07MotivosDocPorPagar(co07CODEMP,co07DESCRIPCION,co07FECHA,co07ASIENTOTIPOCOD,co07NOMENCLATURA)   
   VALUES(@co07CODEMP,@co07descripcion,GETDATE(),@AsientoTipoCod,@NOMENCLATURA)                  
               
-- ======================               
  IF @@ERROR <>0                    
 BEGIN                   
  Set @Msg='ERROR:: INESPERADO'                      
  GOTO Manejaerror                     
 End                
                  
  Set @Msg='OK :: SE INSERTO CON EXITO'                      
                
  return 1                  
                
ManejaError:                             
return -1 

Go
  
      
CREATE PROCEDURE Spu_Con_Upd_co07MotivosDocPorPagar                
@co07CODEMP  varchar(2),             
@co07descripcion varchar(100),               
@co07ITEM  int,                
@AsientoTipoCod varchar(20),                
@NOMENCLATURA varchar(5),              
@Msg   varchar(100) output                
AS                
              
IF(SELECT COUNT(*) FROM co07MotivosDocPorPagar WHERE co07CODEMP = @co07CODEMP AND co07ITEM = @co07ITEM) <= 0                
 Begin              
  Set @Msg='ERROR:: NO EXISTE CODIGO A ACTUALIZAR'                    
  GOTO Manejaerror                   
 End              
               
--   SELECT * fROM co07MotivosDocPorPagar            
     --VALIDAR SI HAY UN CONCEPTO YA ASIGNADO A UN DOCUMENTO !!!          
--   IF(SELECT COUNT(*) FROM co05docu co05 LEFT JOIN co07MotivosDocPorPagar co07            
--ON co05.CO05CON = co07.co07DESCRIPCION            
--where co07.co07DESCRIPCION = @co07descripcion) > 0            
--BEGIN            
--      Set @Msg='ERROR:: HAY UN DOCUMENTO QUE ESTA UTILIZANDO EL CONCEPTO A EDITAR'                    
-- GOTO Manejaerror                  
--END                
-- ====================              
  UPDATE co07MotivosDocPorPagar                 
 SET co07DESCRIPCION = @co07descripcion, co07ASIENTOTIPOCOD = @AsientoTipoCod, co07NOMENCLATURA = @NOMENCLATURA               
 WHERE co07CODEMP = @co07CODEMP                
 AND co07ITEM = @co07ITEM                
                
  IF @@ERROR <>0                  
 BEGIN                 
  Set @Msg='ERROR:: INESPERADO'                    
  GOTO Manejaerror                   
 End              
                
  Set @Msg='OK :: SE ACTUALIZO CON EXITO'                                
  return 1                
              
ManejaError:                          
return -1 
Go

CREATE PROCEDURE Spu_Con_Trae_co08MotivosDocPorPagar_Ventas              
@co08CODEMP varchar(2),            
@Anio  varchar(4)          
AS              
SELECT Motivo.co08ITEM,Motivo.co08DESCRIPCION,      
 Motivo.co08ASIENTOTIPOCOD,asientoTipo.ccc03des, Motivo.co08NOMENCLATURA      
FROM co08MotivosDocPorPagar_Ventas Motivo LEFT JOIN ccc03astip asientoTipo            
ON Motivo.co08CODEMP = asientoTipo.ccc03emp             
 AND Motivo.co08ASIENTOTIPOCOD = ccc03cod          
 AND ccc03aa = @Anio            
WHERE           
co08CODEMP = @co08CODEMP     
  order by CO08ITEM ASC  
  
  Go
    
  
CREATE PROCEDURE Spu_Con_Del_co08MotivosDocPorPagar_Ventas            
@co08CODEMP varchar(2),            
@co08descripcion varchar(100),        
@co08ITEM int,                    
@Msg varchar(100) output            
AS            
IF(SELECT COUNT(*) FROM co08MotivosDocPorPagar_Ventas WHERE             
co08CODEMP = @co08CODEMP AND co08ITEM = @co08ITEM) <= 0            
  BEGIN             
    Set @Msg='VALIDAR :: NO EXISTE MOTIVO A  ELIMINAR'                
 GOTO Manejaerror               
  END            
          
IF(SELECT COUNT(*) FROM co05docu co05 LEFT JOIN co08MotivosDocPorPagar_Ventas co08        
ON co05.CO05CON = co08.co08DESCRIPCION        
where co08.co08DESCRIPCION = @co08descripcion) > 0        
BEGIN        
      Set @Msg='ERROR:: HAY UN DOCUMENTO QUE ESTA UTILIZANDO EL CONCEPTO A ELIMINAR'                
 GOTO Manejaerror              
END            
        
 DELETE FROM co08MotivosDocPorPagar_Ventas            
 WHERE co08CODEMP = @co08CODEMP             
 and co08ITEM = @co08ITEM          
         
 IF @@ERROR <>0              
  BEGIN             
    Set @Msg='ERROR:: INESPERADO'                
 GOTO Manejaerror               
  END            
              
   Set @Msg='OK :: SE ELIMINO CON EXITO'                        
  return 1            
          
Manejaerror:                    
return -1 

Go
  
  
CREATE PROCEDURE Spu_Con_Ins_co08MotivosDocPorPagar_Ventas              
@co08CODEMP  varchar(2),               
@co08descripcion varchar(100),             
@AsientoTipoCod varchar(20),              
@NOMENCLATURA varchar(5),                     
@Msg   varchar(100) output              
AS              
            
    IF(SELECT COUNT(*) FROM co08MotivosDocPorPagar_Ventas where co08CODEMP = @co08CODEMP              
   AND co08DESCRIPCION = @co08descripcion )> 0               
 Begin            
  Set @Msg='ERROR:: YA HAY UN CONCEPTO CREADO'                  
  GOTO Manejaerror                 
 End            
          
-- ====================            
 -- UPDATE co08MotivosDocPorPagar_Ventas               
 --SET   co08ASIENTOTIPOCOD = @AsientoTipoCod, co08NOMENCLATURA = @NOMENCLATURA              
 --WHERE co08CODEMP = @co08CODEMP              
 --AND co08ITEM = @co08ITEM          
           
   INSERT INTO co08MotivosDocPorPagar_Ventas(co08CODEMP,co08DESCRIPCION,co08FECHA,co08ASIENTOTIPOCOD,co08NOMENCLATURA) VALUES(@co08CODEMP,@co08descripcion,GETDATE(),@AsientoTipoCod,@NOMENCLATURA)              
           
-- ======================           
  IF @@ERROR <>0                
 BEGIN               
  Set @Msg='ERROR:: INESPERADO'                  
  GOTO Manejaerror                 
 End            
              
  Set @Msg='OK :: SE INSERTO CON EXITO'                             
  return 1              
            
ManejaError:                     
return -1 
Go
  
    
CREATE PROCEDURE Spu_Con_Upd_co08MotivosDocPorPagar_Ventas              
@co08CODEMP  varchar(2),           
@co08descripcion varchar(100),             
@co08ITEM  int,              
@AsientoTipoCod varchar(20),              
@NOMENCLATURA varchar(5),                         
@Msg   varchar(100) output              
AS              
            
IF(SELECT COUNT(*) FROM co08MotivosDocPorPagar_Ventas WHERE co08CODEMP = @co08CODEMP AND co08ITEM = @co08ITEM) <= 0              
 Begin            
  Set @Msg='ERROR:: NO EXISTE CODIGO A ACTUALIZAR'                  
  GOTO Manejaerror                 
 End            
             
--   SELECT * fROM co08MotivosDocPorPagar_Ventas          
     --VALIDAR SI HAY UN CONCEPTO YA ASIGNADO A UN DOCUMENTO !!!        
--   IF(SELECT COUNT(*) FROM co05docu co05 LEFT JOIN co08MotivosDocPorPagar_Ventas co08          
--ON co05.CO05CON = co08.co08DESCRIPCION          
--where co08.co08DESCRIPCION = @co08descripcion) > 0          
--BEGIN          
--      Set @Msg='ERROR:: HAY UN DOCUMENTO QUE ESTA UTILIZANDO EL CONCEPTO A EDITAR'                  
-- GOTO Manejaerror                
--END              
-- ====================            
  UPDATE co08MotivosDocPorPagar_Ventas               
 SET co08DESCRIPCION = @co08descripcion, co08ASIENTOTIPOCOD = @AsientoTipoCod, co08NOMENCLATURA = @NOMENCLATURA             
 WHERE co08CODEMP = @co08CODEMP              
 AND co08ITEM = @co08ITEM              
              
  IF @@ERROR <>0                
 BEGIN               
  Set @Msg='ERROR:: INESPERADO'                  
  GOTO Manejaerror                 
 End            
              
  Set @Msg='OK :: SE ACTUALIZO CON EXITO'                       
  return 1              
            
ManejaError:                     
return -1 

Go
--EXEC Spu_Con_Trae_SireVentasAnexo03 '01','2024','02','05'        
        
--VENTAS        
Alter PROCEDURE Spu_Con_Trae_SireVentasAnexo03        
@empresa	char(2),        
@anio		char(4),        
@mes		char(2),        
@libro		char(2)        
As        
        
Create Table #RegistroVentaSIRE                                                   
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
moneda char(1),                              
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
              
                          
-- ==== llenar reg de compra        
Insert into #RegistroVentaSIRE(              
Anio,        
Mes,        
Libro,        
Voucher,        
correlativo,        
Fecha_documento,        
--        
Analisis,        
Cuenta_Corriente,        
Ruc_Cuenta_Corriente,        
Nombre_Cuenta_Corriente,        
TipDocCtaCte,        
--        
Tipo_Documento,        
nombretipdoc,        
Documento,        
SerieDocNac,        
NumeroDocNac,        
Fecha_Emision,      
Fecha_VencoPago,        
--        
columna01,        
columna02,        
columna03,        
columna04,        
columna05,        
columna06,        
columna07,        
columna08,        
columna09,        
columna10,        
--        
Referenciafecha,        
ReferenciaTipo,        
ReferenciaSerDoc,        
ReferenciaNumDoc,        
--        
tipo,        
moneda,        
TipoDeCambio,        
--        
periodo,        
CodigoUnicoOperacion,        
FlagdeAjuste,        
NumcorrelativoAsicont,        
ValorFob,        
MonedaTipo,        
TipoCambioInconsistencia,        
CancelacionMedioPago)              
          
Exec Sp_Con_Rep_RegistroVentas @empresa,@anio,@mes,@libro,'S'          
        
        
        
Declare @empresaruc varchar(20)        
Declare @empresanombre varchar(250)        
        
        
SELECT @empresaruc=isnull(Ruc,''),@empresanombre=isnull(Nombre,'')  FROM Empresa WHERE Sistema='CONTABILID' AND Codigo=@empresa
        
        
        
        
SELECT        
@empresaruc as 'RUC',        
@empresanombre as 'ID',        
regventas.Anio + regventas.Mes as 'Periodo',        
'' as 'CAR_SUNAT',        
regventas.Fecha_Emision AS 'Fecha_Emision',        
regventas.Fecha_VencoPago AS 'Fecha_Vcto',       
       
regventas.Tipo_Documento as 'Tipo_CP',        
regventas.SerieDocNac as 'Serie_CP',        
regventas.NumeroDocNac as 'Nro_CP',        
'' as 'Nro_Final',        
regventas.TipDocCtaCte as 'TipoDoc_Cliente',        
regventas.Ruc_Cuenta_Corriente as 'NroDocIdentidad',        
regventas.Nombre_Cuenta_Corriente as 'Razon_Social',        
      
regventas.columna09 as 'Valor_Factor_Exportacion',        
      
regventas.columna01 as 'BI_Gravada',        
      
'00' as 'Dscto_BI',        
regventas.columna04 as 'IGV_IPM',        
      
'0.00'  AS 'Dscto_IGV_IPM',        
      
regventas.columna07 AS 'Mto_Exonerado',        
regventas.columna02 as 'Mto_Inafecto',        
regventas.columna03 as 'ISC',        
Convert(decimal(18,2),'0.00') as 'BI_Grav_IVAP',        
'0.00' as 'IVAP',        
'0' as 'ICBPER',        
      
regventas.columna03 as 'Otros_Atributos',        
regventas.columna06 AS 'Total_CP',        
(CASE WHEN ltrim(rtrim(regventas.moneda)) = 'D' then 'USD' Else 'PEN' end) as 'Moneda',  --ojo , falya los euros      
Convert(decimal(19,3),regventas.TipoDeCambio) AS 'Tipo_Cambio',        
      
(CaSe when (regventas.Referenciafecha='01/01/0001') then '' else regventas.Referenciafecha end) as 'FechaEmision_Modificado',        
(Case when (isnull(regventas.ReferenciaTipo,'-')='-') then '' else regventas.ReferenciaTipo end ) as 'TipoCP_Modificado',       
(Case when (isnull(regventas.ReferenciaSerDoc,'-')='-') then '' else regventas.ReferenciaSerDoc end ) as 'SerieCP_Modificado',       
(Case when (isnull(regventas.ReferenciaNumDoc,'-')='-') then '' else regventas.ReferenciaNumDoc end ) as 'NroCP_Modificado',       
      
'' as 'ID_PROYECTO'        
--ULTIMO CAMPO DE libre utilizacion - opcional - CLU        
  from #RegistroVentaSIRE  regventas        
GO        
--EXEC Spu_Con_Trae_SireVentasAnexo03 '01','2024','02','05'          
Alter PROCEDURE Spu_Con_Trae_SireVentasAnexo03          
@empresa char(2),          
@anio char(4),          
@mes char(2),          
@libro char(2)          
As          
          
Create Table #RegistroVentaSIRE                                                     
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
moneda char(1),                                
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
                
                            
-- ==== llenar reg de compra          
Insert into #RegistroVentaSIRE(                
Anio,          
Mes,          
Libro,          
Voucher,          
correlativo,          
Fecha_documento,          
--          
Analisis,          
Cuenta_Corriente,          
Ruc_Cuenta_Corriente,          
Nombre_Cuenta_Corriente,      
TipDocCtaCte,          
--          
Tipo_Documento,          
nombretipdoc,          
Documento,          
SerieDocNac,          
NumeroDocNac,          
Fecha_Emision,        
Fecha_VencoPago,          
--          
columna01,          
columna02,          
columna03,          
columna04,          
columna05,          
columna06,          
columna07,          
columna08,          
columna09,          
columna10,          
--          
Referenciafecha,          
ReferenciaTipo,          
ReferenciaSerDoc,          
ReferenciaNumDoc,          
--          
tipo,          
moneda,          
TipoDeCambio,          
--          
periodo,          
CodigoUnicoOperacion,          
FlagdeAjuste,          
NumcorrelativoAsicont,          
ValorFob,          
MonedaTipo,          
TipoCambioInconsistencia,          
CancelacionMedioPago)                
            
Exec Sp_Con_Rep_RegistroVentas @empresa,@anio,@mes,@libro,'S'            
          
          
          
Declare @empresaruc varchar(20)          
Declare @empresanombre varchar(250)          
          
          
SELECT @empresaruc=isnull(Ruc,''),@empresanombre=isnull(Nombre,'')  FROM Empresa WHERE Sistema='CONTABILID' AND Codigo=@empresa  
          
          
          
          
SELECT          
@empresaruc as 'RUC',          
@empresanombre as 'ID',          
regventas.Anio + regventas.Mes as 'Periodo',          
'' as 'CAR_SUNAT',          
regventas.Fecha_Emision AS 'Fecha_Emision',          
regventas.Fecha_VencoPago AS 'Fecha_Vcto',         
         
regventas.Tipo_Documento as 'Tipo_CP',          
regventas.SerieDocNac as 'Serie_CP',          
regventas.NumeroDocNac as 'Nro_CP',          
'' as 'Nro_Final',          
regventas.TipDocCtaCte as 'TipoDoc_Cliente',          
regventas.Ruc_Cuenta_Corriente as 'NroDocIdentidad',          
regventas.Nombre_Cuenta_Corriente as 'Razon_Social',          
        
regventas.columna09 as 'Valor_Factor_Exportacion',          
        
regventas.columna01 as 'BI_Gravada',          
        
'00' as 'Dscto_BI',          
regventas.columna04 as 'IGV_IPM',          
        
'0.00'  AS 'Dscto_IGV_IPM',          
        
regventas.columna07 AS 'Mto_Exonerado',          
regventas.columna02 as 'Mto_Inafecto',          
regventas.columna03 as 'ISC',          
Convert(decimal(18,2),'0.00') as 'BI_Grav_IVAP',          
'0.00' as 'IVAP',          
'0' as 'ICBPER',          
        
regventas.columna03 as 'Otros_Atributos',          
regventas.columna06 AS 'Total_CP',          
(CASE WHEN ltrim(rtrim(regventas.moneda)) = 'D' then 'USD' Else 'PEN' end) as 'Moneda',  --ojo , falya los euros        
Convert(decimal(19,3),regventas.TipoDeCambio) AS 'Tipo_Cambio',          
        
(CaSe when (regventas.Referenciafecha='01/01/0001') then '' else regventas.Referenciafecha end) as 'FechaEmision_Modificado',          
(Case when (isnull(regventas.ReferenciaTipo,'-')='-') then '' else regventas.ReferenciaTipo end ) as 'TipoCP_Modificado',         
(Case when (isnull(regventas.ReferenciaSerDoc,'-')='-') then '' else regventas.ReferenciaSerDoc end ) as 'SerieCP_Modificado',         
(Case when (isnull(regventas.ReferenciaNumDoc,'-')='-') then '' else regventas.ReferenciaNumDoc end ) as 'NroCP_Modificado',         
        
'' as 'ID_PROYECTO'          
--ULTIMO CAMPO DE libre utilizacion - opcional - CLU          
  from #RegistroVentaSIRE  regventas          
  
  
  GO
  CREATE Procedure Spu_Con_Trae_SireComprasAnexo11          
@empresa char(2),          
@anio char(4),          
@mes char(2),          
@libro char(2)          
As          
          
Create Table #RegCompraSIRE          
(                                      
Anio        char(4),                                                           
Mes    char(2),                                                              
Libro   char(2),                                      
Voucher   varchar(5),                                                                                         
correlativo      int,                                                                                   
Fecha_documento  datetime,                                                                                 
--                                                                                
Analisis    char(2),                                                                                       
Cuenta_Corriente  varchar(11),                                                                                      
Ruc_Cuenta_Corriente varchar(11),                                                                                            
Nombre_Cuenta_Corriente varchar(250),                                                                                            
TipDocCtaCte   varchar(10),                                                                    
TipoAgenteretencion     varchar(10),                                                                              
--                                                                                
Tipo_Documento   varchar(10),                                                                                
nombretipdoc    varchar(50),                                                                                
Documento    varchar(20),                                                                                
SerieDocNac  varchar(20),                                                                                
NumeroDocNac  varchar(20),                                                                                
NumeroDocNoDomi  varchar(20),                                                                                
AnioDua    varchar(4),                                                                                
Fecha_Emision   varchar(10),                                                                                
Fecha_VencoPago  varchar(10),                                                                                  
--                                                                                         
Columna01    decimal(18,2),                                                                                            
Columna02    decimal(18,2),                                                                                            
Columna03    decimal(18,2),                                                                                           
Columna04    decimal(18,2),                                                                                            
Columna05    decimal(18,2),                                                                                            
Columna06    decimal(18,2),                                                                                            
Columna07    decimal(18,2),                                                                                            
Columna08    decimal(18,2),                                                                                            
Columna09    decimal(18,2),                                                                                            
Columna10 decimal(18,2),                                                                                        
--                                                           
Referenciafecha    varchar(10),          
ReferenciaTipo     varchar(20),               
ReferenciaSerDoc   varchar(20),                   
ReferenciaNumDoc   varchar(20),                               
--                                                                                
NroPago     varchar(20),                                                                                
FecPago     varchar(10),                                                                                
porcentaje    varchar(10),                                                                                
--                                                                
moneda     char(1),                                                                                   
TipoDeCambio    decimal(18,3),                                                                 
tipocompra    char(2),                                                      
NroFormulario    varchar(10),                                     
NroOrden     varchar(10),                                                                                 
afectoaretencion  char(1),                              
--                                                                
periodo   varchar(10),                                                                  
CodigoUnicoOperacion     varchar(20),                                                                                
FlagdeAjuste    varchar(1),                                            
NumcorrelativoAsicont  varchar(10),                                                
CodigoDependenciaaduanera varchar(3),                                              
                                        
-- Nuevos Campos para PLE 5.0                                         
MonedaTipo      varchar(3),                                        
Bienoservicio     varchar(2),                                        
IdentificacionContrato   varchar(12) default(''),                                        
TipoCambioInconsistencia  varchar(1) default(''),                                        
ProvNoHabidosInconsistencia  varchar(1) default(''),                                        
ProvRenunciarionInconsistencia varchar(1) default(''),                                        
DNIutilizadosInconsistencia  varchar(1) default(''),                                        
CancelacionMedioPago   varchar(1) default(''),                                        
--Opcion 1: carla Pone flag de cancelacion                                        
--Opcion 2: cuenta corriente                                        
--Opcion 3: Del modulo de caja y banco                                        
                                      
-- Datos Adicionales para PLE formatio 8.2 informacio de operaciones con sujetos no domiciliados                                        
ValorAdquisiciones    varchar(1) default('0'), -- Como no es obligatorio lo mandamos en cero                                      
OtrosConceptosAdicionales  varchar(1) default('0'), --Como no es obligatorio lo mandamos en cero                                        
                                      
CreditoFiscalTipCompPago  varchar(2) default(''), -- Como no es obligatorio lo mandamos en vacio                                        
CreditoFiscalSerieCompPago  varchar(20) default(''), -- Como no es obligatorio lo mandamos en vacio                                        
CreditoFiscalAniodua   varchar(4) default(''),  -- Como no es obligatorio lo mandamos en vacio                                       
CreditoFiscalNumeroCompPago  varchar(20) default(''), -- Como no es obligatorio lo mandamos en vacio                                       
--                                      
SujNoDomiPais     varchar(4),                                      
SujNoDomiRazonSocial   varchar(100),                                      
SujNoDomiDomicilio    varchar(100),                                      
SujNoDomiIdentificacionNro  varchar(15),            
--                                      
BeneEfecPagoIdentifcaFiscalNro varchar(15), -- Como no es obligatorio lo mandamos en vacio.                                      
BeneEfecPagoRazonSocial   varchar(100), -- Como no es obligatorio lo mandamos en vacio.                                        
BeneEfecPagoPais    varchar(4), -- Como no es obligatorio lo mandamos en vacio.                                       
--                                      
VinculoContriConResidente  varchar(2), -- Como no es obligatorio lo mandamos en vacio.                                      
--                                      
ConvenioEvitarDoble    varchar(2), -- Jalar de configuracion del proveedor Tabla 25                                      
ExonercionAplicada    varchar(1), -- Jalar de configuracion del proveedor Tabla 25                                      
TipodeRenta      varchar(2), -- Jalar de configuracion del proveedor Tabla 31                                      
Modalidaddelservicio   varchar(1), -- Jalar de configuracion del proveedor Tabla 32                                      
--                                      
AplicacionpenulparrafoIR  char(1) -- No es obligatorio, Dejar en blanco.             
                                   
)                                      
                
                            
-- ==== llenar reg de compra          
Insert into #RegCompraSIRE(                
Anio,Mes,Libro,Voucher,correlativo,Fecha_documento,Analisis,Cuenta_Corriente,Ruc_Cuenta_Corriente,Nombre_Cuenta_Corriente,                
TipDocCtaCte,TipoAgenteretencion,Tipo_Documento,nombretipdoc,Documento,SerieDocNac,NumeroDocNac,NumeroDocNoDomi,AnioDua,                
Fecha_Emision,Fecha_VencoPago,Columna01,Columna02,Columna03,Columna04,Columna05,Columna06,Columna07,Columna08,Columna09,Columna10,                
Referenciafecha,ReferenciaTipo,ReferenciaSerDoc,ReferenciaNumDoc,NroPago,FecPago,porcentaje,moneda,TipoDeCambio,tipocompra,NroFormulario,                
NroOrden,afectoaretencion,periodo,CodigoUnicoOperacion,FlagdeAjuste,NumcorrelativoAsicont,CodigoDependenciaaduanera,MonedaTipo,                
Bienoservicio,IdentificacionContrato,TipoCambioInconsistencia, ProvNoHabidosInconsistencia,ProvRenunciarionInconsistencia,DNIutilizadosInconsistencia,                
CancelacionMedioPago,ValorAdquisiciones,OtrosConceptosAdicionales,CreditoFiscalTipCompPago,CreditoFiscalSerieCompPago,CreditoFiscalAniodua,                
CreditoFiscalNumeroCompPago,SujNoDomiPais,SujNoDomiRazonSocial,SujNoDomiDomicilio,SujNoDomiIdentificacionNro,BeneEfecPagoIdentifcaFiscalNro,                
BeneEfecPagoRazonSocial,BeneEfecPagoPais,VinculoContriConResidente,ConvenioEvitarDoble,ExonercionAplicada,TipodeRenta,Modalidaddelservicio,                
AplicacionpenulparrafoIR)                
          
Execute sp_Con_Rep_RegistroCompras @empresa,@anio,@mes,@libro,'1','*','S'          
          
Declare @empresaruc varchar(20)          
Declare @empresanombre varchar(250)          
          
          
sELECT @empresaruc=isnull(Ruc,''),@empresanombre=isnull(Nombre,'')  FROM Empresa WHERE Sistema='CONTABILID' AND Codigo=@empresa  
          
          
          
Select          
 @empresaruc as 'RUC',          
 @empresanombre as 'Nombre_Empresa',          
 Anio + Mes as 'Periodo',          
'' as 'CAR_SUNAT',          
        
regcompras.Fecha_Emision ,          
regcompras.Fecha_VencoPago as 'FecPago',       
         
 regcompras.Tipo_Documento As 'TipoCP',    -- TIPO CP HAY DATO 07 ES OBLIGATORIO CAMPO :       
 regcompras.SerieDocNac AS 'Serie_CP',          
 regcompras.AnioDua as 'Anio',          
 regcompras.NumeroDocNac as 'Nro_CP',          
 '' as 'NroFinal',          
 regcompras.TipDocCtaCte as 'TipoDocIdentidad',          
 regcompras.Ruc_Cuenta_Corriente as 'NroDocIdentidad',          
 regcompras.Nombre_Cuenta_Corriente,          
       
       
         
         
         
 regcompras.Columna01 as 'BI_GRAVADO_DG',        
 regcompras.Columna06 as 'IGV',          
         
         
 regcompras.Columna02 AS 'BI_GRAVADO_DGNG',          
 regcompras.Columna07 AS 'IGV_IMPDGNG',         
         
          
 regcompras.Columna03 AS 'BI_GRAVADO_DNG',          
 regcompras.Columna08 AS 'IGV_IMPDNG',        
         
           
 regcompras.Columna04 AS 'ValorAdq_NG',        
         
           
--(CASE WHEN regcompras.Tipo_Documento = '07' then '0.00' ELSE '' end) as 'ISC',          
 '0.00' as 'ISC',      
 '0.00' as 'ICB_PER',          
         
 regcompras.Columna09 as 'OTROSTRIB',        
           
 regcompras.Columna10 AS 'Total_CP',         
         
          
 regcompras.MonedaTipo AS 'Moneda',          
         
 regcompras.TipoDeCambio,          
 (CASE WHEN regcompras.FecPago = '01/01/0001' then '' ELSE regcompras.FecPago end) as 'Fecha_documento',          
 regcompras.ReferenciaTipo as 'Tipo_CP_Modif',          
 regcompras.ReferenciaSerDoc as 'Serie_CP_Modif',          
 regcompras.CodigoDependenciaaduanera as 'COD_DAM',          
 regcompras.ReferenciaNumDoc as 'Nro_CP',          
 '' as 'Clasif_Bss_Sss',          
 '' as 'ID_PROYECTO',          
 '' as 'PorcPart',          
 '' as 'IMB',          
 '' as 'CAR_CP'  --VACIO        
--ULTIMO CAMPO DE libre utilizacion - opcional          
  from #RegCompraSIRE  regcompras 
  