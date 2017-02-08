// © ABBYY. 2012.
// SAMPLES code is property of ABBYY, exclusive rights are reserved. 
// DEVELOPER is allowed to incorporate SAMPLES into his own APPLICATION and modify it 
// under the terms of License Agreement between ABBYY and DEVELOPER.

// Product: FlexiCapture Engine Samples

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using FCEngine;
using FREngine;
using FileExportFormatEnum = FCEngine.FileExportFormatEnum;
using IEngine = FCEngine.IEngine;
using IImageDocument = FCEngine.IImageDocument;
using IRegion = FCEngine.IRegion;
using Image = System.Drawing.Image;
using ImageFileFormatEnum = FCEngine.ImageFileFormatEnum;
using Point = System.Drawing.Point;
using RotationTypeEnum = FCEngine.RotationTypeEnum;

namespace Sample
{
	public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
        {

            //var teste = @"C:\Users\junior\Dropbox\Public\FCDOTS\Fase5\M1-A\img_samples\0007.JPG";
            //var teste1 = @"C:\Users\junior\Dropbox\Public\FCDOTS\Fase5\M1-A\img_samples\0007_OUT.JPG";

            //var bmpIn = new Bitmap(teste);
            //var bmpOut = ImageFunctions.RotateImage(bmpIn, 0.5);

            //bmpOut.Save(teste1, ImageFormat.Jpeg);


			Application.SetUnhandledExceptionMode( UnhandledExceptionMode.ThrowException );
            Application.Run(new MainForm());
		}

        IEngine engine;
        IFlexiCaptureProcessor processor;
        IDocumentDefinition definition;
        private string[] imageFiles;
        private int currentImageFileIndex = 0;
        private Image processedImage;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            Application.EnableVisualStyles();
            
            initDefaults();
		}

        private void goButton_Click(object sender, EventArgs e)
        {
            try {
                processCurrentImageFile();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        private void processCurrentImageFile()
        {
            ProgressBarForm progressBar = new ProgressBarForm( this );

            try
            {
                progressBar.ShowMessage("Processando imagem");

                string exportPath = @"C:\Temp\images\result";
                if (Directory.Exists(exportPath))
                {
                    Directory.Delete(exportPath, true);
                }

                if (engine == null)
                {
                    engine = loadEngine();
                }

                if (processor == null)
                {
                    processor = engine.CreateFlexiCaptureProcessor();
                    processor.SetUseFirstMatchedDocumentDefinition(true);

                    foreach (object obj in documentoDefListBox.CheckedItems)
                    {
                        processor.AddDocumentDefinitionFile(obj.ToString());
                    }
                }
                else
                {
                    processor.ResetProcessing();
                }

                if (checkCarimbos.Checked)
                {
                    var x = engine.CreateImageProcessingTools();
                    var image = x.OpenImageFile(imageFiles[currentImageFileIndex]).OpenImagePage(0);
                    var image2 = x.FilterColor(image, null, ColorToFilterEnum.CTF_Blue, FilterColorModeEnum.FCM_Stamp);

                    processor.AddImage(image2);
                }

                if (checkBoxBin.Checked)
                {                 
                    var x = engine.CreateImageProcessingTools();
                    var image = x.OpenImageFile(imageFiles[currentImageFileIndex]).OpenImagePage(0);
                    var image2 = x.Binarize(image, BinarizationModeEnum.BM_Version9, false, false);                                     

                    processor.AddImage(image2);
                }
                else 
                    if (checkBoxRotate90.Checked)
                    {
                        var x = engine.CreateImageProcessingTools();
                        var pathImage = imageFiles[currentImageFileIndex];
                        var image = x.OpenImageFile(pathImage).OpenImagePage(0);
                                                
                        var language = engine.PredefinedLanguages.FindLanguage("PortugueseBrazilian");

                       if (x.DetectOrientationByText(image, language) == RotationTypeEnum.RT_Clockwise)
                        {
                            var image2 = x.RotateImageByRotationType(image, RotationTypeEnum.RT_Clockwise);
                            processor.AddImage(image2);                            
                        }                      
                        else if (x.DetectOrientationByText(x.Binarize(image, BinarizationModeEnum.BM_Default, false, false), language) == RotationTypeEnum.RT_Clockwise) 
                        {
                            var image2 = x.RotateImageByRotationType(image, RotationTypeEnum.RT_Clockwise);
                            processor.AddImage(image2);
                        }                        
                        else if (x.DetectOrientationByText(x.Binarize(image, BinarizationModeEnum.BM_Version9, false, false), language) == RotationTypeEnum.RT_Clockwise)
                        {
                            var image2 = x.RotateImageByRotationType(image, RotationTypeEnum.RT_Clockwise);
                            processor.AddImage(image2);
                        }
                        //else
                        //{
                            //pathImage = RotateAndSaveImage(pathImage, pathImage);
                            //var image2 = x.OpenImageFile(pathImage).OpenImagePage(0);
                            //processor.AddImage(image2);
                        //}
                        else
                        {
                           processor.AddImage(image);
                        }                    

                    }
                else
                {
                    processor.AddImageFile(imageFiles[currentImageFileIndex]);
                }

                progressBar.ShowProgress(10);

                if (checkBoxDeskew.Checked)
                {
                    var imageLoadingParams = engine.CreateImageLoadingParams();
                    imageLoadingParams.CorrectSkewByText = false;
                    imageLoadingParams.CorrectSkewByBlackSquares = false;
                    imageLoadingParams.CorrectSkewByBlackSeparators = false;
                    processor.SetImageLoadingParams(imageLoadingParams);

                    processor.PrepareProcessing();
                }
                
                progressBar.ShowProgress(20);

                //processor.SetUseFirstMatchedDocumentDefinition(true);

                IDocument document = processor.RecognizeNextDocument();
                progressBar.ShowProgress(90);

                if (document != null && document.DocumentDefinition != null)
                {
                    treeView.Visible = true;

                    IFileExportParams exportParams = this.engine.CreateFileExportParams();

                    var xmlFile = "jr" + Path.GetFileNameWithoutExtension(imageFiles[currentImageFileIndex]);
                                        
                    exportParams.FileFormat = FileExportFormatEnum.FEF_XML;
                    exportParams.ExportFieldNames = true;
                    exportParams.XMLParams.ExportFieldPosition = true;
                    this.processor.ExportDocumentEx(document, imagesFolderTextBox.Text, xmlFile, exportParams);
                                        
                    string hostName = System.Net.Dns.GetHostName().ToLower();
                    
                    var dirResult = string.Empty;


                    if (hostName == "win-4rsenms1gvd")
                    {
                        dirResult = @"C:\Users\administrator\Dropbox\Temp\images\result.tif";
                    }
                    else if (hostName.Equals("desktop-ppe05p1")) 
                    {
                        dirResult = @"C:\projects\img\result.tif";
                    }                    
                    else
                    {
                        dirResult = @"C:\Users\junior\Dropbox\Temp\images\result.tif";
                    }
                    
                    document.Pages[0].Image.BlackWhiteImage.WriteToFile(
                                dirResult,
                                ImageFileFormatEnum.IFF_Tif,
                                null,
                                ImageCompressionTypeEnum.ICT_CcittGroup4,
                                null);
                    
                    //document.Pages[0].Image.ColorImage.WriteToFile(
                    //            @"C:\Users\junior\Dropbox\Temp\images\result.JPG",
                    //            ImageFileFormatEnum.IFF_Jpg,
                    //            null,
                    //            ImageCompressionTypeEnum.ICT_Jpeg,
                    //            null);

                    Image exportedImage = Image.FromFile(dirResult, false);
                    processedImage = new Bitmap(exportedImage);
                    exportedImage.Dispose();

                    buildDocumentView(treeView, document);
                }
                else
                {
                    treeView.Visible = false;
                    goButton.Visible = false;
                }

                progressBar.ShowProgress(100);
            }
            catch(Exception ex)
            {
                var a = ex.Message;
            }

            finally {
                progressBar.EndProgress();
            }
        }

        private string RotateAndSaveImage(String input, String output)
        {
            var newOutPut = Path.GetDirectoryName(output) + "\\" + Path.GetFileNameWithoutExtension(output) + "2" + Path.GetExtension(output);

            using (var img = Image.FromFile(input))
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                img.Save(newOutPut, ImageFormat.Jpeg);                
            }
            return newOutPut;
        }


	    private void buildDocumentView( TreeView treeView, IDocument document )
        {   
            treeView.Nodes.Clear();
            
            IField firstSection = document.Sections[0];
            TreeNode node = treeView.Nodes.Add( firstSection.Name );
            addDocumentNodeChildren( node, firstSection.Children );
                       
            node.Expand();
            treeView.SelectedNode = node;
        }

        private void addDocumentNode( TreeNode parentNode, IField documentNode )
        {
            IFieldValue value =  documentNode.Value;
            TreeNode treeNode = null;
            if( value == null ) {
                treeNode = parentNode.Nodes.Add( documentNode.Name );
            } else {
                treeNode = parentNode.Nodes.Add( documentNode.Name + ": " + value.AsString );
            }
            if( documentNode.Instances != null ) {
                addDocumentNodeInstances( treeNode, documentNode.Instances );
            } else if( documentNode.Children != null ) {
                addDocumentNodeChildren( treeNode, documentNode.Children );
            }
            IBlocksCollection blocks = documentNode.Blocks;
            if( blocks != null && blocks.Count > 0 ) {
                IRegion region = blocks.Item( 0 ).Region;
                if( region != null ) {
                    if( region.Count > 0 ) {
                        treeNode.Tag = region;
                        int x = region.get_Left( 0 );
                        int y = region.get_Top( 0 );
                        int width = region.get_Right( 0 ) - x;
                        int height = region.get_Bottom( 0 ) - y;
                        using( Graphics g = Graphics.FromImage( processedImage ) ) {
                            for( int j = 0; j < 7; j++ ) {
                                Pen pen = new Pen( Color.FromArgb( 90 - j * 12, 0, 150, 0 ) );
                                g.DrawRectangle( pen, x - j, y - j, width + j * 2, height + j * 2 ); 
                            }
                        }
                     }
                }
            }
        }

        private void addDocumentNodeChildren( TreeNode parentNode, IFields children )
        {
            for( int i = 0; i < children.Count; i++ ) {
                addDocumentNode( parentNode, children[i] );
            }
        }

        private void addDocumentNodeInstances( TreeNode parentNode, IFieldInstances instances )
        {
            for( int i = 0; i < instances.Count; i++ ) {
                TreeNode node = parentNode.Nodes.Add( "[" + i.ToString() + "]" );
                if( instances[i].Children != null ) {
                    addDocumentNodeChildren( node, instances[i].Children );
                }
            }
        }

        private void restoreDefaultsButton_Click(object sender, EventArgs e)
        {
            initDefaults();
        }

        private void initDefaults()
        {
            string hostName = System.Net.Dns.GetHostName().ToLower();

            // Set default paths
            if (hostName == "win-4rsenms1gvd")
            {
                imagesFolderTextBox.Text = @"C:\Temp\";
                documentDefinitionPathTextBox.Text = @"C:\Users\Administrator\Dropbox\Public\FCDOTS\";
            }
            else
            {
                imagesFolderTextBox.Text = @"C:\Users\junior\Dropbox\Temp\Erros\921\";
                documentDefinitionPathTextBox.Text = @"C:\Users\junior\Dropbox\Projects\FXD\InMet\Fase7\921\Project\Templates\";
            }

            processor = null;

            loadImages();
            loadFcDots();
            refreshNextPrevButtons();
        }
        private void loadFcDots()
        {

            var dir = Path.GetDirectoryName(documentDefinitionPathTextBox.Text);

            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            try
            {
                var fcdotsFiles = Directory.GetFiles(dir, "*.FCDOT");
                documentoDefListBox.Items.Clear();
                var items = documentoDefListBox.Items;

                items.AddRange(fcdotsFiles);
            } catch(Exception e) {
                return;
            }
        }

        private void loadImages()
        {
            treeView.Nodes.Clear();
            treeView.Visible = false;
            prevButton.Enabled = false;
            goButton.Visible = true;

            if( processedImage != null ) {
                processedImage.Dispose();
                processedImage = null;
            }
            
            //imageFiles = Directory.GetFiles( imagesFolderTextBox.Text, "*.JPG" );

            imageFiles = RetornarImages(imagesFolderTextBox.Text);

            if (imageFiles == null) return;

            currentImageFileIndex = 0;
            if( imageFiles.Length > 0 ) {
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Load( imageFiles[0] );
                pictureBox.Visible = true;
                goButton.Enabled = true;
                nextButton.Enabled = true;
                toolStripText.Text = imageFiles[currentImageFileIndex];
            } else {
                pictureBox.Visible = false;
                if( pictureBox.Image != null ) {
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;
                }
                goButton.Enabled = false;
                nextButton.Enabled = false;
            }
        }

        private string[] RetornarImages(string diretorioDeDestinoDaPack)
        {
            try
            {
                var arquivosTif = Directory.GetFiles(diretorioDeDestinoDaPack, "*.tif*");
                var arquivosJbg = Directory.GetFiles(diretorioDeDestinoDaPack, "*.jpg");

                var imgs = new List<string>();

                imgs.AddRange(arquivosJbg);
                imgs.AddRange(arquivosTif);

                return imgs.ToArray();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = imagesFolderTextBox.Text;
            if( folderBrowserDialog.ShowDialog() == DialogResult.OK ) {
                imagesFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                loadImages();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "FlexiCapture Document Definition files|*.fcdot";
            openFileDialog.InitialDirectory = Path.GetDirectoryName(documentDefinitionPathTextBox.Text);
            openFileDialog.FileName = Path.GetFileName(documentDefinitionPathTextBox.Text);

            if( openFileDialog.ShowDialog() == DialogResult.OK ) {
                documentDefinitionPathTextBox.Text = openFileDialog.FileName;
                processor = null;
                loadFcDots(); 
            }
        }

        static IEngine loadEngine()
		{				
			IEngine engine = null;
			int hresult = InitializeEngine( FceConfig.GetDeveloperSN(), null, null, out engine );
			Marshal.ThrowExceptionForHR( hresult );	
			return engine;
		}

		static void unloadEngine( ref IEngine engine )
		{			
			int hresult = DeinitializeEngine();
			Marshal.ThrowExceptionForHR( hresult );
            engine = null;
		}

        [DllImport( FceConfig.DllPath, CharSet=CharSet.Unicode ), PreserveSig]
		internal static extern int InitializeEngine( String devSN, String reserved1, String reserved2, out IEngine engine );

		[DllImport( FceConfig.DllPath, CharSet=CharSet.Unicode ), PreserveSig]
		internal static extern int DeinitializeEngine();

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if( node != null ) {
                pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap( processedImage );
                
                IRegion region = node.Tag as IRegion;
                if( region != null ) {
                    pictureBox.Dock = DockStyle.None;
                    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    if( region.Count > 0 ) {
                            int x = region.get_Left( 0 );
                            int y = region.get_Top( 0 );
                            int width = region.get_Right( 0 ) - x;
                            int height = region.get_Bottom( 0 ) - y;

                            using( Graphics g = Graphics.FromImage( pictureBox.Image ) ) {
                                for( int j = 0; j < 7; j++ ) {
                                    Pen pen = new Pen( Color.FromArgb( 240 - 30 * j, 255, 255, 0 ) );
                                    g.DrawRectangle( pen, x - j, y - j, width + j * 2, height + j * 2 ); 
                                }
                            }
                            
							panel.AutoScrollPosition = new Point( x - 80, y - 80 );
					}
                } else {
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            currentImageFileIndex--;

            initNewImage();
            refreshNextPrevButtons();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentImageFileIndex++;

            initNewImage();
            refreshNextPrevButtons();  
        }

        void refreshNextPrevButtons()
        {
            if (imageFiles == null) return;

            nextButton.Enabled = (currentImageFileIndex < imageFiles.Length - 1);
            prevButton.Enabled = (currentImageFileIndex > 0);
        }

        void initNewImage()
        {
            treeView.Visible = false;
            treeView.Nodes.Clear();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if( processedImage != null ) {
                processedImage.Dispose();
                processedImage = null;
            }
            pictureBox.Load( imageFiles[currentImageFileIndex] );
            toolStripText.Text = imageFiles[currentImageFileIndex];
            goButton.Visible = true;
        }

        class Gdi32
		{
			[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
			internal static extern IntPtr DeleteObject( IntPtr hDc );
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            if( Screen.FromControl( this ).WorkingArea.Height > 768 ) {
                Height = 790;
            }
        }

        private string DetermineDocumentType()
        {
            if (engine == null)
            {
                engine = loadEngine();
            }

            if (processor == null)
            {
                processor = engine.CreateFlexiCaptureProcessor();

                processor.AddClassificationTreeFile(
                    @"C:\Users\junior\Dropbox\Projects\FXD\InMet\AbbyyCapas\Classify\Caderneta\CapaClassify.cfl");
            }
            else
            {
                processor.ResetProcessing();
            }

            processor.AddImageFile(imageFiles[currentImageFileIndex]);

            var result = processor.ClassifyNextPage();

            if (result != null && result.PageType == PageTypeEnum.PT_MeetsDocumentDefinition)
            {
                var names = result.GetClassNames();
                return names.Item(0);
            }

            return string.Empty;
        }

	    private void classButton_Click(object sender, EventArgs e)
        {
            try
            {
                var progressBar = new ProgressBarForm(this);
                progressBar.ShowMessage("Processing the image");

                MessageBox.Show(DetermineDocumentType());

                progressBar.EndProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }


}
