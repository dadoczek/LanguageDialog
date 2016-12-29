﻿using Contract.Dtos;
using Contract.Params;
using Model.Models;
using System.Linq;

namespace Repository.AbstractRepo
{
    public interface IDialogueRepository
    {
        void Add(Dialogue dialogue);

        void Remove(int id);

        void Edit(Dialogue dialogue);

        IQueryable<Dialogue> GetAll();

        Dialogue GetOne(int id);

        DialoguePageDto GetPage(DialoguePageParams @params);
        DialoguePageDto GetMyDialoguePage(DialoguePageParams @params);
    }
}
