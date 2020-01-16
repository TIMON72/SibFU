SELECT
  storagedescription.sdName,
  storagedescription.sdAddress,
  storagedescription.sdPhone,
  cities.cName,
  cities.cPhoneCode
FROM storagedescription
  RIGHT OUTER JOIN cities
    USING(IDc)