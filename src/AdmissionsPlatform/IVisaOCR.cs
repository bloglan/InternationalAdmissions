namespace ForeignStudentsPlatform;
internal interface IVisaOCR
{
    VisaOCRResult Recognize(byte[] visaImage);
}
