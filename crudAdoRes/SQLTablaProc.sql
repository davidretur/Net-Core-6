USE [DBEmpleado]  
GO  
  
/****** Object:  Table [dbo].[GroupMeeting]    Script Date: 27/07/2018 00:47:57 ******/  
SET ANSI_NULLS ON  
GO  
  
SET QUOTED_IDENTIFIER ON  
GO  
  
SET ANSI_PADDING ON  
GO  
  
CREATE TABLE [dbo].[GroupMeeting](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [ProjectName] [varchar](50) NULL,  
    [GroupMeetingLeadName] [varchar](50) NULL,  
    [TeamLeadName] [varchar](50) NULL,  
    [Description] [varchar](50) NULL,  
    [GroupMeetingDate] [date] NULL,  
 CONSTRAINT [PK_GroupMeeting-2] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
  
SET ANSI_PADDING OFF  
GO  

Create procedure [dbo].[GetGroupMeetingDetails]  
AS  
BEGIN  
     SELECT * FROM GROUPMEETING  
END  

Create procedure [dbo].[GetGroupMeetingByID](@Id int)  
AS  
BEGIN  
     SELECT * FROM GROUPMEETING where id=@Id  
END 


create procedure [dbo].[InsertGroupMeeting]  
(  
    @ProjectName varchar(50),  
    @GroupMeetingLeadName varchar(50),  
    @TeamLeadName varchar(50),  
    @Description varchar(50),  
    @GroupMeetingDate date  
)  
As  
BEGIN  
  
 INSERT INTO GroupMeeting(ProjectName,GroupMeetingLeadName,TeamLeadName,Description,GroupMeetingDate)  
 VALUES(@ProjectName,@GroupMeetingLeadName,@TeamLeadName,@Description,@GroupMeetingDate)  
  
END 

create procedure [dbo].[UpdateGroupMeeting]  
(  
    @Id int,  
    @ProjectName varchar(50),  
    @GroupMeetingLeadName varchar(50),  
    @TeamLeadName varchar(50),  
    @Description varchar(50),  
    @GroupMeetingDate date  
)  
As  
BEGIN  
     UPDATE GroupMeeting  
     SET ProjectName =@ProjectName,  
     GroupMeetingLeadName =@GroupMeetingLeadName,  
     TeamLeadName = @TeamLeadName,  
     Description = @Description,  
     GroupMeetingDate =@GroupMeetingDate  
     Where Id=@Id  
END 

create procedure [dbo].[DeleteGroupMeeting]  
(  
    @Id int   
)  
As  
BEGIN  
    DELETE FROM GroupMeeting WHERE Id=@Id  
END 