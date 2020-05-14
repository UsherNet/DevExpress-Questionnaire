DevExpress-Questionnaire

This project provices the source code from the November 2014 DevExpress Webinar "Build a Questionnaire for Your Website" 

https://www.youtube.com/watch?v=y1uBstGLIJw&feature=youtu.be


The SQL table used in the presentation can be created using the following script:

CREATE TABLE [dbo].[cQuestions](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[QNo] [FLOAT] NULL,
	[Question] [VARCHAR](1024) NULL,
	[IsSection] [BIT] NULL,
 CONSTRAINT [PK_cQuestions] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

