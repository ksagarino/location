USE [LocationDB]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 18/10/2018 6:42:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[Province] [varchar](50) NULL,
	[IsDeleted] [int] NULL CONSTRAINT [DF_Location_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (1, N'VIFEL BULACAN', N'Address Not Specified', N'City Not Specified', N'BULACAN', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (2, N'NAVOTAS', N'Address Not Specified', N'City Not Specified', N'NCR, THIRD DISTRICT', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (3, N'BAGAC BATAAN', N'Address Not Specified', N'City Not Specified', N'BATAAN', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (4, N'MARIVELES BATAAN"', N'Address Not Specified', N'City Not Specified', N'BATAAN', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (5, N'INTAQ', N'Address Not Specified', N'City Not Specified', N'CEBU', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (6, N'COMPOSTELA', N'Address Not Specified', N'City Not Specified', N'CEBU', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (7, N'TUBIGON', N'Address Not Specified', N'City Not Specified', N'BOHOL', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (8, N'TALIBON', N'Address Not Specified', N'City Not Specified', N'BOHOL', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (9, N'MAHAYAG', N'Address Not Specified', N'City Not Specified', N'BOHOL', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (10, N'DAMPAS', N'Address Not Specified', N'City Not Specified', N'BOHOL', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (11, N'TAGOLOAN', N'Address Not Specified', N'City Not Specified', N'MISAMIS ORIENTAL', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (12, N'MAIN OFFICE', N'Address Not Specified', N'City Not Specified', N'CEBU', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (13, N'HOLCIM BULACAN', N'Address Not Specified', N'City Not Specified', N'BULACAN', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (14, N'LBC DAVAO', N'Address Not Specified', N'City Not Specified', N'DAVAO DEL SUR', 0)
INSERT [dbo].[Location] ([ID], [Name], [Address], [City], [Province], [IsDeleted]) VALUES (15, N'MANILA', N'Address Not Specified', N'City Not Specified', N'MANILA', 0)
SET IDENTITY_INSERT [dbo].[Location] OFF
