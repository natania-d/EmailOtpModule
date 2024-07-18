using EmailOtpModule;

public class Program
{
    public static void Main(string[] args)
    {
        EmailOtpMod otpModule = new EmailOtpMod();

        string testEmail = "user@dso.org.sg";
        var status = otpModule.GenerateOtpEmailAsync(testEmail);
        Console.WriteLine($"Email generation status: {status}");

        TextReader tIn = Console.In;
        string otpStatus = otpModule.CheckOtp(tIn);
        Console.WriteLine($"OTP check status: {otpStatus}");
    }
}
// Tested using above program and unit tests.