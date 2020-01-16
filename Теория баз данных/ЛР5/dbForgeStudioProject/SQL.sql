SELECT
  goodscatalog.gcName, typegoods.tgName,
  goodscatalog.gcMeasure, goodscatalog.gcCost
FROM goodscatalog
  INNER JOIN typegoods
    ON goodscatalog.IDtg = typegoods.IDtg