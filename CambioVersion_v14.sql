Go

--Exec Spu_Con_Rep_LibDiarioPLE  '01','2021','10'          
Alter Procedure Sp_Con_Rep_LibroMayorAnaliticoPLE
/*Formato 5.1 : Libro Diario*/        
@ccd01emp char(2),      
@ccd01ano char(4),      
@ccd01mes char(2)      
As                            
        
Declare @Librodiario Table         
(        
ccd01subd  char(2),        
ccd01numer  varchar(5) ,        
ccd01ord  float,        
ccd01con  varchar(300),        
ccd01cta  varchar(15),        
ccm01des  varchar(60) ,        
ccd01deb  float ,        
ccd01hab  float ,        
ccd01fedoc  datetime,        
ccd01fevou  datetime,        
ccb02des    varchar(60),        
Periodo     varchar(10),        
Correlativo    varchar(50),        
NumcorrelativoAsicont varchar(50),        
estadooperacion   char(1),        
SaldoDeudor    decimal(18,2),        
SaldoAcreedor   decimal(18,2),        
indicadormayorPLE  char(1),        
MonedaTipo    varchar(10),        
CodigoUnidadOperacion char(1) ,        
CodigoCentroCosto  varchar(20) ,        
TipoDocumentoEmisor  varchar(20) ,        
NumeroDocumentoEmisor varchar(20) ,        
TipDocAsociadoOperacion  varchar(20) ,        
TipDocAsociadoOperacionSerie varchar(20)  ,        
TipDocAsociadoOperacionNumero varchar(20) ,         
FechaContable    varchar(10),        
FechaVencimiento   varchar(10),        
FechaOperacion    varchar(10),        
GlosaReferencial   varchar(20),        
DatoEstructurado   varchar(20)        
)        
        
If   @ccd01mes='01' -- Si esta en el mes enero debe tomar la apertura                  
 Begin    
 Insert @Librodiario(        
 ccd01subd,ccd01numer,ccd01ord,ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,ccd01fedoc,ccd01fevou,        
 ccb02des,Periodo,Correlativo,NumcorrelativoAsicont,estadooperacion,SaldoDeudor,SaldoAcreedor,indicadormayorPLE,MonedaTipo,        
 CodigoUnidadOperacion,CodigoCentroCosto,TipoDocumentoEmisor,NumeroDocumentoEmisor,TipDocAsociadoOperacion,TipDocAsociadoOperacionSerie,        
 TipDocAsociadoOperacionNumero,FechaContable,FechaVencimiento,FechaOperacion,GlosaReferencial,DatoEstructurado)        
                   
   Select ccd01subd,ccd01numer,ccd01ord,dbo.Fnc_EliminaCar(lower(isnull(ccd01con,''))) as ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,                            
    ccd01fedoc,ccd01fevou,ccb02des                          
    ,Periodo        =  (ccd01ano + '01' + '00'),                          
    Correlativo     =  (ccd01ano +  ccd01mes   + Isnull(ccd01subd,'') + isnull(ccd01numer,'')),              
              
    NumcorrelativoAsicont = (Case When ccd01mes in (Select right(ccb03cod,2) from ccb03per where ccb03emp=@ccd01emp And               
             Left(ccb03cod,4)=@ccd01ano And Isnull(ccb03tipoperiodo,'')='A') then 'A' else 'M' end)  +             
             rtrim(Convert(varchar(10),CONVERT(int,ccd01ord))),              
    estadooperacion = '1',                            
    SaldoDeudor     = Convert(decimal(18,2),ccd01deb),              
    SaldoAcreedor   = Convert(decimal(18,2),ccd01hab),              
    indicadormayorPLE ='1',               
    -- Cambios Ple          
    MonedaTipo = (Case When ccd01dn='S' then 'PEN' else 'USD' End),          
    CodigoUnidadOperacion = '',          
    CodigoCentroCosto = Isnull(ccd01cc,''),          
    TipoDocumentoEmisor ='',          
    NumeroDocumentoEmisor='',          
 TipDocAsociadoOperacion = (Case When ccd01tipdoc in ('01','02','03','07','08','12','51','52') then ccd01tipdoc else '00' end),          
 TipDocAsociadoOperacionSerie =  dbo.PadR(LTRIM(RTRIM((Case When (Case When ccd01tipdoc in ('01','02','03','07','08','12','51','52') then ccd01tipdoc else '00' end)='00' then '' else dbo.ExtraeSerieyNumero(ccd01ndoc,'S') end))),4,'0'),          
 TipDocAsociadoOperacionNumero = (Case When (Case When ccd01tipdoc in ('01','02','03','07','08','12','51','52') then ccd01tipdoc else '00' end)='00' then (Case When Isnumeric(dbo.ExtraeSerieyNumero(ccd01ndoc,'N'))= 1 then dbo.ExtraeSerieyNumero(ccd01ndoc,'N') else '00000001' end) else (Case When Isnumeric(dbo.ExtraeSerieyNumero(ccd01ndoc,'N'))= 1 then dbo.ExtraeSerieyNumero(ccd01ndoc,'N') else '00000001' end) end),          
      
 FechaContable = '',          
 FechaVencimiento = '',          
 FechaOperacion = (Case When Isnull(ccd01fedoc,'')='' Then '01/01/0001' Else Convert(Varchar(10),Convert(date,ccd01fedoc),103) End) ,                           
 GlosaReferencial ='',          
 DatoEstructurado=''          
           
    from ccd  inner join ccm01cta  On                             
    ccd01emp = ccm01emp And ccd01ano= ccm01aa  And ccd01cta=ccm01cta                        
    inner Join ccb02subd On                        
    ccd01emp=ccb02emp And ccd01ano = ccb02aa And ccd01subd=ccb02cod                        
    where                        
    ccd01emp =@ccd01emp                        
    And ccd01ano=@ccd01ano                        
    And ccd01mes in ('00','01')                  
    And abs(Isnull(ccd01deb,0)) + abs(isnull(ccd01hab,0))<>0                        
    Order By ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord                       
 End                   
Else If (@ccd01mes>=02 And @ccd01mes<=11) -- Si esta en el mes de febrero a Noviembre toma el mismo mes                  
Begin                    
 Insert @Librodiario(        
 ccd01subd,ccd01numer,ccd01ord,ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,ccd01fedoc,ccd01fevou,        
 ccb02des,Periodo,Correlativo,NumcorrelativoAsicont,estadooperacion,SaldoDeudor,SaldoAcreedor,indicadormayorPLE,MonedaTipo,        
 CodigoUnidadOperacion,CodigoCentroCosto,TipoDocumentoEmisor,NumeroDocumentoEmisor,TipDocAsociadoOperacion,TipDocAsociadoOperacionSerie,        
 TipDocAsociadoOperacionNumero,FechaContable,FechaVencimiento,FechaOperacion,GlosaReferencial,DatoEstructurado)        
         
    Select ccd01subd,ccd01numer,ccd01ord,dbo.Fnc_EliminaCar(lower(isnull(ccd01con,''))) as ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,                            
    ccd01fedoc,ccd01fevou,ccb02des                          
    ,Periodo        =  (ccd01ano +  (Case When ccd01mes<=12 then ccd01mes else '12' end)  + '00'),                          
    Correlativo     =  (ccd01ano +  ccd01mes   + Isnull(ccd01subd,'') + isnull(ccd01numer,'')),              
    NumcorrelativoAsicont = 'M' + rtrim(Convert(varchar(10),CONVERT(int,ccd01ord))),              
    estadooperacion = '1',                            
    SaldoDeudor     = Convert(decimal(18,2),ccd01deb),              
    SaldoAcreedor   = Convert(decimal(18,2),ccd01hab),              
    indicadormayorPLE ='1',               
     -- Cambios Ple          
    MonedaTipo = (Case When ccd01dn='S' then 'PEN' else 'USD' End),          
    CodigoUnidadOperacion = '',          
    CodigoCentroCosto = Isnull(ccd01cc,''),          
    TipoDocumentoEmisor ='',          
    NumeroDocumentoEmisor='',          
 TipDocAsociadoOperacion = (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end),          
 TipDocAsociadoOperacionSerie =  (Case When (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end)='00' then '' else dbo.ExtraeSerieyNumero(ccd01ndoc,'S') end),          
 TipDocAsociadoOperacionNumero = (Case When (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end)='00' then (Case when Isnull(ccd01ndoc,'')='' then ccd01numer else ccd01ndoc end ) else dbo.ExtraeSerieyNumero(ccd01ndoc,'N') end),          
 FechaContable = '',          
 FechaVencimiento = '',          
 FechaOperacion = (Case When Isnull(ccd01fedoc,'')='' Then '01/01/0001' Else Convert(Varchar(10),Convert(date,ccd01fedoc),103) End) ,                           
 GlosaReferencial ='',          
 DatoEstructurado=''          
    from ccd  inner join ccm01cta  On                             
    ccd01emp = ccm01emp And ccd01ano= ccm01aa  And ccd01cta=ccm01cta                        
    inner Join ccb02subd On                        
    ccd01emp=ccb02emp And ccd01ano = ccb02aa And ccd01subd=ccb02cod                        
    where                        
    ccd01emp =@ccd01emp                        
    And ccd01ano=@ccd01ano                        
    And ccd01mes=@ccd01mes                        
    And abs(Isnull(ccd01deb,0)) + abs(isnull(ccd01hab,0))<>0                        
    Order By ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord                        
End                    
                    
Else If @ccd01mes>=12  -- Si esta en el mes de diciembre tomoa todos los mese se diciembre                  
Begin                    
 Insert @Librodiario(        
 ccd01subd,ccd01numer,ccd01ord,ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,ccd01fedoc,ccd01fevou,        
 ccb02des,Periodo,Correlativo,NumcorrelativoAsicont,estadooperacion,SaldoDeudor,SaldoAcreedor,indicadormayorPLE,MonedaTipo,        
 CodigoUnidadOperacion,CodigoCentroCosto,TipoDocumentoEmisor,NumeroDocumentoEmisor,TipDocAsociadoOperacion,TipDocAsociadoOperacionSerie,        
 TipDocAsociadoOperacionNumero,FechaContable,FechaVencimiento,FechaOperacion,GlosaReferencial,DatoEstructurado)        
     
    Select ccd01subd,ccd01numer,ccd01ord,dbo.Fnc_EliminaCar(lower(isnull(ccd01con,''))) as ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,              
    ccd01fedoc,ccd01fevou,ccb02des,              
    Periodo        =  (ccd01ano +  (Case When ccd01mes<=12 then ccd01mes else '12' end)  + '00'),              
    Correlativo     =  (ccd01ano +  ccd01mes   + Isnull(ccd01subd,'') + isnull(ccd01numer,'')),              
    NumcorrelativoAsicont = (Case When ccd01mes in (Select right(ccb03cod,2) from ccb03per where ccb03emp=@ccd01emp And               
             Left(ccb03cod,4)=@ccd01ano And Isnull(ccb03tipoperiodo,'')='C') then 'C' else 'M' end)  + rtrim(Convert(varchar(10),CONVERT(int,ccd01ord))),              
    estadooperacion = '1',              
    SaldoDeudor     = Convert(decimal(18,2),ccd01deb),              
    SaldoAcreedor   = Convert(decimal(18,2),ccd01hab),              
--    SELECT CONVERT (varchar(17), CAST(1158963.256389 AS money), 2)              
    indicadormayorPLE ='1',               
    -- Cambios Ple          
    MonedaTipo = (Case When ccd01dn='S' then 'PEN' else 'USD' End),          
    CodigoUnidadOperacion = '',          
    CodigoCentroCosto = Isnull(ccd01cc,''),          
    TipoDocumentoEmisor ='',          
    NumeroDocumentoEmisor='',          
         
 TipDocAsociadoOperacion = (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end),          
 TipDocAsociadoOperacionSerie =  (Case When (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end)='00' then '' else dbo.ExtraeSerieyNumero(ccd01ndoc,'S') end),          
 TipDocAsociadoOperacionNumero = (Case When (Case When ccd01tipdoc in ('01','02','03','07','08','51','52') then ccd01tipdoc else '00' end)='00' then (Case when Isnull(ccd01ndoc,'')='' then ccd01numer else ccd01ndoc end ) else dbo.ExtraeSerieyNumero(ccd01ndoc,'N') end),          
         
 FechaContable = '',          
 FechaVencimiento = '',          
 FechaOperacion = (Case When Isnull(ccd01fedoc,'')='' Then '01/01/0001' Else Convert(Varchar(10),Convert(date,ccd01fedoc),103) End) ,                           
 GlosaReferencial ='',          
 DatoEstructurado=''            
    from ccd  inner join ccm01cta  On                             
    ccd01emp = ccm01emp And ccd01ano= ccm01aa  And ccd01cta=ccm01cta                        
    inner Join ccb02subd On                        
    ccd01emp=ccb02emp And ccd01ano = ccb02aa And ccd01subd=ccb02cod                        
    where                        
    ccd01emp =@ccd01emp            
    And ccd01ano=@ccd01ano                        
    And ccd01mes>='12'  -- Todos los peridos mayor e igual a 12                    
    And abs(Isnull(ccd01deb,0)) + abs(isnull(ccd01hab,0))<>0                        
    Order By ccd01ano,ccd01mes,ccd01subd,ccd01numer,ccd01ord                
End        
--SELECT CONVERT (varchar(17), CAST(1158963.256389 AS money), 2)         
      
 -- Remplazar caracteres no validos en numero docuemnto       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = dbo.Fnc_EliminaCar(TipDocAsociadoOperacionNumero)       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = replace(TipDocAsociadoOperacionNumero,'/',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = replace(TipDocAsociadoOperacionNumero,'.',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = replace(TipDocAsociadoOperacionNumero,'-',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = replace(TipDocAsociadoOperacionNumero,' ','')       
 -- Remplazar caracteres no validos en Serie       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = dbo.Fnc_EliminaCar(TipDocAsociadoOperacionSerie)       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = replace(TipDocAsociadoOperacionSerie,'/',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = replace(TipDocAsociadoOperacionSerie,'.',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = replace(TipDocAsociadoOperacionSerie,'-',' ')       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = replace(TipDocAsociadoOperacionSerie,' ','')       
        
--=== Convertir las series o numeros 000 a 1       
 Update @Librodiario Set TipDocAsociadoOperacionNumero = (Case When Convert(float,TipDocAsociadoOperacionNumero)=0 Then '1' Else  TipDocAsociadoOperacionNumero end)       
     Where isnumeric(TipDocAsociadoOperacionNumero)=1      
      
--=== Convertir las series o numeros 000 a 1       
 Update @Librodiario Set TipDocAsociadoOperacionSerie = (Case When Convert(float,TipDocAsociadoOperacionSerie)=0 Then '1' Else  TipDocAsociadoOperacionSerie end)       
     Where isnumeric(TipDocAsociadoOperacionSerie)=1      
      
 -- == Completar serie a 4 digitos      
 Update @Librodiario Set TipDocAsociadoOperacionSerie = dbo.Padr(TipDocAsociadoOperacionSerie,4,'0') --where TipDocAsociadoOperacion<>'00'      
       
 -- == Si la factura empiexa por F, compeltar a 8 digitos      
 Update @Librodiario Set TipDocAsociadoOperacionNumero = dbo.Padr(TipDocAsociadoOperacionNumero,8,'0')       
 where TipDocAsociadoOperacion='01'      
    And Left(TipDocAsociadoOperacionSerie,1)='F'      
      
 Select         
 ccd01subd,ccd01numer,ccd01ord,ccd01con,ccd01cta,ccm01des,ccd01deb,ccd01hab,ccd01fedoc,ccd01fevou,        
 ccb02des,Periodo,Correlativo,NumcorrelativoAsicont,estadooperacion,SaldoDeudor,SaldoAcreedor,indicadormayorPLE,MonedaTipo,        
 CodigoUnidadOperacion,CodigoCentroCosto,TipoDocumentoEmisor,NumeroDocumentoEmisor,TipDocAsociadoOperacion,TipDocAsociadoOperacionSerie,        
 TipDocAsociadoOperacionNumero,FechaContable,FechaVencimiento,FechaOperacion,GlosaReferencial,DatoEstructurado        
 From @Librodiario 
  