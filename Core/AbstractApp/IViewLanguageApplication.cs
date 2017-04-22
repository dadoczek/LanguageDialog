using Contract.Responses;

namespace Core.Applictaion
{
    public interface IViewLanguageApplication
    {
        DictionaryResponse<string, string> GetViewText(string viewName, int languageId);
    }
}