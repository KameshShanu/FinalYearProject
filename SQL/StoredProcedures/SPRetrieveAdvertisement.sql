USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPRetrieveAdvertisement]    Script Date: 2/1/2017 1:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPRetrieveAdvertisement] 
AS
BEGIN
SET NOCOUNT ON;
SELECT advertisement_cat.CategoryId
      ,advertisement_cat.CategoryName
	  ,advertisement_cat.OrderId
      ,advertisement_cat.FileURL
	  ,advertisement_cat.FileType
      ,advertisement_cat.IsModified
      ,advertisement_cat.IsDeleted
	  ,advertisement_cat.CreatedDate
	  ,advertisement_cat.ModifiedDate

FROM AdvertisementCategory advertisement_cat
WHERE advertisement_cat.IsDeleted = 0

 
SELECT advertisement_item.CategoryId
      ,advertisement_item.ItemId
	  ,advertisement_item.OrderId
	  ,advertisement_item.ItemName
      ,advertisement_item.FileURL
	  ,advertisement_item.FileType
      ,advertisement_item.IsModified
      ,advertisement_item.IsDeleted
	  ,advertisement_item.CreatedDate
	  ,advertisement_item.ModifiedDate

FROM AdvertisementItem advertisement_item
WHERE advertisement_item.IsDeleted = 0
END
RETURN 0


