namespace backend.Models.Request
{
    public class ChecklistItemRequest
    {
        public int IdLogin { get; set; }
        public int IdChecklist { get; set; }
        public string NomeItem { get; set; }
    }
}