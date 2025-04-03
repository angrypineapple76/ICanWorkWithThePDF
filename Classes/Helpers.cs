using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.PdfCleanup.Autosweep;
using iText.PdfCleanup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace ICanWorkWithThePDF.Classes
{
    public static class Helpers
    {
        public static void RemoveWaterMarckAndSave(string fileStream, string outPutDir)
        {
            iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(fileStream), new iText.Kernel.Pdf.PdfWriter(outPutDir));
            ICleanupStrategy cleanupStrategy = new RegexBasedCleanupStrategy(new Regex(@"Evaluation Warning : The document was created with Spire.PDF for .NET", RegexOptions.IgnoreCase)).SetRedactionColor(ColorConstants.WHITE);
            PdfCleaner.AutoSweepCleanUp(pdf, cleanupStrategy);
            pdf.Close();
        }
    }
}
