-- Cambio en asiento tipo : Se corrigio que no condicionaba por año
Go
Alter PROCEDURE [dbo].[sp_Con_Del_Asiento_Tipo]    
/*--------------------------------------------------------------------------*/    
/* Objetivo   : Elimino un Asiento Tipo         */    
/* Actualiza  :            */    
/* Creado Por : Miguel Angel Valverde Malaga           */    
/* Fecha      : 03/08/1999          */    
/*--------------------------------------------------------------------------*/    
    
@cEmpresa  varchar(2),  
@ccc03aa char(4),  
@cCodigo  varchar(5),  
@cMsgRetorno  varchar(100) OUTPUT    
    
AS    
    
DECLARE @nDelDetalles int    
    
BEGIN TRANSACTION    
    
/* Verifico que Exista el Asiento Tipo para Eliminarlo */    
IF (SELECT COUNT(*)     
 FROM ccc03astip    
 WHERE ccc03emp = @cEmpresa    
 And   ccc03aa = @ccc03aa  
 AND   ccc03cod = @cCodigo) > 0    
    BEGIN    
 /* Elimino los Detalles del Asiento Tipo */    
 EXECUTE @nDelDetalles = sp_Con_Del_Detalles_Asi_Tipo @cEmpresa,@ccc03aa, @cCodigo, @cMsgRetorno OUTPUT    
 IF @nDelDetalles = -1    
     BEGIN    
  SELECT @cMsgRetorno = 'No se Pudo Eliminar los Detalles del Asiento Tipo'
  GOTO ManejaError    
     END    
    
 /* Elimino el Asiento Tipo */    
 DELETE FROM ccc03astip    
 WHERE ccc03emp = @cEmpresa    
 And   ccc03aa = @ccc03aa  
 AND   ccc03cod = @cCodigo    
 IF @@ERROR <> 0    
     BEGIN    
  SELECT @cMsgRetorno = 'No se Pudo Eliminar el Asiento Tipo'
  GOTO ManejaError    
     END    
    END    
ELSE    
    BEGIN    
 SELECT @cMsgRetorno = 'El Asiento Tipo no existe, Por Favor verifique'
 GOTO ManejaError    
    END    
    
/* Grabo las Operaciones si Elimino Bien */    
SELECT @cMsgRetorno = 'Se Elimino exitosamente el Asiento Tipo'    
COMMIT TRANSACTION    
RETURN 0    
    
/* Deshago las Operaciones si Ocurrio algun Error */    
ManejaError:    
ROLLBACK TRANSACTION    
RETURN -1    
    
/* Ejecuto el Procedure */  
Go

Alter PROCEDURE [dbo].[sp_Con_Del_Detalles_Asi_Tipo]    
/*--------------------------------------------------------------------------*/    
/* Objetivo   : Elimino Todos los Detalles de un Asiento Tipo      */    
/* Actualiza  :            */    
/* Creado Por : Miguel Angel Valverde Malaga           */    
/* Fecha      : 03/08/1999          */    
/*--------------------------------------------------------------------------*/    
    
@cEmpresa varchar(2),    
@ccd03aa  char(4),  
@cCodigo varchar(5),    
@cMsgRetorno varchar(100) OUTPUT    
    
AS    
    
BEGIN TRANSACTION    
    
/* Elimino los Detalles del Asiento Tipo */    
DELETE FROM ccd03astip    
WHERE ccd03emp = @cEmpresa    
And   ccd03aa = @ccd03aa  
AND   ccd03cod = @cCodigo    
IF @@ERROR <> 0    
    BEGIN    
 SELECT @cMsgRetorno = 'No se Pudo Eliminar los Detalles del Asiento Tipo'    
 GOTO ManejaError    
    END    
    
/* Grabo las Operaciones si Elimino Bien */    
SELECT @cMsgRetorno = 'Se Elimino exitosamente los Detalles del Asiento Tipo'
COMMIT TRANSACTION    
RETURN 0    
    
/* Deshago las Operaciones si Ocurrio algun Error */    
ManejaError:    
ROLLBACK TRANSACTION    
RETURN -1    
    
/* Ejecuto el Procedure */  