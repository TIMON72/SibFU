SELECT
  goodscatalog.gcName,
  goodstransfers.gtDate,
  goodstransfers.gtAmount
FROM (SELECT
         storagedescription.IDsd,
         CONCAT(storagedescription.sdName, ', ', storagedescription.sdAddress, ', ', cities.cName) AS expr1
       FROM storagedescription
         INNER JOIN cities
           ON storagedescription.IDc = cities.IDc) SubQuery,
     (SELECT
         storagedescription.IDsd,
         CONCAT(storagedescription.sdName, ', ', storagedescription.sdAddress, ', ', cities.cName) AS expr1
       FROM storagedescription
         INNER JOIN cities
           ON storagedescription.IDc = cities.IDc) SubQuery_1,
     goodstransfers
       INNER JOIN goodscatalog
         ON goodstransfers.IDgc = goodscatalog.IDgc