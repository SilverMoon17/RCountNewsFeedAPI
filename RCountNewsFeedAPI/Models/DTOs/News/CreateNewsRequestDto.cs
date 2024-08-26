﻿namespace RCountNewsFeedAPI.Models.DTOs;

public class CreateNewsRequestDto
{
    public string Header { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string CreatedByUserId { get; set; }
    public string UpdatedByUserId { get; set; }
}