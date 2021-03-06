USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPRetrieveDriverWiseBata]    Script Date: 3/16/2017 12:39:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPRetrieveDriverWiseBata] 
@DriverId nvarchar(max),
@VehicleId  nvarchar(max),
@EmployeeNumber  nvarchar(max),
@StartDate datetime,
@EndDate datetime

AS
BEGIN

SELECT DISTINCT 
	   trip.TripId
      ,trip.Amount
	  ,trip.VoucherNumber
	  ,trip.DispatchedHotel
      ,trip.Createdby
      ,trip.Updatedby
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
		INNER JOIN TripBata bata ON trip.TripId IN (SELECT DISTINCT bata.TripId FROM TripBata)

	 WHERE 
		(1 = CASE WHEN @DriverId IS NULL THEN 1 WHEN trip.DriverId = @DriverId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @VehicleId IS NULL THEN 1 WHEN trip.VehicleId = @VehicleId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @EmployeeNumber IS NULL THEN 1 WHEN driver.EmpNumber = @EmployeeNumber THEN 1 ELSE 0 END) AND
		Trip.IsDeleted = 0 AND trip.TimeIn >=@StartDate AND trip.TimeIn <= @EndDate 

SELECT * FROM PackagesList 

END
RETURN 0



--exec [SPRetrieveDriverWiseBata] 15,0 ,0,'2016-12-06 17:32:49.770','2017-1-06 17:32:49.770'
