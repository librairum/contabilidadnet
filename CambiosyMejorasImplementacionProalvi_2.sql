--1 Agrandar campo de glosa para reporte de analisis de cuenta corriente
--2 Agregar Reporte de archivo plano

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

-
--Exec Spu_Con_Rep_ccd '01','2021','01','*','*','*','01','01'        
CREATE  Procedure Spu_Con_Rep_ccd        
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
