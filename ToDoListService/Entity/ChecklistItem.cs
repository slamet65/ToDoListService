namespace ToDoListService.Entity
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }
    }
}
