namespace LMMProject.Models;

public class SearchSessionModel
{
    public bool HasError { get; set; }
    public string Message { get; set; }
    public List<LMMProject.Models.Session> Data { get; set; }
}