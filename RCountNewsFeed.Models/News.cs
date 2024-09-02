namespace RCountNewsFeed.Models;

public class News
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public Category Category { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string UpdatedByUserId { get; set; }
    public DateTime Updated { get; set; } = DateTime.UtcNow;
}

// Project CRUD
// Project entity
// ProjectId news
// Filter by project