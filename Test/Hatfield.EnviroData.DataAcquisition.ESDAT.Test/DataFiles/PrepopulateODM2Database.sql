USE [ODM2]

INSERT INTO [ODM2].[CV_UnitsType]
           ([Term],[Name])
     VALUES
           ('dimensionless','dimensionless'),
		   ('mg/L','mg/L'),
		   ('ug/mL','ug/mL'),
		   ('%','%')

INSERT INTO [ODM2].[Units]
           ([UnitsTypeCV],[UnitsAbbreviation],[UnitsName],[UnitsLink])
     VALUES
           ('dimensionless','di','dimensionless',NULL),
		   ('mg/L','mg','mg/L',NULL),
		   ('ug/mL','ug','ug/mL',NULL),
		   ('%','%','%',NULL)

INSERT INTO [ODM2].[Variables]
           ([VariableTypeCV],[VariableCode],[VariableNameCV],[VariableDefinition],[SpeciationCV],[NoDataValue])
     VALUES
           ('Chemistry','Unknown','1,1,1-Trichloroethane',NULL,'Unknown',-9999),
		   ('Unknown','Unknown','1,1,1-Trichloroethane',NULL,'Unknown',-9999)

INSERT INTO [ODM2].[Methods]
           ([MethodTypeCV],[MethodCode],[MethodName],[MethodDescription],[MethodLink],[OrganizationID])
     VALUES
           ('Specimen collection', '', '', NULL, NULL, NULL),
		   ('Specimen analysis', '', '', NULL, NULL, NULL)

INSERT INTO [ODM2].[SamplingFeatures]
           ([SamplingFeatureUUID],[SamplingFeatureTypeCV],[SamplingFeatureCode])
     VALUES
           ('de305d54-75b4-431b-adb2-eb6b9e546014', 'Site', ''),
           ('de305d54-75b4-431b-adb2-eb6b9e546014', 'Specimen', '')

INSERT INTO [ODM2].[ProcessingLevels]
           ([ProcessingLevelCode])
     VALUES
           ('')

INSERT INTO [ODM2].[People]
           ([PersonFirstName],[PersonMiddleName],[PersonLastName])
     VALUES
           ('','','')

INSERT INTO [ODM2].[Organizations]
           ([OrganizationTypeCV],[OrganizationName],[OrganizationCode])
     VALUES
           ('Company','Hatfield','Hat'),
		   ('Laboratory','AGAT','AGA')

GO