USE [ODM2]

INSERT INTO [ODM2].[Units]
           ([UnitsTypeCV],[UnitsAbbreviation],[UnitsName],[UnitsLink])
     VALUES
           ('Dimensionless','Di','Dimensionless',NULL),
		   ('Action','mg','mg/L',NULL),
		   ('Action','ug','ug/mL',NULL),
		   ('Action','%','%',NULL)

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
           ('Unknown')

INSERT INTO [ODM2].[People]
           ([PersonFirstName],[PersonMiddleName],[PersonLastName])
     VALUES
           ('Unknown','Unknown','Unknown')

INSERT INTO [ODM2].[Organizations]
           ([OrganizationTypeCV],[OrganizationName],[OrganizationCode])
     VALUES
           ('Company','Hatfield','Hat'),
		   ('Laboratory','AGAT','AGA')

INSERT INTO [ODM2].[ExtensionProperties]
           ([PropertyName],[PropertyDataTypeCV])
     VALUES
           ('SampleCode','String'),
		   ('Comments','String'),
           ('Prefix','String'),
           ('Total or Filtered','String'),
           ('Result Type','String'),
           ('EQL','String'),
           ('EQL Units','String'),
           ('QA','String'),
           ('UCL','String'),
           ('LCL','String'),
           ('Field ID','String'),
           ('Sample Depth','String'),
           ('Matrix Type','String'),
           ('Sample Type','String'),
           ('Parent Sample','String'),
           ('SDG','String'),
           ('Lab SampleID','String'),
           ('Lab Report Number','String')

GO