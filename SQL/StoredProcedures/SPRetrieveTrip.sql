USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPRetrieveTrip]    Script Date: 2/27/2017 1:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPRetrieveTrip] 
@DispatchedHotel  nvarchar(max),
@IsOpen  bit,
@IsRemoved  bit,
@IsArchive bit,
@StartDate datetime,
@EndDate datetime,
@VoucherNumber varchar(max)
AS
BEGIN
SET NOCOUNT ON;
SELECT DISTINCT trip.TripId
      ,trip.PaymentType
      ,trip.GuestName
      ,trip.RoomNumber
      ,trip.MeterReadingIn
      ,trip.MeterReadingOut
      ,trip.Amount
      ,trip.PackageCost
	  ,trip.AdditionalKmCost
      ,trip.WaitingHourCost
      ,trip.PassengerType
      ,trip.PaymentDateTime
      ,trip.Remarks
	  ,trip.VoucherNumber
	  ,trip.DispatchedHotel
      ,trip.Createdby
      ,trip.Updatedby
	  ,trip.TripMileage
      ,trip.IsCustomPackage
      ,trip.IsOpen
	  ,trip.IsRemoved
	  ,trip.IsArchive
	  ,trip.TimeOut AS CreatedDate
	  ,trip.TimeIn AS UpdatedDate
	  ,trip.TimeIn
	  ,trip.TimeOut
	  ,driver.FirstName+' '+ driver.LastName AS DriverName
	  ,driver.EmpNumber AS EmployeeNumber
	  ,vehicle.VehicleNumber
	  ,vehicle.VehicleMake
	  ,vehicle.VehicleModel
	  ,vehicle.VehicleType
	  ,bata.Description AS BataDescription
	  ,bata.Amount AS BataAmount

FROM Trip trip
 INNER JOIN Driver driver ON driver.DriverId = trip.DriverId
 INNER JOIN Vehicle vehicle ON vehicle.VehicleId = trip.VehicleId
 LEFT JOIN TripBata bata ON trip.TripId =(SELECT DISTINCT bata.TripId FROM TripBata)

 WHERE 
	(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN trip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND	
	(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN trip.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN trip.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsArchive IS NULL THEN 1 WHEN trip.IsArchive = @IsArchive THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @VoucherNumber IS NULL THEN 1 WHEN trip.VoucherNumber LIKE '%'+@VoucherNumber+'%' THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @StartDate IS NULL AND @EndDate IS NULL THEN 1 WHEN trip.TimeIn >= @StartDate AND trip.TimeIn <= @EndDate THEN 1 ELSE 0 END) AND --modified date filtering
    trip.IsDeleted = 0

 -- SELECT * FROM PackagesList package
 --  INNER JOIN Trip tripPackage ON tripPackage.TripId=  package.TripId 
 --  WHERE 
	--(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN tripPackage.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
	--(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN tripPackage.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
	--(1 = CASE WHEN @IsArchive IS NULL THEN 1 WHEN tripPackage.IsArchive = @IsArchive THEN 1 ELSE 0 END) AND
 --  tripPackage.IsDeleted = 0
END
RETURN 0

--exec [SPRetrieveTrip] CGH,1,null,0,null,null,187


