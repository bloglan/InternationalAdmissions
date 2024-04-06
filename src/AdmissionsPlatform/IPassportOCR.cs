namespace AdmissionsPlatform;
public interface IPassportOcr
{
    PassportOcrResult Recognize(byte[] passportImage);
}
