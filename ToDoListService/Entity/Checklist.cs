namespace ToDoListService.Entity
{
    public class Checklist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChecklistItem> ListItem { get; set; }
    }
}
