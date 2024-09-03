namespace RCountNewsFeed.Models.DTOs.News;

public class UpdateNewsRequestDto
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public int ProjectId { get; set; }
    public string UpdatedByUserId { get; set; }
}