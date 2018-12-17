
insert into AgnusCrm.dbo.Unity 
select Unidade, Descricao,0 from PRICOMPUWORKS.dbo.Unidades uu
left outer join AgnusCrm.dbo.Unity u on u.code = uu.Unidade
where u.code is null
go

insert into AgnusCrm.dbo.brand 
select Marca, Descricao from PRICOMPUWORKS.dbo.marcas
go
 
insert into family
	select familia, Descricao from PRICOMPUWORKS.dbo.familias
go
 
insert into subfamily
	select subfamilia, Descricao, familia from PRICOMPUWORKS.dbo.subfamilias sf
	left outer join subfamily s on s.code = sf.SubFamilia and s.familyCode = sf.Familia
	where s.code is null
go

insert into Product
select a.Artigo,a.Descricao,0,f.code as 'Familia',sf.id as 'SubFamilia',b.code,a.Observacoes,a.STKActual,
	1
 from PRICOMPUWORKS.dbo.Artigo A
	
	inner join Family f on f.code = a.Familia
	inner join SubFamily sf on sf.code = a.SubFamilia and sf.familyCode = a.Familia
	left outer join brand b on b.code = a.Marca
	left outer join Product p on p.code = a.Artigo
	where p.code is null
go

insert into ProductPrice
select p.id,'MZN',am.Unidade,isnull(am.PVP1,0),isnull(am.PVP2,0),isnull(am.PVP3,0),isnull(am.PVP4,0)
	,isnull(am.PVP5,0),isnull(am.PVP6,0),
	am.PVP1IvaIncluido,am.PVP2IvaIncluido,am.PVP3IvaIncluido,am.PVP4IvaIncluido,
	am.PVP5IvaIncluido,am.PVP6IvaIncluido
	 
 from PRICOMPUWORKS.dbo.ArtigoMoeda am
	inner join Product p on p.code = am.Artigo
	left outer join ProductPrice pp on pp.product = p.id and pp.unity = am.Unidade
where Moeda ='MT' and pp.product is null
go

insert into entity 

select 'Cliente',P.Cliente,left(P.Nome,50),left(P.Fac_Mor,100),
	left(P.Fac_Local,20),P.NumContrib,
	P.Pais,P.Fac_Tel, 'MZN' from PRICOMPUWORKS.dbo.Clientes P
	where p.Cliente not in (select code from Entity)
go

insert into Customer 
select id,1 from Entity where id not in (select entityId from Customer)

go

insert into Contact

select Contacto,left(Co.PrimeiroNome,50) + ' '+ left(co.UltimoNome,49),left(Co.PrimeiroNome,50),
	left(co.NomesIntermedios,50) ,left(co.UltimoNome,50),co.Titulo,
	left(co.Email,50),left(co.EmailAssist,50),'Cliente',co.Telemovel,co.Telefone,null from PRICOMPUWORKS.dbo.Contactos Co

go

insert into Contact_Entity
select c.id,e.id,a.TipoContacto,null,null from 
(
	select c.Cliente,co.Contacto,lce.TipoContacto from PRICOMPUWORKS.dbo.LinhasContactoEntidades lce
	inner join PRICOMPUWORKS.dbo.Contactos co on co.Id = lce.IDContacto
	inner join PRICOMPUWORKS.dbo.Clientes c on c.Cliente = lce.Entidade and lce.TipoEntidade = 'C' 
) as a
inner join Entity e on e.code = a.Cliente
inner join Contact c on c.code = a.Contacto
left outer join Contact_Entity ce on ce.contactId =c.id and ce.entityId = e.id
where ce.id is null
go