USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[RetrieveTripPage]    Script Date: 2/23/2017 3:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RetrieveTripPage] 
@DispatchedHotel  nvarchar(max),
@IsOpen  bit,
@IsRemoved  bit,
@IsArchive bit,
@VoucherNumber varchar(max),
@PageNumber int,
@PageSize int = 20
AS
BEGIN
SET NOCOUNT ON;
SELECT trip.TripId
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

FROM Trip trip
 INNER JOIN Driver driver ON driver.DriverId = trip.DriverId
 INNER JOIN Vehicle vehicle ON vehicle.VehicleId = trip.VehicleId

 WHERE 
	(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN trip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND	
	(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN trip.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN trip.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsArchive IS NULL THEN 1 WHEN trip.IsArchive = @IsArchive THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @VoucherNumber IS NULL THEN 1 WHEN trip.VoucherNumber LIKE '%'+@VoucherNumber+'%' THEN 1 ELSE 0 END) AND
    trip.IsDeleted = 0

 ORDER BY TripId desc
    OFFSET @PageSize * (@PageNumber - 1) ROWS
    FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE);


	SELECT COUNT(TripId) AS 'ItemCount'
	FROM Trip
	 WHERE 
	(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN trip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND	
	(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN trip.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN trip.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @IsArchive IS NULL THEN 1 WHEN trip.IsArchive = @IsArchive THEN 1 ELSE 0 END) AND
	(1 = CASE WHEN @VoucherNumber IS NULL THEN 1 WHEN trip.VoucherNumber LIKE '%'+@VoucherNumber+'%' THEN 1 ELSE 0 END) AND
    trip.IsDeleted = 0 

END
RETURN 0

--exec [RetrieveTripPage] CGH,0,0,0,null,1


