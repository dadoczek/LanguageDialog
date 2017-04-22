using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IViewLanguageService
    {
        IDictionary<string, string> GetViewText(string viewName, int languageId);
    }
}