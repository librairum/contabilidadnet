--======= Agregar copia de asientos Tipos, cuando se copia una empresa
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