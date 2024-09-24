
Create  View V_CtaCte  
As  
Select ccd01emp,ccd01ano,ccd01ana,ccd01cod,ccd01cta,ccd01tipdoc,ccd01ndoc,  
Min(ccd01fedoc) as 'FechaInicial',Sum(ccd01deb) as ccd01deb,Sum(ccd01hab) as ccd01hab,Sum(ccd01car) as ccd01car,Sum(ccd01abo) as ccd01abo,  
Sum(ccd01deb)-Sum(ccd01hab) as 'SaldoSoles',  
Sum(ccd01car)-Sum(ccd01abo) as 'SaldoDolares'  
From ccd where isnull(ccd01ana, '') <> '' And isnull(ccd01cod, '') <> ''  
Group by ccd01emp,ccd01ano,ccd01ana,ccd01cod,ccd01cta,ccd01tipdoc,ccd01ndoc  

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



