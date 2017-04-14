using Contract.Dtos;

namespace Contract.Params
{
    public class DialoguePageParams
    {
        public int Page { get; set; } = 1;
        public string Name { get; set; }
        public int SizePage { get; set; } = 20;
        public int? LanguageId { get; set; }
        public string IdUser { get; set; }
        public bool MyView { get; set; }
        public DialogueSortDto Sort { get; set; }
    }
}
