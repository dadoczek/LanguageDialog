using System.Collections.Generic;
using System.Linq;
using Model.Models;
using Service.Abstract;
using Service.Helper;

namespace Service
{
    public class ViewLanguageService : EntityBaseService, IViewLanguageService
    {
        public ViewLanguageService(IRepositoryProvider provider) : base(provider)
        {
        }

        public IDictionary<string, string> GetViewText(string viewName, int languageId)
        {
            return RepositoryProvider.Do(repo =>
            {
                var viewLanguage = repo.GetCollection<ViewLanguage>()
                    .FirstOrDefault(v => v.LanguageId == languageId && v.ViewName == viewName);
                return ConvertData(viewLanguage.ViewTexts);
            });
        }

        private static IDictionary<string, string> ConvertData(IEnumerable<ViewText> data)
        {
            return data.ToDictionary(viewText => viewText.NameId, viewText => viewText.Text);
        }
    }
}
