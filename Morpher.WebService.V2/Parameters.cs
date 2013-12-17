namespace Morpher.WebService.V2
{
    public class Parameters
    {
        /// <summary>
        /// URL веб-сервиса.  Необязательный.  По умолчанию http://morpher.ru/WebService.asmx.
        /// </summary>
        public string Url;

        /// <summary>
        /// Имя пользователя.  Необязательно, но указание имени пользователя дает больше возможностей и избавляет от многих проблем.
        /// http://morpher.ru/Register.aspx
        /// </summary>
        public string Username;

        /// <summary>
        /// Пароль. 
        /// </summary>
        public string Password;
    }
}
