<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DocSiteContents.ascx.cs" Inherits="MbUnit.Documentation.DocSiteContents" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:UpdatePanel ID="tocUpdatePanel" runat="server" ChildrenAsTriggers="true">
	<ContentTemplate>
		<div class="toc_buttons_container">
			<div class="toc_sync_container">
				<asp:ImageButton runat="server" ID="tocSyncButton" CssClass="toc_sync_button" 
				ImageUrl="~/DocSiteSync.gif" ToolTip="Synchronizes the sidebar with the current topic."
				onmouseover="this.className='toc_sync_button toc_sync_button_hot';" onmouseout="this.className='toc_sync_button';" />
				<asp:UpdateProgress runat="server" ID="tocUpdateProgress" AssociatedUpdatePanelID="tocUpdatePanel">
					<ProgressTemplate>
						<div class="toc_sync_progress">Please wait...</div>
					</ProgressTemplate>
				</asp:UpdateProgress>
			</div>
		</div>
		<div class="toc">
			<asp:TreeView ID="contentsTreeView" runat="server" ExpandDepth="0" ImageSet="Msdn" DataSourceID="contentsXmlDataSource" Width="100%"
				OnSelectedNodeChanged="contentsTreeView_SelectedNodeChanged" AutoGenerateDataBindings="false">
				<ParentNodeStyle Font-Bold="False" />
				<HoverNodeStyle CssClass="topicitem_hot" />
				<SelectedNodeStyle CssClass="topicitem_selected" />
				<NodeStyle CssClass="topicitem" />
				<DataBindings>
					<asp:TreeNodeBinding DataMember="topic" SelectAction="SelectExpand" PopulateOnDemand="true" TextField="name" ValueField="name" />
				</DataBindings>
			</asp:TreeView>
		</div>

		<asp:XmlDataSource XPath="topics/topic" ID="contentsXmlDataSource" runat="server"></asp:XmlDataSource>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="tocSyncButton" EventName="Click" />
		<asp:PostBackTrigger ControlID="contentsTreeView" />
	</Triggers>
</asp:UpdatePanel>