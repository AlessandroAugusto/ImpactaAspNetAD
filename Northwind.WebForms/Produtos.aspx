<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Northwind.WebForms.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Produtos</h2>
    <div class="row">
        <div class="col-lg-12">
            <asp:RadioButtonList runat="server"
                ID="criterioRadioButtonList"
                RepeatDirection="Horizontal"
                RepeatLayout="Flow"
                OnSelectedIndexChanged="criterioRadioButtonList_SelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Text="Categoria" Value="0" Selected="True" />
                <asp:ListItem Text="Fornecedor" Value="1" />
            </asp:RadioButtonList>
            <asp:MultiView ActiveViewIndex="0"
                runat="server" ID="criterioMultiView">
                <asp:View runat="server" ID="categoriaView">
                    <asp:DropDownList runat="server"
                        ID="categoriaDrop"
                        DataTextField="CategoryName"
                        DataValueField="CategoryID"
                        DataSourceID="categoriaDataSource"
                        AppendDataBoundItems="true"
                        AutoPostBack="true">

                        <asp:ListItem Text="Selecione uma categoria" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server"
                        ID="categoriaDataSource"
                        TypeName="Northwind.Repositorios.SqlServer.Ado.CategoriaRepositorio"
                        SelectMethod="Selecionar" />
                </asp:View>
                <asp:View runat="server" ID="fornecedorView">
                    <asp:DropDownList runat="server"
                        ID="fornecedorDrop"
                        DataTextField="CompanyName"
                        DataValueField="SupplierID"
                        DataSourceID="fornecedorDataSource"
                        AppendDataBoundItems="true"
                        AutoPostBack="true">
                        <asp:ListItem Text="Selecione um fornecedor" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server"
                        ID="fornecedorDataSource"
                        TypeName="Northwind.Repositorios.SqlServer.Ado.FornecedorRepositorio"
                        SelectMethod="Selecionar" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView runat="server"
                ID="produtosGrid"
                Width="100%"
                DataSourceID="produtosPorCategoriaDataSource"
                AutoGenerateColumns="false"
                >
                <Columns>
                    <asp:BoundField HeaderText="Produto" DataField="ProductName" />
                    <asp:BoundField HeaderText="Preço" DataField="UnitPrice" DataFormatString="{0:C}" />
                    <asp:BoundField HeaderText="Estoque" DataField="UnitsInStock" />
                </Columns>

            </asp:GridView>
            <asp:ObjectDataSource runat="server"
                ID="produtosPorCategoriaDataSource"
                TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio"
                SelectMethod="SelecionarPorCategoria">

                <SelectParameters>
                    <asp:ControlParameter ControlID="categoriaDrop" 
                        PropertyName="SelectedValue"
                        name="categoriaId"
                        Type="Int32"/>
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource runat="server"
                ID="produtosPorFornecedorDataSource"
                TypeName="Northwind.Repositorios.SqlServer.Ado.ProdutoRepositorio"
                SelectMethod="SelecionarPorFornecedor">

                <SelectParameters>
                    <asp:ControlParameter ControlID="fornecedorDrop" 
                        PropertyName="SelectedValue"
                        name="fornecedorId"
                        Type="Int32"/>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
