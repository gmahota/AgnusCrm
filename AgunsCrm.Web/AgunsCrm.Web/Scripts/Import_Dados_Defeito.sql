--insert into AgnusCrm.dbo.brand 
--select Marca, Descricao from primarin.dbo.marcas
 
--insert into family
 --select familia, Descricao from primarin.dbo.familias
 
--insert into subfamily
 --select subfamilia, Descricao, familia from primarin.dbo.subfamilias
 use primarin
 select a.artigo, a.descricao, am.pvp1 from primarin.dbo.Artigo a
 inner join artigomoeda am on am.artigo = a.artigo and am.moeda like 'M%'