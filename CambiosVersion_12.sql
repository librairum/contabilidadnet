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