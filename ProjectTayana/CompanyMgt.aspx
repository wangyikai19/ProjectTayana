<%@ Page Title="" Language="C#" MasterPageFile="~/Mgt.Master" AutoEventWireup="true" CodeBehind="CompanyMgt.aspx.cs" Inherits="ProjectTayana.CompanyMgt" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h6>Content :</h6>
    <div>
        <textarea name="editor1" id="editor1" rows="50" cols="80" runat="server">
 </textarea>
    </div>

    <div class="center btns">
        <asp:Button ID="btnOK" runat="server" Text="修改" OnClick="btnOK_Click" />
    </div>

    <h6>Content Text :</h6>
<asp:TextBox ID="certificatTbox" runat="server" type="text" class="form-control" placeholder="Enter certificat text" TextMode="MultiLine" Height="200px"></asp:TextBox>
<asp:Label ID="uploadCertificatLab" runat="server" Visible="False" ForeColor="#009933" class="d-flex justify-content-center"></asp:Label>
<asp:Button ID="uploadCertificatBtn" runat="server" Text="Upload Certificat Text" class="" OnClick="uploadCertificatBtn_Click"/>


    <h6>Upload Horizontal Group Image :</h6>
<div class="input-group my-3">
    <asp:FileUpload ID="imageUploadH" runat="server" class="" AllowMultiple="True" />
    <asp:Button ID="UploadHBtn" runat="server" Text="Upload" class="" OnClick="UploadHBtn_Click" />
</div>
<h6>Horizontal Image List :</h6>
<asp:RadioButtonList ID="RadioButtonListH" runat="server" class="my-3 mx-auto" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListH_SelectedIndexChanged" CellPadding="10" RepeatColumns="2" RepeatDirection="Horizontal"></asp:RadioButtonList>
<asp:Button ID="DelHImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelHImageBtn_Click" />

    <h6>Upload Vertical Group Image :</h6>
<div class="input-group my-3">
    <asp:FileUpload ID="imageUploadV" runat="server" class="" AllowMultiple="True" />
    <asp:Button ID="Button2" runat="server" Text="Upload" class="" OnClick="UploadVBtn_Click" />
</div>

<h6>Vertical Image List :</h6>
<asp:RadioButtonList ID="RadioButtonListV" runat="server" class="my-3 mx-auto" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListV_SelectedIndexChanged" CellPadding="10" RepeatColumns="2" RepeatDirection="Vertical"></asp:RadioButtonList>
<asp:Button ID="DelVImageBtn" runat="server" Text="Delete Image" type="button" class="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete？')" Visible="False" OnClick="DelVImageBtn_Click" />

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
