select * from Organizadores o 
INNER JOIN AspNetUsers u ON o.Id = u.Id
LEFT JOIN Eventos e ON e.OrganizadorId = o.Id

-- *********************************************************

delete from AspNetUserClaims
delete from AspNetUsers
delete from Enderecos
delete from Eventos
delete from Organizadores

