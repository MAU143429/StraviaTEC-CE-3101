/****** Object:  Table [dbo].[Account]    Script Date: 28/5/2022 15:46:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[no_race] [int] NOT NULL,
	[bank_account] [varchar](20) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Activity]    Script Date: 28/5/2022 15:46:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity](
	[no_activity] [int] NOT NULL IDENTITY(1,1),
	[sport] [varchar](20) NULL,
	[no_race] [int] NULL,
	[no_chalenge] [int] NULL,
	[o_username] [varchar](20) NULL,
	[route] [text] NULL,
	[length] [int] NULL,
	[a_date] [datetime] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[no_activity] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 28/5/2022 15:46:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[category] [varchar](20) NOT NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[category] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Challenge]    Script Date: 28/5/2022 15:46:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Challenge](
	[no_challenge] [int] NOT NULL IDENTITY(1,1),
	[c_name] [varchar](20) NULL,
	[final_date] [datetime] NULL,
 CONSTRAINT [PK_Challenge] PRIMARY KEY CLUSTERED 
(
	[no_challenge] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Follow]    Script Date: 28/5/2022 15:46:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Follow](
	[u_username] [varchar](20) NOT NULL,
	[follow] [varchar](20) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Group]    Script Date: 28/5/2022 15:46:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Group](
	[no_group] [int] NOT NULL IDENTITY(1,1),
	[g_name] [varchar](20) NULL,
	[o_username] [varchar](20) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[no_group] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Inscription]    Script Date: 28/5/2022 15:46:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inscription](
	[no_inscription] [int] NOT NULL IDENTITY(1,1),
	[no_race] [int] NOT NULL,
	[u_username] [varchar](20) NOT NULL,
	[voucher] [text] NULL,
	[is_accepted] [bit] NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[no_inscription] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Organizer]    Script Date: 28/5/2022 15:46:54 ******/
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

/****** Object:  Table [dbo].[Participation]    Script Date: 28/5/2022 15:46:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Participation](
	[u_username] [varchar](20) NULL,
	[no_challenge] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Permission]    Script Date: 28/5/2022 15:46:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permission](
	[no_challenge] [int] NOT NULL,
	[no_group] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Race]    Script Date: 28/5/2022 15:46:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Race](
	[no_race] [int] NOT NULL IDENTITY(1,1),
	[category] [varchar](20) NULL,
	[r_name] [varchar](20) NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED 
(
	[no_race] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Result]    Script Date: 28/5/2022 15:46:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Result](
	[no_result] [int] NOT NULL IDENTITY(1,1),
	[no_activity] [int] NULL,
	[u_username] [varchar](20) NULL,
	[duration] [timestamp] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[no_result] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sponsor]    Script Date: 28/5/2022 15:46:56 ******/
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

/****** Object:  Table [dbo].[Sponsorship]    Script Date: 28/5/2022 15:46:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sponsorship](
	[tradename] [varchar](20) NOT NULL,
	[no_race] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sport]    Script Date: 28/5/2022 15:46:57 ******/
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

/****** Object:  Table [dbo].[User]    Script Date: 28/5/2022 15:46:57 ******/
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

ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Challenge] FOREIGN KEY([no_chalenge])
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

ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Challenge] FOREIGN KEY([no_challenge])
REFERENCES [dbo].[Challenge] ([no_challenge])
GO

ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Challenge]
GO

ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Group] FOREIGN KEY([no_group])
REFERENCES [dbo].[Group] ([no_group])
GO

ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Group]
GO

ALTER TABLE [dbo].[Race]  WITH CHECK ADD  CONSTRAINT [FK_Race_Category] FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([category])
GO

ALTER TABLE [dbo].[Race] CHECK CONSTRAINT [FK_Race_Category]
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


