USE [transcendworld_dev]
GO
/****** Object:  StoredProcedure [dbo].[SPRetrieveTripReport]    Script Date: 9/1/2017 5:46:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPRetrieveTripReport] 
@Dispatcher nvarchar(max),
@DispatchedHotel  nvarchar(max),
@PassengerType  nvarchar(max),
@PaymentType  nvarchar(max),
@VehicleId nvarchar(max),
@DriverId nvarchar(max),
@StartDate datetime,
@EndDate datetime,
@IsOpen bit,
@IsRemoved bit,
@CorporateName nvarchar(max),
@PaymentCategory nvarchar(max)
AS
BEGIN
DROP TABLE[TempTable]
CREATE TABLE TempTable
(
	[TripId] [int],
	[PaymentType] [nvarchar](max),
	[GuestName] [nvarchar](max),
	[RoomNumber] [nvarchar](max),
	[MeterReadingInGap] [int],
	[MeterReadingOutGap] [int],
	[MeterReadingInGps] [int],
	[MeterReadingOutGps] [int],
	[MeterReadingIn] [int],
	[MeterReadingOut] [int],
	[Amount] [decimal](18, 2),
	[PackageCost] [decimal](18, 2),
	[AdditionalKmCost] [decimal](18, 2),
	[WaitingHourCost] [decimal](18, 2),
	[PassengerType] [nvarchar](max),
	[PaymentDateTime] [datetime],
	[Remarks] [nvarchar](max),
	[VoucherNumber] [nvarchar](max),
	[DispatchedHotel] [nvarchar](max),
	[Createdby] [nvarchar](max),
	[Updatedby] [nvarchar](max),
	[TripMileage] [int],
	[TripDuration] [nvarchar](max),
	[IsCustomPackage] [bit],
	[IsOpen] [bit],
	[IsRemoved] [bit],
	[IsArchive] [bit],
	[CreatedDate] [datetime],
	[UpdatedDate] [datetime],
	[TimeIn] [datetime],
	[TimeOut] [datetime],
	[PaymentCategory] [nvarchar](max) NULL,
	[CorporateName] [nvarchar](max) NULL,
	[ReservationNo] [nvarchar](max) NULL,
	[DriverName] [nvarchar](max),
	[EmployeeNumber] [nvarchar](max),
	[VehicleNumber] [nvarchar](max),
	[VehicleMake] [nvarchar](max),
	[VehicleModel] [nvarchar](max),
	[VehicleType] [nvarchar](max),
	[BataDescription] [nvarchar](max),
	[BataAmount] [decimal](18, 2)
)

 INSERT INTO TempTable 
 (
	TripId,
	PaymentType,
	GuestName,
	RoomNumber,
	MeterReadingInGap,
	MeterReadingOutGap,
	MeterReadingInGps,
	MeterReadingOutGps,
	MeterReadingIn,
	MeterReadingOut,
	Amount,
	PackageCost,
	AdditionalKmCost,
	WaitingHourCost,
	PassengerType,
	PaymentDateTime,
	Remarks,
	VoucherNumber,
	DispatchedHotel,
	Createdby,
	Updatedby,
	TripMileage,
	TripDuration,
	IsCustomPackage,
	IsOpen,
	IsRemoved,
	IsArchive,
	CreatedDate,
	UpdatedDate,
	TimeIn,
	TimeOut,
	PaymentCategory,
	CorporateName,
	ReservationNo,
	DriverName,
	EmployeeNumber,
	VehicleNumber,
	VehicleMake,
	VehicleModel,
	VehicleType,
	BataDescription,
	BataAmount
 )
 SELECT * FROM 
 (
	SELECT DISTINCT 
	   trip.TripId
      ,ISNULL(trip.PaymentType,'') as PaymentType
      ,trip.GuestName
      ,trip.RoomNumber
	  ,trip.MeterReadingInGap
	  ,trip.MeterReadingOutGap
	  ,trip.MeterReadingInGps
	  ,trip.MeterReadingOutGps
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
	  ,trip.TripDuration
      ,trip.IsCustomPackage
      ,trip.IsOpen
	  ,trip.IsRemoved
	  ,trip.IsArchive
	  ,trip.TimeOut AS CreatedDate
	  ,trip.TimeIn AS UpdatedDate
	  ,trip.TimeIn
	  ,trip.TimeOut
	  ,trip.PaymentCategory
	  ,trip.CorporateName
	  ,trip.ReservationNo
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
		(1 = CASE WHEN @Dispatcher IS NULL THEN 1 WHEN trip.Updatedby = @Dispatcher THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN trip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PassengerType IS NULL THEN 1 WHEN trip.PassengerType = @PassengerType THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PaymentType IS NULL THEN 1 WHEN trip.PaymentType = @PaymentType THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @DriverId IS NULL THEN 1 WHEN trip.DriverId = @DriverId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @VehicleId IS NULL THEN 1 WHEN trip.VehicleId = @VehicleId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN trip.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN trip.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @CorporateName IS NULL THEN 1 WHEN trip.CorporateName = @CorporateName THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PaymentCategory IS NULL THEN 1 WHEN trip.PaymentCategory = @PaymentCategory THEN 1 ELSE 0 END) AND
		Trip.IsDeleted = 0 AND trip.TimeIn >=@StartDate AND trip.TimeIn <= @EndDate 	--modified date filtering
) AS a

INSERT INTO TempTable 
(
	TripId,
	PaymentType,
	GuestName,
	RoomNumber,
	MeterReadingInGap,
	MeterReadingOutGap,
	MeterReadingInGps,
	MeterReadingOutGps,
	MeterReadingIn,
	MeterReadingOut,
	Amount,
	PackageCost,
	AdditionalKmCost,
	WaitingHourCost,
	PassengerType,
	PaymentDateTime,
	Remarks,
	VoucherNumber,
	DispatchedHotel,
	Createdby,
	Updatedby,
	TripMileage,
	TripDuration,
	IsCustomPackage,
	IsOpen,
	IsRemoved,
	IsArchive,
	CreatedDate,
	UpdatedDate,
	TimeIn,
	TimeOut,
	PaymentCategory,
	CorporateName,
	ReservationNo,
	DriverName,
	EmployeeNumber,
	VehicleNumber,
	VehicleMake,
	VehicleModel,
	VehicleType,
	BataDescription,
	BataAmount
)
SELECT * FROM 
(
	SELECT DISTINCT
	   archiveTrip.TripId
      ,ISNULL(archiveTrip.PaymentType,'') as PaymentType
      ,archiveTrip.GuestName
      ,archiveTrip.RoomNumber
	  ,archiveTrip.MeterReadingInGap
	  ,archiveTrip.MeterReadingOutGap
	  ,archiveTrip.MeterReadingInGps
	  ,archiveTrip.MeterReadingOutGps
      ,archiveTrip.MeterReadingIn
      ,archiveTrip.MeterReadingOut
      ,archiveTrip.Amount
      ,archiveTrip.PackageCost
	  ,archiveTrip.AdditionalKmCost
      ,archiveTrip.WaitingHourCost
      ,archiveTrip.PassengerType
      ,archiveTrip.PaymentDateTime
      ,archiveTrip.Remarks
	  ,archiveTrip.VoucherNumber
	  ,archiveTrip.DispatchedHotel
      ,archiveTrip.Createdby
      ,archiveTrip.Updatedby
	  ,archiveTrip.TripMileage
	  ,archiveTrip.TripDuration
      ,archiveTrip.IsCustomPackage
      ,archiveTrip.IsOpen
	  ,archiveTrip.IsRemoved
	  ,archiveTrip.IsArchive
	  ,archiveTrip.TimeOut AS CreatedDate
	  ,archiveTrip.TimeIn AS UpdatedDate
	  ,archiveTrip.TimeIn
	  ,archiveTrip.TimeOut
	  ,archiveTrip.PaymentCategory
	  ,archiveTrip.CorporateName
	  ,archiveTrip.ReservationNo
	  ,driver.FirstName+' '+ driver.LastName AS DriverName
	  ,driver.EmpNumber AS EmployeeNumber
	  ,vehicle.VehicleNumber
	  ,vehicle.VehicleMake
	  ,vehicle.VehicleModel
	  ,vehicle.VehicleType
	  ,bata.Description AS BataDescription
	  ,bata.Amount AS BataAmount
	  
	FROM ArchiveTrip archiveTrip
		INNER JOIN Driver driver ON driver.DriverId = archiveTrip.DriverId
		INNER JOIN Vehicle vehicle ON vehicle.VehicleId = archiveTrip.VehicleId
		LEFT JOIN TripBata bata ON archiveTrip.TripId = (SELECT DISTINCT bata.TripId FROM TripBata)
	WHERE
		(1 = CASE WHEN @Dispatcher IS NULL THEN 1 WHEN archiveTrip.Updatedby = @Dispatcher THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @DispatchedHotel IS NULL THEN 1 WHEN archiveTrip.DispatchedHotel = @DispatchedHotel THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PassengerType IS NULL THEN 1 WHEN archiveTrip.PassengerType = @PassengerType THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PaymentType IS NULL THEN 1 WHEN archiveTrip.PaymentType = @PaymentType THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @DriverId IS NULL THEN 1 WHEN archiveTrip.DriverId = @DriverId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @VehicleId IS NULL THEN 1 WHEN archiveTrip.VehicleId = @VehicleId THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @IsOpen IS NULL THEN 1 WHEN archiveTrip.IsOpen = @IsOpen THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @IsRemoved IS NULL THEN 1 WHEN archiveTrip.IsRemoved = @IsRemoved THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @CorporateName IS NULL THEN 1 WHEN archiveTrip.CorporateName = @CorporateName THEN 1 ELSE 0 END) AND
		(1 = CASE WHEN @PaymentCategory IS NULL THEN 1 WHEN archiveTrip.PaymentCategory = @PaymentCategory THEN 1 ELSE 0 END) AND
		ArchiveTrip.IsDeleted = 0 AND archiveTrip.TimeIn >=@StartDate AND archiveTrip.TimeIn <= @EndDate 
) AS b 

SELECT * FROM TempTable
SELECT * FROM PackagesList packages
INNER JOIN TempTable temp ON packages.TripId = temp.TripId

END
RETURN 0