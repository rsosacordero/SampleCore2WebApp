USE [EFWWT]
GO

ALTER TABLE Person.StateProvince
DROP CONSTRAINT IF EXISTS FK_StateProvince_CountryRegionCode
GO

ALTER TABLE Person.StateProvince
ADD CONSTRAINT FK_StateProvince_CountryRegionCode 
FOREIGN KEY (CountryRegionCode) REFERENCES Person.CountryRegion (CountryRegionCode)
GO