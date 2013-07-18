<%@ Page Title="FacebookStory" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="FacebookStory.aspx.cs" Inherits="AspNetSamples.FacebookStory" %>

<%@ Register Assembly="AspNetSamples" Namespace="AspNetSamples" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        FacebookStory
    </h2>

    <p> Этот пример демонстрирует генерацию текстов на трех языках по шаблонам при помощи интерфейса <b>IDynamicDeclension</b>.
        Выделенные слова автоматически склоняются в соответствии с языком и шаблоном.
    </p>

    <cc1:FlushingLiteral ID="FlushingLiteral1" runat="server" />
</asp:Content>
