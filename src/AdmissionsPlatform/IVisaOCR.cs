namespace AdmissionsPlatform;
internal interface IVisaOCR
{
    VisaOCRResult Recognize(byte[] visaImage);
}
