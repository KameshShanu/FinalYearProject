USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPArchiveTrip]    Script Date: 5/23/2017 10:25:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPArchiveTrip] 

@StartDate datetime,
@EndDate datetime

AS
BEGIN
SET NOCOUNT ON;

 INSERT INTO ArchiveTrip 
 SELECT * FROM (
	SELECT 
       [TripId]
      ,[PackageId]
      ,[PaymentType]
      ,[VehicleId]
      ,[VehicleNumber]
      ,[DriverId]
      ,[DriverName]
      ,[GuestName]
      ,[RoomNumber]
      ,[MeterReadingIn]
      ,[MeterReadingOut]
      ,[MeterReadingInGps]
      ,[MeterReadingOutGps]
      ,[MeterReadingInStatus]
      ,[MeterReadingOutStatus]
      ,[Amount]
      ,[PackageCost]
      ,[AdditionalKmCost]
      ,[WaitingHourCost]
      ,[IsOpen]
      ,[IsRemoved]
      ,[IsDeleted]
      ,[PassengerType]
      ,[PassengerTypeList]
      ,[TimeIn]
      ,[TimeOut]
      ,[TripDuration]
      ,[PaymentDateTime]
      ,[Remarks]
      ,[AdditionalKM]
      ,[WaitedHrs]
      ,[VoucherNumber]
      ,[DispatchedHotel]
      ,[Createdby]
      ,[Updatedby]
      ,[TripMileage]
      ,[MeterReadingInGap]
      ,[MeterReadingOutGap]
      ,[PaymentCategory]
      ,[CorporateName]
      ,[ReservationNo]
      ,[IsCustomPackage]
      ,[IsArchive]
      ,[Created]
      ,[Modified]
	  ,[IsReopened]
  FROM Trip
 WHERE Trip.TimeIn >=@StartDate AND Trip.TimeIn <= @EndDate AND Trip.IsOpen = 0
) AS T

DELETE 
FROM Trip
WHERE Trip.TimeIn >=@StartDate AND Trip.TimeIn <= @EndDate AND Trip.IsOpen = 0

SELECT 'Success';

END 
RETURN 0

--exec [SPArchiveTripNew] '10/19/2016 6:16 AM','10/20/2016 6:17 PM'


