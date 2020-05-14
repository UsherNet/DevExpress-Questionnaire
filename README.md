#### DevExpress-Questionnaire ####

This project provices the source code from the November 2014 DevExpress Webinar "Build a Questionnaire for Your Website" 

<a href="http://www.youtube.com/watch?feature=player_embedded&v=y1uBstGLIJw
" target="_blank"><img src="http://img.youtube.com/vi/y1uBstGLIJw/0.jpg" 
alt="Build a Questionnaire Video" width="240" height="180" border="10" /></a>

The SQL table used in the presentation can be created using the following script:

```CREATE TABLE [dbo].[cQuestions](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[QNo] [FLOAT] NULL,
	[Question] [VARCHAR](1024) NULL,
	[IsSection] [BIT] NULL,
 CONSTRAINT [PK_cQuestions] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]```

