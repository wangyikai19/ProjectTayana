<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="OverViewMgt.aspx.cs" Inherits="ProjectTayana.OverViewMgt" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.9.359/pdf.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h6>YachYacht Model :</h6>
<asp:DropDownList ID="DListModel" runat="server" DataSourceID="SqlDataSource1" DataTextField="yachtModel" DataValueField="id" AutoPostBack="True" Width="100%" Font-Bold="True" class="" OnSelectedIndexChanged="DListModel_SelectedIndexChanged" ></asp:DropDownList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT [yachtModel], [id] FROM [Yacht]"></asp:SqlDataSource>
<hr />
<h6>Dimensions Image :</h6>
<asp:Literal ID="LiteralDimImg" runat="server"></asp:Literal>
<div class="input-group my-3">
    <asp:FileUpload ID="DimImgUpload" runat="server" class="" />
    <asp:Button ID="BtnUploadDimImg" runat="server" Text="Upload" class="" OnClick="BtnUploadDimImg_Click" />
</div>
<span class="badge badge-pill badge-warning text-dark">*Upload by No Choose File Could Clean File!</span>
<hr />
<h6>Downloads File :</h6>
<asp:Literal ID="PDFpreview" runat="server" ></asp:Literal>
<div class="input-group my-3">
    <asp:FileUpload ID="FileUpload" runat="server" class="" />
    <asp:Button ID="BtnUploadFile" runat="server" Text="Upload" class="" OnClick="BtnUploadFile_Click" />
</div>
<span class="badge badge-pill badge-warning text-dark">*Upload by No Choose File Could Clean File!</span>
    <h6>Dimensions Text :</h6>
<table class="table table-hover">
    <thead>
    </thead>
    <tbody>
        <asp:Literal ID="LitDimensionsHtml" runat="server"></asp:Literal>

                <tr>
            <th>
                <p class="d-inline-block m-r-20">Hull length</p>
            </th>
            <td>
                <asp:TextBox ID="txt_Hulllength" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">L.W.L.</p>
            </th>
            <td>
                <asp:TextBox ID="txt_LWL" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">B. MAX</p>
            </th>
            <td>
                <asp:TextBox ID="txt_BMAX" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">Standard draft</p>
            </th>
            <td>
                <asp:TextBox ID="txt_StandardDraft" runat="server" type="text" class="form-control"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">Ballast</p>
            </th>
            <td>
                <asp:TextBox ID="txt_Ballast" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">Displacement</p>
            </th>
            <td>
                <asp:TextBox ID="txt_Displacement" runat="server" type="text" class="form-control"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">Sail area</p>
            </th>
            <td>
                <asp:TextBox ID="txt_SailArea" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>
                <tr>
            <th>
                <p class="d-inline-block m-r-20">Cutter</p>
            </th>
            <td>
                <asp:TextBox ID="txt_Cutter" runat="server" type="text" class="form-control" ></asp:TextBox>
            </td>
        </tr>


        <tr>
            <th>
                <p class="d-inline-block m-r-20">Dimensions Image</p>
            </th>
            <td>
<%--                <asp:TextBox ID="TBoxDimImg" runat="server" type="text" class="form-control"></asp:TextBox>--%>
                <asp:Label ID="TBoxDimImg" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                <p class="d-inline-block m-r-20">Downloads File</p>
            </th>
            <td>
<%--                <asp:TextBox ID="TBoxDLFile" runat="server" type="text" class="form-control"></asp:TextBox>--%>
                <asp:Label ID="TBoxDLFile" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <th>
                <asp:Label ID="LabUpdateTitle" runat="server" Text="Click for Update"></asp:Label>
            </th>
            <td>
                <asp:Button ID="BtnUpdateDimensionsList" runat="server" Text="Update Dimensions List" class="btn btn-outline-primary btn-block" OnClick="BtnUpdateDimensionsList_Click" />
                <asp:Label ID="LabUpdateDimensionsList" runat="server" Text="*Upload Success!" ForeColor="green" class="d-flex justify-content-center" Visible="False"></asp:Label>
            </td>
        </tr>
    </tfoot>
</table>
    <h6>Main Content :</h6>
    <textarea name="editor1" id="editor1" rows="50" cols="80" runat="server"></textarea>
<asp:Label ID="LabUploadMainContent" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
<asp:Button ID="BtnUploadMainContent" runat="server" Text="Upload Overview Content" class="mt-3" OnClick="BtnUploadMainContent_Click" />
     <script type="text/jscript" src="https://cdn.ckeditor.com/ckeditor5/34.1.0/super-build/ckeditor.js"></script>
<script type="text/javascript">
    // This sample still does not showcase all CKEditor 5 features (!)
    // Visit https://ckeditor.com/docs/ckeditor5/latest/features/index.html to browse all the features.
    CKEDITOR.ClassicEditor.create(document.getElementById("ContentPlaceHolder1_editor1"), {
        // https://ckeditor.com/docs/ckeditor5/latest/features/toolbar/toolbar.html#extended-toolbar-configuration-format
        toolbar: {
            items: ['ckfinder', '|',
                'exportPDF', 'exportWord', '|',
                'findAndReplace', 'selectAll', '|',
                'heading', '|',
                'bold', 'italic', 'strikethrough', 'underline', 'code', 'subscript', 'superscript', 'removeFormat', '|',
                'bulletedList', 'numberedList', 'todoList', '|',
                'outdent', 'indent', '|',
                'undo', 'redo',
                '-',
                'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
                'alignment', '|',
                'link', 'insertImage', 'blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
                'specialCharacters', 'horizontalLine', 'pageBreak', '|',
                'textPartLanguage', '|',
                'sourceEditing'
            ],
            shouldNotGroupWhenFull: true
        },
        // Changing the language of the interface requires loading the language file using the <script> tag.
        language: 'tw',
        list: {
            properties: {
                styles: true,
                startIndex: true,
                reversed: true
            }
        },
        // https://ckeditor.com/docs/ckeditor5/latest/features/headings.html#configuration
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
            ]
        },
        // https://ckeditor.com/docs/ckeditor5/latest/features/editor-placeholder.html#using-the-editor-configuration
        placeholder: 'Welcome to CKEditor 5!',
        // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-family-feature
        fontFamily: {
            options: [
                'default',
                'Arial, Helvetica, sans-serif',
                'Courier New, Courier, monospace',
                'Georgia, serif',
                'Lucida Sans Unicode, Lucida Grande, sans-serif',
                'Tahoma, Geneva, sans-serif',
                'Times New Roman, Times, serif',
                'Trebuchet MS, Helvetica, sans-serif',
                'Verdana, Geneva, sans-serif'
            ],
            supportAllValues: true
        },
        // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-size-feature
        fontSize: {
            options: [10, 12, 14, 'default', 18, 20, 22],
            supportAllValues: true
        },
        // Be careful with the setting below. It instructs CKEditor to accept ALL HTML markup.
        // https://ckeditor.com/docs/ckeditor5/latest/features/general-html-support.html#enabling-all-html-features
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        // Be careful with enabling previews
        // https://ckeditor.com/docs/ckeditor5/latest/features/html-embed.html#content-previews
        htmlEmbed: {
            showPreviews: true
        },
        // https://ckeditor.com/docs/ckeditor5/latest/features/link.html#custom-link-attributes-decorators
        link: {
            decorators: {
                addTargetToExternalLinks: true,
                defaultProtocol: 'https://',
                toggleDownloadable: {
                    mode: 'manual',
                    label: 'Downloadable',
                    attributes: {
                        download: 'file'
                    }
                }
            }
        },
        // https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html#configuration
        mention: {
            feeds: [
                {
                    marker: '@',
                    feed: [
                        '@apple', '@bears', '@brownie', '@cake', '@cake', '@candy', '@canes', '@chocolate', '@cookie', '@cotton', '@cream',
                        '@cupcake', '@danish', '@donut', '@dragée', '@fruitcake', '@gingerbread', '@gummi', '@ice', '@jelly-o',
                        '@liquorice', '@macaroon', '@marzipan', '@oat', '@pie', '@plum', '@pudding', '@sesame', '@snaps', '@soufflé',
                        '@sugar', '@sweet', '@topping', '@wafer'
                    ],
                    minimumCharacters: 1
                }
            ]
        },
        // The "super-build" contains more premium features that require additional configuration, disable them below.
        // Do not turn them on unless you read the documentation and know how to configure them and setup the editor.
        removePlugins: [
            // These two are commercial, but you can try them out without registering to a trial.
            // 'ExportPdf',
            // 'ExportWord',



            // This sample uses the Base64UploadAdapter to handle image uploads as it requires no configuration.
            // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/base64-upload-adapter.html
            // Storing images as Base64 is usually a very bad idea.
            // Replace it on production website with other solutions:
            // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/image-upload.html
            // 'Base64UploadAdapter',
            'RealTimeCollaborativeComments',
            'RealTimeCollaborativeTrackChanges',
            'RealTimeCollaborativeRevisionHistory',
            'PresenceList',
            'Comments',
            'TrackChanges',
            'TrackChangesData',
            'RevisionHistory',
            'Pagination',
            'WProofreader',
            // Careful, with the Mathtype plugin CKEditor will not load when loading this sample
            // from a local file system (file://) - load this site via HTTP server if you enable MathType
            'MathType'
        ]
    });
</script>
</asp:Content>
