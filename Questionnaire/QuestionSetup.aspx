<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionSetup.aspx.cs" Inherits="QuestionSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="site.css" rel="stylesheet" />
    <title>Question Administration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsQuestions" KeyFieldName="Id" EnableTheming="True" Theme="Mulberry" Width="100%">
                <SettingsPager PageSize="50">
                </SettingsPager>
                <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom">
                </SettingsEditing>
                <Settings ShowFilterRow="True" />
                <Columns>
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="50px">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="QNo" VisibleIndex="2" Width="50px">
                        <Settings AutoFilterCondition="BeginsWith" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Question" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="IsSection" VisibleIndex="4" Width="50px"></dx:GridViewDataCheckColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource runat="server" ID="dsQuestions" ConnectionString='<%$ ConnectionStrings:MyWebConnectionString %>' DeleteCommand="DELETE FROM [cQuestions] WHERE [Id] = @Id" InsertCommand="INSERT INTO [cQuestions] ([QNo], [Question], [IsSection]) VALUES (@QNo, @Question, @IsSection)" SelectCommand="SELECT * FROM [cQuestions] ORDER BY [QNo]" UpdateCommand="UPDATE [cQuestions] SET [QNo] = @QNo, [Question] = @Question, [IsSection] = @IsSection WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="QNo" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="Question" Type="String"></asp:Parameter>
                    <asp:Parameter Name="IsSection" Type="Boolean"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="QNo" Type="Double"></asp:Parameter>
                    <asp:Parameter Name="Question" Type="String"></asp:Parameter>
                    <asp:Parameter Name="IsSection" Type="Boolean"></asp:Parameter>
                    <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
