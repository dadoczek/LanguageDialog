using System.Collections.Generic;
using Contract.Params;
using Contract.WebModel;
using Model.Models;

namespace Service.Abstract
{
    public interface IDialogueService
    {
        void Add(Dialogue dialogue);
        void Edit(Dialogue dialogue);
        void Remove(int id);
        Dialogue GetOne(int id);
        ICollection<Dialogue> GetAll();
        PageData<Dialogue> GetPage(DialoguePageParams @params);
    }
}