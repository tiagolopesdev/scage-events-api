namespace SCAGEEvents.Api.Utils
{
    public class ResponseApi
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public static string Error(string message)
        {
            return message;
        }

        public static ResponseApi New(string message, object data)
        {
            var response = new ResponseApi
            {
                Message = message,
                Data = data
            };
            return response;
        }
    }

    public enum TypeAction
    {
        Criar = 0,
        Atualizar = 1,
        Obter = 2,
        Deletar = 3,
    }
}
