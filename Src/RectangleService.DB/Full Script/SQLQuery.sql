ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserClaims] DROP CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__AspNetUse__Creat__4CA06362]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_AspNetUsers_IsActive]
GO
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Rol__Creat__49C3F6B7]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/29/2023 6:39:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 5/29/2023 6:39:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 5/29/2023 6:39:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserClaims]') AND type in (N'U'))
DROP TABLE [dbo].[UserClaims]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/29/2023 6:39:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Rectangles]    Script Date: 5/29/2023 6:39:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rectangles]') AND type in (N'U'))
DROP TABLE [dbo].[Rectangles]
GO
/****** Object:  Table [dbo].[Rectangles]    Script Date: 5/29/2023 6:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rectangles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
 CONSTRAINT [PK_Rectangle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/29/2023 6:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Icon] [varbinary](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[Description] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 5/29/2023 6:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 5/29/2023 6:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/29/2023 6:39:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[TwoFactorProvider] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Rectangles] ON 
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (1, 0, 0, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (2, 10, 10, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (3, 20, 20, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (4, 30, 30, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (5, 40, 40, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (6, 50, 50, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (7, 60, 60, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (8, 70, 70, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (9, 80, 80, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (10, 90, 90, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (11, 100, 100, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (12, 110, 110, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (13, 120, 120, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (14, 130, 130, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (15, 140, 140, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (16, 150, 150, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (17, 160, 160, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (18, 170, 170, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (19, 180, 180, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (20, 190, 190, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (21, 200, 200, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (22, 210, 210, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (23, 220, 220, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (24, 230, 230, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (25, 240, 240, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (26, 250, 250, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (27, 260, 260, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (28, 270, 270, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (29, 280, 280, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (30, 290, 290, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (31, 300, 300, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (32, 310, 310, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (33, 320, 320, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (34, 330, 330, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (35, 340, 340, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (36, 350, 350, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (37, 360, 360, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (38, 370, 370, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (39, 380, 380, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (40, 390, 390, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (41, 400, 400, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (42, 410, 410, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (43, 420, 420, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (44, 430, 430, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (45, 440, 440, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (46, 450, 450, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (47, 460, 460, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (48, 470, 470, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (49, 480, 480, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (50, 490, 490, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (51, 500, 500, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (52, 510, 510, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (53, 520, 520, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (54, 530, 530, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (55, 540, 540, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (56, 550, 550, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (57, 560, 560, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (58, 570, 570, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (59, 580, 580, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (60, 590, 590, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (61, 600, 600, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (62, 610, 610, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (63, 620, 620, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (64, 630, 630, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (65, 640, 640, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (66, 650, 650, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (67, 660, 660, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (68, 670, 670, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (69, 680, 680, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (70, 690, 690, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (71, 700, 700, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (72, 710, 710, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (73, 720, 720, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (74, 730, 730, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (75, 740, 740, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (76, 750, 750, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (77, 760, 760, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (78, 770, 770, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (79, 780, 780, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (80, 790, 790, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (81, 800, 800, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (82, 810, 810, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (83, 820, 820, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (84, 830, 830, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (85, 840, 840, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (86, 850, 850, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (87, 860, 860, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (88, 870, 870, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (89, 880, 880, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (90, 890, 890, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (91, 900, 900, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (92, 910, 910, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (93, 920, 920, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (94, 930, 930, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (95, 940, 940, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (96, 950, 950, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (97, 960, 960, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (98, 970, 970, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (99, 980, 980, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (100, 990, 990, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (101, 1000, 1000, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (102, 1010, 1010, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (103, 1020, 1020, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (104, 1030, 1030, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (105, 1040, 1040, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (106, 1050, 1050, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (107, 1060, 1060, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (108, 1070, 1070, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (109, 1080, 1080, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (110, 1090, 1090, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (111, 1100, 1100, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (112, 1110, 1110, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (113, 1120, 1120, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (114, 1130, 1130, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (115, 1140, 1140, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (116, 1150, 1150, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (117, 1160, 1160, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (118, 1170, 1170, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (119, 1180, 1180, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (120, 1190, 1190, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (121, 1200, 1200, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (122, 1210, 1210, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (123, 1220, 1220, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (124, 1230, 1230, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (125, 1240, 1240, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (126, 1250, 1250, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (127, 1260, 1260, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (128, 1270, 1270, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (129, 1280, 1280, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (130, 1290, 1290, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (131, 1300, 1300, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (132, 1310, 1310, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (133, 1320, 1320, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (134, 1330, 1330, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (135, 1340, 1340, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (136, 1350, 1350, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (137, 1360, 1360, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (138, 1370, 1370, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (139, 1380, 1380, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (140, 1390, 1390, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (141, 1400, 1400, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (142, 1410, 1410, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (143, 1420, 1420, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (144, 1430, 1430, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (145, 1440, 1440, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (146, 1450, 1450, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (147, 1460, 1460, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (148, 1470, 1470, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (149, 1480, 1480, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (150, 1490, 1490, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (151, 1500, 1500, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (152, 1510, 1510, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (153, 1520, 1520, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (154, 1530, 1530, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (155, 1540, 1540, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (156, 1550, 1550, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (157, 1560, 1560, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (158, 1570, 1570, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (159, 1580, 1580, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (160, 1590, 1590, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (161, 1600, 1600, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (162, 1610, 1610, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (163, 1620, 1620, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (164, 1630, 1630, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (165, 1640, 1640, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (166, 1650, 1650, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (167, 1660, 1660, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (168, 1670, 1670, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (169, 1680, 1680, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (170, 1690, 1690, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (171, 1700, 1700, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (172, 1710, 1710, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (173, 1720, 1720, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (174, 1730, 1730, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (175, 1740, 1740, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (176, 1750, 1750, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (177, 1760, 1760, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (178, 1770, 1770, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (179, 1780, 1780, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (180, 1790, 1790, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (181, 1800, 1800, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (182, 1810, 1810, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (183, 1820, 1820, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (184, 1830, 1830, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (185, 1840, 1840, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (186, 1850, 1850, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (187, 1860, 1860, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (188, 1870, 1870, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (189, 1880, 1880, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (190, 1890, 1890, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (191, 1900, 1900, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (192, 1910, 1910, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (193, 1920, 1920, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (194, 1930, 1930, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (195, 1940, 1940, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (196, 1950, 1950, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (197, 1960, 1960, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (198, 1970, 1970, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (199, 1980, 1980, 10, 10)
GO
INSERT [dbo].[Rectangles] ([Id], [X], [Y], [Width], [Height]) VALUES (200, 1990, 1990, 10, 10)
GO
SET IDENTITY_INSERT [dbo].[Rectangles] OFF
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [TwoFactorProvider], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'd619b8b1-208b-41f4-9d3a-e13d1dc41f7a', N'admin', N'ADMIN', N'123@abc.com', N'123@ABC.COM', 0, N'AQAAAAEAACcQAAAAEEqJ9DOFH62fmPnnPMbUUBgjtFbUd1N81TuUeFYDJ1uQANrqnZp3jDgRlb5xZyfiDg==', N'NLQMEBQS36Z5KC5NMDDQYNOA452RM66H', N'd0e15cf6-9c46-487b-acd3-f5fe75cbdbdd', N'4378881234', 1, 0, NULL, 1, 0, N'Sam', N'Smith', NULL, 1, N'00000000-0000-0000-0000-000000000000', CAST(N'2023-05-26T02:10:33.0482751' AS DateTime2), N'00000000-0000-0000-0000-000000000000', NULL)
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF__Rol__Creat__49C3F6B7]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_AspNetUsers_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__AspNetUse__Creat__4CA06362]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
