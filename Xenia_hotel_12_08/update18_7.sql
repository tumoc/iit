CREATE TABLE [dbo].[Amenities](
	[ID] [int] primary key IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Status] [bit] NOT NULL,
	[Index] [int] ,
	[Home] [bit] NOT NULL,
	[languageID] [varchar](10)  not NULL
)CREATE TABLE [dbo].[MenuAmenity](
	[MenuAmenityID] [int] primary key IDENTITY(1,1) NOT NULL,
	MenuID [int]  foreign key(MenuID) references Menu(ID),
	[AmenityID] [int] foreign key(AmenityID) references Amenities(ID),
)
go
CREATE TABLE [dbo].[RoomAmenity](
	[RoomAmenityID] [int] primary key IDENTITY(1,1) NOT NULL,
	[RoomID] [int]  foreign key(RoomID) references Room(ID),
	[AmenityID] [int] foreign key(AmenityID) references Amenities(ID),
) go
Create table Subscribe (
	ID int primary key Identity(1,1),
	Email nvarchar(100) not null,
	CreateDate datetime not null
) go 