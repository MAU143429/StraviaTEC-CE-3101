/****** Object:  Table [dbo].[Account]    Script Date: 2/6/2022 18:36:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[no_race] [int] NULL,
	[bank_account] [varchar](20) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 2/6/2022 18:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[no_activity] [int] IDENTITY(1,1) NOT NULL,
	[sport] [varchar](20) NULL,
	[no_race] [int] NULL,
	[no_challenge] [int] NULL,
	[o_username] [varchar](20) NULL,
	[route] [text] NULL,
	[distance] [int] NULL,
	[height] [int] NULL,
	[a_date] [date] NULL,
	[u_username] [varchar](20) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[no_activity] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 2/6/2022 18:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[category] [varchar](20) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[category] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Challenge]    Script Date: 2/6/2022 18:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Challenge](
	[no_challenge] [int] IDENTITY(1,1) NOT NULL,
	[o_username] [varchar](20) NULL,
	[c_name] [varchar](20) NULL,
	[final_date] [date] NULL,
 CONSTRAINT [PK_Challenge] PRIMARY KEY CLUSTERED 
(
	[no_challenge] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Follow]    Script Date: 2/6/2022 18:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Follow](
	[u_username] [varchar](20) NULL,
	[follow] [varchar](20) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Group]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Group](
	[no_group] [int] IDENTITY(1,1) NOT NULL,
	[o_username] [varchar](20) NULL,
	[g_name] [varchar](20) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[no_group] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Inscription]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inscription](
	[no_inscription] [int] IDENTITY(1,1) NOT NULL,
	[no_race] [int] NULL,
	[u_username] [varchar](20) NULL,
	[voucher] [text] NULL,
	[is_accepted] [bit] NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[no_inscription] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Member]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Member](
	[u_username] [varchar](20) NULL,
	[no_group] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Organizer]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organizer](
	[o_username] [varchar](20) NOT NULL,
	[o_password] [varchar](20) NULL,
 CONSTRAINT [PK_Organizer] PRIMARY KEY CLUSTERED 
(
	[o_username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Participation]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Participation](
	[u_username] [varchar](20) NULL,
	[no_challenge] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PermissionC]    Script Date: 2/6/2022 18:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PermissionC](
	[no_challenge] [int] NULL,
	[no_group] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PermissionR]    Script Date: 2/6/2022 18:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PermissionR](
	[no_race] [int] NULL,
	[no_group] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Race]    Script Date: 2/6/2022 18:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Race](
	[no_race] [int] IDENTITY(1,1) NOT NULL,
	[o_username] [varchar](20) NULL,
	[r_name] [varchar](20) NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
(
	[no_race] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RaceC]    Script Date: 2/6/2022 18:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RaceC](
	[no_race] [int] NULL,
	[category] [varchar](20) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Result]    Script Date: 2/6/2022 18:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Result](
	[no_result] [int] IDENTITY(1,1) NOT NULL,
	[no_activity] [int] NULL,
	[u_username] [varchar](20) NULL,
	[duration] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[no_result] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sponsor]    Script Date: 2/6/2022 18:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sponsor](
	[tradename] [varchar](20) NOT NULL,
	[phone] [int] NULL,
	[ceo] [varchar](20) NULL,
	[logo] [text] NULL,
 CONSTRAINT [PK_Sponsor] PRIMARY KEY CLUSTERED 
(
	[tradename] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sponsorship]    Script Date: 2/6/2022 18:37:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sponsorship](
	[tradename] [varchar](20) NULL,
	[no_race] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sport]    Script Date: 2/6/2022 18:37:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sport](
	[sport] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED 
(
	[sport] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2/6/2022 18:37:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[u_username] [varchar](20) NOT NULL,
	[category] [varchar](20) NULL,
	[name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[birthdate] [date] NULL,
	[nationality] [varchar](20) NULL,
	[u_password] [varchar](20) NULL,
	[image] [text] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[u_username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Race]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Challenge] FOREIGN KEY([no_challenge])
REFERENCES [dbo].[Challenge] ([no_challenge])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Challenge]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Organizer] FOREIGN KEY([o_username])
REFERENCES [dbo].[Organizer] ([o_username])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Organizer]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Race]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Sport] FOREIGN KEY([sport])
REFERENCES [dbo].[Sport] ([sport])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Sport]
GO

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_User]
GO

ALTER TABLE [dbo].[Challenge]  WITH CHECK ADD  CONSTRAINT [FK_Challenge_Organizer] FOREIGN KEY([o_username])
REFERENCES [dbo].[Organizer] ([o_username])
GO

ALTER TABLE [dbo].[Challenge] CHECK CONSTRAINT [FK_Challenge_Organizer]
GO

ALTER TABLE [dbo].[Follow]  WITH CHECK ADD  CONSTRAINT [FK_Follow_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Follow] CHECK CONSTRAINT [FK_Follow_User]
GO

ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Organizer] FOREIGN KEY([o_username])
REFERENCES [dbo].[Organizer] ([o_username])
GO

ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Organizer]
GO

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Race]
GO

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_User]
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Group] FOREIGN KEY([no_group])
REFERENCES [dbo].[Group] ([no_group])
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Group]
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_User]
GO

ALTER TABLE [dbo].[Participation]  WITH CHECK ADD  CONSTRAINT [FK_Participation_Challenge] FOREIGN KEY([no_challenge])
REFERENCES [dbo].[Challenge] ([no_challenge])
GO

ALTER TABLE [dbo].[Participation] CHECK CONSTRAINT [FK_Participation_Challenge]
GO

ALTER TABLE [dbo].[Participation]  WITH CHECK ADD  CONSTRAINT [FK_Participation_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Participation] CHECK CONSTRAINT [FK_Participation_User]
GO

ALTER TABLE [dbo].[PermissionC]  WITH CHECK ADD  CONSTRAINT [FK_PermissionC_Challenge] FOREIGN KEY([no_challenge])
REFERENCES [dbo].[Challenge] ([no_challenge])
GO

ALTER TABLE [dbo].[PermissionC] CHECK CONSTRAINT [FK_PermissionC_Challenge]
GO

ALTER TABLE [dbo].[PermissionC]  WITH CHECK ADD  CONSTRAINT [FK_PermissionC_Group] FOREIGN KEY([no_group])
REFERENCES [dbo].[Group] ([no_group])
GO

ALTER TABLE [dbo].[PermissionC] CHECK CONSTRAINT [FK_PermissionC_Group]
GO

ALTER TABLE [dbo].[PermissionR]  WITH CHECK ADD  CONSTRAINT [FK_PermissionR_Group] FOREIGN KEY([no_group])
REFERENCES [dbo].[Group] ([no_group])
GO

ALTER TABLE [dbo].[PermissionR] CHECK CONSTRAINT [FK_PermissionR_Group]
GO

ALTER TABLE [dbo].[PermissionR]  WITH CHECK ADD  CONSTRAINT [FK_PermissionR_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[PermissionR] CHECK CONSTRAINT [FK_PermissionR_Race]
GO

ALTER TABLE [dbo].[Race]  WITH CHECK ADD  CONSTRAINT [FK_Race_Organizer] FOREIGN KEY([o_username])
REFERENCES [dbo].[Organizer] ([o_username])
GO

ALTER TABLE [dbo].[Race] CHECK CONSTRAINT [FK_Race_Organizer]
GO

ALTER TABLE [dbo].[RaceC]  WITH CHECK ADD  CONSTRAINT [FK_RaceC_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([category])
GO

ALTER TABLE [dbo].[RaceC] CHECK CONSTRAINT [FK_RaceC_Category]
GO

ALTER TABLE [dbo].[RaceC]  WITH CHECK ADD  CONSTRAINT [FK_RaceC_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[RaceC] CHECK CONSTRAINT [FK_RaceC_Race]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Activity] FOREIGN KEY([no_activity])
REFERENCES [dbo].[Activity] ([no_activity])
GO

ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Activity]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_User] FOREIGN KEY([u_username])
REFERENCES [dbo].[User] ([u_username])
GO

ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_User]
GO

ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sponsorship_Race] FOREIGN KEY([no_race])
REFERENCES [dbo].[Race] ([no_race])
GO

ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sponsorship_Race]
GO

ALTER TABLE [dbo].[Sponsorship]  WITH CHECK ADD  CONSTRAINT [FK_Sponsorship_Sponsor] FOREIGN KEY([tradename])
REFERENCES [dbo].[Sponsor] ([tradename])
GO

ALTER TABLE [dbo].[Sponsorship] CHECK CONSTRAINT [FK_Sponsorship_Sponsor]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([category])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Category]
GO


