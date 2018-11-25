
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