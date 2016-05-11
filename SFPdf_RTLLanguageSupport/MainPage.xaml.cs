using SFPdf_RTLLanguageSupport.Utils;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SFPdf_RTLLanguageSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<FontFamilyModel> fontFamilyList = new List<FontFamilyModel>();

        private void GeneratePdf_Click(object sender, RoutedEventArgs e)
        {
            CreatePDF();
        }

        public async void CreatePDF()
        {
            PdfDocument document = new PdfDocument();

            document.PageSettings.Size = PdfPageSize.A4;

            //set fixed margin
            //document.PageSettings.SetMargins(12);

            //Add a page to the document.
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            FontFamilyModel fontFamilyModel = new FontFamilyModel();
            fontFamilyModel.FontName = "segoeuiFont";
            fontFamilyModel.FontType = assembly.GetManifestResourceStream("SFPdf_RTLLanguageSupport.Assets.Fonts.segoeui.ttf");
            fontFamilyList.Add(fontFamilyModel);

            fontFamilyModel = new FontFamilyModel();
            fontFamilyModel.FontName = "arialFont";
            fontFamilyModel.FontType = assembly.GetManifestResourceStream("SFPdf_RTLLanguageSupport.Assets.Fonts.arial.ttf");
            fontFamilyList.Add(fontFamilyModel);

            fontFamilyModel = new FontFamilyModel();
            fontFamilyModel.FontName = "andlsoFont";
            fontFamilyModel.FontType = assembly.GetManifestResourceStream("SFPdf_RTLLanguageSupport.Assets.Fonts.andlso.ttf");
            fontFamilyList.Add(fontFamilyModel);

            fontFamilyModel = new FontFamilyModel();
            fontFamilyModel.FontName = "tradoFont";
            fontFamilyModel.FontType = assembly.GetManifestResourceStream("SFPdf_RTLLanguageSupport.Assets.Fonts.trado.ttf");
            fontFamilyList.Add(fontFamilyModel);            

            PdfFont Arabicfont;
            if (fontFamily.SelectedIndex == -1 || fontFamily.SelectedIndex == 1)
                Arabicfont = new PdfTrueTypeFont(fontFamilyList[1].FontType, 16);
            else
                Arabicfont = new PdfTrueTypeFont(fontFamilyList[fontFamily.SelectedIndex].FontType, 16); 

            PdfStringFormat FormatRTL = new PdfStringFormat();
            FormatRTL.Alignment = PdfTextAlignment.Right;
            FormatRTL.WordWrap = PdfWordWrapType.Word;
            
            PdfStringFormat FormatLTR = new PdfStringFormat();
            FormatLTR.Alignment = PdfTextAlignment.Left;
            FormatLTR.WordWrap = PdfWordWrapType.Word;

            string richText;
            TextToWriteInPDF.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out richText);

            PdfTextElement textElement = new PdfTextElement(ArabicScripting.ConvertArabicTextToRTLShapes(richText), Arabicfont, null, PdfBrushes.Black, FormatRTL);
            
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            
            layoutFormat.Layout = PdfLayoutType.Paginate;

            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            
            PdfLayoutResult result = textElement.Draw(page, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);

            //Save the document.
            MemoryStream PdfMemoryStream = new MemoryStream();
            await document.SaveAsync(PdfMemoryStream);

            var pdfFile = await SaveContract(PdfMemoryStream);

            if (pdfFile != null)
                await Windows.System.Launcher.LaunchFileAsync(pdfFile);

            //Close the document.
            document.Close(true);
        }

        private async Task<StorageFile> SaveContract(Stream stream)
        {
            stream.Position = 0;

            StorageFile stFile;

            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedFileName = "SFPdfRTL";
            fileSavePicker.FileTypeChoices.Add(".pdf", new List<string> { ".pdf" });
            fileSavePicker.SuggestedStartLocation = PickerLocationId.Desktop;

            stFile = await fileSavePicker.PickSaveFileAsync();

            if (stFile != null)
            {
                IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                Stream st = fileStream.AsStreamForWrite();
                st.SetLength(0);
                st.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);
                st.Flush();
                st.Dispose();
                fileStream.Dispose();
            }

            return stFile;
        }
    }

    public class FontFamilyModel
    {
        public string FontName { get; set; }
        public Stream FontType { get; set; }
    }

}
