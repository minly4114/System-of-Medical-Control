namespace SMC_Client_Desktop
{
    /// <summary>
    /// Данный класс содержит все требуемые для работы приложения поля.
    /// Заполнение данных полей происходит после нажатия кнопки "Войти" в приветственном меню
    /// </summary>
    public static class CurrentSession
    {
        public static string LastName { get; set; }
        public static string FirstName { get; set; }
        public static string MiddleName { get; set; }
        public static string BirthdayDate { get; set; }
        public static string PolicyNumber { get; set; }
        public static string PasportInfo { get; set; }
        public static string PolyclinicName { get; set; }

    }
}
