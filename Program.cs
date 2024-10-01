using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using DevExpress.Pdf;
using DevExpress.Drawing;

//Specify the signature's image data and location parameters:
//byte[] imageData = File.ReadAllBytes("sig_cropped.png");
int pageNumber = 1;
int angleInDegrees = 0;
double angleInRadians = angleInDegrees * (Math.PI / 180);
PdfOrientedRectangle signatureBounds = new PdfOrientedRectangle(new PdfPoint(120, 800), 120, 40, angleInRadians);
using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
{
  documentProcessor.LoadDocument("letter.pdf");
  //using (var dxImage = DXImage.FromStream(new FileStream("resized_sig.png", FileMode.Open))) {
  using (var dxImage = DXImage.FromStream(new FileStream("sig_cropped.png", FileMode.Open))) {
   using (var gr = documentProcessor.CreateGraphics()){
     gr.DrawImage(dxImage, new RectangleF(new System.Numerics.Vector4(100, 465, 180, 45)));
     gr.AddToPageForeground(documentProcessor.Document.Pages[0]);
   }
  }
  //Save a signed document:
  documentProcessor.SaveDocument(@"2024_10FAssertion_signed.pdf");// new PdfSaveOptions() { Signature = signature });
}
