USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPArchiveTripById]    Script Date: 9/1/2017 11:55:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPArchiveTripById] 
@TripId int
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
 WHERE Trip.[TripId] = @TripId
) AS T

IF @@ROWCOUNT = 1
	BEGIN
		DELETE 
		FROM Trip
		WHERE Trip.[TripId] = @TripId
		SELECT 'Success';
	END
ELSE
	BEGIN
		SELECT 'Failure';
	END
END 
RETURN 0
--exec [SPArchiveTripById] 13190
GO