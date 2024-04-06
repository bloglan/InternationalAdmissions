namespace AdmissionsPlatform;
internal interface IVisaOcr
{
    VisaOcrResult Recognize(byte[] visaImage);
}
