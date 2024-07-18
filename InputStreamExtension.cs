using System.IO;

namespace EmailOtpModule
{
    public static class InputStreamExtension
    {
        public static string ReadOtp(this TextReader input)
        {
            Console.Write("Enter OTP: ");
            return input.ReadLine() ?? string.Empty;
        }
    }
}
