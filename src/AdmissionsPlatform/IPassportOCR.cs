namespace ForeignStudentsPlatform;
public interface IPassportOCR
{
    PassportOCRResult Recognize(byte[] passportImage);
}
