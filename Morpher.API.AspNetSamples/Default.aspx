<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AspNetSamples._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h1>Примеры склонения по падежам при помощи Morpher.API.dll </h1>

    <p>
        На этой страничке собраны примеры использования библиотеки склонения по падежам Morpher.API.dll.  Пока имеется только один пример:
    </p>
    <ul>
        <li>
            <a href='FacebookStory.aspx'>FacebookStory - История на Фейсбуке</a>.  Генерация параллельных текстов по шаблону на русском, украинском и английском языках.
        </li>
    </ul>
</asp:Content>
