namespace RCountNewsFeed.Models.DTOs.News;

public class NewsDto
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public Models.Category Category { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTime Created { get; set; }
    public string UpdatedByUserId { get; set; }
    public DateTime Updated { get; set; }
}