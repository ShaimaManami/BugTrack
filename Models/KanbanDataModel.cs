using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
public class KanbanDataModel
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Status { get; set; }
    public string Summary { get; set; }
    public string Type { get; set; }
    public string Priority { get; set; }
   
    public string Color { get; set; }

    public List<KanbanDataModel> KanbanTasks()
    {
        List<KanbanDataModel> TaskDetails = new List<KanbanDataModel>();
        TaskDetails.Add(new KanbanDataModel { Id = "Task 1", Title = "Task  - 29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer.", Type = "Story", Priority = "Low", Color = "#8b447a" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 2", Title = "Task  - 29002", Status = "InProgress", Summary = "Improve application performance", Type = "Improvement", Priority = "Normal", Color = "#7d7297" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 3", Title = "Task  - 29003", Status = "Open", Summary = "Arrange a web meeting with the customer to get new requirements.", Type = "Others", Priority = "Critical", Color = "#27AE60" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 4", Title = "Task  - 29004", Status = "InProgress", Summary = "Fix the issues reported in the IE browser.", Type = "Bug", Priority = "Release Breaker", Color = "#cc0000" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 5", Title = "Task  - 29005", Status = "Review", Summary = "Fix the issues reported by the customer.", Type = "Bug", Priority = "Low", Color = "#cc0000" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 6", Title = "Task  - 29007", Status = "Validate", Summary = "Validate new requirements", Type = "Improvement", Priority = "Low", Color = "#7d7297" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 7", Title = "Task  - 29009", Status = "Review", Summary = "Fix the issues reported in Safari browser.", Type = "Bug", Priority = "Release Breaker", Color = "#cc0000" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 8", Title = "Task  - 29010", Status = "Close", Summary = "Test the application in the IE browser.", Type = "Story", Priority = "Low",  Color = "#8b447a" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 9", Title = "Task  - 29011", Status = "Validate", Summary = "Validate the issues reported by the customer.", Type = "Story", Priority = "High",  Color = "#8b447a" });
        TaskDetails.Add(new KanbanDataModel { Id = "Task 10", Title = "Task  - 29036", Status = "Testing", Summary = "Test editing feature in the IE browser.", Type = "Story", Priority = "Normal",  });
        return TaskDetails;
    }
}
public class KanbanDialogModels
{

    public string text { get; set; }
    public string key { get; set; }
    public string type { get; set; }
    public object validationRules { get; set; }

    public List<KanbanDialogModels> DialogCards()
    {
        List<KanbanDialogModels> DialogCard = new List<KanbanDialogModels>();
        DialogCard.Add(new KanbanDialogModels { key = "Id", type = "Input" });
        DialogCard.Add(new KanbanDialogModels { key = "Status", type = "DropDown" });
       // DialogCard.Add(new KanbanDialogModels { key = "Estimate", type = "Numeric", validationRules = new { range = new int[] { 0, 1000 } } });
        DialogCard.Add(new KanbanDialogModels { key = "Summary", type = "TextArea", validationRules = new { required = true } });
        return DialogCard;
    }
}