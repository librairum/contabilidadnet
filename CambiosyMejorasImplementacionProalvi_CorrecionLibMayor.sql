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
