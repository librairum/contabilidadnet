
Go
Drop proc sp_Con_Rep_RegistroCompras_anual_BiMo
Go
Drop proc sp_Con_Rep_RegistroCompras_BiMoneda

Go
Create procedure Sp_Con_Rep_RegistroCompras_anual  
@cEmpresa varchar(2),              
@cAno  varchar(4),              
@cMes  varchar(2),              
@cLibro  varchar(2),              
@orden  char(1), -- = tal como estaba 2=por fechas               
@filtro  char(2), -- = todas / 1=solo con detraciones              
@tipomoneda char(1)     -- = REG COM EN SOLES / O=REG COMP EN MONEDA ORIGINAL              
  
As  
-- =====  
SET NOCOUNT ON              
DECLARE @CONT INT              
DECLARE @MES CHAR(2)              
SET @CONT=1              
              
              
-- Crear Tala temporal                                                                              
Create Table #RegCompraAnual  
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
Columna10    decimal(18,2),                                                                          
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
  
WHILE @CONT<13              
 BEGIN              
  IF @CONT<10              
   Begin              
    SET @MES='0' + CONVERT(CHAR(1),@CONT)              
   End              
  Else              
   Begin              
    SET @MES=CONVERT(CHAR(2),@CONT)               
   End              
                
  --PRINT @MES              
Insert into #RegCompraAnual(  
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
              
Execute sp_Con_Rep_RegistroCompras @cEmpresa,@cAno,@MES,@cLibro,'1','*',@tipomoneda         
                 
  SET @CONT=@CONT+1  
  CONTINUE   
END  
  
-- Listar   
Select * from #RegCompraAnual Order By Anio,Mes,Libro,Voucher Asc  

Go      
--Exec sp_Con_Rep_RegistroVentas_anual '01','2007','02','S'      
Alter procedure [dbo].[sp_Con_Rep_RegistroVentas_anual]      
@cEmpresa  varchar(2),                                            
@cAno      varchar(4),                                            
@cMes      varchar(2),                                            
@cLibro    varchar(2),                                            
@cMoneda   varchar(1)                                                
AS      
SET NOCOUNT ON      
DECLARE @CONT INT      
DECLARE @MES CHAR(2)      
SET @CONT=1      
      
Create Table #RegistroVentasAnual  
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
  
WHILE @CONT<13      
 BEGIN      
  IF @CONT<10      
   Begin      
    SET @MES='0' + CONVERT(CHAR(1),@CONT)      
   End      
  Else      
   Begin      
    SET @MES=CONVERT(CHAR(2),@CONT)       
   End      
        
   
 Insert Into #RegistroVentasAnual(Anio,Mes,Libro,Voucher,correlativo,Fecha_documento,Analisis,Cuenta_Corriente,Ruc_Cuenta_Corriente,Nombre_Cuenta_Corriente,  
    TipDocCtaCte,Tipo_Documento,nombretipdoc,Documento,SerieDocNac,  
    NumeroDocNac,Fecha_Emision,Fecha_VencoPago,columna01,columna02,columna03,columna04,columna05,columna06,columna07,columna08,  
    columna09,columna10,Referenciafecha,ReferenciaTipo,ReferenciaSerDoc,ReferenciaNumDoc,tipo,moneda,TipoDeCambio,periodo,  
    CodigoUnicoOperacion,FlagdeAjuste,NumcorrelativoAsicont,ValorFob,MonedaTipo,TipoCambioInconsistencia,CancelacionMedioPago  
)  
  EXECUTE sp_Con_Rep_RegistroVentas @cEmpresa,@cAno,@MES,@cLibro,@cMoneda      
  
  SET @CONT=@CONT+1      
  CONTINUE      
    
END      
      
Select * from #RegistroVentasAnual order by   
Anio,Mes,Libro,Voucher  
  