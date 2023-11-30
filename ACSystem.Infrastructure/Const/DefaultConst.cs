using ACSystem.Infrastructure.Utilities;

namespace ACSystem.Infrastructure.Const
{
    public static class DefaultConst
    {
        public const int TakeCount = 10;

        public const string Required= "وارد کردن مقدار فیلد اجباری است";
        public const string LengthExceed = " طول رشته زیاد است حداقل و حداکثر 8 کاراکتر";
        public const string EmailInvalid = "آدرس ایمیل نامعتبر است";


        public const string Failure = "عملیات شکست خورد";
        public const string Success = "عملیات با موفقیت انجام شد";
        public static readonly double CashTimeOut = 30;
        public static readonly int SuccessCode = 0;
        public static readonly int FailureCode = 1;

        public static readonly string LetterRefExist = "قبلا کاربر مورد نظر به کاربر مشخص شده نامه ای ارسال کرده است";
        public static readonly string IdCodeExist = "کاربری با این شناسه قبلا ثبت شده است";
        public static readonly string EmailExist = "کاربری با این شناسه قبلا ثبت شده است";
    }
}
