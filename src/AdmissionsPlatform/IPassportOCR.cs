namespace AdmissionsPlatform;
public interface IPassportOCR
{
    PassportOCRResult Recognize(byte[] passportImage);
}
